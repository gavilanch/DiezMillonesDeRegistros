using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DiezMillonesDemo
{
    internal class Utilidades
    {
        public static void CrearArchivoConDatos(int registros, string ruta)
        {

            if (File.Exists(ruta))
            {
                File.Delete(ruta);
            }

            using (StreamWriter writer = new StreamWriter(ruta, append: true))
                for (int i = 1; i <= registros; i++)
                {
                    {
                        writer.WriteLine($"valor {i}");
                    }
                }

        }

        public static void Calentamiento(string ruta)
        {
            CrearArchivoConDatos(1, ruta);
            CodigoEficiente.InsertarDatos(ruta);
        }
    }
}
