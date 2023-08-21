using Pedidos;

namespace Cadetes
{
public class Cadete 
    {
        private int id;
        private string? nombre;
        private string? direccion;
        private string? telefono;

        private List<Pedido>? listadoPedidos;


        public Cadete(int id, string nombre, string direccion, string telefono){
            this.id = id;
            this.nombre = nombre;
            this.direccion = direccion;
            this.telefono = telefono;
            this.listadoPedidos = new List<Pedido>(); 

        }
    
        public void agregarPedido(Pedido pedidoNuevo){
            this.listadoPedidos?.Add(pedidoNuevo);
            Console.WriteLine("El pedido fue agregado");
        }
        public int jornalACobrar(){
            int cantidadDePedidos = (this.listadoPedidos!.Count() * 500);
            return cantidadDePedidos;
        }
    }   

    
}