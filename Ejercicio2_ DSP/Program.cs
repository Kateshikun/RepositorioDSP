using System; 
using System.Collections.Generic; 
using System.Linq; 
using System.Text; 
using System.Threading.Tasks;

namespace Ejercicio2__DSP
{
    //--------- Integrantes  ---------//
    //Anderson Ruben Portillo Alfaro PA250120
    //Daniel Adrian Castillo Garcia CG250400
    //Francisco Josue Santos Lopez SL251022
    //Nahum de Jesus Flores Giron FG250084
    //Rudy Mauricio Gonsalez Pineda GP250120
    
    internal class Conjunto
    {
        // Lista privada para almacenar los elementos
        private List<decimal> elementos;

        // Constructor
        public Conjunto()
        {
            elementos = new List<decimal>();
        }

        // Constructor que recibe un vector de decimales
        public Conjunto(decimal[] valores)
        {
            elementos = new List<decimal>();
            foreach (var v in valores)
            {
                InsertarNumero(v); 
            }
        }

        // Retornar la cantidad de elementos
        public int CantidadElementos()
        {
            return elementos.Count;
        }

        //Comprobar si existe un elemento
        public bool ExisteElemento(decimal valor)
        {
            foreach (decimal e in elementos)
            {
                if (e == valor)
                    return true;
            }
            return false;
        }

        //Insertar un elemento al conjunto
        public bool InsertarNumero(decimal valor)
        {
            if (valor >= 0 && !ExisteElemento(valor))
            {
                elementos.Add(valor);
                return true;
            }
            return false;
        }

        //Extraer un elemento del conjunto
        public decimal? ExtraerElemento(decimal valor)
        {
            if (ExisteElemento(valor))
            {
                elementos.Remove(valor);
                return valor;
            }
            return null;
        }

        //Retornar un vector con todos los elementos
        public decimal[] ObtenerElementos()
        {
            if (elementos.Count == 0)
                return null;

            return elementos.ToArray(); // Retorna copia
        }
    }

    internal class Program
    {
        static void Main(string[] args)
        {
            // Crear instancias
            Conjunto conjunto1 = new Conjunto();
            Conjunto conjunto2 = new Conjunto();
            Conjunto conjunto3 = new Conjunto(ValoresAleatorios());

            // Pedir datos al usuario
            Console.WriteLine("Bienvenido al programa de Conjunto de Elementos");
            Console.WriteLine("\n--Ingrese 5 decimales positivos para el conjunto 1--");

            for (int i = 0; i < 5; i++)
            {
                Console.Write($"num {i + 1}: ");
                if (decimal.TryParse(Console.ReadLine(), out decimal num))
                {
                    if (conjunto1.InsertarNumero(num))
                        Console.WriteLine("Número insertado correctamente.");
                    else
                        Console.WriteLine("No se pudo insertar (ya existe o no es válido).");
                }
                else
                {
                    Console.WriteLine("Valor inválido. Intente de nuevo.");
                    i--; // repetir intento
                }
            }

            // Mostrar conjunto 1
            Console.WriteLine("\nElementos del conjunto 1:");
            ImprimirElementos(conjunto1);

            // Mostrar conjunto 2 (vacío)
            Console.WriteLine("\nElementos del conjunto 2:");
            ImprimirElementos(conjunto2);

            // Mostrar conjunto 3 (aleatorios)
            Console.WriteLine("\nElementos del conjunto 3:");
            ImprimirElementos(conjunto3);

            // --- Demostración de métodos ---
            Console.WriteLine("\nPruebas de métodos:");

            // Cantidad de elementos
            Console.WriteLine($"Conjunto1 tiene {conjunto1.CantidadElementos()} elementos.");

            // Comprobar existencia
            Console.Write("Digite un número a buscar en conjunto1: ");
            decimal buscado = decimal.Parse(Console.ReadLine());
            Console.WriteLine(conjunto1.ExisteElemento(buscado)
                ? "El número existe en el conjunto."
                : "El número NO existe en el conjunto.");

            // Extraer elemento
            Console.Write("Digite un número a extraer de conjunto1: ");
            decimal eliminar = decimal.Parse(Console.ReadLine());
            var resultado = conjunto1.ExtraerElemento(eliminar);
            if (resultado != null)
                Console.WriteLine($"Se eliminó el número {resultado}.");
            else
                Console.WriteLine("El número no se encontró.");

            // Mostrar de nuevo conjunto1
            Console.WriteLine("\nConjunto1 después de extracción:");
            ImprimirElementos(conjunto1);

            Console.WriteLine("\nFin de la demostración. Presione una tecla para salir.");
            Console.ReadKey();
        }

        // Generar 15 decimales aleatorios entre [-10,10]
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

        // Método auxiliar para imprimir elementos de un conjunto
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
