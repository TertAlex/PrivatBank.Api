using Sentinelab.PrivatBank.Api.Extensions;
using Sentinelab.PrivatBank.Api.Mapper;
using Sentinelab.PrivatBank.Api.Models.Requests;
using System;
using System.Net.Http;
using System.Net.Http.Headers;
using System.Text;
using System.Threading.Tasks;

namespace Sentinelab.PrivatBank.Api.Helpers
{
    internal class PrivatBankHttpClient
    {
        private readonly int _merchantId;
        private readonly string _password;
        private readonly HttpClient _httpClient;
        private readonly PrivatBankMapper _mapper = new PrivatBankMapper();

        private const string ContentType = "text/xml";

        public PrivatBankHttpClient(int merchantId, string password)
        {
            _merchantId = merchantId;
            _password = password;
            _httpClient = new HttpClient
            {
                BaseAddress = new Uri(Constants.PrivatBankHost)
            };
            _httpClient.DefaultRequestHeaders.Accept.Add(new MediaTypeWithQualityHeaderValue(ContentType));
        }

        public async Task<T> PostAsync<T>(string url, RequestData requestData)
        {
            var serializedData = XmlSerializer.Serialize(requestData);
            var dataToSing = $"{serializedData.Replace("<?xml version=\"1.0\" encoding=\"utf-16\"?><RequestData>", "").Replace("</RequestData>", "")}{_password}";
            var signature = dataToSing.GetHashMd5().GetHashSha1();

            var request = _mapper.MakeBaseRequest(requestData, _merchantId, signature);

            var body = XmlSerializer.Serialize(request);

            var requestUri = new Uri(_httpClient.BaseAddress, url);

            using (var message = new HttpRequestMessage(HttpMethod.Post, requestUri))
            {
                using (var content = new StringContent(body, Encoding.UTF8, ContentType))
                {
                    message.Content = content;
                    using (var response = await _httpClient.SendAsync(message).ConfigureAwait(false))
                    {
                        return await ReadResponseAsync<T>(response).ConfigureAwait(false);
                    }
                }
            }
        }

        private async Task<T> ReadResponseAsync<T>(HttpResponseMessage response)
        {
            var result = await response.Content.ReadAsStringAsync().ConfigureAwait(false);
            return XmlSerializer.Deserialize<T>(result);
        }
    }
}
