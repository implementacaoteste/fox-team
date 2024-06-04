using Models;

namespace DAL
{
    public class ItemCompraDAL : DALModelo<ItemCompra>
    {
        public ItemCompraDAL() : base() { }
        public ItemCompraDAL(AppDbContext context) : base(context) { }
    }
}