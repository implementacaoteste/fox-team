using DAL;
using Models;

namespace BLL
{
    public class GrupoProdutoBLL
    {
        private void ValidarDados(GrupoProduto _grupoProduto, bool _estaInserindo = true)
        {
            throw new ArgumentNullException(nameof(_grupoProduto), "A entidade não pode ser nula");
        }
        public void Inserir(GrupoProduto _grupoProduto)
        {
            ValidarDados(_grupoProduto);
            new GrupoProdutoDAL().Inserir(_grupoProduto);
        }
        public List<GrupoProduto> BuscarTodos()
        {
            return new GrupoProdutoDAL().BuscarTodos();
        }
        public GrupoProduto? BuscarPorId(int _id)
        {
            return new GrupoProdutoDAL().BuscarPorId(_id);
        }
        public void Alterar(GrupoProduto _grupoProduto)
        {
            ValidarDados(_grupoProduto, false);
            new GrupoProdutoDAL().Alterar(_grupoProduto);
        }
        public void Excluir(int _id)
        {
            new GrupoProdutoDAL().Excluir(_id);
        }
    }
}