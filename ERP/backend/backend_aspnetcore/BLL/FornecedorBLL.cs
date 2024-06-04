using DAL;
using Models;

namespace BLL
{
    public class FornecedorBLL
    {
        private void ValidarDados(Fornecedor _fornecedor, bool _estaInserindo = true)
        {
            if (_fornecedor == null)
                throw new Exception("Informe um registro válido para fornecedor.");
        }
        public void Inserir(Fornecedor _fornecedor)
        {
            ValidarDados(_fornecedor);
            new FornecedorDAL().Inserir(_fornecedor);
        }
        public List<Fornecedor> BuscarTodos()
        {
            return new FornecedorDAL().BuscarTodos();
        }
        public Fornecedor? BuscarPorId(int _id)
        {
            return new FornecedorDAL().BuscarPorId(_id);
        }
        public void Alterar(Fornecedor _fornecedor)
        {
            ValidarDados(_fornecedor, false);
            new FornecedorDAL().Alterar(_fornecedor);
        }
        public void Excluir(int _id)
        {
            new FornecedorDAL().Excluir(_id);
        }
    }
}