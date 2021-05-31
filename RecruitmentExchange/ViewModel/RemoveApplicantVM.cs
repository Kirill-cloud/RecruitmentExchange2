using RecruitmentExchange.AppData;
using RecruitmentExchange.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RecruitmentExchange.ViewModel
{
    public class RemoveApplicantVM : TabContentBase
    {
        private Applicant applicant;
        private readonly ApplicantVM origin;

        public RemoveApplicantVM(Applicant applicant, ApplicantVM origin)
        {
            this.applicant = applicant;
            this.origin = origin;
            TabName += applicant.Name;

            LoadRelatedDataAsync();
        }

        public override string TabName { get; set; } = "Удалить соискателя ";
        public string DeleteConstr { get; set; }
        bool isReady = true;
        public int DealCount { get; private set; } = 0;

        async Task LoadRelatedDataAsync()
        {
            isReady = false;

            DBMethods db = new();

            DealCount = (await db.GetAllDeals()).Where(x => x.Applicant.Id == applicant.Id).Count();

            if (DealCount != 0)
            {
                DeleteConstr = "Нельзя удалить соискателся пока с нем есть сделки";
                OnPropertyChanged(nameof(DeleteConstr));
            }

            OnPropertyChanged("DealCount");

            isReady = true;
        }

        public RelayCommand Remove
        {
            get
            {
                return new RelayCommand(async obj =>
                {
                    DBMethods db = new();
                    await db.RemoveApplicant(applicant);
                    origin.Cancel.Execute(null);
                }, new Func<object, bool>(obj =>
                {
                    return isReady && DealCount == 0;
                }));
            }
        }

    }
}
