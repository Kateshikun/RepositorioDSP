// Conjunto.cs
using System;
using System.Collections.Generic;

namespace Ejercicio2__DSP
{
    internal class Conjunto
    {
        // Único objeto List permitido (privado)
        private List<decimal> conjuntoNumeros = new List<decimal>();

        // Contador privado para evitar usar miembros de List distintos de Add/Remove
        private int cantidadNumeros = 0;

        /// <summary>
        /// Constructor vacío.
        /// </summary>
        public Conjunto()
        {
            conjuntoNumeros = new List<decimal>();
            cantidadNumeros = 0;
        }

        /// <summary>
        /// Constructor que recibe un vector de decimales. Inserta solo valores positivos y sin duplicados.
        /// </summary>
        public Conjunto(decimal[] numeros)
        {
            conjuntoNumeros = new List<decimal>();
            cantidadNumeros = 0;
            if (numeros == null) return;

            foreach (var n in numeros)
            {
                // Reutiliza la lógica de inserción para asegurar unicidad y positividad
                InsertarNumero(n);
            }
        }

        /// <summary>
        /// Retorna la cantidad de elementos almacenados.
        /// </summary>
        public int CantidadElementos()
        {
            return cantidadNumeros;
        }

        /// <summary>
        /// Comprueba si un elemento existe en el conjunto.
        /// </summary>
        public bool ExisteElemento(decimal valor)
        {
            foreach (decimal e in conjuntoNumeros)
            {
                if (e == valor)
                    return true;
            }
            return false;
        }

        /// <summary>
        /// Inserta un número decimal positivo en el conjunto. Devuelve true si se agregó.
        /// (Se considera positivo: valor > 0)
        /// </summary>
        public bool InsertarNumero(decimal valor)
        {
            if (valor <= 0) // aceptar solo positivos (según enunciado)
                return false;

            // comprobar existencia recorriendo la lista (sin usar Contains/Count/Index)
            foreach (decimal e in conjuntoNumeros)
            {
                if (e == valor)
                    return false; // ya existe
            }

            // usar únicamente Add para almacenar
            conjuntoNumeros.Add(valor);
            cantidadNumeros++;
            return true;
        }

        /// <summary>
        /// Extrae (elimina) un elemento solicitado. Retorna el valor si se eliminó, o null si no se encontró.
        /// </summary>
        public decimal? ExtraerElemento(decimal valor)
        {
            // buscar si existe
            bool encontrado = false;
            foreach (decimal e in conjuntoNumeros)
            {
                if (e == valor)
                {
                    encontrado = true;
                    break;
                }
            }

            if (encontrado)
            {
                // usar Remove para eliminar (permitido)
                conjuntoNumeros.Remove(valor);
                cantidadNumeros--;
                return valor;
            }

            return null;
        }

        /// <summary>
        /// Retorna un vector copia con todos los elementos, o null si está vacío.
        /// </summary>
        public decimal[] ObtenerElementos()
        {
            if (cantidadNumeros == 0)
                return null;

            decimal[] copia = new decimal[cantidadNumeros];
            int idx = 0;
            foreach (decimal e in conjuntoNumeros)
            {
                copia[idx++] = e;
            }
            return copia;
        }
    }
}
