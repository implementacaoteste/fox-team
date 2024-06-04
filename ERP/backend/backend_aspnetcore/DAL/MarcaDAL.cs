using Models;

namespace DAL
{
    public class MarcaDAL : DALModelo<Marca>
    {
        public MarcaDAL() : base() { }
        public MarcaDAL(AppDbContext context) : base(context) { }
    }
}