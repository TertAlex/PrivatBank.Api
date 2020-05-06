using Sentinelab.PrivatBank.Api.Abstract;
using Sentinelab.PrivatBank.Api.Concrete;

namespace Sentinelab.PrivatBank.Api
{
    public class PrivatBankApi
    {
        public IPersonalClient PersonalClient { get; }

        public PrivatBankApi(int merchantId, string password, string card)
        {
            PersonalClient = new PersonalClient(merchantId, password, card);
        }
    }
}
