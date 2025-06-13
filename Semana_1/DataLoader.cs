using System;
using System.Collections.Generic;
using System.Globalization;
using System.IO;
using System.Linq;

namespace rnaperceptron
{
    /// <summary>
    /// Clase utilitaria para cargar datos de pingüinos desde un archivo CSV.
    /// </summary>
    public static class DataLoader
    {
        /// <summary>
        /// Carga los datos de pingüinos desde un archivo CSV, omitiendo filas con datos faltantes.
        /// </summary>
        /// <param name="path">Ruta del archivo CSV.</param>
        /// <returns>Lista de objetos Penguin con los datos cargados.</returns>
        public static List<Penguin> CargarDatos(string path)
        {
            // Lee todas las líneas del archivo
            var lines = File.ReadAllLines(path);
            var data = new List<Penguin>();

            // Omite la primera línea (cabecera) y procesa cada línea de datos
            foreach (var line in lines.Skip(1))
            {
                var cols = line.Split(',');

                // Verifica que la línea tenga suficientes columnas
                if (cols.Length < 6) continue;

                // Omite filas con valores faltantes ("NA") en las columnas relevantes
                if (cols[3] == "NA" || cols[4] == "NA") continue;

                try
                {
                    // Crea un objeto Penguin y lo agrega a la lista
                    data.Add(new Penguin
                    {
                        Species = cols[0],
                        BillDepthMm = double.Parse(cols[3], CultureInfo.InvariantCulture),
                        FlipperLengthMm = double.Parse(cols[4], CultureInfo.InvariantCulture)
                    });
                }
                catch
                {
                    // Si ocurre un error al parsear, omite la fila
                }
            }
            // Devuelve la lista de pingüinos cargados
            return data;
        }
    }
}