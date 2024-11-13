using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using VShop.ProdutoApi.Context;
using VShop.ProdutoApi.Models;

namespace VShop.ProdutoApi.Repositorios
{
    public class CategoriaRepository : ICategoriaRepository
    {
        private readonly AppDbContext _Context;

        public CategoriaRepository(AppDbContext context)
        {
            _Context = context;
        }

        public async Task<IEnumerable<Categoria>> GetAll()
        {
            //Tem que ser alterado em produção, para não retornar tudo na memória
            return await _Context.Categorias.ToListAsync();
        }
        public async Task<IEnumerable<Categoria>> GetCategoriasProdutos()
        {
            return await _Context.Categorias.Include(c=> c.Produtos).ToListAsync();
        }
        public async Task<Categoria> GetById(int id)
        {
            return await _Context.Categorias.Where(c=> c.CategoriaId == id).FirstOrDefaultAsync();
        }
        public async Task<Categoria> Create(Categoria categoria)
        {
            _Context.Categorias.Add(categoria);
            await _Context.SaveChangesAsync();
            return categoria;
        }
        public async Task<Categoria> Update(Categoria categoria)
        {
            _Context.Entry(categoria).State = EntityState.Modified;
            await _Context.SaveChangesAsync();
            return categoria;
        }
        public async Task<Categoria> Delete(int id)
        {
            var categoria = await GetById(id);
            _Context.Categorias.Remove(categoria);
            await _Context.SaveChangesAsync();
            return categoria;
        }
    }
}