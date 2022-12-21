using AutoMapper;
using System.Globalization;
using LoanApi.Models;
using LoanApi.DTO;

namespace LoanApi.Utilities
{
    public class AutoMapperProfile: Profile
    {
        public AutoMapperProfile()
        {
            CreateMap<Loandetail, LoandetailDTO>().ReverseMap();
            CreateMap<Userdetail, UserdetailDTO>().ReverseMap();
        }

    }
}
