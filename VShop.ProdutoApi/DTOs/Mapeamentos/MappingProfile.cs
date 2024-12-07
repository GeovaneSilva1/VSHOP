using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using AutoMapper;
using VShop.ProdutoApi.Models;

namespace VShop.ProdutoApi.DTOs.Mapeamentos
{
    
    public class MappingProfile: Profile
    {
        //Perfis de mapeamento
        public MappingProfile()
        {
            CreateMap<Categoria,CategoriaDTO>().ReverseMap();

            CreateMap<ProdutoDTO,Produto>();

            CreateMap<Produto,ProdutoDTO>()
                .ForMember(x => x.CategoriaNome, opt => opt.MapFrom(src => src.Categoria.Nome));
        }
    }
}