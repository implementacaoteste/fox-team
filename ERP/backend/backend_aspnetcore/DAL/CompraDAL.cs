using Models;

namespace DAL
{
    public class CompraDAL : DALModelo<Compra>
    {
        public CompraDAL() : base() { }
        public CompraDAL(AppDbContext context) : base(context) { }
    }
}