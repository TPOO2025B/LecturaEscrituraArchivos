using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LecturaEscrituraArchivos.Clases
{
    [Serializable]
    public class Libro
    {
        private int id;
        private string titulo;
        private string autor;

        public Libro(string titulo, string autor)
        {
            this.id = Base.BaseDeDatos.BaseDatosLibros.Count + 1; 
            this.titulo = titulo;
            this.autor = autor;
            Base.BaseDeDatos.BaseDatosLibros.Add(this);
        }

        public void ImprimirLibro()
        {
            Console.WriteLine("****************************************");
            Console.WriteLine($"ID: {id}"); 
            Console.WriteLine($"Título: {titulo}");
            Console.WriteLine($"Autor: {autor}");

        }
        public int getId()
        {
            return id;
        }
    }
}
