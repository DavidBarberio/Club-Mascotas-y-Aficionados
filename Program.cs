using System;
using System.Collections.Generic;

namespace Club
{
    public class Program
    {
        public static void Main(string[] args)
        {
            String input;
            IniciarDatos();
            do
            {
                input = MostrarMenu();

                switch (input)
                {
                    case "1":
                        SocioControlador.AltaSocio();
                        break;

                    case "2":
                        SocioControlador.BajaSocio();
                        break;

                    case "3":
                        SocioControlador.MostrarSocios();
                        break;

                    case "4":
                        MascotaRepositorio.AltaMascota();
                        break;

                    case "5":
                        MascotaRepositorio.BajaMascota();
                        break;

                    case "6":
                        MascotaRepositorio.MostrarMascotas();
                        break;

                    case "7":
                        MascotaRepositorio.AsociarMascotaSocio();
                        break;

                    case "8":
                        SocioControlador.ToCSV();
                        MascotaRepositorio.ToCSV();
                        break;

                    case "9":
                        Console.WriteLine("Has salido del programa");
                        break;
                }
            } while (input != "9");
        }

        public static String MostrarMenu()
        {
            Console.WriteLine("\n-----------------------------------");
            Console.WriteLine("               MENU                ");
            Console.WriteLine("-----------------------------------");
            Console.WriteLine("1.- Alta socio");
            Console.WriteLine("2.- Baja socio");
            Console.WriteLine("3.- Mostrar socios");
            Console.WriteLine("4.- Alta mascota");
            Console.WriteLine("5.- Baja mascota");
            Console.WriteLine("6.- Mostrar mascotas");
            Console.WriteLine("7.- Asociar/Comprar mascota");
            Console.WriteLine("8.- CSV");
            Console.WriteLine("9.- Salir");
            Console.WriteLine("-----------------------------------");
            Console.WriteLine("Introduce la opcion a realizar");
            return Console.ReadLine();
        }

        public static void IniciarDatos()
        {
            Socio socio1 = new Socio("123", "Juan", 27, Sexo.HOMBRE);
            Socio socio2 = new Socio("456", "María", 24, Sexo.MUJER);
            Mascota mascota1 = new Mascota("123", "Lluvia", Especie.PERRO, 2);
            Mascota mascota2 = new Mascota("789", "Luna", Especie.GATO, 6);
            Mascota mascota3 = new Mascota("741", "Sol", Especie.PERRO, 1);
            Mascota mascota4 = new Mascota("852", "Trueno", Especie.PERRO, 3);

            SocioRepositorio.Guardar(socio1);
            SocioRepositorio.Guardar(socio2);
            MascotaRepositorio.Guardar(mascota1);
            mascota2.Asociar(socio2);
            MascotaRepositorio.Guardar(mascota2);
            MascotaRepositorio.Guardar(mascota3);
            MascotaRepositorio.Guardar(mascota4);
        }
    }
}