using AutoMapper;
using Entities.Concrete;
using Entities.DTOs;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Entities.Mapping.Profiles
{
    public class BusinessProfile : Profile
    {
        public BusinessProfile()
        {
            CreateMap<Courthouse, CourthouseDto>().ReverseMap();
            CreateMap<Courthouse, CourthouseDetailDto>().ReverseMap();

            CreateMap<TransferRequest, TransferRequestDetailDto>().ReverseMap();
            CreateMap<TransferRequest, TransferRequestDto>().ReverseMap();
        }
    }
}
