using DAL;
using Models;

namespace BLL
{
    public class GrupoUsuarioBLL
    {
        private void ValidarDados(GrupoUsuario _grupoUsuario, bool _estaInserindo = true)
        {
            if (!_estaInserindo && _grupoUsuario.Id <= 0)
                throw new Exception("O id tem que ser maior que 0 (zero)");
        }
        public void Inserir(GrupoUsuario _grupoUsuario)
        {
            ValidarDados(_grupoUsuario);
            new GrupoUsuarioDAL().Inserir(_grupoUsuario);
        }
        public List<GrupoUsuario> BuscarTodos()
        {
            return new GrupoUsuarioDAL().BuscarTodos();
        }
        public GrupoUsuario? BuscarPorId(int _id)
        {
            return new GrupoUsuarioDAL().BuscarPorId(_id);
        }
        public void Alterar(GrupoUsuario _grupoUsuario)
        {
            ValidarDados(_grupoUsuario, false);
            new GrupoUsuarioDAL().Alterar(_grupoUsuario);
        }
        public void Excluir(int _id)
        {
            new GrupoUsuarioDAL().Excluir(_id);
        }
    }
}