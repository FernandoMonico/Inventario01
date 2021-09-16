using AutoMapper;
using Inventario01.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Inventario01.Dto
{
    public class Mapper : Profile
    {
        public Mapper() {
            CreateMap<Marca, MarcaDto>();
            CreateMap<MarcaDto, Marca>();
        }
    }
}
