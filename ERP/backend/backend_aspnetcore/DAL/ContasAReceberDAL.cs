using Models;

namespace DAL
{
    public class ContasAReceberDAL : DALModelo<ContasAReceber>
    {
        public ContasAReceberDAL() : base() { }
        public ContasAReceberDAL(AppDbContext context) : base(context) { }
    }
}