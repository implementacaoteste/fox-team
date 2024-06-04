using Models;

namespace DAL
{
    public class GrupoProdutoDAL : DALModelo<GrupoProduto>
    {
        public GrupoProdutoDAL() : base() { }
        public GrupoProdutoDAL(AppDbContext context) : base(context) { }
    }
}