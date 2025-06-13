using System;
using System.Collections.Generic;
using System.Globalization;
using System.IO;
using System.Linq;

namespace rnaperceptron
{
    /// <summary>
    /// Clase principal del programa. Permite entrenar y probar un perceptrón simple para clasificación de pingüinos.
    /// </summary>
    class Program
    {
        /// <summary>
        /// Punto de entrada principal del programa.
        /// </summary>
        /// <param name="args">Argumentos de línea de comandos (no utilizados).</param>
        static void Main(string[] args)
        {
            // Variables para almacenar los datos y el estado del perceptrón
            List<Penguin> data = null;                // Lista completa de datos cargados
            List<Penguin> entrenamiento = null;       // Datos de entrenamiento (80%)
            List<Penguin> pruebas = null;             // Datos de prueba (20%)
            (double w1, double w2, double b) pesos = (0, 0, 0); // Pesos y sesgo del perceptrón
            bool entrenado = false;                   // Indica si el perceptrón ha sido entrenado

            // Bucle principal del menú
            while (true)
            {
                // Mostrar menú de opciones
                Console.WriteLine("\n--- MENÚ PERCEPTRÓN PINGÜINOS ---");
                Console.WriteLine("1. Cargar datos");
                Console.WriteLine("2. Dividir datos (80% entrenamiento, 20% prueba)");
                Console.WriteLine("3. Entrenar perceptrón");
                Console.WriteLine("4. Probar perceptrón");
                Console.WriteLine("5. Validación cruzada");
                Console.WriteLine("6. Mostrar función de pérdida (Loss)");
                Console.WriteLine("7. Salir");
                Console.Write("Seleccione una opción: ");
                var opcion = Console.ReadLine();

                // Opción 1: Cargar datos desde un archivo CSV
                if (opcion == "1")
                {
                    Console.Write("Ruta del archivo CSV (ejemplo: penguins_size.csv): ");
                    string path = Console.ReadLine();
                    if (!File.Exists(path))
                    {
                        Console.WriteLine("Archivo no encontrado.");
                        continue;
                    }
                    data = DataLoader.CargarDatos(path);
                    Console.WriteLine($"Datos cargados: {data.Count}");
                    entrenado = false;
                }
                // Opción 2: Dividir los datos en entrenamiento y prueba (80/20)
                else if (opcion == "2")
                {
                    if (data == null || data.Count == 0)
                    {
                        Console.WriteLine("Primero cargue los datos.");
                        continue;
                    }
                    var rand = new Random();
                    data = data.OrderBy(x => rand.Next()).ToList();
                    int splitIndex = (int)(data.Count * 0.8);
                    entrenamiento = data.Take(splitIndex).ToList();
                    pruebas = data.Skip(splitIndex).ToList();
                    Console.WriteLine($"Datos divididos: {entrenamiento.Count} entrenamiento, {pruebas.Count} prueba.");
                    entrenado = false;
                }
                // Opción 3: Entrenar el perceptrón con los datos de entrenamiento
                else if (opcion == "3")
                {
                    if (entrenamiento == null || entrenamiento.Count == 0)
                    {
                        Console.WriteLine("Primero divida los datos.");
                        continue;
                    }
                    Console.Write("Número de épocas (ejemplo: 100): ");
                    int epocas = int.TryParse(Console.ReadLine(), out int e) ? e : 100;
                    Console.Write("Tasa de aprendizaje (ejemplo: 0.01): ");
                    double lr = double.TryParse(Console.ReadLine(), NumberStyles.Any, CultureInfo.InvariantCulture, out double l) ? l : 0.01;
                    pesos = Perceptron.Entrenar(entrenamiento, epocas, lr);
                    entrenado = true;
                }
                // Opción 4: Probar el perceptrón con los datos de prueba
                else if (opcion == "4")
                {
                    if (!entrenado || pruebas == null || pruebas.Count == 0)
                    {
                        Console.WriteLine("Primero entrene el perceptrón.");
                        continue;
                    }
                    Perceptron.Probar(pruebas, pesos.w1, pesos.w2, pesos.b);
                }
                // Opción 5: Realizar validación cruzada k-fold
                else if (opcion == "5")
                {
                    if (data == null || data.Count == 0)
                    {
                        Console.WriteLine("Primero cargue los datos.");
                        continue;
                    }
                    Console.Write("Número de pliegues (k) para validación cruzada (ejemplo: 5): ");
                    int k = int.TryParse(Console.ReadLine(), out int val) ? val : 5;
                    Console.Write("Número de épocas (ejemplo: 100): ");
                    int epocas = int.TryParse(Console.ReadLine(), out int e) ? e : 100;
                    Console.Write("Tasa de aprendizaje (ejemplo: 0.01): ");
                    double lr = double.TryParse(Console.ReadLine(), NumberStyles.Any, CultureInfo.InvariantCulture, out double l) ? l : 0.01;
                    Perceptron.CrossValidation(data, k, epocas, lr);
                }
                // Opción 6: Mostrar la función de pérdida (Loss) en los datos de entrenamiento
                else if (opcion == "6")
                {
                    if (!entrenado || entrenamiento == null || entrenamiento.Count == 0)
                    {
                        Console.WriteLine("Primero entrene el perceptrón.");
                        continue;
                    }
                    double loss = Perceptron.Loss(entrenamiento, pesos.w1, pesos.w2, pesos.b);
                    Console.WriteLine($"Función de pérdida (Loss) en entrenamiento: {loss:F4}");
                }
                // Opción 7: Salir del programa
                else if (opcion == "7")
                {
                    Console.WriteLine("Saliendo...");
                    break;
                }
                // Opción no válida
                else
                {
                    Console.WriteLine("Opción no válida.");
                }
            }
        }
    }
}