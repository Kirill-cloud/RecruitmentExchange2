using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MVVM
{
    class MainVM
    {
        IEnumerable<VMBase> viewModels;
        public IEnumerable<VMBase> ViewModels { get { return viewModels; } }
        public MainVM()
        {
            viewModels.Append(new FirstTabVM());
            viewModels.Append(new SecondTabVM());
        }
    }
}
