using System;

namespace Ejercicio2__DSP
{
    internal class Program
    {
        //--------- Integrantes  ---------//
        //Anderson Ruben Portillo Alfaro PA250120
        //Daniel Adrian Castillo Garcia CG250400
        //Francisco Josue Santos Lopez SL251022
        //Nahum de Jesus Flores Giron FG250084
        //Rudy Mauricio Gonsalez Pineda GP250120
        static void Main(string[] args)
        {
            /// <summary>
            /// Creacion de instancias de la clase Conjunto (se iran probando los constructores)
            /// </summary>
            Conjunto conjunto1 = new Conjunto();
            Conjunto conjunto2 = new Conjunto();
            Conjunto conjunto3 = new Conjunto(ValoresAleatorios());

            /// <summary>
            /// Se le solicita al usuario ingresar 5 decimales positivos para el conjunto1
            /// Si el numero ya existe o no es positivo, no se agrega
            /// </summary>
            Console.WriteLine("\tBienvenido al programa de Conjunto de Elementos");
            Console.WriteLine("\n\t--Ingrese 5 decimales positivos para el conjunto 1--");

            for (int i = 0; i < 5; i++)
            {
                Console.Write($"\tnum {i + 1}: ");
                string entrada = Console.ReadLine();
                if (decimal.TryParse(entrada, out decimal num))
                {
                    if (conjunto1.InsertarNumero(num))
                        Console.WriteLine("Número insertado correctamente.");
                    else
                        Console.WriteLine("No se pudo insertar (ya existe o no es válido - debe ser > 0).");
                }
                else
                {
                    Console.WriteLine("Valor inválido. Intente de nuevo.");
                    i--;
                }
            }

            /// <summary>
            /// Se muestran los elementos de los conjuntos
            /// El conjunto 1 tiene los numeros ingresados por el usuario
            /// El conjunto 2 esta vacio
            /// El conjunto 3 tiene 15 numeros aleatorios entre [-10,10] (solo se guardan los positivos y sin duplicados)
            /// </summary>
            Console.WriteLine("\n\tElementos del conjunto 1:");
            ImprimirElementos(conjunto1);        
            Console.WriteLine("\n\tElementos del conjunto 2:");
            ImprimirElementos(conjunto2);
            Console.WriteLine("\n\tElementos del conjunto 3:");
            ImprimirElementos(conjunto3);

            /// <summary>
            /// Se prueban los métodos CantidadElementos, ExisteElemento y ExtraerElemento
            /// </summary>
            Console.WriteLine("\n\t--Pruebas de métodos--");
            Console.WriteLine($"\tConjunto1 tiene {conjunto1.CantidadElementos()} elementos.");
            Console.Write("\tDigite un número a buscar en conjunto1: ");
            if (decimal.TryParse(Console.ReadLine(), out decimal buscado))
            {
                Console.WriteLine(conjunto1.ExisteElemento(buscado)
                    ? "\tEl número existe en el conjunto." // "?" significa un if y ":" un else
                    : "\tEl número NO existe en el conjunto.");
            }
            else
            {
                Console.WriteLine("\tEntrada inválida.");
            }

            Console.Write("\tDigite un número a extraer de conjunto1: ");
            if (decimal.TryParse(Console.ReadLine(), out decimal eliminar))
            {
                var resultado = conjunto1.ExtraerElemento(eliminar);
                if (resultado != null)
                    Console.WriteLine($"\tSe eliminó el número {resultado}.");
                else
                    Console.WriteLine("\tEl número no se encontró.");
            }
            else
            {
                Console.WriteLine("\tEntrada inválida.");
            }

            // Demostracion final del conjunto1 después de la extracción
            Console.WriteLine("\n\tConjunto1 después de extracción:");
            ImprimirElementos(conjunto1);

            Console.WriteLine("\n\tFin de la demostración. Presione una tecla para salir.");
            Console.ReadKey();
        }

        // Genera 15 decimales aleatorios entre [-10,10]
        public static decimal[] ValoresAleatorios()
        {
            Random aleatorio = new Random();
            decimal[] numAleatorios = new decimal[15];

            for (int i = 0; i < 15; i++)
            {
                double numero = Math.Round((aleatorio.NextDouble() * 20) - 10, 2);
                numAleatorios[i] = (decimal)numero;
            }
            return numAleatorios;
        }

        // Método aparte para imprimir elementos de un conjunto (Asi no se repite el código)
        public static void ImprimirElementos(Conjunto conjunto)
        {
            var elementos = conjunto.ObtenerElementos();
            if (elementos == null)
                Console.WriteLine("El conjunto está vacío.");
            else
            {
                foreach (var e in elementos)
                    Console.Write($"{e} ");
                Console.WriteLine();
            }
        }
    }
}
