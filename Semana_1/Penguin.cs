using System;
namespace rnaperceptron
{
    /// <summary>
    /// Representa un pingüino con sus características relevantes para la clasificación.
    /// </summary>
    public class Penguin
    {
        /// <summary>
        /// Especie del pingüino (por ejemplo, "Gentoo").
        /// </summary>
        public string Species;

        /// <summary>
        /// Profundidad del pico en milímetros.
        /// </summary>
        public double BillDepthMm;

        /// <summary>
        /// Longitud de la aleta en milímetros.
        /// </summary>
        public double FlipperLengthMm;
    }
}