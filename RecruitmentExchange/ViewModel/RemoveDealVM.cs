using RecruitmentExchange.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RecruitmentExchange.ViewModel
{
    class RemoveDealVM : TabViewBase
    {
        public override string TabName { get; set; } = "Удать сделку";

        private Deal selected;
        private DealVM dealVM;

        public RemoveDealVM(Deal selected, DealVM dealVM)
        {
            this.selected = selected;
            this.dealVM = dealVM;
        }

    }
}
