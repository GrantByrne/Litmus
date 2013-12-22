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
    interface IColorHelper
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
        LitmusColor ComputeAverageColors(IEnumerable<LitmusColor> colors);

        /// <summary>
        /// Computes the color that shows up the most often
        /// </summary>
        /// <param name="colors">
        /// The total collection of sampled colors
        /// </param>
        /// <returns>
        /// The color object that showed up the most often
        /// </returns>
        LitmusColor ComputeProminentColor(IEnumerable<LitmusColor> colors);
    }
}
