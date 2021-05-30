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
    public class EditDealVMTests
    {
        [TestMethod()]
        public void ValidateNullTest()
        {
            int errorsCount = 3;
            var testDealVM = new EditDealVM(null,null);

            testDealVM.Validate();

            Assert.AreEqual(errorsCount, testDealVM.Errors.Count);
        }
        [TestMethod()]
        public void ValidateTest()
        {
            int errorsCount = 0;
            var testDealVM = new EditDealVM(null, null);

            testDealVM.SelectedCompany = new();
            testDealVM.SelectedVacancy = new();
            testDealVM.SelectedApplicant = new();

            testDealVM.Validate();

            Assert.AreEqual(errorsCount, testDealVM.Errors.Count);
        }
    }
}