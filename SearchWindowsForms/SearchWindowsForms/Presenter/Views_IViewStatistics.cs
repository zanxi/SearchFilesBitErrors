using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SearchWindowsForms.Presenter
{
    public interface IViewStatistics : IView
    {
        string fileName { get; }
        event Action Save;
    }
}
