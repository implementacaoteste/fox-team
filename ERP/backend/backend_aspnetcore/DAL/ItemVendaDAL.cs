using Models;

namespace DAL
{
    public class ItemVendaDAL : DALModelo<ItemVenda>
    {
        public ItemVendaDAL() : base() { }
        public ItemVendaDAL(AppDbContext context) : base(context) { }
    }
}