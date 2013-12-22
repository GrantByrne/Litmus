using SlimDX.Direct3D9;
using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Litmus
{
    public class DirectxColorProvider : Form, ILitmus
    {
        private readonly IColorHelper _colorHelper;
        private readonly ISamplePointService _samplePointService;

        /// <summary>
        /// Handles the graphics device
        /// </summary>
        private static Device d;

        private static SamplePoints _samplePoints;

        private static Graphics _graphics;

        /// <summary>
        /// Ctor
        /// </summary>
        public DirectxColorProvider()
        {
            _colorHelper = new ColorHelper();
            _samplePointService = new SamplePointService();

            PresentParameters present_params = new PresentParameters();
            if (d == null)
            {
                d = new Device(new Direct3D(), 0, DeviceType.Hardware, IntPtr.Zero, CreateFlags.SoftwareVertexProcessing, present_params);
            }
            if (_samplePoints == null)
            {
                _samplePoints = _samplePointService.GetSamplePoints(.1f);
            }

            if (_graphics == null)
            {
                _graphics = this.CreateGraphics();
            }
        }

        public LitmusColor GetMostCommonColor()
        {
            return this._colorHelper.ComputeProminentColor(GetColors());
        }

        public LitmusColor GetAverageColor()
        {
            return this._colorHelper.ComputeAverageColors(GetColors());
        }

        private IEnumerable<LitmusColor> GetColors()
        {
            var colors = new List<LitmusColor>();

            using (var memoryImage = new Bitmap(_samplePoints.CenterBox.Width, _samplePoints.CenterBox.Height, _graphics))
            {
                using (Graphics memoryGraphics = Graphics.FromImage(memoryImage))
                {
                    var size = new System.Drawing.Size
                    {
                        Width = _samplePoints.CenterBox.Width,
                        Height = _samplePoints.CenterBox.Height
                    };

                    memoryGraphics.CopyFromScreen(_samplePoints.CenterBox.X,
                                                    _samplePoints.CenterBox.Y,
                                                    0,
                                                    0,
                                                    size,
                                                    CopyPixelOperation.SourceCopy);

                    foreach (var point in _samplePoints.Points)
                    {
                        var pixel = memoryImage.GetPixel(point.X - _samplePoints.CenterBox.X, point.Y - _samplePoints.CenterBox.Y);
                        var sampledColor = new LitmusColor
                        {
                            Red = pixel.R,
                            Green = pixel.G,
                            Blue = pixel.B
                        };
                        colors.Add(sampledColor);
                    }
                }

            }

            return colors;
        }
    }
}
