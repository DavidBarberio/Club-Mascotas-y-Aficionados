using System;
using System.Collections.Generic;

namespace Club
{
    public enum Sexo
    {
        HOMBRE, MUJER, OTRO
    }
    public class Socio
    {
        public string dni;
        public string nombre;
        public int edad;
        public Sexo sexo;

        public Socio(string dni, string nombre, int edad, Sexo sexo)
        {
            this.dni = dni;
            this.nombre = nombre;
            this.edad = edad;
            this.sexo = sexo;
        }

        public void Imprimir()
        {
            Console.WriteLine(dni + " - " + nombre + " - " + edad + " año(s)" + " - " + sexo);
        }

        public String ImprimirToCSV()
        {
            return dni + "," + nombre + "," + edad + "," + sexo;
        }


        public static String CabeceraCSV()
        {
            return "dni,nombre,edad,sexo";
        }
    }
}