using Models;

namespace DAL
{
    public class FornecedorDAL : DALModelo<Fornecedor>
    {
        public FornecedorDAL() : base() { }
        public FornecedorDAL(AppDbContext context) : base(context) { }
    }
}