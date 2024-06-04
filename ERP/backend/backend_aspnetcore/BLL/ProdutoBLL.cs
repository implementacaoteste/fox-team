using DAL;
using Models;

namespace BLL
{
    public class ProdutoBLL
    {
        public void Inserir(Produto _produto)
        {
            new ProdutoDAL().Inserir(_produto);
        }
        public List<Produto>BuscarTodos()
        {
            return new ProdutoDAL().BuscarTodos();
        }
        public Produto? BuscarPorId(int _id)
        {
            return new ProdutoDAL().BuscarPorId(_id);
        }
        public void Alterar(Produto _produto)
        {
            new ProdutoDAL().Alterar(_produto);
        }
        public void Excluir(int _id)
        {
            new ProdutoDAL().Excluir(_id);
        }
    }
}