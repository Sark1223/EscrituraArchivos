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
        class InfoPersona
        {
            public string nombre;
            public sbyte edad;
            public float peso;
            public byte estatura;

            //constructor de la clase 
            public InfoPersona(string nombre, sbyte edad, float peso, byte estatura)
            {
                this.nombre = nombre;
                this.edad = edad;
                this.peso = peso;
                this.estatura = estatura;
            }
            
            public DateTime Fecha()
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
                        InfoPersona datos = new InfoPersona(nombre, edad, peso, estatura);

                        //escribirlo en el archivo "escribir"
                        sw.WriteLine("FECHA: {0}\n" +
                             "NOMBRE: {1}\n" +
                             "EDAD: {2} años\n" +
                             "PESO: {3} kg\n" +
                             "ESTATURA: {4}\n" +
                             "IMC: {5}\n",
                             datos.Fecha(), datos.nombre, datos.edad, datos.peso, datos.estatura, datos.MetodoIMC());
                        
                        Console.Clear();
                        
                        error = false;
                    }
                    //Revision de errores 
                    catch (OverflowException)
                    {
                        Console.ForegroundColor = ConsoleColor.Red;
                        Console.WriteLine("Has ingresado muchos caracteres");
                        Console.ResetColor();
                        Console.WriteLine("Presione enter para continuar. . . ");
                        Console.ReadKey();
                        Console.Clear();
                    }
                    catch (FormatException)
                    {
                        Console.ForegroundColor = ConsoleColor.Red;
                        Console.WriteLine("Los datos no son del formato correcto");
                        Console.ResetColor();
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
                    //si ingresa sí lower
                    if (decision.ToLower() == "si" || decision.ToLower() == "sí" /*ToLowe hace que la cadena se haga minuscula para comparar*/)
                    {
                        Console.WriteLine("Escribiendo. . . \n");
                        //significa que quiere seguir agregando datos, por lo tanto no quiere cerrar el programa
                        cerrar = false;
                    }
                    else if (decision.ToLower() == "no")
                    {
                        //Si dice que no quiere agregar mas datos, cerrar es igual a verdadero
                        cerrar = true;
                    }
                    else
                    {
                        Console.WriteLine("Favor de ingresar solo una de las 2 opciones dadas.");
                        //desicion sera igual a error para que el siclo continue pidiendo respuesta
                        decision = "error";
                    }

                } while (decision == "error");// mientras la decision este equivocada

            } while (cerrar == false);// mientras el usuario no se quiera salir
            
            sw.Close();//cuando un archivo se cierra se guarda

            Console.WriteLine("Se ha completado la escritura ☺\n");
            Console.WriteLine("Presione enter para finalizar. . .");
            Console.ReadKey();
        }
    }
}
