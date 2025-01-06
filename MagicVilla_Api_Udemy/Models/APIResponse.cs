using System.Net;

namespace MagicVilla_Api_Udemy.Models
{
    public class APIResponse
    {
        public HttpStatusCode StatusCode { get; set; }
        public bool Success { get; set; } = true;
        public List<string> ErrorMessage { get; set; }
        public object Result {  get; set; }
    }
}
