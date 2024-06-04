using DAL;
using Models;

namespace BLL
{
    public class FixaKardexBLL
    {
        private void ValidarDados(FixaKardex _fixaKardex, bool _estaInserindo = true)
        {
            if (_fixaKardex == null)
                throw new Exception("Informe um registro válido.");
        }
        public void Inserir(FixaKardex _fixaKardex)
        {
            ValidarDados(_fixaKardex);
            new FixaKardexDAL().Inserir(_fixaKardex);
        }
        public List<FixaKardex> BuscarTodos()
        {
            return new FixaKardexDAL().BuscarTodos();
        }
        public FixaKardex? BuscarPorId(int _id)
        {
            return new FixaKardexDAL().BuscarPorId(_id);
        }
        public void Alterar(FixaKardex _fixaKardex)
        {
            ValidarDados(_fixaKardex, false);
            new FixaKardexDAL().Alterar(_fixaKardex);
        }
        public void Excluir(int _id)
        {
            new FixaKardexDAL().Excluir(_id);
        }
    }
}