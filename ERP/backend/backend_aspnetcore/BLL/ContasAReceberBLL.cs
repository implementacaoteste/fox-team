using DAL;
using Models;

namespace BLL
{
    public class ContasAReceberBLL
    {
        private void ValidarDados(ContasAReceber _contasAReceber, bool _estaInserindo = true)
        {
            if (_contasAReceber == null)
                throw new Exception("A entidade não pode ser nula.");
        }
        public void Inserir(ContasAReceber _contasAReceber)
        {
            ValidarDados(_contasAReceber);
            new ContasAReceberDAL().Inserir(_contasAReceber);
        }
        public List<ContasAReceber> BuscarTodos()
        {
            return new ContasAReceberDAL().BuscarTodos();
        }
        public ContasAReceber? BuscarPorId(int _id)
        {
            return new ContasAReceberDAL().BuscarPorId(_id);
        }
        public void Alterar(ContasAReceber _contasAReceber)
        {
            ValidarDados(_contasAReceber, false);
            new ContasAReceberDAL().Alterar(_contasAReceber);
        }
        public void Excluir(int _id)
        {
            new ContasAReceberDAL().Excluir(_id);
        }
    }
}