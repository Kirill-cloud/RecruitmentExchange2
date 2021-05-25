using RecruitmentExchange.AppData;
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
        public override string TabName { get; set; } = "Удать сделку между ";

        private Deal selected;
        private DealVM origin;

        public RemoveDealVM(Deal selected, DealVM dealVM)
        {
            this.selected = selected;
            this.origin = dealVM;
            TabName += selected.Company.Name + " " + selected.Applicant.Name;
        }

        public RelayCommand Remove
        {
            get
            {
                return new RelayCommand(async obj =>
                {
                    DBMethods db = new();
                    await db.RemoveDeal(selected);
                    origin.State = new IdleDealVM();
                });
            }
        }

    }
}
