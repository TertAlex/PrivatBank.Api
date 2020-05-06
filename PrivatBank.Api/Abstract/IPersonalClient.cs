using Sentinelab.PrivatBank.Api.Dto;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace Sentinelab.PrivatBank.Api.Abstract
{
    public interface IPersonalClient
    {
        Task<List<StatementItem>> GetStatement(DateTime start, DateTime end);
    }
}
