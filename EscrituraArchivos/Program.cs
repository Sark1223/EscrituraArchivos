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
            StreamWriter sw = new StreamWriter("escribir.txt");
            //Si el archivo no existe lo crera
            //Si el archivo existe escribira sobre el

            string[] lineas =
            {
                "esto es una linea",
                "esta es mi segunda linea",
                "aquí quiero ver un corazón <3",
                "me gusta el pan"
            };

            Console.WriteLine("Escribiendo. . . \n");

            //recorrer el arreglo para escribir las lineas en el archivo
            foreach(string linea in lineas)
            {
                //escribir en el archivo
                sw.WriteLine(linea);
                Console.WriteLine(linea);
            }

            sw.Close();

            Console.WriteLine("\nSe ha completado la escritura ☺");
            Console.ReadKey();
        }
    }
}
