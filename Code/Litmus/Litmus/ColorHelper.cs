using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Litmus
{
    /// <summary>
    /// Helps with the process of resolving a single color from many colors
    /// </summary>
    class ColorHelper : IColorHelper
    {
        /// <summary>
        /// Gets the average of all the colors provided
        /// </summary>
        /// <param name="colors">
        /// The total collection of sampled colors
        /// </param>
        /// <returns>
        /// A color object that represents the average of all the sampled 
        /// colors
        /// </returns>
        public LitmusColor ComputeAverageColors(IEnumerable<LitmusColor> colors)
        {
            int red = 0;
            int green = 0;
            int blue = 0;
            int count = 0;

            foreach (var color in colors)
            {
                red += color.Red;
                green += color.Green;
                blue += color.Blue;
                count++;
            }

            return new LitmusColor
            {
                Red = (byte)(red / count),
                Green = (byte)(green / count),
                Blue = (byte)(blue / count)
            };
        }

        /// <summary>
        /// Computes the color that shows up the most often
        /// </summary>
        /// <param name="colors">
        /// The total collection of sampled colors
        /// </param>
        /// <returns>
        /// The color object that showed up the most often
        /// </returns>
        public LitmusColor ComputeProminentColor(IEnumerable<LitmusColor> colors)
        {
            var colorCount = new Dictionary<LitmusColor, int?>();

            foreach (var color in colors)
            {
                if (!colorCount.ContainsKey(color))
                {
                    colorCount[color] = 0;
                }
                colorCount[color]++;
            }

            return colorCount.OrderByDescending(p => p.Value).First().Key;
        }
    }
}
