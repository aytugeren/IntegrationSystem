using AutoMapper;
using Product.Application.Features.Commands.CreateProduct;
using Product.Application.Model;
using Product.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Product.Application.Mapping
{
    public class MappingProfile : Profile
    {
        public MappingProfile()
        {
            CreateMap<ProductEntity, CreateProductCommand>().ReverseMap();
            CreateMap<ProductEntity, ProductVM>().ReverseMap();
        }
    }
}
