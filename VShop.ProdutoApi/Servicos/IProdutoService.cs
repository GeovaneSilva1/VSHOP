using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using VShop.ProdutoApi.DTOs;

namespace VShop.ProdutoApi.Servicos
{
    public interface IProdutoService
    {
        Task<IEnumerable<ProdutoDTO>> GetProdutos();
        Task<ProdutoDTO> GetProdutoById(int id);
        Task AddProduto(ProdutoDTO produtoDTO);
        Task UpdateProduto(ProdutoDTO produtoDTO);
        Task RemoveProduto(int id);
        
    }
}