using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

//Usings
using System.Data.Entity;
using System.ComponentModel.DataAnnotations;

namespace codeFirstttt
{
    public class ModeloContext : DbContext
    {

        //Constructor de la BD en SQL
        //Tablas
        public virtual List<Producto> Productos { get; set; }
        public virtual List<Cliente> Clientes { get; set; }
        public virtual List<Pedido> Pedidos { get; set; }
        public virtual List<LineaPedido> LineaPedidos { get; set; }

        //@"Data Source=localhost\sqlexpress;Initial Catalog=codeFirstMiercoles;Integrated Security=True"
        public ModeloContext() : base(){}

    }

    //Clase Producto
    public class Producto
    {
        [Key]
        public int ProductoId { get; set; }
        public string Descripcion { get; set; }
        public int Precio { get; set; }
    }

    //Clase Pedido
    public class Pedido
    {
        [Key]
        public int PedidoId { get; set; }
        public int ClienteId { get; set; }
    }

    //Clase Cliente
    public class Cliente
    {
        [Key]
        public int ClienteId { get; set; }
        public string Nombre { get; set; }
    }

    //Clase LineaPedido
    public class LineaPedido
    {
        [Key]
        public int LineaPedidoId { get; set; }

        public int PedidoId { get; set; }
        public int ProductoId { get; set; }
        public int Unidades { get; set; }
    }
}
