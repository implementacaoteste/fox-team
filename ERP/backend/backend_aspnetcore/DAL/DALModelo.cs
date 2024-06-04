namespace DAL
{
    public class DALModelo<T> where T : class
    {
        protected readonly AppDbContext context;
        /// <summary>
        /// O context só será destruído se foi originado aqui
        /// </summary>
        private readonly bool inicio;

        public DALModelo()
        {
            context = new AppDbContext();
            inicio = true;
        }
        public DALModelo(AppDbContext _context)
        {
            context = _context;
            inicio = false;
        }
        public virtual void Salvar(T _t)
        {
            if ((context.Entry(_t).Property("Id").CurrentValue as int?) == 0)
                Inserir(_t);
            else
                Alterar(_t);
        }
        public virtual void Inserir(T _t)
        {
            SalvarComEntityFramework(_t);
        }
        public virtual List<T> BuscarTodos()
        {
            return context.Set<T>().ToList();
        }
        public virtual T? BuscarPorId(int _id)
        {
            return context.Set<T>().Find(_id);
        }
        public virtual void Alterar(T _t)
        {
            SalvarComEntityFramework(_t);
        }
        public virtual void Excluir(int _id)
        {
            var t = BuscarPorId(_id);
            if (t != null)
                Excluir(t);
        }
        public virtual void Excluir(T _t)
        {
            SalvarComEntityFramework(_t, true);
        }
        private void SalvarComEntityFramework(T _t, bool _excluir = false)
        {
            if (_excluir)
                context.Remove(_t);
            else if ((context.Entry(_t).Property("Id").CurrentValue as int?) == 0)
                context.Add(_t);
            else
                context.Update(_t);
            
            context.SaveChanges();
        }
        public void Dispose()
        {
            if (inicio)
                context.Dispose();
        }
    }
}