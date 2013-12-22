using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Litmus
{
    interface ISamplePointService
    {
        SamplePoints GetSamplePoints(float screenPercentage);
    }
}
