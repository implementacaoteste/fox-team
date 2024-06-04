using DAL;
using Models;

namespace BLL
{
    public class ItemContasAPagarBLL
    {
        private void ValidarDados(ItemContasAPagar _itemContasAPagar, bool _estaInserindo = true)
        {
            if (_itemContasAPagar == null)
                throw new Exception("A entidade não pode ser nula.");
        }
        public void Inserir(ItemContasAPagar _itemContasAPagar)
        {
            ValidarDados(_itemContasAPagar);
            new ItemContasAPagarDAL().Inserir(_itemContasAPagar);
        }
        public List<ItemContasAPagar> BuscarTodos()
        {
            return new ItemContasAPagarDAL().BuscarTodos();
        }
        public ItemContasAPagar? BuscarPorId(int _id)
        {
            return new ItemContasAPagarDAL().BuscarPorId(_id);
        }
        public void Alterar(ItemContasAPagar _itemContasAPagar)
        {
            ValidarDados(_itemContasAPagar, false);
            new ItemContasAPagarDAL().Alterar(_itemContasAPagar);
        }
        public void Excluir(int _id)
        {
            new ItemContasAPagarDAL().Excluir(_id);
        }
    }
}