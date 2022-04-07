using System;
using System.Collections.Generic;

namespace Club
{
    public class SocioControlador
    {

        public static void AltaSocio()
        {
            string dni;
            string nombre;
            int edad;
            Sexo sexo = Sexo.OTRO;

            Console.WriteLine("Introduce el DNI:");
            dni = Console.ReadLine();

            Console.WriteLine("Introduce el nombre:");
            nombre = Console.ReadLine();

            Console.WriteLine("Introduce la edad:");
            edad = Int32.Parse(Console.ReadLine());

            Console.WriteLine("Introduce el sexo [H/M]:");
            String aux = Console.ReadLine().ToUpper();
            if (aux == "H")
            {
                sexo = Sexo.HOMBRE;
            }
            else if (aux == "M")
            {
                sexo = Sexo.MUJER;
            }
            SocioRepositorio.Guardar(new Socio(dni, nombre, edad, sexo));
            Console.WriteLine("El socio ha sido dado de alta");
        }

        public static void MostrarSocios()
        {
            foreach (var item in SocioRepositorio.ListaSocios())
            {
                item.Imprimir();
            }
        }

        public static void BajaSocio()
        {
            Console.WriteLine("Introduzca el DNI del socio que desea eliminar:");
            String dniEliminar = Console.ReadLine();

            Socio socio = SocioRepositorio.BuscarID(dniEliminar);
            if (socio != null)
            {
                SocioRepositorio.Borrar(socio);
                Console.WriteLine("El socio ha sido dado de baja");
            }
            else
            {
                Console.WriteLine("No existe ningún socio con ese DNI");
            }
        }
        public static void GuardarCSV(string path)
        {
            using (var writer = new StreamWriter(path))
            {
                writer.WriteLine(Socio.CabeceraCSV());

                foreach (var item in SocioRepositorio.ListaSocios())
                {
                    writer.WriteLine(item.ImprimirToCSV());
                }
            }
        }
        public static void ToCSV()
        {
            GuardarCSV("socios.csv");
        }
    }
}