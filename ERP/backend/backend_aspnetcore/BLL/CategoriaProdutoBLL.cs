using DAL;
using Microsoft.EntityFrameworkCore.Infrastructure.Internal;
using Microsoft.Extensions.Logging;
using Models;
using Infra;

namespace BLL
{
    public class CategoriaProdutoBLL
    {
        private void ValidarDados(CategoriaProduto _categoriaProduto, bool _estaInserindo = true)
        {
            if (!_estaInserindo && _categoriaProduto.Id <= 0)
                throw new Exception("O id tem que ser maior que 0 (zero)");
        }
        public void Inserir(CategoriaProduto _categoriaProduto)
        {
            ValidarDados(_categoriaProduto);
            new CategoriaProdutoDAL().Inserir(_categoriaProduto);
        }
        public List<CategoriaProduto> BuscarTodos()
        {
            return new CategoriaProdutoDAL().BuscarTodos();
        }
        public CategoriaProduto? BuscarPorId(int _id)
        {
            return new CategoriaProdutoDAL().BuscarPorId(_id);
        }
        public void Alterar(CategoriaProduto _categoriaProduto)
        {
            ValidarDados(_categoriaProduto, false);
            new CategoriaProdutoDAL().Alterar(_categoriaProduto);
        }
        public void Excluir(int _id)
        {
            new CategoriaProdutoDAL().Excluir(_id);
        }
    }
}