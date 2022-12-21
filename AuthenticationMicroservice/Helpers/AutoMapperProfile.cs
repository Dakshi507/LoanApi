using AuthenticationMicroservice.Models;
using AutoMapper;
using AuthorizationMicroservice.DTOS;

namespace AuthenticationMicroservice.Helpers
{
    public class AutoMapperProfile : Profile
    {

        public AutoMapperProfile()
        {
            CreateMap<LoginDto, UserDetail>();
            CreateMap<RegisterDto, UserDetail>();



        }
    }
}
