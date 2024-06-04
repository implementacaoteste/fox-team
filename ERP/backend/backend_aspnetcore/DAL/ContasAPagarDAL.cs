using Models;

namespace DAL
{
    public class ContasAPagarDAL : DALModelo<ContasAPagar>
    {
        public ContasAPagarDAL() : base() { }
        public ContasAPagarDAL(AppDbContext context) : base(context) { }
    }
}