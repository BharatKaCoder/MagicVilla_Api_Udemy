using System;
using System.Text;
using MagicVilla_Utility;
using MagicVillaUdemy_Web.Models;
using MagicVillaUdemy_Web.Services.IServices;
using Newtonsoft.Json;

namespace MagicVillaUdemy_Web.Services
{
    public class BaseService : IBaseService
    {
        public APIResponse responseModel { get ; set; }
        public IHttpClientFactory httpClientFactory { get; set; }
        public BaseService(IHttpClientFactory httpClientFactory)
        {
            this.responseModel = new ();
            this.httpClientFactory = httpClientFactory;
        }

        public async Task<T> SendAsync<T>(APIRequest request)
        {
            try
            {
                var clint = httpClientFactory.CreateClient("MagicAPI");
                HttpRequestMessage Message = new HttpRequestMessage();
                Message.Headers.Add("Accept", "application/json");
                Message.RequestUri = new Uri(request.ApiUrl);
                if (request.Data != null)
                {
                    Message.Content = new StringContent(JsonConvert.SerializeObject(request.Data),
                        Encoding.UTF8, "application/json");
                }
                switch (request.ApiType)
                {
                    case StaticDetails.APIType.POST:
                        Message.Method = HttpMethod.Post;
                        break;

                    case StaticDetails.APIType.DELETE:
                        Message.Method = HttpMethod.Delete;
                        break;

                    case StaticDetails.APIType.UPDATE:
                        Message.Method = HttpMethod.Put;
                        break;

                    default:
                        Message.Method = HttpMethod.Get;
                        break;
                }
                HttpResponseMessage apiResponse = null;
                apiResponse = await clint.SendAsync(Message);
                var ApiContent = await apiResponse.Content.ReadAsStringAsync();
                var APIResponse = JsonConvert.DeserializeObject<T>(ApiContent);
                return APIResponse;
            }
            catch (Exception ex)
            {
                var dto = new APIResponse
                {
                    ErrorMessage = new List<string> { (Convert.ToString(ex.Message)) },
                    Success = false,
                };
                var res= JsonConvert.SerializeObject(dto);
                var APIResponse = JsonConvert.DeserializeObject<T>(res);
                return APIResponse;
            }
        }
    }
}
