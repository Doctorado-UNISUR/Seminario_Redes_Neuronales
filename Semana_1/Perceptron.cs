using System;
using System.Collections.Generic;
using System.Globalization;
using System.IO;
using System.Linq;
namespace rnaperceptron
{
    /// <summary>
    /// Clase estática que implementa un perceptrón simple para clasificación binaria de pingüinos.
    /// </summary>
    public static class Perceptron
    {
        /// <summary>
        /// Función de activación escalón (step function).
        /// </summary>
        /// <param name="x">Valor de entrada.</param>
        /// <returns>0 si x &lt; 0, 1 en caso contrario.</returns>
        public static int Paso(double x) => x < 0 ? 0 : 1;

        /// <summary>
        /// Calcula la combinación lineal de las características del pingüino y los pesos.
        /// </summary>
        /// <param name="x">Pingüino de entrada.</param>
        /// <param name="w1">Peso para BillDepthMm.</param>
        /// <param name="w2">Peso para FlipperLengthMm.</param>
        /// <param name="b">Término de sesgo (bias).</param>
        /// <returns>Valor real de la combinación lineal.</returns>
        public static double F(Penguin x, double w1, double w2, double b) =>
            w1 * x.BillDepthMm + w2 * x.FlipperLengthMm + b;

        /// <summary>
        /// Clasifica un pingüino usando los pesos y el sesgo dados.
        /// </summary>
        /// <param name="x">Pingüino de entrada.</param>
        /// <param name="w1">Peso para BillDepthMm.</param>
        /// <param name="w2">Peso para FlipperLengthMm.</param>
        /// <param name="b">Término de sesgo (bias).</param>
        /// <returns>1 si se clasifica como "Gentoo", 0 en caso contrario.</returns>
        public static int Clasificar(Penguin x, double w1, double w2, double b) => Paso(F(x, w1, w2, b));

        /// <summary>
        /// Entrena el perceptrón usando el algoritmo de aprendizaje supervisado.
        /// </summary>
        /// <param name="datos">Lista de pingüinos para entrenamiento.</param>
        /// <param name="iteraciones">Número de épocas de entrenamiento.</param>
        /// <param name="lr">Tasa de aprendizaje (learning rate).</param>
        /// <returns>Tupla con los pesos y el sesgo entrenados.</returns>
        public static (double w1, double w2, double b) Entrenar(List<Penguin> datos, int iteraciones, double lr = 0.01)
        {
            double w1 = 0, w2 = 0, b = 0;
            for (int epoca = 1; epoca <= iteraciones; epoca++)
            {
                foreach (var x in datos)
                {
                    int etiquetaReal = x.Species == "Gentoo" ? 1 : 0;
                    int clase = Clasificar(x, w1, w2, b);

                    if (etiquetaReal == 1 && clase == 0)
                    {
                        w1 += x.BillDepthMm * lr;
                        w2 += x.FlipperLengthMm * lr;
                        b += 1 * lr;
                    }
                    else if (etiquetaReal == 0 && clase == 1)
                    {
                        w1 -= x.BillDepthMm * lr;
                        w2 -= x.FlipperLengthMm * lr;
                        b -= 1 * lr;
                    }
                }
                Console.WriteLine($"Época {epoca}: w1={w1:F4}, w2={w2:F4}, b={b:F4}");
            }
            return (w1, w2, b);
        }

        /// <summary>
        /// Prueba el perceptrón con un conjunto de datos y muestra los resultados.
        /// </summary>
        /// <param name="data">Lista de pingüinos para prueba.</param>
        /// <param name="w1">Peso entrenado para BillDepthMm.</param>
        /// <param name="w2">Peso entrenado para FlipperLengthMm.</param>
        /// <param name="b">Sesgo entrenado.</param>
        public static void Probar(List<Penguin> data, double w1, double w2, double b)
        {
            int correctos = 0, incorrectos = 0;
            foreach (var x in data)
            {
                int clase = Clasificar(x, w1, w2, b);
                int etiquetaReal = x.Species == "Gentoo" ? 1 : 0;

                if (clase == etiquetaReal)
                {
                    Console.WriteLine($"Correcto {x.Species} {clase} {F(x, w1, w2, b):F2}");
                    correctos++;
                }
                else
                {
                    incorrectos++;
                    Console.WriteLine(clase == 1 ? "Es NO Gentoo etiquetado Incorrectamente" : "Es Gentoo etiquetado Incorrectamente");
                }
            }
            Console.WriteLine("\nResultados:");
            Console.WriteLine($"Correctos: {correctos} - {(correctos * 100.0 / data.Count):F2}%");
            Console.WriteLine($"Incorrectos: {incorrectos} - {(incorrectos * 100.0 / data.Count):F2}%");
        }

        /// <summary>
        /// Realiza validación cruzada k-fold sobre el conjunto de datos.
        /// </summary>
        /// <param name="data">Lista de pingüinos.</param>
        /// <param name="k">Número de particiones (folds).</param>
        /// <param name="epocas">Épocas de entrenamiento por fold.</param>
        /// <param name="lr">Tasa de aprendizaje.</param>
        public static void CrossValidation(List<Penguin> data, int k = 5, int epocas = 100, double lr = 0.01)
        {
            var rand = new Random();
            var shuffled = data.OrderBy(x => rand.Next()).ToList();
            int foldSize = data.Count / k;
            double totalAccuracy = 0;

            for (int fold = 0; fold < k; fold++)
            {
                var test = shuffled.Skip(fold * foldSize).Take(foldSize).ToList();
                var train = shuffled.Take(fold * foldSize).Concat(shuffled.Skip((fold + 1) * foldSize)).ToList();

                var pesos = Entrenar(train, epocas, lr);

                int correctos = 0;
                foreach (var x in test)
                {
                    int clase = Clasificar(x, pesos.w1, pesos.w2, pesos.b);
                    int etiquetaReal = x.Species == "Gentoo" ? 1 : 0;
                    if (clase == etiquetaReal) correctos++;
                }
                double acc = 100.0 * correctos / test.Count;
                totalAccuracy += acc;
                Console.WriteLine($"Fold {fold + 1}: {acc:F2}% de acierto ({correctos}/{test.Count})");
            }
            Console.WriteLine($"\nPrecisión promedio: {(totalAccuracy / k):F2}%");
        }

        /// <summary>
        /// Calcula el error cuadrático medio (MSE) para un conjunto de datos y pesos dados.
        /// </summary>
        /// <param name="datos">Lista de pingüinos.</param>
        /// <param name="w1">Peso para BillDepthMm.</param>
        /// <param name="w2">Peso para FlipperLengthMm.</param>
        /// <param name="b">Sesgo.</param>
        /// <returns>Error cuadrático medio.</returns>
        public static double Loss(List<Penguin> datos, double w1, double w2, double b)
        {
            double suma = 0;
            foreach (var x in datos)
            {
                int etiquetaReal = x.Species == "Gentoo" ? 1 : 0;
                int prediccion = Paso(F(x, w1, w2, b)); // Aplica la función de activación
                suma += Math.Pow(etiquetaReal - prediccion, 2);
            }
            return suma / datos.Count;
        }
    }
}