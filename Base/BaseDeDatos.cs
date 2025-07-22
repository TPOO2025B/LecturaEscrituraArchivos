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


        public static void guardarDatosEnArchivo()
        {
            BinaryFormatter bf = new BinaryFormatter();
            FileStream archivoNuevo = new FileStream(nombreBaseDatosArticulo, FileMode.Create);
            bf.Serialize(archivoNuevo, BaseDatosArticulos);
        }

        public static void cargarDatosDesdeArchivo()
        {
            if (File.Exists(nombreBaseDatosArticulo))
            {
                BinaryFormatter bf = new BinaryFormatter();
                FileStream archivoExistente = new FileStream(nombreBaseDatosArticulo, FileMode.Open);
                BaseDatosArticulos = (List<Articulo>)bf.Deserialize(archivoExistente);
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

    }
}