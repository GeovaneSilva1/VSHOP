namespace VShop.ProdutoApi.Models;

    public class Produto
    {
        public int Id {get;set;}
        public string Nome {get;set;}
        public int Preco {get;set;}
        public string? Descricao {get;set;}
        public long estoque {get;set;}
        public string? ImageUrl {get;set;}

        public Categoria? Categoria {get;set;}
        public int CategoriaId {get;set;}

    }