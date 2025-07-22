using LecturaEscrituraArchivos.Base;
using LecturaEscrituraArchivos.Clases;
using System;
using System.Collections.Generic;
using System.ComponentModel.Design;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LecturaEscrituraArchivos
{
    internal class Program
    {
        static void Main(string[] args)
        {
            BaseDeDatos.cargarDatosDesdeArchivo();
            while (true)
            {
                Menu();
            }


        }

        private static void Menu()
        {
            Console.Clear();
            Console.WriteLine("Menu Comisariato");
            Console.WriteLine("1.- Ingresar Artículo");
            Console.WriteLine("2.- Consultar Artículos");
            Console.WriteLine("3.- Consultar Artículo por ID");
            Console.WriteLine("4.- Modificar Artículo");
            Console.WriteLine("5.- Eliminar Artículo");
            Console.WriteLine("6.- Salir");
            Console.Write("Seleccione una opción: ");
            string opcion = Console.ReadLine();
            switch(opcion)
            {
                case "1":
                    IngresarArticulo();
                    BaseDeDatos.guardarDatosEnArchivo(); 
                    break;
                case "2":
                    ConsultarArticulos();
                    break;
                case "3":
                    ConsultarArticuloPorId();
                    break;
                case "4":
                    ModificarArticulo();
                    BaseDeDatos.guardarDatosEnArchivo();
                    break;
                case "5":
                    EliminarArticulo();
                    BaseDeDatos.guardarDatosEnArchivo();
                    break;
                case "6":
                    Environment.Exit(0);
                    break;
                default:
                    Console.WriteLine("Opción no válida. Intente de nuevo.");
                    Console.ReadKey();
                    Menu();
                    break;
            }
        }

        private static void EliminarArticulo()
        {
            Console.Clear();
            Console.WriteLine("ELIMINACIÓN DE ARTÍCULO");
            Console.Write("Ingrese el ID del artículo a elimiar: ");
            int id = Convert.ToInt32(Console.ReadLine());

            Articulo objArticuloConsultado = BaseDeDatos.getArticuloxId(id);
            if (objArticuloConsultado == null)
            {
                Console.WriteLine("Artículo no existe!");
            }
            else
            {
                objArticuloConsultado.ImprimirArticulo();
                Console.WriteLine("¿Está seguro que desea eliminar el artículo? (S/N): ");
                string confirmacion = Console.ReadLine();
                if (confirmacion == "S")
                {
                    BaseDeDatos.BaseDatosArticulos.Remove(objArticuloConsultado);
                    Console.WriteLine("Artículo Eliminado con Éxito!");
                }
            }
            Console.ReadLine();

        }

        private static void ModificarArticulo()
        {
            Console.Clear();
            Console.WriteLine("ACTUALIZACION DE ARTÍCULO");
            Console.Write("Ingrese el ID del artículo a actualizar: ");
            int id = Convert.ToInt32(Console.ReadLine());

            Articulo objArticuloConsultado = BaseDeDatos.getArticuloxId(id);
            if (objArticuloConsultado == null)
            {
                Console.WriteLine("Artículo no existe!");
            }
            else
            {
                objArticuloConsultado.ImprimirArticulo();


                string nombre;
                string descripcion;
                decimal precio;
                decimal costo;
                int stock;
                Console.Write("Nombre del artículo: ");
                nombre = Console.ReadLine();
                objArticuloConsultado.setNombre(nombre);
                Console.Write("Descripción del artículo: ");
                descripcion = Console.ReadLine();
                objArticuloConsultado.setDescripcion(descripcion);
                Console.Write("Precio del artículo: ");
                precio = decimal.Parse(Console.ReadLine());
                objArticuloConsultado.setPrecio(precio);
                Console.Write("Costo del artículo: ");
                costo = System.Convert.ToDecimal(Console.ReadLine());
                objArticuloConsultado.setCosto(costo);
                Console.Write("Stock del artículo: ");
                stock = int.Parse(Console.ReadLine());
                objArticuloConsultado.setStock(stock);
                Console.WriteLine("Producto actualizado con éxito!");
            }
            Console.ReadLine();
        }

        private static void ConsultarArticuloPorId()
        {
            Console.Clear();
            Console.WriteLine("CONSULTA DE ARTÍCULO");
            Console.Write("Ingrese el ID del artículo a buscar: ");
            int id = Convert.ToInt32( Console.ReadLine());

            Articulo objArticuloConsultado = BaseDeDatos.getArticuloxId(id);
            if (objArticuloConsultado == null)
            {
                Console.WriteLine("Artículo no existe!");
            }
            else
            {
                objArticuloConsultado.ImprimirArticulo();
            }
            Console.ReadLine();
        
        }

        private static void ConsultarArticulos()
        {
            Console.Clear();
            Console.WriteLine("LISTA DE ARTÍCULOS");
            BaseDeDatos.ImprimirTodosArticulos();
            Console.ReadLine();
        }

        private static void IngresarArticulo()
        {
            string nombre;
            string descripcion;
            decimal precio;
            decimal costo;
            int stock;

            Console.Clear();
            Console.WriteLine("INGRESO DE ARTÍCULO");
            Console.WriteLine();
            Console.Write("Nombre del artículo: ");
            nombre = Console.ReadLine();
            Console.Write("Descripción del artículo: ");
            descripcion = Console.ReadLine();
            Console.Write("Precio del artículo: ");
            precio = decimal.Parse(Console.ReadLine());
            Console.Write("Costo del artículo: ");
            costo = System.Convert.ToDecimal(Console.ReadLine());
            Console.Write("Stock del artículo: ");
            stock = int.Parse(Console.ReadLine());
            Articulo objArticulo = new Articulo(nombre,descripcion, precio, costo, stock);
            Console.WriteLine("Artículo ingresado correctamente.");
            Console.ReadLine();

        }
    }
}
