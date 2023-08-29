using System.ComponentModel;
using Clientes;

namespace Pedidos
{
public class Pedido
    {
        public enum Estados {
            Pendiente,
            Encamino,
            Entregado,
            Cancelado,
        }
        private int numero;

        private string? observaciones;

        private Estados estado;

        private Cliente? cliente;
        public int Numero { get => numero; set => numero = value; }

        public Pedido(int numero, string observaciones, string nombre, string direccion, string telefono, string datosRefDireccion){
            this.numero =  numero;
            this.observaciones = observaciones;
            estado = Estados.Pendiente;
            cliente = new Cliente(nombre, direccion, telefono, datosRefDireccion);
        }
        public void verDireccionCliente(){
            Console.WriteLine("La direccion del cliente: " + cliente!.Direccion + cliente.DatosRefDireccion);
        }
        public void verDatosCliente(){
            Console.WriteLine("Nombre: " + cliente!.Nombre);
            Console.WriteLine("Telefono: " + cliente.Telefono);
        } 

        public void cambiarEstado(int tipoCambio){
            int caso = (int)estado;
            if(tipoCambio == 1){
                if(caso == 0){
                    estado = Estados.Encamino;
                }else{
                    estado = Estados.Entregado;
                }
            }else{
                estado = Estados.Cancelado;
            }
        }
    }
}

