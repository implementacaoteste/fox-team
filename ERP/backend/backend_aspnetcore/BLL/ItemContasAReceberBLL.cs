using DAL;
using Models;

namespace BLL
{
    public class ItemContasAReceberBLL
    {
        private void ValidarDados(ItemContasAReceber _itemContasAReceber, bool _estaInserindo = true)
        {
            if (_itemContasAReceber == null)
                throw new Exception("A entidade não pode ser nula.");
        }
        public void Inserir(ItemContasAReceber _itemContasAReceber)
        {
            ValidarDados(_itemContasAReceber);
            new ItemContasAReceberDAL().Inserir(_itemContasAReceber);
        }
        public List<ItemContasAReceber> BuscarTodos()
        {
            return new ItemContasAReceberDAL().BuscarTodos();
        }
        public ItemContasAReceber? BuscarPorId(int _id)
        {
            return new ItemContasAReceberDAL().BuscarPorId(_id);
        }
        public void Alterar(ItemContasAReceber _itemContasAReceber)
        {
            ValidarDados(_itemContasAReceber, false);
            new ItemContasAReceberDAL().Alterar(_itemContasAReceber);
        }
        public void Excluir(int _id)
        {
            new ItemContasAReceberDAL().Excluir(_id);
        }
    }
}