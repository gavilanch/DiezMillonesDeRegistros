using DiezMillonesDemo;
using System.Diagnostics;

Console.WriteLine("Procesando");

var ruta = @"C:\Users\ASUS\source\repos\DiezMillonesDemo\DiezMillonesDemo\data.txt";

// Calentamiento
Utilidades.Calentamiento(ruta);

Utilidades.CrearArchivoConDatos(10_000_000, ruta);

Console.WriteLine("Insertando los datos en SQL Server");

Stopwatch sw = new Stopwatch();

sw.Start();

Console.WriteLine("--Proceso eficiente--");
CodigoEficiente.InsertarDatos(ruta);

sw.Stop();

Console.WriteLine($"Duración: {sw.ElapsedMilliseconds / 1000.0} segundos");

sw.Restart();

Console.WriteLine("--Proceso ineficiente--");
CodigoIneficiente.InsertarDatos(ruta);

sw.Stop();

Console.WriteLine($"Duración: {sw.ElapsedMilliseconds / 1000.0} segundos");

Console.WriteLine("Fin");
