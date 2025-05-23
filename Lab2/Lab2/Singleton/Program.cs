using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace Singleton
{
    public sealed class Authenticator
    {

        private static Authenticator _instance = null;

        private static readonly object _lockObg = new object();

        private Authenticator()
        {
            Console.WriteLine("Authenticator викликано.");
        }

        public static Authenticator Instance
        {
            get
            {
                if (_instance == null)
                {
                    lock (_lockObg)
                    {
                        if (_instance == null)
                        {
                            _instance = new Authenticator();
                        }
                    }
                }
                return _instance;
            }
        }

        public void Authenticate()
        {
            Console.WriteLine("Аутентифікація виконана!");
        }

    }

    class Program
    {
        static void Main(string[] args)
        {
            static void WriteLineGreen(string message)
            {
                Console.ForegroundColor = ConsoleColor.Green;
                Console.WriteLine(message);
                Console.ResetColor();
            }

            Console.OutputEncoding = System.Text.Encoding.UTF8;
            Console.InputEncoding = System.Text.Encoding.UTF8;

            Thread thread1 = new Thread(() =>
            {
                Authenticator auth1 = Authenticator.Instance;
                auth1.Authenticate();
                WriteLineGreen($"auth1 HashCode: {auth1.GetHashCode()}");
            });

            Thread thread2 = new Thread(() =>
            {
                Authenticator auth2 = Authenticator.Instance;
                auth2.Authenticate();
                WriteLineGreen($"auth2 HashCode: {auth2.GetHashCode()}");
            });

            thread1.Start();
            thread2.Start();

            thread1.Join();
            thread2.Join();

            var a1 = Authenticator.Instance;
            var a2 = Authenticator.Instance;
            Console.WriteLine($"Обидва об'єкти однакові? {ReferenceEquals(a1, a2)}");


        }
    }
}
