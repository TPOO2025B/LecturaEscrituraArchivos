using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LecturaEscrituraArchivos.Clases
{
    [Serializable]
    public class Cliente
    {
        private int id;
        private string nombre;
        private string apellido;
        private string email;
        private List<Libro> librosLeidos;

        public Cliente(string nombre, string apellido, string email)
        {
            this.id = Base.BaseDeDatos.BaseDatosClientes.Count + 1;
            this.nombre = nombre;
            this.apellido = apellido;
            this.email = email;
            librosLeidos = new List<Libro>();
            Base.BaseDeDatos.BaseDatosClientes.Add(this);
        }

        public void addLibro(Libro nuevoLibro)
        {
            librosLeidos.Add(nuevoLibro);
        }

        public void ImprimirCliente()
        {
            Console.WriteLine("****************************************");
            Console.WriteLine($"ID: {id}");
            Console.WriteLine($"Nombre: {nombre}");
            Console.WriteLine($"Apellido: {apellido}");
            Console.WriteLine($"Email: {email}");
            if (librosLeidos.Count > 0)
            {
                Console.WriteLine("Libros leídos:");
                foreach (var libro in librosLeidos)
                {
                    libro.ImprimirLibro();
                }
            }
            else
            {
                Console.WriteLine("No se han asignado libros leídos.");
            }
        }

    }
}
