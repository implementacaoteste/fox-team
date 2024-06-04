using System.Collections.Generic;

namespace Infra
{
    public enum Mensagem
    {
        NaoEncontrado,
        EntidadeNula,
        Excluido,
        Erro500,
        Nenhuma
    }
    public static class Texto
    {
        private static readonly Dictionary<string, (string, string)> dicionario = new Dictionary<string, (string, string)>()
        {
            { "Usuario", ("Usuário", "o") },
            { "Descricao", ("Descrição", "a") },
            { "Cliente", ("Cliente", "o") },
            { "CategoriaProduto", ("Categoria de produto", "a") },
            { "Grupo", ("Grupo", "o") }
        };
        public static string Verbose(string _entidade, Mensagem mensagem = Mensagem.Nenhuma)
        {
            var (entidade, artigo) = dicionario.ContainsKey(_entidade) ? dicionario[_entidade] : (_entidade, "o");

            switch (mensagem)
            {
                case Mensagem.EntidadeNula:
                    return $"Informe um{(artigo == "a" ? "a" : "")} {entidade.ToLower()} válid{(artigo == "a" ? "a" : "o")}.";
                case Mensagem.NaoEncontrado:
                    return $"{entidade} não encontrad{(artigo == "a" ? "a" : "o")}.";
                case Mensagem.Excluido:
                    return $"{entidade} excluíd{(artigo == "a" ? "a" : "o")} com sucesso!";
                case Mensagem.Nenhuma:
                    return entidade;
                case Mensagem.Erro500:
                    return "Erro interno do servidor";
                default:
                    return "Mensagem não reconhecida.";
            }
        }
    }
}
