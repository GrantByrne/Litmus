using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Litmus
{
    /// <summary>
    ///     Exposes methods for access color attributes about the screen
    /// </summary>
    public interface ILitmus
    {
        /// <summary>
        ///     Gets the color that shows up most often on the screen from a section of pixels on the screen
        /// </summary>
        /// <returns>
        ///     The Red, Green, and Blue values for the pixel which appears most often on the screen
        /// </returns>
        LitmusColor GetMostCommonColor();

        /// <summary>
        ///     Gets the average color of a section of pixels on the screen
        /// </summary>
        /// <returns>
        ///      The average of the Red, Green, and Blue values for the colors on the screen
        /// </returns>
        LitmusColor GetAverageColor();
    }
}
