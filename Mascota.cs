using System;
using System.Collections.Generic;

namespace Club
{

    public enum Especie
    {
        PERRO, GATO, CONEJO, HAMSTER, TORTUGA, OTRO
    }
    public class Mascota
    {
        public String id;
        public string nombre;
        public Especie especie;
        public int edad;
        public Socio propietario;

        public Mascota(String id, string nombre, Especie especie, int edad)
        {
            this.id = id;
            this.nombre = nombre;
            this.especie = especie;
            this.edad = edad;
        }

        public void Imprimir()
        {
            String texto = id + " - " + nombre + " - " + especie + " - " + edad + " año(s)";
            if (propietario != null)
            {
                texto += " - (" + propietario.nombre + ")";
            }
            Console.WriteLine(texto);
        }

        public String ImprimirToCSV()
        {
            String texto = id + "," + nombre + "," + especie + "," + edad + ",";
            if (propietario != null)
            {
                texto += propietario.nombre;
            }
            return texto;
        }

        public static String CabeceraCSV()
        {
            return "id,nombre,especie,edad,propietario";
        }

        public void Asociar(Socio socio)
        {
            propietario = socio;
        }
    }
}