using Models;

namespace DAL
{
    public class GrupoUsuarioDAL : DALModelo<GrupoUsuario>
    {
        public GrupoUsuarioDAL() : base() { }

        public GrupoUsuarioDAL(AppDbContext context) : base(context) { }
    }
}