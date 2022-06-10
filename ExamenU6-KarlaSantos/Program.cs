using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.IO;

namespace ExamenU6_KarlaSantos
{
    class Program
    {
        //inicio de clase Producto
        class Producto
        {
            //Decalracion de campos
            public string nombre, descripcion;
            public float precio;
            public int cantidadStock;

            //Costructor
            public Producto(string nombre, string descripcion, float precio, int cantidadStock)
            {
                this.nombre = nombre;
                this.descripcion = descripcion;
                this.precio = precio;
                this.cantidadStock = cantidadStock;
            }

            //Destructor 
            ~Producto()
            {
                Console.WriteLine("Memoria del objeto Producto destruida");
            }

        }//fin de clase Producto

        static void Main(string[] args)
        {
            //nombre de consola
            Console.Title = "Inventario de Amazon";

            //declaracion de variables
            bool salir = false;
            byte opcion;

            //Decalracion de variables para Informacion
            string nombre, descripcion;
            float precio;
            int cantidadStock;

            //Archivos para consutar
           
            

            do
            {
                //inicio de menú
                Console.WriteLine("BIENVENIDO A AMAZON (inventario)" +
                                  "\nMenú de opciones:" +
                                  "\n1) Registrar un produto al inventario." +
                                  "\n2) Consultar inventario." +
                                  "\n3) Salir.");
                Console.Write("Ingrese el número de la opcion deseada: ");
                opcion = byte.Parse(Console.ReadLine());

                Console.Clear();

                //Casos 
                switch (opcion)
                {
                    case 1:
                        { StreamWriter sw = new StreamWriter("Productos.txt", true);
                            Console.WriteLine("----AGREGAR UN ARTICULO AL INVENTARIO.----");

                            bool error = true;
                            
                            do
                            {
                                try
                                {
                                    Console.WriteLine("Ingresar los siguientes datos del Producto.");

                                    Console.Write("Nombre: ");
                                    nombre = Console.ReadLine();

                                    Console.Write("Descripcion: ");
                                    descripcion = Console.ReadLine();

                                    Console.Write("Precio: ");
                                    precio = float.Parse(Console.ReadLine());

                                    Console.Write("Cantidad en Stock: ");
                                    cantidadStock = int.Parse(Console.ReadLine());

                                    error = false;
                                    
                                    Console.WriteLine("Los datos ingresados son validos");

                                    Producto llamar = new Producto(nombre, descripcion, precio, cantidadStock);

                                    sw.WriteLine("Nombre: {0}" +
                                                 "\nDescripcion: {1} " + 
                                                 "\nPrecio: {2:C}"+
                                                 "\nCantidad en Stock: {3:C}", llamar.nombre, llamar.descripcion, llamar.cantidadStock, llamar.precio);
                                }
                                catch (IOException e)
                                {
                                    Console.WriteLine(e.Message);
                                    Console.WriteLine("Precion <enter> para continuar. . .");
                                    Console.ReadKey();
                                    Console.Clear();
                                }
                                catch (OverflowException e)
                                {
                                    Console.WriteLine(e.Message);
                                    Console.WriteLine("Precion <enter> para continuar. . .");
                                    Console.ReadKey();
                                    Console.Clear();
                                }
                                catch (FormatException)
                                {
                                    Console.WriteLine("El tipo de dato ingresado es erroneo");
                                    Console.WriteLine("Precion <enter> para continuar. . .");
                                    Console.ReadKey();
                                    Console.Clear();
                                }

                            } while (error == true);

                            Console.WriteLine("\nLOS DATOS SE HAN INGRESADO CORRECTAMENTE.");sw.Close();
                        }
                        break;
                    case 2:
                        {
                            StreamReader sr = new StreamReader("Productos.txt");

                            Console.WriteLine("----CONSULTAR ARTICULOS DEL INVENTARIO.----");
                            string leer;

                            while ((leer = sr.ReadLine()) != null)
                            {
                                Console.WriteLine(leer);
                            }

                            sr.Close();
                        }
                        break;
                    case 3:
                        {
                            Console.WriteLine("----EL PROGRAMA A FINALIZADO.----");
                            salir = true;
                        }
                        break;
                    default:
                        Console.WriteLine("OPCION INVALIDA." +
                                          "\nFAVOR DE INGRESAR UN VALOR QUE SE ENCUENTRE EN EL MENU DE OPCIONES.");
                        break;
                }

                Console.WriteLine("Precion <enter> para continuar. . .");
                Console.ReadKey();
                Console.Clear();

            } while (salir != true);
            
            Console.WriteLine("CAMBIOS GUARDADOS EN EL ARCHIVO <Productos>" +
                              "\nPresione cualquier tecla para salir. . .");
            Console.ReadKey();
        }
    }
}
