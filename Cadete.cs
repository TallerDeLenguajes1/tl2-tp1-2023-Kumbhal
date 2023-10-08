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
        public List<Pedido>? ListadoPedidos { get => listadoPedidos;}


        public Cadete(int id, string nombre, string direccion, string telefono){
            this.id = id;
            this.nombre = nombre;
            this.direccion = direccion;
            this.telefono = telefono;
            this.listadoPedidos = new List<Pedido>();
        }
        public int GetIdCadete(){
            return id;
        }
        public void AgregarPedido(Pedido pedidoNuevo){
            this.listadoPedidos.Add(pedidoNuevo);
            Console.WriteLine("El pedido fue agregado");
        }
        public int CantidadPedidosCadete(){
            return listadoPedidos.Count();
        }
        public int CantidadPedidosEntregados(){
            List<Pedido> pedidosEntregados = listadoPedidos!.FindAll(pedido => pedido.getEstado() == Pedido.Estados.Entregado);
            return pedidosEntregados.Count();
        }
        public void MostrarListaPedidos(){
            foreach (var pedido in listadoPedidos){
                Console.WriteLine("ID Pedido: "+pedido.Numero);
                pedido.verDatosCliente();
            }
        }
        public int JornalACobrar(){
            int jornal = CantidadPedidosEntregados() * 500;
            return jornal;
        }
        public void ListarInformacion(){
            Console.WriteLine("\nID: "+id);
            Console.WriteLine("\nNombre: "+nombre);
        }
        public void CambiarEstado(int idPedido){
            Pedido pedidoACambiar = listadoPedidos.Find(pedido => pedido.Numero == idPedido);
            if (pedidoACambiar != null){
                pedidoACambiar.CambiarEstado();
            }else{
                Console.WriteLine("\nNo se encontró el id del pedido.");
            }
        }
    }   
}