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
        //creación de clase infoPersona
        class infoPersona
        {
            public string nombre;
            public sbyte edad;
            public float peso;
            public byte estatura;

            //constructor de la clase 
            public infoPersona(string nombre, sbyte edad, float peso, byte estatura)
            {
                this.nombre = nombre;
                this.edad = edad;
                this.peso = peso;
                this.estatura = estatura;
            }
            
            public DateTime fecha()
            {
                // Declaramos nuestra variable tipo fecha.
                DateTime dtToday = DateTime.Now;
                return dtToday;
            }

            public float MetodoIMC()
            {
                float estatura = this.estatura / 100;
                return  this.peso / (estatura*estatura);
            }
        }

        static void Main(string[] args)
        {
            //escritura en archivo
            StreamWriter sw = new StreamWriter("Informacion.txt", true);
            Console.WriteLine("Escribiendo. . . \n");

            //obtencion de datos 
            Console.WriteLine("Favor de ingresar los siguientes datos.");
            Console.Write("Nombre: ");
            string nombre = Console.ReadLine();

            Console.Write("Edad: ");
            sbyte edad = sbyte.Parse(Console.ReadLine());

            Console.Write("Peso (kg): ");
            float peso = float.Parse(Console.ReadLine());

            Console.Write("Estatura (cm) : ");
            byte estatura = byte.Parse(Console.ReadLine());

            //creacion de objeto tipo infoPersona
            infoPersona Datos = new infoPersona(nombre, edad, peso, estatura);

            //escribirlo en el archivo "escribir"
            sw.WriteLine("FECHA: {0}\n" +
                         "NOMBRE: {1}\n" +
                         "EDAD: {2} años\n" +
                         "PESO: {3} kg\n" +
                         "ESTATURA: {4}\n" +
                         "IMC: {5}\n", 
                         Datos.fecha(), Datos.nombre, Datos.edad, Datos.peso, Datos.estatura, Datos.MetodoIMC());

            //guardar cambios
            sw.Close();
            Console.Clear();

            Console.WriteLine("Se ha completado la escritura ☺");
            Console.ReadKey();
        }
    }
}
