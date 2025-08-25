using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Ejercicio2__DSP
{
    internal class Program
    {
        static void Main(string[] args)
        {
            //Creacion de instancia de la clase Conjunto
            Conjunto conjunto1 = new Conjunto();
            Conjunto conjunto2 = new Conjunto();
            Conjunto conjunto3 = new Conjunto(ValoresAleatorios());

            //Pedir datos al usuario
            Console.WriteLine("Bienvenido al programa de Conjunto de Elementos");
            Console.ReadKey();
            Console.Write("\n--A continuacion digite 5 decimales positivos que desea agregar al conjunto--"); //No se si peuden convertir esta parte en metodo Rudy o fran jejejeje :v
            for (int i = 0; i < 5; i++)
            {
                Console.Write($"\nnum {i + 1}: ");
                if (decimal.TryParse(Console.ReadLine(), out decimal num))
            {
                if (conjunto1.InsertarNumero(num))
                {
                    Console.WriteLine("El numero se ha insertado correctamente");
                }
                else
                {
                    Console.WriteLine("El numero no se ha podido insertar");
                }
                conjunto1.InsertarNumero(num);
            }
                else
                {
                    Console.WriteLine("El valor ingresado no es un decimal positivo. Intente de nuevo.");
                }
                Console.ReadKey();
            }

            Console.WriteLine("Los numeros aleatorios generados para el conjunto 3 son: ");
            for (int i = 0; i < 15; i++)
            {
               // Console.WriteLine(conjunto3.); Aqui continuen cuando hagan el metodo F de la guia
            }

        }

        public static decimal[] ValoresAleatorios()
        {
            //Obtendremos 15 numeros decimales aleatorios, cada uno en el rango [-10, 10]
            Random aleatorio = new Random();
            decimal[] numAleatorios = new decimal[15];
            
            for (int i = 0; i < 15; i++)
            {              
               double numero = Math.Round((aleatorio.NextDouble() * 20) -10 ,2);
               numAleatorios[i] = (decimal)numero;
            }         
            return numAleatorios;
        }
    }
}
