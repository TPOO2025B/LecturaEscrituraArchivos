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
            BaseDeDatos.cargarDatosDesdeArchivoArticulo();
            BaseDeDatos.cargarDatosDesdeArchivoCliente();
            BaseDeDatos.cargarDatosDesdeArchivoLibro();


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
            Console.WriteLine("6.- Ingresar Libro");
            Console.WriteLine("7.- Ingresar Cliente");
            Console.WriteLine("8.- Consultar Clientes");
            Console.WriteLine("9.- Salir");
            Console.Write("Seleccione una opción: ");
            string opcion = Console.ReadLine();
            switch(opcion)
            {
                case "1":
                    IngresarArticulo();
                    BaseDeDatos.guardarDatosEnArchivoArticulo(); 
                    break;
                case "2":
                    ConsultarArticulos();
                    break;
                case "3":
                    ConsultarArticuloPorId();
                    break;
                case "4":
                    ModificarArticulo();
                    BaseDeDatos.guardarDatosEnArchivoArticulo();
                    break;
                case "5":
                    EliminarArticulo();
                    BaseDeDatos.guardarDatosEnArchivoArticulo();
                    break;
                case "6":
                    IngresarLibro();
                    BaseDeDatos.guardarDatosEnArchivoLibro();
                    break;
                case "7":
                    IngresarCliente();
                    BaseDeDatos.guardarDatosEnArchivoCliente();
                    break;
                case "8":
                    ConsultarClientes();
                    break;
                case "9":
                    Environment.Exit(0);
                    break;
                default:
                    Console.WriteLine("Opción no válida. Intente de nuevo.");
                    Console.ReadKey();
                    Menu();
                    break;
            }
        }

        private static void ConsultarClientes()
        {
            BaseDeDatos.ImprimirTodosClientes();
            Console.ReadLine();
        }

        private static void IngresarCliente()
        {
            string nombre;
            string apellido;
            string mail;

            Console.Clear();
            Console.WriteLine("INGRESO DE CLIENTES");
            Console.WriteLine();
            Console.Write("Nombre del Cliente: ");
            nombre = Console.ReadLine();
            Console.Write("Apellido del Cliente: ");
            apellido = Console.ReadLine();
            Console.Write("Mail del Cliente: ");
            mail = Console.ReadLine();

            Cliente objCliente= new Cliente(nombre, apellido, mail);
            Console.WriteLine("Cliente ingresado correctamente.");

            Console.WriteLine("");
            Console.WriteLine("¿Desea Asignar al cliente un Libro leído? (S/N)");
            string respuesta = Console.ReadLine().ToUpper();
            if (respuesta == "S")
            {
                BaseDeDatos.ImprimirTodosLibros();
                Console.Write("Ingrese el ID del libro que desea asignar: ");
                int idLibro = Convert.ToInt32(Console.ReadLine());
                Libro objLibroConsultado = BaseDeDatos.GetLibroXId(idLibro);
                if (objLibroConsultado != null)
                {
                    objCliente.addLibro(objLibroConsultado);
                    Console.WriteLine("Libro asignado al cliente correctamente.");
                }
                else
                {
                    Console.WriteLine("El libro con el ID ingresado no existe.");
                }


            }
            else
            {
                Console.WriteLine("No se ingresó ningún libro.");
            }

            Console.ReadLine();
        }

        private static void IngresarLibro()
        {
            string titulo;
            string autor;

            Console.Clear();
            Console.WriteLine("INGRESO DE LIBROS");
            Console.WriteLine();
            Console.Write("Nombre del libro: ");
            titulo = Console.ReadLine();
            Console.Write("Descripción del libro: ");
            autor = Console.ReadLine();
          
            Libro objLibro = new Libro(titulo, autor);
            Console.WriteLine("Libro ingresado correctamente.");
            Console.ReadLine();
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
