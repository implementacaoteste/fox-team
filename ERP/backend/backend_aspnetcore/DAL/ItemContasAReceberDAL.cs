using Models;

namespace DAL
{
    public class ItemContasAReceberDAL : DALModelo<ItemContasAReceber>
    {
        public ItemContasAReceberDAL() : base() { }
        public ItemContasAReceberDAL(AppDbContext context) : base(context) { }
    }
}