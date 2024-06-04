namespace Models
{
    public class Permissao
    {
        public int Id { get; set; }
        public string? Descricao { get; set; }
        public List<GrupoUsuario>? GrupoUsuarioList { get; set; }
    }
}