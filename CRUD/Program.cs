using System;

namespace CRUD
{
    class Program
    {
        static void Main(string[] args)
        {
            // Crear una instancia de la clase Carrera
            Carrera carrera1 = new Carrera
            {
                Nombre = "Ingeniería en Sistemas",
                Sigla = "IS",
                Titulo = "Ingeniero en Sistemas",
                Duracion = 5
            };

            Carrera carrera2 = new Carrera
            {
                Nombre = "Licenciatura en Matemáticas",
                Sigla = "LM",
                Titulo = "Licenciado en Matemáticas",
                Duracion = 4
            };

            // Agregar las carreras
            carrera1.Add();
            carrera2.Add();

            // Buscar una carrera por su sigla
            Carrera foundCarrera = (Carrera)carrera1.FindBySigla("IS");
            if (foundCarrera != null)
            {
                Console.WriteLine($"Carrera encontrada: {foundCarrera.Nombre}");
            }
            else
            {
                Console.WriteLine("Carrera no encontrada.");
            }

            // Modificar una carrera
            foundCarrera.Titulo = "Ingeniero en Sistemas Computacionales";
            foundCarrera.Modify();

            // Verificar si la modificación se realizó
            Carrera updatedCarrera = (Carrera)carrera1.Find();
            if (updatedCarrera != null)
            {
                Console.WriteLine($"Carrera modificada: {updatedCarrera.Titulo}");
            }

            // Eliminar una carrera
            carrera1.Erase();

            // Intentar encontrar la carrera eliminada
            Carrera deletedCarrera = (Carrera)carrera1.Find();
            if (deletedCarrera == null)
            {
                Console.WriteLine("Carrera eliminada exitosamente.");
            }
            else
            {
                Console.WriteLine("Error al eliminar la carrera.");
            }
        }
    }
}
