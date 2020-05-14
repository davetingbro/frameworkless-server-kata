using System;

namespace FrameworklessServerKata
{
    class Program
    {
        static void Main(string[] args)
        {
            try
            {
                var server = new Server();
                server.Start();
            }
            catch (Exception e)
            {
                Console.WriteLine("You have crashed the server...");
                Console.WriteLine(e.Message);
                throw;
            }
        }
    }
}