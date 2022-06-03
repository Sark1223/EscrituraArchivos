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
                float estatura = this.estatura / 100F;
                return  this.peso / (estatura*estatura);
            }
        }

        static void Main(string[] args)
        {
            //Nombre del programa 
            Console.Title = "REGISTRO DE DATOS";

            //escritura en archivo
                StreamWriter sw = new StreamWriter("Informacion.txt", true);
                Console.WriteLine("Escribiendo. . . \n");
            
            bool cerrar = false;
            string decision;
            do
            {
                //Declaracion de variables 
                bool error = true;
                string nombre;
                sbyte edad;
                float peso;
                byte estatura;

                do
                {
                    try
                    {
                        //obtencion de datos 
                        Console.WriteLine("Favor de ingresar los siguientes datos.");
                        Console.Write("Nombre: ");
                        nombre = Console.ReadLine();

                        Console.Write("Edad: ");
                        edad = sbyte.Parse(Console.ReadLine());

                        Console.Write("Peso (kg): ");
                        peso = float.Parse(Console.ReadLine());

                        Console.Write("Estatura (cm) : ");
                        estatura = byte.Parse(Console.ReadLine());

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
                        
                        Console.Clear();
                        
                        error = false;
                    }
                    //Revision de errores 
                    catch (OverflowException)
                    {
                        Console.WriteLine("Has ingresado muchos caracteres");
                        Console.WriteLine("Presione enter para continuar. . . ");
                        Console.ReadKey();
                        Console.Clear();
                    }
                    catch (FormatException)
                    {
                        Console.WriteLine("Los datos no son del formato correcto");
                        Console.WriteLine("Presione enter para continuar. . . ");
                        Console.ReadKey();
                        Console.Clear();
                    }
                    catch (Exception e)
                    {
                        Console.WriteLine(e);
                        Console.WriteLine("Presione enter para continuar. . . ");
                        Console.ReadKey();
                        Console.Clear();
                    }

                    

                } while (error != false);

                Console.WriteLine("Los datos ingresados son validos. . .\n");

                //opcion para desidir si detener el programa o no.
                do
                {
                    Console.Write("Desea registrar más datos?\n" +
                                      "→ Si\n" +
                                      "→ No\n" +
                                      "Ingrese la opcion deseada: ");
                    decision = Console.ReadLine();

                    Console.Clear();

                    //validacion de la respuesta que el ususario introdujo
                    if (decision == "si" || decision == "Si" || decision == "sí" || decision == "Sí" || decision == "SÍ" || decision == "SI")
                    {
                        Console.WriteLine("Escribiendo. . . \n");
                        cerrar = false;
                    }
                    else if (decision == "no" || decision == "NO" || decision == "No")
                    {
                        cerrar = true;
                    }
                    else
                    {
                        Console.WriteLine("Favor de ingresar solo una de las 2 opciones dadas.");
                        decision = "error";
                    }

                } while (decision == "error");

            } while (cerrar == false);
            Console.WriteLine("Se ha completado la escritura ☺\n");
            Console.WriteLine("Presione enter para finalizar. . .");
            sw.Close();
            Console.ReadKey();
        }
    }
}
