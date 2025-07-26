using LecturaEscrituraArchivos.Clases;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Runtime.Serialization.Formatters.Binary;
using System.Text;
using System.Threading.Tasks;

namespace LecturaEscrituraArchivos.Base
{
    public static class BaseDeDatos
    {
        public static List<Articulo> BaseDatosArticulos = new List<Articulo>();
        private static string nombreBaseDatosArticulo = "Articulos.dat";


        public static List<Cliente> BaseDatosClientes = new List<Cliente>();
        private static string nombreBaseDatosCliente = "Clientes.dat";


        public static List<Libro> BaseDatosLibros = new List<Libro>();
        private static string nombreBaseDatosLibro = "Libro.dat";


        public static void guardarDatosEnArchivoArticulo()
        {
            BinaryFormatter bf = new BinaryFormatter();
            FileStream archivoNuevo = new FileStream(nombreBaseDatosArticulo, FileMode.Create);
            bf.Serialize(archivoNuevo, BaseDatosArticulos);
            archivoNuevo.Close();
        }

        public static void cargarDatosDesdeArchivoArticulo()
        {
            if (File.Exists(nombreBaseDatosArticulo))
            {
                BinaryFormatter bf = new BinaryFormatter();
                FileStream archivoExistente = new FileStream(nombreBaseDatosArticulo, FileMode.Open);
                BaseDatosArticulos = (List<Articulo>)bf.Deserialize(archivoExistente);
                archivoExistente.Close();
            }
        }

        public static void guardarDatosEnArchivoCliente()
        {
            BinaryFormatter bf = new BinaryFormatter();
            FileStream archivoNuevo = new FileStream(nombreBaseDatosCliente, FileMode.Create);
            bf.Serialize(archivoNuevo, BaseDatosClientes);
            archivoNuevo.Close();
        }

        public static void cargarDatosDesdeArchivoCliente()
        {
            if (File.Exists(nombreBaseDatosCliente))
            {
                BinaryFormatter bf = new BinaryFormatter();
                FileStream archivoExistente = new FileStream(nombreBaseDatosCliente, FileMode.Open);
                BaseDatosClientes = (List<Cliente>)bf.Deserialize(archivoExistente);
                archivoExistente.Close();
            }
        }


        public static void guardarDatosEnArchivoLibro()
        {
            BinaryFormatter bf = new BinaryFormatter();
            FileStream archivoNuevo = new FileStream(nombreBaseDatosLibro, FileMode.Create);
            bf.Serialize(archivoNuevo, BaseDatosLibros);
            archivoNuevo.Close();
        }

        public static void cargarDatosDesdeArchivoLibro()
        {
            if (File.Exists(nombreBaseDatosLibro))
            {
                BinaryFormatter bf = new BinaryFormatter();
                FileStream archivoExistente = new FileStream(nombreBaseDatosLibro, FileMode.Open);
                BaseDatosLibros = (List<Libro>)bf.Deserialize(archivoExistente);
                archivoExistente.Close();
            }
        }



        public static Articulo getArticuloxId(int id)
        {

            foreach (var articulo in BaseDatosArticulos)
            {
                if (articulo.getId() == id)
                {
                    return articulo;
                }
            }
            return null;
        }


        public static void ImprimirTodosArticulos()
        {
            foreach (var articulo in BaseDatosArticulos)
            {
                articulo.ImprimirArticulo();
            }
        }


        public static void ImprimirTodosLibros()
        {
            foreach (var libro in BaseDatosLibros)
            {
                libro.ImprimirLibro();
            }
        }

        public static Libro GetLibroXId(int id)
        {
            foreach (var libro in BaseDatosLibros)
            {
                if (libro.getId() == id)
                {
                    return libro;
                }
            }
            return null;
        }

        public static void ImprimirTodosClientes()
        {
            foreach (var cliente in BaseDatosClientes)
            {
                cliente.ImprimirCliente();
            }
        }

    }
}