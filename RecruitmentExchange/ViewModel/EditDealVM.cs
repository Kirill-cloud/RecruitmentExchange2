using RecruitmentExchange.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RecruitmentExchange.ViewModel
{
    class EditDealVM : TabViewBase
    {
        private Deal selected;
        private DealVM origin;

        public EditDealVM(Deal selected, DealVM origin)
        {
            this.selected = selected;
            this.origin = origin;
        }

        public override string TabName { get => throw new NotImplementedException(); set => throw new NotImplementedException(); }
    }
}
