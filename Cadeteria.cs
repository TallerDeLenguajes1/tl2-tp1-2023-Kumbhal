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
        public void asignarPedido(Pedido pedidoNuevo, Cadete cadeteAsignar){
            if(listadoCadetes.Contains(cadeteAsignar)){
                cadeteAsignar.ListadoPedidos.Add(pedidoNuevo);
            }else{
                listadoCadetes.Add(cadeteAsignar);
                cadeteAsignar.ListadoPedidos.Add(pedidoNuevo);
            }
        }
        public void agregarCadete(Cadete nuevoCadete){
            listadoCadetes?.Add(nuevoCadete);
            Console.WriteLine("Se agrego nuevo cadete");
            return; 
        }
        public void listarCadetes(){
            foreach (var cadete in listadoCadetes){
                cadete.listarInformacion();
            }
        }
        public void reasignarPedidos(int idPedidBusc, Cadete cadeteAsignado,Cadete cadeteACambiar){
            Pedido pedidoAMover;
            pedidoAMover = cadeteAsignado.ListadoPedidos.Find(pedidobuscado => pedidobuscado.Numero == idPedidBusc);
        }
        public void eliminarPedido(){}
        
        
    }      

}

    