using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using VShop.Web.Models;

namespace VShop.Web.Servicos.Contratos
{
    public interface IProdutoService
    {
        Task<IEnumerable<ProdutoViewModel>> GetAllProdutos();
        Task<IEnumerable<ProdutoViewModel>> FindProdutoById(int id);
        Task<IEnumerable<ProdutoViewModel>> CreateProduto(ProdutoViewModel produtoVM);
        Task<IEnumerable<ProdutoViewModel>> UpdateProduto(ProdutoViewModel produtoVM);
        Task<bool> DeleteProdutoById(int id);
    }
}