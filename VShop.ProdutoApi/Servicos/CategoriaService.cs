using System;
using System.Collections.Generic;
using System.Data.SqlTypes;
using System.Linq;
using System.Threading.Tasks;
using AutoMapper;
using VShop.ProdutoApi.DTOs;
using VShop.ProdutoApi.Models;
using VShop.ProdutoApi.Repositorios;

namespace VShop.ProdutoApi.Servicos
{
    public class CategoriaService : ICategoriaService
    {
        private readonly ICategoriaRepository _categoriaRepository;
        private readonly IMapper _mapper;

        public CategoriaService(ICategoriaRepository categoriaRepository, IMapper mapper)
        {
            _categoriaRepository = categoriaRepository;
            _mapper = mapper;
        }

        public async Task<IEnumerable<CategoriaDTO>> GetCategorias()
        {
            var categoriasEntity = await _categoriaRepository.GetAll();
            return _mapper.Map<IEnumerable<CategoriaDTO>>(categoriasEntity);
        }

        public async Task<IEnumerable<CategoriaDTO>> GetCategoriasProdutos()
        {
            var categoriasEntity = await _categoriaRepository.GetCategoriasProdutos();
            return _mapper.Map<IEnumerable<CategoriaDTO>>(categoriasEntity);
        }

        public async Task<CategoriaDTO> GetCategoriasById(int id)
        {
            var categoriasEntity = await _categoriaRepository.GetById(id);
            return _mapper.Map<CategoriaDTO>(categoriasEntity);
        }

        public async Task AddCategoria(CategoriaDTO categoriaDTO)
        {
            var categoriasEntity = _mapper.Map<Categoria>(categoriaDTO);
            await _categoriaRepository.Create(categoriasEntity);
            categoriaDTO.CategoriaId = categoriasEntity.CategoriaId;
        }

        public async Task UpdateCategoria(CategoriaDTO categoriaDTO)
        {
            var categoriasEntity = _mapper.Map<Categoria>(categoriaDTO);
            await _categoriaRepository.Update(categoriasEntity);
        }

        public async Task RemoveCategoria(int id)
        {
            var categoriasEntity = _categoriaRepository.GetById(id).Result;
            await _categoriaRepository.Delete(categoriasEntity.CategoriaId);
        }

    }
}