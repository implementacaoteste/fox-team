using DAL;
using Models;

namespace BLL
{
    public class PermissaoBLL
    {
        private void ValidarDados(Permissao _permissao, bool _estaInserindo = true)
        {
            if (_permissao == null)
                throw new Exception("A entidade não pode ser nula.");
        }
        public void Inserir(Permissao _permissao)
        {
            ValidarDados(_permissao);
            new PermissaoDAL().Inserir(_permissao);
        }
        public List<Permissao> BuscarTodos()
        {
            return new PermissaoDAL().BuscarTodos();
        }
        public Permissao? BuscarPorId(int _id)
        {
            return new PermissaoDAL().BuscarPorId(_id);
        }
        public void Alterar(Permissao _permissao)
        {
            ValidarDados(_permissao, false);
            new PermissaoDAL().Alterar(_permissao);
        }
        public void Excluir(int _id)
        {
            new PermissaoDAL().Excluir(_id);
        }
    }
}