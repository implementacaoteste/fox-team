using Models;

namespace DAL
{
    public class VendaDAL : DALModelo<Venda>
    {
        public VendaDAL() : base() { }
        public VendaDAL(AppDbContext context) : base(context) { }
    }
}