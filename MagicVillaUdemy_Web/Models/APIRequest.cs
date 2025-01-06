using static MagicVilla_Utility.StaticDetails;

namespace MagicVillaUdemy_Web.Models
{
    public class APIRequest
    {
        public APIType ApiType { get; set; } = APIType.GET;
        public string ApiUrl { get; set; }
        public object Data {  get; set; } 
    }
}
