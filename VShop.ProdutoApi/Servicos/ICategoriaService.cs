using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using VShop.ProdutoApi.DTOs;

namespace VShop.ProdutoApi.Servicos
{
    public interface ICategoriaService
    {
        //o Serviço deve retornar os DTos para o cliente (Consumidor)
        Task<IEnumerable<CategoriaDTO>> GetCategorias();
        Task<IEnumerable<CategoriaDTO>> GetCategoriasProdutos();
        Task<CategoriaDTO> GetCategoriasById(int id);
        Task AddCategoria(CategoriaDTO categoriaDto);
        Task UpdateCategoria(CategoriaDTO categoriaDto);
        Task RemoveCategoria(int id);

    }
}