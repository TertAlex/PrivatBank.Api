using Sentinelab.PrivatBank.Api.Abstract;
using Sentinelab.PrivatBank.Api.Helpers;
using Sentinelab.PrivatBank.Api.Mapper;
using Sentinelab.PrivatBank.Api.Models;
using Sentinelab.PrivatBank.Api.Models.Response;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Sentinelab.PrivatBank.Api.Dto;

namespace Sentinelab.PrivatBank.Api.Concrete
{
    public class PersonalClient : IPersonalClient
    {
        private readonly string _card;

        private readonly PrivatBankHttpClient _privatBankHttpClient;
        private readonly PrivatBankMapper _mapper = new PrivatBankMapper();

        public PersonalClient(int merchantId, string password, string card)
        {
            _card = card;

            _privatBankHttpClient = new PrivatBankHttpClient(merchantId, password);
        }

        public async Task<List<StatementItem>> GetStatement(DateTime start, DateTime end)
        {
            var requestData = _mapper.MakeStatementRequestData(start, end, _card);
            var statement = await _privatBankHttpClient.PostAsync<BaseResponse<Statements>>(Constants.StatementResource, requestData).ConfigureAwait(false);
            var statementItems = statement.Data.Info.Response.StatementItem
                .Select(x => _mapper.MapStatement(x))
                .ToList();
            return statementItems;
        }
    }
}
