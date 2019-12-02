using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TestLogica.Model;

namespace TestLogica
{
    public class Program
    {
        public static void Main(string[] args)
        {
            int casos;
            int[] m, n;
            Agente agente;
            Plataforma plataforma;
            Console.WriteLine("Capture el numero de casos");
            casos = Int32.Parse(Console.ReadLine());
            m = new int[casos];
            n = new int[casos];
            
            for(int i = 0;i < casos; i++)
            {
                Console.WriteLine("Capture el numero de filas a recorrer");
                m[i] = Int32.Parse(Console.ReadLine());
                Console.WriteLine("Capture el numero de columnas a recorrer");
                n[i] = Int32.Parse(Console.ReadLine());
            }

            for(int i = 0; i < casos; i++)
            {
                plataforma = new Plataforma(m[i], n[i]);
                agente = new Agente();
                agente.Mapa = plataforma;
                agente.Init();
                while (true)
                {
                    agente.Move();
                    if (agente.Stop)
                    {
                        Console.WriteLine(agente.Sentido.ToString());
                        break;
                    }
                }
            }

            Console.ReadLine();
        }
    }
}
