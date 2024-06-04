using DAL;
using Models;

namespace BLL
{
    public class VendaBLL
    {
        private void ValidarDados(Venda _venda, bool _estaInserindo = true)
        {
            if (_venda == null)
                throw new Exception("A entidade não pode ser nula.");
        }
        public void Inserir(Venda _venda)
        {
            ValidarDados(_venda);
            new VendaDAL().Inserir(_venda);
        }
        public List<Venda> BuscarTodos()
        {
            return new VendaDAL().BuscarTodos();
        }
        public Venda? BuscarPorId(int _id)
        {
            return new VendaDAL().BuscarPorId(_id);
        }
        public void Alterar(Venda _venda)
        {
            ValidarDados(_venda, false);
            new VendaDAL().Alterar(_venda);
        }
        public void Excluir(int _id)
        {
            new VendaDAL().Excluir(_id);
        }
    }
}