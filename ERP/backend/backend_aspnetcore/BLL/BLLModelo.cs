using System;
using System.Collections.Generic;
using DAL;

namespace BLL
{
    public abstract class BLLModelo<T, U> where T : class where U : DALModelo<T>
    {
        protected virtual void ValidarDados(T _t, bool _inserindo = true)
        {
            if (_t == null)
                throw new ArgumentNullException(nameof(_t), "A entidade não pode ser nula.");
        }

#warning ignore CS8618
        protected U DataLayer { get; set; }
#warning restore CS8618
        public virtual void Inserir(T _t)
        {
            ValidarDados(_t);
            DataLayer.Inserir(_t);
        }

        public virtual List<T> BuscarTodos()
        {
            return DataLayer.BuscarTodos();
        }

        public virtual T? BuscarPorId(int _id)
        {
            return DataLayer.BuscarPorId(_id);
        }

        public virtual void Alterar(T _t)
        {
            ValidarDados(_t, false);
            DataLayer.Alterar(_t);
        }

        public virtual void Excluir(int _id)
        {
            DataLayer.Excluir(_id);
        }
    }
}
