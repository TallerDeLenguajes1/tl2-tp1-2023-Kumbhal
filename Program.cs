

using Pedidos;

int numeroDePedido = 0;

Console.WriteLine("---SISTEMA---");
Console.WriteLine("1 - Dar alta pedido");
Console.WriteLine("2 - Asigar Cadete");
Console.WriteLine("3 - Cambiar estado pedido");
Console.WriteLine("4 - Reasignar pedido");
Console.WriteLine("5 - Salir");
Console.WriteLine("Ingrese una opcion: ");
String? opcion = Console.ReadLine();


switch (opcion){
    case "1":
        crearPedido();
        break;
    case "2":
        
        break;
}


void crearPedido(){
    numeroDePedido += 1;
    Console.WriteLine("--- Alta de pedido ---");
    Console.WriteLine("INFORMACION DEL CLIENTE");
    Console.WriteLine("Ingrese el nombre del cliente");
    String? nombreCliente = Console.ReadLine();
    Console.WriteLine("direccion cliente");
    String? direccionCliente = Console.ReadLine();
    Console.WriteLine("telefono cliente");
    String? telefonoCliente = Console.ReadLine();
    Console.WriteLine("datos de referencia cliente");
    String? refenciaCliente = Console.ReadLine();
    Console.WriteLine("\nINFORMACION DEL PEDIDO");
    Console.WriteLine("Observaciones del pedido: ");
    String? observacionesPedido = Console.ReadLine();

    Pedido nuevoPedido = new Pedido(numeroDePedido, observacionesPedido, nombreCliente, direccionCliente, telefonoCliente, refenciaCliente);
    Console.WriteLine("Pedido Creado");
    return;
}

