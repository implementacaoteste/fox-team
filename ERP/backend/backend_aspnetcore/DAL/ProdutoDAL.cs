using Models;

namespace DAL
{
    public class ProdutoDAL : DALModelo<Produto>
    {
        public ProdutoDAL() : base() { }
        public ProdutoDAL(AppDbContext context) : base(context) { }
    }
}