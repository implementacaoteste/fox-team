using DAL;
using Models;

namespace BLL
{
    public class FormaPagamentoBLL
    {
        private void ValidarDados(FormaPagamento _formaPagamento, bool _estaInserindo = true)
        {
            if (_formaPagamento == null)
                throw new Exception("Informe um registro válido para forma de pagamento.");
        }
        public void Inserir(FormaPagamento _formaPagamento)
        {
            ValidarDados(_formaPagamento);
            new FormaPagamentoDAL().Inserir(_formaPagamento);
        }
        public List<FormaPagamento> BuscarTodos()
        {
            return new FormaPagamentoDAL().BuscarTodos();
        }
        public FormaPagamento? BuscarPorId(int _id)
        {
            return new FormaPagamentoDAL().BuscarPorId(_id);
        }
        public void Alterar(FormaPagamento _formaPagamento)
        {
            ValidarDados(_formaPagamento, false);
            new FormaPagamentoDAL().Alterar(_formaPagamento);
        }
        public void Excluir(int _id)
        {
            new FormaPagamentoDAL().Excluir(_id);
        }
    }
}