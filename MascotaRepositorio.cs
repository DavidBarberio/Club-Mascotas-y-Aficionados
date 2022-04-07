using System;
using System.Collections.Generic;
using System.IO;

namespace Club
{
    public class MascotaRepositorio
    {
        private static List<Mascota> listaMascotas = new List<Mascota>();

        public static void AltaMascota()
        {
            String id;
            String nombre;
            Especie especie = Especie.OTRO;
            int edad;

            Console.WriteLine("Introduce el ID:");
            id = Console.ReadLine();

            Console.WriteLine("Introduce el nombre:");
            nombre = Console.ReadLine();

            Console.WriteLine("Introduce la especie:");
            Console.WriteLine("[P] -> Perro, [G] -> Gato, [C] -> Conejo, [H] -> Hamster, [T] -> Tortuga, Por defecto será OTRO:");
            String aux = Console.ReadLine().ToUpper();
            if (aux == "P")
            {
                especie = Especie.PERRO;
            }
            else if (aux == "G")
            {
                especie = Especie.GATO;
            }
            else if (aux == "C")
            {
                especie = Especie.CONEJO;
            }
            else if (aux == "H")
            {
                especie = Especie.HAMSTER;
            }
            else if (aux == "T")
            {
                especie = Especie.TORTUGA;
            }
            else
            {
                especie = Especie.OTRO;
            }

            Console.WriteLine("Introduce la edad:");
            edad = Int32.Parse(Console.ReadLine());

            listaMascotas.Add(new Mascota(id, nombre, especie, edad));
            Console.WriteLine("La mascota ha sido dada de alta");
        }

        public static void MostrarMascotas()
        {
            List<Mascota> lista = listaMascotas.OrderBy(x => x.especie).ThenBy(x => x.edad).ToList();
            foreach (var item in lista)
            {
                item.Imprimir();
            }
        }

        public static void BajaMascota()
        {
            Console.WriteLine("Introduzca el ID de la mascota que desea eliminar:");
            String idEliminar = Console.ReadLine();

            Mascota mascota = BuscarID(idEliminar);
            if (mascota != null)
            {
                listaMascotas.Remove(mascota);
                Console.WriteLine("La mascota ha sido dada de baja");
            }
            else
            {
                Console.WriteLine("No existe ninguna mascota con ese ID ");
            }
        }

        public static void AsociarMascotaSocio()
        {
            Console.WriteLine("Introduzca el DNI del socio que desea asociar a la mascota");
            String dni = Console.ReadLine();
            Socio socio = SocioRepositorio.BuscarID(dni);
            if (socio == null)
            {
                Console.WriteLine("No existe ningun socio");
                return;
            }
            Console.WriteLine("Introduzca el ID de la mascota que va a ser asocidada");
            String id = Console.ReadLine();
            Mascota mascota = BuscarID(id);
            if (mascota == null)
            {
                Console.WriteLine("No existe ninguna mascota");
                return;
            }
            mascota.Asociar(socio);
            Console.WriteLine("Sea ha asociado la mascota " + mascota.nombre + " a " + socio.nombre);

        }

        public static Mascota BuscarID(String id)
        {
            return listaMascotas.Find(x => x.id == id);
        }

        public static void Guardar(Mascota mascota)
        {
            listaMascotas.Add(mascota);
        }

        public static void GuardarCSV(string path)
        {
            using (var writer = new StreamWriter(path))
            {
                writer.WriteLine(Mascota.CabeceraCSV());

                foreach (var item in listaMascotas)
                {
                    writer.WriteLine(item.ImprimirToCSV());
                }
            }
        }
        public static void ToCSV()
        {
            GuardarCSV("mascotas.csv");
        }
    }
}