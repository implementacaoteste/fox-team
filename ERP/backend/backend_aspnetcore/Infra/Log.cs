namespace Infra
{
    public static class Log
    {
        public static void GravarLog(string _texto)
        {
            System.Console.WriteLine($"{DateTime.Now}: {_texto}");
        }
    }
}