using DAL;
using Models;

namespace BLL
{
    public class MarcaBLL
    {
        private void ValidarDados(Marca _marca, bool _estaInserindo = true)
        {
            if (_marca == null)
                throw new Exception("A entidade não pode ser nula.");
        }
        public void Inserir(Marca _marca)
        {
            ValidarDados(_marca);
            new MarcaDAL().Inserir(_marca);
        }
        public List<Marca> BuscarTodos()
        {
            return new MarcaDAL().BuscarTodos();
        }
        public Marca? BuscarPorId(int _id)
        {
            return new MarcaDAL().BuscarPorId(_id);
        }
        public void Alterar(Marca _marca)
        {
            ValidarDados(_marca, false);
            new MarcaDAL().Alterar(_marca);
        }
        public void Excluir(int _id)
        {
            new MarcaDAL().Excluir(_id);
        }
    }
}