using Cadetes;
using Pedidos;

namespace Cadeterias
{
public class Cadeteria
    {
        private string? nombre;
        private string? telefono;
        private List<Cadete>? listadoCadetes;
        private List<Pedido> listadoPedidos;

        public Cadeteria(string nombre, string telefono){
            this.nombre = nombre;   
            this.telefono = telefono;  
            listadoCadetes = new List<Cadete>();
            listadoPedidos = new List<Pedido>();
        }

        public int CantidadCadetes(){
            return listadoCadetes.Count();
        }
        private bool ListadoCadetesVacio(){
            return (CantidadCadetes() == 0);
        }
        public void MostrarPedidosCadete(int idCadete){
            List<Pedido> listadoPedidosCadete = listadoPedidos.FindAll(pedido => pedido.IdCadete == idCadete);
            if (listadoPedidosCadete != null){
                foreach (var pedido in listadoPedidosCadete){
                    Console.WriteLine("Id: "+pedido.Numero);
                    pedido.verDatosCliente();
                }
            }
        }
        public void CargarListadoCadetes(List<Cadete> listadoCadetesCSV){
            this.listadoCadetes = listadoCadetesCSV;
        }
        public void CrearPedido(int numPedido, string? obsPedido, string? nombreCliente, string? direccionCliente, string? telefonoCliente, string?datosRef){
            Pedido nuevoPedido = new Pedido(numPedido, obsPedido, nombreCliente, direccionCliente, telefonoCliente, datosRef);
            listadoPedidos.Add(nuevoPedido);
        }
        public void AsignarCadeteAPedido(int numPedido, int idCadete){
            if(!ListadoCadetesVacio()){
                    if (listadoPedidos != null){
                        Pedido pedidoBuscado = listadoPedidos.Find(pedido => pedido.Numero == numPedido);
                        pedidoBuscado.AsignarCadete(idCadete);
                    }else{
                        Console.WriteLine("No hay pedidos para asignar.");
                    }
            }else{
                Console.WriteLine("No hay cadetes registrados para asignar pedido. ");
            }
        }
        public void CambiarEstadoPedido(int idPedido){
            Pedido pedidoBuscado = listadoPedidos.Find(pedido => pedido.Numero == idPedido);
            if(pedidoBuscado != null){
                pedidoBuscado.CambiarEstado();
            }else{
                Console.WriteLine("No se encontro un pedido con ese ID");
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
        public void ReasignarPedido(int idPedidBusc,int cadeteAsignado){
            Pedido pedidoBuscado;
            if(listadoCadetes != null){
                pedidoBuscado = listadoPedidos.Find(pedido => pedido.Numero == idPedidBusc);
                if (pedidoBuscado != null){
                    pedidoBuscado.AsignarCadete(cadeteAsignado);
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
                montoTotalJornada = cadete.JornalACobrar() + montoTotalJornada;
            }
            Console.WriteLine("Monto ganado: "+montoTotalJornada);
        }
        public void ListarInformacionCadeteria(){
            Console.WriteLine("\n=========="+this.nombre+"==========");
            Console.WriteLine("\nTelefono:"+this.telefono);
        }
        public void ListarPedidosPendientes(){
            foreach (var pedido in listadoPedidos){
                Console.WriteLine("\nID pedido:" + pedido.Numero);
                pedido.verDatosCliente();
            }
        }
    }      
}

    