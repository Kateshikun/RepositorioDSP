using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Text;
using System.Threading.Tasks;

namespace Ejercicio2__DSP
{
    internal class Conjunto
    {
        //Creacion de la lista donde se almacenaran numeros decimales positivos
        //Ya esta declarada como privada, por lo tanto solo se podra acceder a esta desde una instancia de la clase
        private List<decimal> conjuntoNumeros = new List<decimal>();
        private int cantidadNumeros = 0;


        //Metodo constructor vacio que inicializa la lista con tamaño predeterminado si no se dan parametros
        public Conjunto()
        {
            conjuntoNumeros = new List<decimal>();
        }

        //Sobrecarga de metodo constructor que recibe un vector de numeros decimales y los agrega a la lista
        public Conjunto(decimal[] numeros)
        {
            for (int i = 0; i < numeros.Length; i++)
            {
                this.conjuntoNumeros.Add(numeros[i]);
                cantidadNumeros++;
            }
        }

        //Metodo que retorna la cantidad de numeros en la lista
        public string RetornarCantidad()
        {
            return "La cantidad de numeros en el conjunto es: " + cantidadNumeros;
        } 

        /*public  List<decimal> getConjuntoNumeros() //No se si hay que poner este metodo aun hmmmmmmm
        {
            return this.conjuntoNumeros;
        }*/


        //Metodo que comprueba que un numero decimal positivo este en la lista. Retorna true si esta y false si no.
        public bool ComprobarExistencia(decimal numero)
        {
            for (int i = 0; i < cantidadNumeros; i++)
            {
                if (this.conjuntoNumeros[i] == numero)
                {
                    return true;
                }
            }
            return false;
        }


        //Metodo que inserta un numero decimal positivo en la lista. Retorna true si se pudo insertar y false si no.
        public bool InsertarNumero(decimal numero)
        {
            if (numero < 0)
            {
                return false;
            }

            else for (int i = 0; i < cantidadNumeros; i ++) {
                if (this.conjuntoNumeros[i] == numero) {
                return false;
                }
            } 

            this.conjuntoNumeros.Add(numero);
            cantidadNumeros++;
            return true;
        }
    }
}
