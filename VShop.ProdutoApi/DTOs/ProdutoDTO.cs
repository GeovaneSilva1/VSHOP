using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text.Json.Serialization;
using System.Threading.Tasks;
using VShop.ProdutoApi.Models;

namespace VShop.ProdutoApi.DTOs
{
    public class ProdutoDTO
    {
        public int Id {get;set;}

        [Required(ErrorMessage = "O Nome é Obrigatório!")]
        [MinLength(3)]
        [MaxLength(100)]
        public string Nome {get;set;}

        [Required(ErrorMessage = "O Preço é Obrigatório!")]
        public int Preco {get;set;}

        [Required(ErrorMessage = "A descrição é Obrigatória!")]
        [MinLength(5)]
        [MaxLength(200)]
        public string? Descricao {get;set;}

        [Required(ErrorMessage = "O estoque é Obrigatório!")]
        [Range(1,9999)]
        public long estoque {get;set;}
        public string? ImageUrl {get;set;}
        [JsonIgnore]
        public Categoria? Categoria {get;set;}
        public int CategoriaId {get;set;}

    }
}