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
        public List<Pedido>? ListadoPedidos { get => ListadoPedidos; set => ListadoPedidos = value; }


        public Cadete(int id, string nombre, string direccion, string telefono){
            this.id = id;
            this.nombre = nombre;
            this.direccion = direccion;
            this.telefono = telefono;
            this.ListadoPedidos = new List<Pedido>();
        }


        public void agregarPedido(Pedido pedidoNuevo){
            this.ListadoPedidos?.Add(pedidoNuevo);
            Console.WriteLine("El pedido fue agregado");
        }
        private int jornalACobrar(){
            int cantidadDePedidos = (ListadoPedidos!.Count()) * 500;
            return cantidadDePedidos;
        }
        public void listarInformacion(){
            Console.WriteLine("\nID: "+id);
            Console.WriteLine("\nNombre: "+nombre);
            Console.WriteLine("\nTelefono Cadete: "+telefono);
        }
    }   
}