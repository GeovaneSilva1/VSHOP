using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;
using VShop.ProdutoApi.Models;

namespace VShop.ProdutoApi.DTOs
{
    public class CategoriaDTO
    {
        public int CategoriaId {get;set;}
        
        [Required(ErrorMessage = "O Nome é Obrigatório!")]
        [MinLength(3)]
        [MaxLength(100)]
        public string Nome {get;set;}
        public ICollection<Produto> Produtos {get;set;}
    }
}