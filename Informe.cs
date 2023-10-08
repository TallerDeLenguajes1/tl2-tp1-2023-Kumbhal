using System;
using System.Collections.Generic;
using System.IO;
using Cadeterias;
using Cadetes;

namespace Informes{
    public class Informe{
        public List<Cadete> CargarDatosCadete(string? rutaArchivoCadete){
            Cadete cadete = null;
            List<Cadete> listadoCadetes = new List<Cadete> ();
            using (var reader = new StreamReader(rutaArchivoCadete)){
                while (!reader.EndOfStream){
                    var linea = reader.ReadLine();
                    var valores = linea.Split(',');
                    if (valores.Length >= 4){
                        int id = int.Parse(valores[0]);
                        string nombre = valores[1];
                        string direccion = valores[2];
                        string telefono = valores[3];
                        cadete = new Cadete(id, nombre, direccion, telefono);
                        listadoCadetes.Add(cadete);
                    }
                }
            }
            return listadoCadetes;
        }
        public Cadeteria CargarDatosCadeteria(string? rutaArchivoCadeteria){
        // Variables para almacenar los datos del archivo CSV
        string nombre = "";
        string telefono = "";
        List<Cadete> cadetes = new List<Cadete>();

        // Leer el archivo CSV y procesar los datos
        using (var reader = new StreamReader(rutaArchivoCadeteria)){
            // Leer el resto de líneas para obtener los datos
            while (!reader.EndOfStream){
                var linea = reader.ReadLine();
                var valores = linea.Split(',');
                if (valores.Length >= 2){
                    nombre = valores[0];
                    telefono = valores[1];
                }
            }
        }
        // Crear una instancia de Cadeteria con los datos obtenidos
        Cadeteria cadeteria = new Cadeteria(nombre, telefono);
        // Asignar la lista de cadetes (si es necesario) a la instancia de Cadeteria
        return cadeteria;
    }
}
}