using DAL;
using Models;
using System;
using System.Collections.Generic;

namespace BLL
{
    public class UsuarioBLL
    {
        private readonly UsuarioDAL usuarioDAL;

        public UsuarioBLL()
        {
            usuarioDAL = new UsuarioDAL();
        }

        public List<Usuario> BuscarTodos()
        {
            return usuarioDAL.BuscarTodos();
        }

        public Usuario? BuscarPorId(int _id)
        {
            return usuarioDAL.BuscarPorId(_id);
        }

        public void Inserir(Usuario _usuario)
        {
            ArgumentNullException.ThrowIfNull(_usuario, "O arqumento 'usuário' não pode ser nulo");
            usuarioDAL.Inserir(_usuario);
        }

        public void Alterar(Usuario _usuario)
        {
            ArgumentNullException.ThrowIfNull(_usuario);
            usuarioDAL.Alterar(_usuario);
        }

        public void Excluir(int _id)
        {
            usuarioDAL.Excluir(_id);
        }
    }
}
