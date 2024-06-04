using Models;

namespace DAL
{
    public class ItemContasAPagarDAL : DALModelo<ItemContasAPagar>
    {
        public ItemContasAPagarDAL() : base() { }
        public ItemContasAPagarDAL(AppDbContext context) : base(context) { }
    }
}