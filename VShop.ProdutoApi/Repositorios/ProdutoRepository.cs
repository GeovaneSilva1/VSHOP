using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using VShop.ProdutoApi.Context;
using VShop.ProdutoApi.Models;

namespace VShop.ProdutoApi.Repositorios
{
    public class ProdutoRepository: IProdutoRepository
    {
        //Injeção de dependencia do contexto
        private readonly AppDbContext _Context;

        public ProdutoRepository(AppDbContext context)
        {
            _Context = context;
        }

        public async Task<IEnumerable<Produto>> GetAll()
        {
            return await _Context.Produtos.ToListAsync();
        }

        public async Task<Produto> GetById(int id)
        {
            return await _Context.Produtos.Where(p=> p.Id == id).FirstOrDefaultAsync();
        }

        public async Task<Produto> Create(Produto produto)
        {
             _Context.Produtos.Add(produto);
            await _Context.SaveChangesAsync();
            return produto;
        }

        public async Task<Produto> Update(Produto produto)
        {
            _Context.Entry(produto).State = EntityState.Modified;
            await _Context.SaveChangesAsync();
            return produto;
        }
        public async Task<Produto> Delete(int id)
        {
            var produto = await GetById(id);
            _Context.Produtos.Remove(produto);
            await _Context.SaveChangesAsync();
            return produto;
        }

    }
}