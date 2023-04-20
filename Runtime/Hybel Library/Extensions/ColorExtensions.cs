using UnityEngine;

namespace Hybel.ExtensionMethods
{
    /// <summary>
    /// Extension Methods used on Colors.
    /// </summary>
    public static class ColorExtensions
    {
        /// <summary>
        /// Converts a color to hex code.
        /// </summary>
        /// <param name="color">Color.</param>
        /// <returns>4 channel hex code with a preceeding #.</returns>
        public static string ToHexWithHashRGB(this Color color) =>
            "#" + color.ToHexRGB();

        /// <summary>
        /// Converts a color to hex code.
        /// </summary>
        /// <param name="color">Color.</param>
        /// <returns>4 channel hex code.</returns>
        public static string ToHexRGB(this Color color) =>
            ColorUtility.ToHtmlStringRGB(color);

        /// <summary>
        /// Converts a color to hex code.
        /// </summary>
        /// <param name="color">Color.</param>
        /// <returns>4 channel hex code with a preceeding #.</returns>
        public static string ToHexWithHashRGBA(this Color color) =>
            "#" + color.ToHexRGBA();

        /// <summary>
        /// Converts a color to hex code.
        /// </summary>
        /// <param name="color">Color.</param>
        /// <returns>4 channel hex code.</returns>
        public static string ToHexRGBA(this Color color) =>
            ColorUtility.ToHtmlStringRGBA(color);

        /// <summary>
        /// Sets any value of the color to a given value.
        /// </summary>
        /// <param name="color">Original Color.</param>
        /// <param name="r">Red.</param>
        /// <param name="g">Green.</param>
        /// <param name="b">Blue.</param>
        /// <param name="a">Alpha.</param>
        /// <returns>Original Color with altered components.</returns>
        public static Color With(this Color color, float? r = null, float? g = null, float? b = null, float? a = null) =>
            new Color(r ?? color.r, g ?? color.g, b ?? color.b, a ?? color.a);
    }
}