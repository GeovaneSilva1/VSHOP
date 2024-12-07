using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace VShop.Web.Models
{
    public class ProdutoViewModel
    {
        public int Id {get;set;}
        public String? Nome {get;set;}
        public int Preco {get;set;}
        public String? Descricao {get;set;}
        public long estoque {get;set;}
        public String? ImageUrl {get;set;}
        public String? CategoriaNome {get;set;}
        public int CategoriaId {get;set;}

    }
}