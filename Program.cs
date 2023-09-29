using System.IO;
using System.Collections;
using Pedidos;
using Cadeterias;
using Cadetes;

int opcion = 0;
string? stringNom = "";
string? stringDir = "";
string? stringTel = "";
Console.WriteLine("Ingrese el nombre de la cadeteria: ");
stringNom = Console.ReadLine();
Console.WriteLine("Ingrese el telefono de la cadeteria: ");
stringTel = Console.ReadLine();
Cadeteria cadeteriaNueva = new Cadeteria(stringNom, stringTel);

while(opcion != 5){
    menuCadeteria();
    Console.WriteLine("Ingrese la opcion: ");
    int.TryParse(Console.ReadLine(), out opcion);
    switch(opcion){
        case 1:
            Cadete cadeteNuevo;
            Console.WriteLine("Ingrese el nombre del cadete: ");
            stringNom = Console.ReadLine();
            Console.WriteLine("Ingrese la direccion del cadete: ");
            stringDir = Console.ReadLine();
            Console.WriteLine("Ingrese el telefono del cadete: ");
            stringTel = Console.ReadLine();
            cadeteNuevo = new Cadete ((cadeteriaNueva.cantidadCadetes() + 1),stringNom, stringDir, stringTel);
            break;
        case 2:
            Pedido pedidoNuevo;
            Console.WriteLine();
            break;
    }
}
void menuCadeteria(){
    Console.WriteLine("1) Agregar Cadete.\n 2) Asignar pedido a cadete.\n 3)Listar cadetes ");
}