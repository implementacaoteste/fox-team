using DAL;
using Models;

namespace BLL
{
    public class ItemCompraBLL
    {
        private void ValidarDados(ItemCompra _itemCompra, bool _estaInserindo = true)
        {
            if (_itemCompra == null)
                throw new Exception("A entidade não pode ser nula.");
        }
        public void Inserir(ItemCompra _itemCompra)
        {
            ValidarDados(_itemCompra);
            new ItemCompraDAL().Inserir(_itemCompra);
        }
        public List<ItemCompra> BuscarTodos()
        {
            return new ItemCompraDAL().BuscarTodos();
        }
        public ItemCompra? BuscarPorId(int _id)
        {
            return new ItemCompraDAL().BuscarPorId(_id);
        }
        public void Alterar(ItemCompra _itemCompra)
        {
            ValidarDados(_itemCompra, false);
            new ItemCompraDAL().Alterar(_itemCompra);
        }
        public void Excluir(int _id)
        {
            new ItemCompraDAL().Excluir(_id);
        }
    }
}