using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection.Metadata.Ecma335;
using System.Runtime.CompilerServices;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using VShop.ProdutoApi.DTOs;
using VShop.ProdutoApi.Repositorios;
using VShop.ProdutoApi.Servicos;

namespace VShop.ProdutoApi.Controlers
{
    [ApiController]
    [Route("api/[controller]")]
    public class CategoriasController : ControllerBase
    {
        private readonly ICategoriaService _categoriaService;

        public CategoriasController(ICategoriaService categoriaService)
        {
            _categoriaService = categoriaService;
        }
        //Definindo os EndPoints
        [HttpGet]
        public async Task<ActionResult<IEnumerable<CategoriaDTO>>> Get() //Get que retorna todas as categorias
        {
            var categoriasDTO = await _categoriaService.GetCategorias();
            if (categoriasDTO is null)
                return NotFound("Categoria não encontrada.");

            return Ok(categoriasDTO);
        }

        [HttpGet("produtos")]
        public async Task<ActionResult<IEnumerable<CategoriaDTO>>> GetCategoriasProdutos()
        {
            var categoriasDTO = await _categoriaService.GetCategoriasProdutos();
            if (categoriasDTO is null)
                return NotFound("Produto não encontrado");

            return Ok(categoriasDTO);
        }

        [HttpGet("{id:int}", Name = "GetCategoria")]
        public async Task<ActionResult<CategoriaDTO>> Get(int id)
        {
            var categoriasDTO = await _categoriaService.GetCategoriasById(id);
            if (categoriasDTO is null)
                return BadRequest("Categoria não encontrada");
            
            return Ok(categoriasDTO);
        }

        [HttpPost]
        public async Task<ActionResult> Post([FromBody] CategoriaDTO categoriaDTO)
        {
            if (categoriaDTO is null)
                return BadRequest("Dados inválidos");
            
            await _categoriaService.AddCategoria(categoriaDTO);

            return new CreatedAtRouteResult("GetCategoria", new {id = categoriaDTO.CategoriaId},categoriaDTO);
        }

        [HttpPut("{id:int}")]
        public async Task<ActionResult> Put(int id, [FromBody] CategoriaDTO categoriaDTO)
        {
            if ((id != categoriaDTO.CategoriaId) || (categoriaDTO is null))
                return BadRequest();

            await _categoriaService.UpdateCategoria(categoriaDTO);
            return Ok(categoriaDTO);
        }

        [HttpDelete("{id:int}")]
        public async Task<ActionResult<CategoriaDTO>> Delete(int id)
        {
            var categoriaDTO = _categoriaService.GetCategoriasById(id);
            if (categoriaDTO is null)
                return NotFound("Categoria não encontrada");

            await _categoriaService.RemoveCategoria(id);
            return Ok(categoriaDTO);

        }


    }
}