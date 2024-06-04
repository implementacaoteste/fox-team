using Models;

namespace DAL
{
    public class FormaPagamentoDAL : DALModelo<FormaPagamento>
    {
        public FormaPagamentoDAL() : base() { }
        public FormaPagamentoDAL(AppDbContext context) : base(context) { }
    }
}