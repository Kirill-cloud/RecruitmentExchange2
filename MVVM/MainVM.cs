using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MVVM
{
    class MainVM
    {
        readonly List<VMBase> viewModels = new();
        public IEnumerable<VMBase> ViewModels { get { return viewModels; } }
        public MainVM()
        {
            viewModels.Add(new FirstTabVM());
            viewModels.Add(new SecondTabVM());
        }

    }
}
