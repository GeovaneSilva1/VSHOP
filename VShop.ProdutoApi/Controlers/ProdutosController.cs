using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using VShop.ProdutoApi.DTOs;
using VShop.ProdutoApi.Models;
using VShop.ProdutoApi.Servicos;

namespace VShop.ProdutoApi.Controlers
{
    [ApiController]
    [Route("api/[controller]")]
    public class ProdutosController : ControllerBase
    {
        private readonly IProdutoService _ProdutoService;
        public ProdutosController(IProdutoService produtoService)
        {
            _ProdutoService = produtoService;
        }

        [HttpGet]
        public async Task<ActionResult<IEnumerable<ProdutoDTO>>> Get()
        {
            var produtoDTO = await _ProdutoService.GetProdutos();
            if (produtoDTO is null)
                return NotFound("Produto não encontrado.");
            
            return Ok(produtoDTO);
        }

        [HttpGet("{id:int}", Name = "GetProduto")]
        public async Task<ActionResult<ProdutoDTO>> Get(int id)
        {
            var produtoDTO = await _ProdutoService.GetProdutoById(id);
            if (produtoDTO is null)
                return BadRequest("Produto não encontrado.");
            
            return Ok(produtoDTO);
        }

        [HttpPost]
        public async Task<ActionResult<ProdutoDTO>> Post([FromBody] ProdutoDTO produtoDTO)
        {
            if (produtoDTO is null)
                return BadRequest("Dados de produtos Inválidos");

            await _ProdutoService.AddProduto(produtoDTO);

            return new CreatedAtRouteResult("GetProduto", new {id = produtoDTO.Id}, produtoDTO);
        }

        [HttpPut("{id:int}")]
        public async Task<ActionResult<ProdutoDTO>> Put(int id,[FromBody] ProdutoDTO produtoDTO)
        {
            if ((produtoDTO is null) || (id != produtoDTO.Id))
                return BadRequest("Dados Inválidos");

            await _ProdutoService.UpdateProduto(produtoDTO);

            return Ok(produtoDTO);
        }

        [HttpDelete("{id:int}")]
        public async Task<ActionResult<ProdutoDTO>> Delete(int id)
        {
            var produtoDTO = _ProdutoService.GetProdutoById(id);

            if (produtoDTO is null)
                return NotFound("Produto não encontrado.");
            
            await _ProdutoService.RemoveProduto(id);

            return Ok(produtoDTO);
        }
    }
}