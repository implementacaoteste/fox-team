using Models;

namespace DAL
{
    public class PermissaoDAL : DALModelo<Permissao>
    {
        public PermissaoDAL() : base() { }
        public PermissaoDAL(AppDbContext context) : base(context) { }
    }
}