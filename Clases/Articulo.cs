using LecturaEscrituraArchivos.Base;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LecturaEscrituraArchivos.Clases
{
    [Serializable]
    public class Articulo
    {
        private int id;
        private string nombre;
        private string descripcion;
        private decimal precio;
        private decimal costo;
        private decimal ganancia;
        private int stock;

        public Articulo( string nombre, string descripcion, decimal precio, decimal costo, int stock)
        {
            this.id = BaseDeDatos.BaseDatosArticulos.Count + 1;
            this.nombre = nombre;
            this.descripcion = descripcion;
            this.precio = precio;
            this.costo = costo;
            this.ganancia = precio - costo;
            this.stock = stock;
            BaseDeDatos.BaseDatosArticulos.Add(this);
        }

        public int getId()
        {
            return id;
        }
        public string getNombre()
        {
            return nombre;
        }
        public string getDescripcion()
        {
            return descripcion;
        }
        public decimal getPrecio()
        {
            return precio;
        }
        public decimal getCosto()
        {
            return costo;
        }
        public decimal getGanancia()
        {
            return ganancia;
        }
        public int getStock()
        {
            return stock;
        }

        public void setNombre(string nombre)
        {
            this.nombre = nombre;
        }
        public void setDescripcion(string descripcion)
        {
            this.descripcion = descripcion;
        }
        public void setPrecio(decimal precio)
        {
            this.precio = precio;
            this.ganancia = precio - costo; // Actualizar ganancia al cambiar el precio
        }
        public void setCosto(decimal costo)
        {
            this.costo = costo;
            this.ganancia = precio - costo; // Actualizar ganancia al cambiar el costo
        }
        public void setStock(int stock)
        {
            this.stock = stock;
        }

        public void ImprimirArticulo()
        {
            Console.WriteLine("****************************************");
            Console.WriteLine("Id: " + this.id.ToString());
            Console.WriteLine("Nombre: "+ this.nombre);
            Console.WriteLine("Descripción: " + this.descripcion);
            Console.WriteLine("Precio: $" + this.precio.ToString("F2"));
            Console.WriteLine("Costo: $" + this.costo.ToString("F2"));
            Console.WriteLine("Ganancia: $" + this.ganancia.ToString("F2"));
            Console.WriteLine("Stock: " + this.stock.ToString());
        }


    }
}
