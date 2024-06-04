using Models;

namespace DAL
{
    public class CategoriaProdutoDAL : DALModelo<CategoriaProduto>
    {
        public CategoriaProdutoDAL() : base() { }
        public CategoriaProdutoDAL(AppDbContext context) : base(context) { }
    }
}