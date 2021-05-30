using Microsoft.VisualStudio.TestTools.UnitTesting;
using RecruitmentExchange.ViewModel;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RecruitmentExchange.ViewModel.Tests
{
    [TestClass()]
    public class EditVacancyVMTests
    {
        [TestMethod()]
        public void ValidateNullTest()
        {
            int errorsCount = 3;
            var testVacancyVM = new EditVacancyVM(null,null);

            testVacancyVM.Validate();

            Assert.AreEqual(errorsCount, testVacancyVM.Errors.Count);
        }
        [TestMethod()]
        public void ValidateEmptyTest()
        {
            int errorsCount = 3;
            var testVacancyVM = new EditVacancyVM(null, null);


            testVacancyVM.Description = "";

            testVacancyVM.Validate();

            Assert.AreEqual(errorsCount, testVacancyVM.Errors.Count);
        }
        [TestMethod()]
        public void ValidateTest()
        {
            int errorsCount = 0;
            var testVacancyVM = new EditVacancyVM(null, null);


            testVacancyVM.Description = "fd";
            testVacancyVM.SelectedCompany = new();
            testVacancyVM.SelectedRole = new();

            testVacancyVM.Validate();

            Assert.AreEqual(errorsCount, testVacancyVM.Errors.Count);
        }
    }
}