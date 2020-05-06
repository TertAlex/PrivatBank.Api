using Sentinelab.PrivatBank.Api.Dto;
using Sentinelab.PrivatBank.Api.Extensions;
using Sentinelab.PrivatBank.Api.Models;
using Sentinelab.PrivatBank.Api.Models.Requests;
using System;
using System.Collections.Generic;

namespace Sentinelab.PrivatBank.Api.Mapper
{
    public class PrivatBankMapper
    {
        public RequestData MakeStatementRequestData(DateTime start, DateTime end, string card)
        {
            return new RequestData
            {
                Oper = "cmt",
                Wait = 0,
                Test = 0,
                Payment = new Payment
                {
                    Id = "",
                    PaymentItems = new List<PaymentItem>
                    {
                        new PaymentItem
                        {
                            Name = "sd",
                            Value = start.ToDotFormatString()
                        },
                        new PaymentItem
                        {
                            Name = "ed",
                            Value = end.ToDotFormatString()
                        },
                        new PaymentItem
                        {
                            Name = "card",
                            Value = card
                        }
                    }
                }
            };
        }

        public BaseRequest MakeBaseRequest(RequestData requestData, int merchantId, string signature)
        {
            return new BaseRequest
            {
                Version = "1.0",
                Merchant = new Merchant
                {
                    Id = merchantId,
                    Signature = signature
                },
                Data = requestData
            };
        }

        public StatementItem MapStatement(Statement statement)
        {
            var currency = statement.CardAmount.Substring(statement.CardAmount.Length - 3, 3);

            return new StatementItem
            {
                Card = statement.Card,
                AppCode = statement.AppCode,
                Description = statement.Description,
                Rest = Convert.ToDouble(statement.Rest.Replace($" {currency}", "")),
                Terminal = statement.Terminal,
                Time = DateTime.ParseExact($"{statement.TranDate} {statement.TranTime}", "yyyy-MM-dd HH:mm:ss", null),
                Currency = currency,
                Amount = Convert.ToDouble(statement.CardAmount.Replace($" {currency}", ""))
            };
        }
    }
}
