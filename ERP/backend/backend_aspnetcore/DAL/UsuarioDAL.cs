using Microsoft.EntityFrameworkCore;
using Models;

namespace DAL
{
    public class UsuarioDAL : DALModelo<Usuario>
    {
        public UsuarioDAL() : base() { }

        public UsuarioDAL(AppDbContext context) : base(context) { }

        public List<Usuario> BuscarPorNomeUsuario(string _nomeUsuario)
        {
            return BuscarTodos().Where(u => u.NomeUsuario == _nomeUsuario).ToList();
        }
        public override void Inserir(Usuario _t)
        {
            // Verificar se há grupos de usuário associados
            if (_t.GrupoUsuarioList != null && _t.GrupoUsuarioList.Count > 0)
            {
                // Iterar sobre cada grupo de usuário associado ao usuário
                for (int i = 0; i < _t.GrupoUsuarioList.Count; i++)
                {
                    var grupoUsuario = _t.GrupoUsuarioList[i];

                    // Verificar se o grupo de usuário já existe no banco de dados
                    var existingGroup = context.GrupoUsuario.Find(grupoUsuario.Id);
                    if (existingGroup == null)
                    {
                        // Se o grupo de usuário não existe, insira-o no banco de dados
                        context.GrupoUsuario.Add(grupoUsuario);
                    }
                    else
                    {
                        // Se o grupo de usuário já existe no banco de dados, associe-o ao usuário
                        _t.GrupoUsuarioList[i] = existingGroup; // Substituir a instância pelo grupo existente
                    }
                }
            }

            // Agora podemos inserir o usuário
            base.Inserir(_t);
            context.SaveChanges(); // Salvar as alterações no banco de dados
        }

    }
}