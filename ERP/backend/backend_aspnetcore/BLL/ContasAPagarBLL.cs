using DAL;
using Models;

namespace BLL
{
    public class ContasAPagarBLL
    {
        private void ValidarDados(ContasAPagar _contasAPagar, bool _estaInserindo = true)
        {
            if (_contasAPagar == null)
                throw new Exception("A entidade não pode ser nula.");
        }
        public void Inserir(ContasAPagar _contasAPagar)
        {
            ValidarDados(_contasAPagar);
            new ContasAPagarDAL().Inserir(_contasAPagar);
        }
        public List<ContasAPagar> BuscarTodos()
        {
            return new ContasAPagarDAL().BuscarTodos();
        }
        public ContasAPagar? BuscarPorId(int _id)
        {
            return new ContasAPagarDAL().BuscarPorId(_id);
        }
        public void Alterar(ContasAPagar _contasAPagar)
        {
            ValidarDados(_contasAPagar, false);
            new ContasAPagarDAL().Alterar(_contasAPagar);
        }
        public void Excluir(int _id)
        {
            new ContasAPagarDAL().Excluir(_id);
        }
    }
}