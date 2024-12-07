using System;
using System.Collections.Generic;
using System.Linq;
using System.Text.Json;
using System.Text.Json.Serialization;
using System.Threading.Tasks;
using VShop.Web.Models;
using VShop.Web.Servicos.Contratos;

namespace VShop.Web.Servicos
{
    public class ProdutoServico : IProdutoService
    {
        private readonly IHttpClientFactory _ClientFactory;
        private const string apiEndPoint = "/api/produtos/";
        private readonly JsonSerializerOptions _options;
        private ProdutoViewModel produtoVM;
        private IEnumerable<ProdutoViewModel> produtosVM;

        public ProdutoServico(IHttpClientFactory clientFactory)
        {
            _ClientFactory = clientFactory;
            _options = new JsonSerializerOptions { PropertyNameCaseInsensitive = true };
        }

        public Task<IEnumerable<ProdutoViewModel>> GetAllProdutos()
        {
            throw new NotImplementedException();
        }
        public Task<IEnumerable<ProdutoViewModel>> FindProdutoById(int id)
        {
            throw new NotImplementedException();
        }
        public Task<IEnumerable<ProdutoViewModel>> CreateProduto(ProdutoViewModel produtoVM)
        {
            throw new NotImplementedException();
        }
        public Task<IEnumerable<ProdutoViewModel>> UpdateProduto(ProdutoViewModel produtoVM)
        {
            throw new NotImplementedException();
        }
        public Task<bool> DeleteProdutoById(int id)
        {
            throw new NotImplementedException();
        }

    
    }
}