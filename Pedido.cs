using System.ComponentModel;
using Clientes;

namespace Pedidos
{
public class Pedido
    {
        public enum Estados {
            Pendiente,
            Cancelado,
            Encamino,
            Entregado
        }
        private int numero;

        private string? observaciones;

        private Estados estado;

        private Cliente? cliente;

        public Pedido(int numero, string observaciones, string nombre, string direccion, string telefono, string datosRefDireccion){
            this.numero =  numero;
            this.observaciones = observaciones;
            this.estado = Estados.Pendiente;
            cliente = new Cliente(nombre, direccion, telefono, datosRefDireccion);
        }

        public void verDireccionCliente(){
            Console.WriteLine("La direccion del cliente: " + cliente!.Direccion + cliente.DatosRefDireccion);
        }

        public void verDatosCliente(){
            Console.WriteLine("Nombre: " + cliente!.Nombre);
            Console.WriteLine("Telefono: " + cliente.Telefono);
        } 

        public void cambiarEstado(int cambioEstado){
            if(cambioEstado == 2){

            }
            switch (cambioEstado)
            {
                case 1:
                    estado = Estados.Encamino;
                    break;
                default:
            }
        }
    }
}

