using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using AutoMapper;
using VShop.ProdutoApi.DTOs;
using VShop.ProdutoApi.Models;
using VShop.ProdutoApi.Repositorios;

namespace VShop.ProdutoApi.Servicos
{
    public class ProdutoService: IProdutoService
    {
        private readonly IMapper _mapper;
        private IProdutoRepository _produtoRepository;

        public ProdutoService(IMapper mapper, IProdutoRepository produtoRepository)
        {
            _mapper = mapper;
            _produtoRepository = produtoRepository;
        }
        public async Task<IEnumerable<ProdutoDTO>> GetProdutos()
        {
            var produtosEntity = await _produtoRepository.GetAll();
            return _mapper.Map<IEnumerable<ProdutoDTO>>(produtosEntity);
        }

        public async Task<ProdutoDTO> GetProdutoById(int id)
        {
            var produtosEntity = await _produtoRepository.GetById(id);
            return _mapper.Map<ProdutoDTO>(produtosEntity);
        }

        public async Task AddProduto(ProdutoDTO produtoDTO)
        {
            var produtosEntity = _mapper.Map<Produto>(produtoDTO);
            await _produtoRepository.Create(produtosEntity);
            produtoDTO.Id = produtosEntity.Id;
        }

        public async Task UpdateProduto(ProdutoDTO produtoDTO)
        {
            var produtosEntity = _mapper.Map<Produto>(produtoDTO);
            await _produtoRepository.Update(produtosEntity);
        }

        public async Task RemoveProduto(int id)
        {
            var produtosEntity = await _produtoRepository.GetById(id);
            await _produtoRepository.Delete(produtosEntity.Id);
            
        }
    }
}