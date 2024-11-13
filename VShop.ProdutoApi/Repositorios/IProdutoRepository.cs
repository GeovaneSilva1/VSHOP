using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using VShop.ProdutoApi.Models;

namespace VShop.ProdutoApi.Repositorios
{
    public interface IProdutoRepository
    {
        Task<IEnumerable<Produto>> GetAll();
        Task<Produto> GetById(int id);
        Task<Produto> Create(Produto produto);
        Task<Produto> Update(Produto produto);
        Task<Produto> Delete(int id);
        
    }
}