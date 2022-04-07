using System;
using System.Collections.Generic;

namespace Club
{
    public class SocioRepositorio
    {
        private static List<Socio> listaSocios = new List<Socio>();

        public static Socio BuscarID(String id)
        {
            return listaSocios.Find(x => x.dni == id);

        }
        
        public static void Guardar(Socio socio)
        {
            listaSocios.Add(socio);
        }

         public static void Borrar(Socio socio)
        {
            listaSocios.Remove(socio);
        }

        public static List<Socio> ListaSocios(){
            return listaSocios;
        }
    }
}