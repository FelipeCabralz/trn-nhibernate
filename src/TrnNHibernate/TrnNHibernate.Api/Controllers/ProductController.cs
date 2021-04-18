using Microsoft.AspNetCore.Mvc;
using NHibernate;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using TrnNHibernate.Api.Core.Requests;
using TrnNHibernate.Entidades;

namespace TrnNHibernate.Api.Controllers
{
    [Route("produto")]
    public class ProductController : ControllerBase
    {
        private readonly ISession _session;

        public ProductController(ISession session)
        {
            _session = session;
        }

        [HttpPost]
        [Route("novo")]
        public IActionResult NovoProduto([FromBody] ProdutoRequest produtoRequest)
        {
            var produto = new Produto(produtoRequest.Nome, produtoRequest.PrecoUnitario, produtoRequest.QuantidadeEstoque);
            _session.Save(produto);
            return Ok("Cliente gravado com sucesso");
        }
        [HttpPost]
        [Route("atualizar")]
        public IActionResult AtualizarProduto([FromBody] ProdutoRequest produtoRequest)
        {
            using (ITransaction transaction = _session.BeginTransaction())
            {
                var produtoExistente = _session.Get<Produto>(produtoRequest.Id);
                produtoExistente.Atualizar(produtoRequest.Nome, produtoRequest.PrecoUnitario, produtoRequest.QuantidadeEstoque);
                _session.Update(produtoExistente);

                transaction.Commit();
            }
            return Ok("Produto atualizado com sucesso");
        }
        [HttpGet]
        [Route("{id}")]
        public IActionResult RecuperarProduto(int id)
        {
            var produto = _session.Get<Produto>(id);
            return Ok(produto);
        }
    }

}
