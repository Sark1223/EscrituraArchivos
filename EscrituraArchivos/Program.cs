using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.IO;

namespace EscrituraArchivos
{
    class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("Escribiendo. . . \n");
            
            //escritura en archivo
            StreamWriter sw = new StreamWriter("escribir.txt", true);
            
            //obtencion de datos 
            Console.Write("Ingrese un nombre: ");
            string name = Console.ReadLine();

            //escribirlo en el archivo "escribir"
            sw.WriteLine(name);

            //guardar cambios
            sw.Close();
            Console.Clear();

            Console.WriteLine("Se ha completado la escritura ☺");
            Console.ReadKey();
        }
    }
}
