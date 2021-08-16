using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GithubProfileViewsIncrement
{
    public static class Logger
    {
        /// <summary>
        /// log writer
        /// </summary>
        /// <param name="message"></param>
        /// <param name="type"></param>
        public static void Write(string message, TypeMessage type)
        {
            switch (type)
            {
                case TypeMessage.Debug:
                    Console.ForegroundColor = ConsoleColor.Blue;
                    Console.WriteLine($"{DateTime.Now} [Debug] {message}");
                    Console.ForegroundColor = ConsoleColor.White;
                    break;
                case TypeMessage.Done:
                    Console.ForegroundColor = ConsoleColor.Green;
                    Console.WriteLine($"{DateTime.Now} [+] : {message}");
                    Console.ForegroundColor = ConsoleColor.White;
                    break;
                case TypeMessage.Error:
                    Console.ForegroundColor = ConsoleColor.Red;
                    Console.WriteLine($"{DateTime.Now} [!] : {message}");
                    Console.ForegroundColor = ConsoleColor.White;
                    break;
                case TypeMessage.Info:
                    Console.ForegroundColor = ConsoleColor.Yellow;
                    Console.WriteLine($"{DateTime.Now} [-] : {message}");
                    Console.ForegroundColor = ConsoleColor.White;
                    break;
            }
        }
    }
    /// <summary>
    /// log types
    /// </summary>
    public enum TypeMessage
    {
        Error,
        Done,
        Debug,
        Info,
    }
}
