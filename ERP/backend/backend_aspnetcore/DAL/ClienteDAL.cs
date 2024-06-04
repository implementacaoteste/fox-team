using Models;

namespace DAL
{
    public class ClienteDAL : DALModelo<Cliente>
    {
        public ClienteDAL() : base() { }
        public ClienteDAL(AppDbContext context) : base(context) { }
    }
}