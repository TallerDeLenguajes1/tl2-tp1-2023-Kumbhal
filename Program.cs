using System.IO;
using System.Collections;
using Pedidos;
using Cadeterias;
using Cadetes;
using AccesoADato;

int opcion = 0;
string? stringNom = "";
string? stringDir = "";
string? stringTel = "";
string? stringObsPed = "";
string? stringDatRef = "";
int varInt = 0;
int idCadete = 0;
int idPedido = 0;
Cadeteria cadeteriaNueva;
Console.WriteLine("\n==========INTERFAZ USUARIO==========");
Console.WriteLine("\nCARGA DE DATOS DE CADETERIA Y CADETES DESDE ARCHIVO:");
Console.WriteLine("\n1) Para cargar datos desde CSV");
Console.WriteLine("\n2) Para cargar datos desde JSON");
int.TryParse(Console.ReadLine(), out varInt);
if (varInt == 1){
    AccesoADatos cargarDatosCSV = new AccesoCSV();
    cadeteriaNueva = cargarDatosCSV.CargarDatosCadeteria("Cadeteria.csv");
    cadeteriaNueva.CargarListadoCadetes(cargarDatosCSV.CargarDatosCadete("Cadetes.csv"));
}else{
    AccesoADatos cargarDatosJSON = new AccesoJSON();
    cadeteriaNueva = cargarDatosJSON.CargarDatosCadeteria("Cadeteria.JSON");
    cadeteriaNueva.CargarListadoCadetes(cargarDatosJSON.CargarDatosCadete("Cadetes.JSON"));     
}
Random numeroRandom = new Random();

while(opcion != 5){
    cadeteriaNueva.ListarInformacionCadeteria();
    MenuCadeteria();
    Console.WriteLine("Ingrese la opcion: ");
    int.TryParse(Console.ReadLine(), out opcion);
    switch(opcion){
        case 1:
            Console.WriteLine("\nIngrese el nombre del cliente: ");
            stringNom = Console.ReadLine();
            Console.WriteLine("\nIngrese la direccion del cliente: ");
            stringDir = Console.ReadLine();
            Console.WriteLine("\nIngrese el telefono del cliente: ");
            stringTel = Console.ReadLine();
            Console.WriteLine("\nIngrese observaciones del pedido: ");
            stringObsPed = Console.ReadLine();
            Console.WriteLine("\nIngrese datos de referencia del cliente: ");
            stringDatRef = Console.ReadLine();
            cadeteriaNueva.CrearPedido(numeroRandom.Next(1,100), stringNom, stringDir, stringTel, stringObsPed, stringDatRef);
            break;
        case 2:
            Console.WriteLine("\n==========LISTADO CADETES==========");
            cadeteriaNueva.listarCadetes();
            Console.WriteLine("\nIngrese el id del cadete para asignar pedido: ");
            int.TryParse(Console.ReadLine(), out idCadete);
            cadeteriaNueva.ListarPedidosPendientes();
            Console.WriteLine("\nIngrese el ID del pedido: ");
            int.TryParse(Console.ReadLine(), out idPedido);
            cadeteriaNueva.AsignarCadeteAPedido(idPedido,idCadete);
            Console.Clear();
            break;
        case 3:
            cadeteriaNueva.listarCadetes();
            Console.WriteLine("Ingrese el numero del cadete: ");
            int.TryParse(Console.ReadLine(), out idCadete);
            cadeteriaNueva.MostrarPedidosCadete(idCadete);
            Console.WriteLine("Ingrese el numero de pedido: ");
            int.TryParse(Console.ReadLine(), out idPedido);
            cadeteriaNueva.CambiarEstadoPedido(idPedido);
            Console.Clear();
            break;
        case 4:
            cadeteriaNueva.listarCadetes();
            Console.WriteLine("Ingrese el ID del cadete que recibe el pedido: ");
            int.TryParse(Console.ReadLine(), out idCadete);
            Console.Clear();
            Console.WriteLine("Ingrese el ID del pedido: ");
            int.TryParse(Console.ReadLine(), out idPedido);
            cadeteriaNueva.ReasignarPedido(idPedido, idCadete);
            break;
    }
}
cadeteriaNueva.MostrarInforme();
void MenuCadeteria(){
    Console.WriteLine("\n1)Crear Pedido.\n2)Asignar pedido a cadete.\n3)Cambiar estado pedido.\n4)Reasignar pedido a cadete.\n5)Salir.");
}