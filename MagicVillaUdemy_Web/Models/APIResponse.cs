using System.Net;

namespace MagicVillaUdemy_Web.Models
{
    public class APIResponse
    {
        public HttpStatusCode StatusCode { get; set; }
        public bool Success { get; set; } = true;
        public List<string> ErrorMessage { get; set; }
        public object Result {  get; set; }
    }
}
