using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DesignPatternsProject.Interface;

public interface ITime
{
    public float GetEstimationTime();
    public float GetLoggedTime();
}
