using Cadetes;
using Pedidos;

namespace Cadeterias
{
public class Cadeteria
    {
        private string? nombre;
        private string? telefono;
        private List<Cadete>? listadoCadetes;

        public Cadeteria(string nombre, string telefono){
            this.nombre = nombre;   
            this.telefono = telefono;  
            listadoCadetes = new List<Cadete>();
        }

        public int CantidadCadetes(){
            return listadoCadetes.Count();
        }
        private bool ListadoCadetesVacio(){
            return (CantidadCadetes() == 0);
        }
        public List<Cadete> GetListadoCadetes(){
            return ListadoCadetesVacio() ? new List<Cadete> () : listadoCadetes;
        }
        public void PedidosCadete(int idCadete){
            Cadete cadeteBuscado = listadoCadetes.Find(cadete => cadete.GetIdCadete() == idCadete);
            cadeteBuscado.MostrarListaPedidos();
        }
        public void CargarListadoCadetes(List<Cadete> listadoCadetesCSV){
            this.listadoCadetes = listadoCadetesCSV;
        }
        public Pedido CrearPedido(int numPedido, string? obsPedido, string? nombreCliente, string? direccionCliente, string? telefonoCliente, string?datosRef){
            Pedido nuevoPedido = new Pedido(numPedido, obsPedido, nombreCliente, direccionCliente, telefonoCliente, datosRef);
            return nuevoPedido;
        }
        public void AsignarPedido(List<Pedido> listadoPedidosSinAsig, int numPedido, int idCadete){
            if(!ListadoCadetesVacio()){
                Cadete cadeteBuscado = listadoCadetes.Find(cadete => cadete.GetIdCadete() == idCadete);
                if(cadeteBuscado != null){
                    if (listadoPedidosSinAsig != null){
                        Pedido pedidoBuscado = listadoPedidosSinAsig.Find(pedido => pedido.Numero == numPedido);
                        cadeteBuscado.AgregarPedido(pedidoBuscado);
                        listadoPedidosSinAsig.Remove(pedidoBuscado);
                    }else{
                        Console.WriteLine("No hay pedidos para asignar.");
                    }
                }else{
                    Console.WriteLine("No se encontro un cadete con el id. ");
                }
            }else{
                Console.WriteLine("No hay cadetes registrados para asignar pedido. ");
            }
        }
        public void CambiarEstadoPedido(int idCadete, int idPedido){
            Cadete cadeteNuevo = listadoCadetes.Find(cadete => cadete.GetIdCadete() == idCadete);
            if(cadeteNuevo != null){
                cadeteNuevo.CambiarEstado(idPedido);
            }else{
                Console.WriteLine("No se encontro un cadete con ese ID");
            }
        }
        public void AgregarCadete(Cadete nuevoCadete){
            listadoCadetes?.Add(nuevoCadete);
            Console.WriteLine("Se agrego nuevo cadete");
            return; 
        }
        public void listarCadetes(){
            foreach (var cadete in listadoCadetes){
                cadete.ListarInformacion();
            }
        }
        public void ReasignarPedido(int idPedidBusc,int cadeteAsignado,int cadeteACambiar){
            Cadete cadeteTemp = listadoCadetes.Find(cadete => cadete.GetIdCadete() == cadeteACambiar);
            Pedido pedidoBuscado;
            if(cadeteTemp != null){
                pedidoBuscado = cadeteTemp.ListadoPedidos.Find(pedido => pedido.Numero == idPedidBusc);
                cadeteTemp.ListadoPedidos.Remove(pedidoBuscado);
                if (pedidoBuscado != null){
                    cadeteTemp = listadoCadetes.Find(cadete => cadete.GetIdCadete() == cadeteAsignado);
                    if (cadeteTemp != null){
                        cadeteTemp.AgregarPedido(pedidoBuscado);
                    }else{
                        Console.WriteLine("Se produjo un error. ");
                    }        
                }else{
                    Console.WriteLine("Se produjo un error. ");
                }
            }else{
                Console.WriteLine("Se produjo un error. ");
            }
        }
        public void MostrarInforme(){
            int montoTotalJornada = 0;
            foreach (var cadete in listadoCadetes){
                cadete.ListarInformacion();
                Console.WriteLine("Jornal : "+cadete.JornalACobrar());
                Console.WriteLine("Total de pedidos enviados: " +cadete.CantidadPedidosEntregados());
                Console.WriteLine("Promedio de pedidos entregados: " + cadete.CantidadPedidosCadete() / cadete.CantidadPedidosEntregados());
                montoTotalJornada = cadete.JornalACobrar() + montoTotalJornada;
            }
            Console.WriteLine("Monto ganado: "+montoTotalJornada);
        }
        public void ListarInformacionCadeteria(){
            Console.WriteLine("\n=========="+this.nombre+"==========");
            Console.WriteLine("\nTelefono:"+this.telefono);
        }
        public void ListarPedidosPendientes(List<Pedido> listaPedidosPendientes){
            foreach (var pedido in listaPedidosPendientes){
                Console.WriteLine("\nID pedido:" + pedido.Numero);
                pedido.verDatosCliente();
            }
        }
    }      
}

    