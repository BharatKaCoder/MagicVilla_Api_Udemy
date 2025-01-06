﻿using MagicVilla_Utility;
using MagicVillaUdemy_Web.Models;
using MagicVillaUdemy_Web.Models.DTO;
using MagicVillaUdemy_Web.Services.IServices;
using static MagicVilla_Utility.StaticDetails;

namespace MagicVillaUdemy_Web.Services
{
    public class VillaService : BaseService, IVillaService
    {
        private readonly IHttpClientFactory _ClientFactory;
        private string VillaUrl;
        public VillaService(IHttpClientFactory clientFactory, IConfiguration configuration) : base(clientFactory) 
        {
            _ClientFactory = clientFactory;
            VillaUrl = configuration.GetValue<string>("ServerUrls:VillaAPI");
        }
        public Task<T> CreateAsync<T>(VillaCreateDTO dto)
        {
            return SendAsync<T>(new APIRequest()
            {
                ApiType = StaticDetails.APIType.POST,
                Data = dto,
                ApiUrl = VillaUrl + "/api/villaapi"
            });
        }

        public Task<T> DeleteAsync<T>(int id)
        {
            return SendAsync<T>(new APIRequest()
            {
                ApiType = StaticDetails.APIType.DELETE,
                ApiUrl = VillaUrl + "/api/villaapi/" + id
            });
        }

        public Task<T> GetAllAsync<T>()
        {
            return SendAsync<T>(new APIRequest()
            {
                ApiType = StaticDetails.APIType.GET,
                ApiUrl = VillaUrl + "/api/villaapi/"
            });
        }

        public Task<T> GetAsync<T>(int id)
        {
            return SendAsync<T>(new APIRequest()
            {
                ApiType = StaticDetails.APIType.GET,
                ApiUrl = VillaUrl + "/api/villaapi/" + id
            });
        }

        public Task<T> UpdateAsync<T>(VillaUpdateDTO dto)
        {
            return SendAsync<T>(new APIRequest()
            {
                ApiType = StaticDetails.APIType.PUT,
                Data = dto,
                ApiUrl = VillaUrl + "/api/villaapi/"
            });
        }
    }
}
