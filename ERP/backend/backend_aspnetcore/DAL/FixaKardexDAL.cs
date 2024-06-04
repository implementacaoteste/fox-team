using Models;

namespace DAL
{
    public class FixaKardexDAL : DALModelo<FixaKardex>
    {
        public FixaKardexDAL() : base() { }
        public FixaKardexDAL(AppDbContext context) : base(context) { }
    }
}