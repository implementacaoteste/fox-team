using DAL;
using Models;

namespace BLL
{
    public class ItemVendaBLL
    {
        private void ValidarDados(ItemVenda _itemVenda, bool _estaInserindo = true)
        {
            if (_itemVenda == null)
                throw new Exception("A entidade não pode ser nula.");
        }
        public void Inserir(ItemVenda _itemVenda)
        {
            ValidarDados(_itemVenda);
            new ItemVendaDAL().Inserir(_itemVenda);
        }
        public List<ItemVenda> BuscarTodos()
        {
            return new ItemVendaDAL().BuscarTodos();
        }
        public ItemVenda? BuscarPorId(int _id)
        {
            return new ItemVendaDAL().BuscarPorId(_id);
        }
        public void Alterar(ItemVenda _itemVenda)
        {
            ValidarDados(_itemVenda, false);
            new ItemVendaDAL().Alterar(_itemVenda);
        }
        public void Excluir(int _id)
        {
            new ItemVendaDAL().Excluir(_id);
        }
    }
}