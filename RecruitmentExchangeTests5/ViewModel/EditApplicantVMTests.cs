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
    public class EditApplicantVMTests
    {
        [TestMethod()]
        public void ValidateNullTest()
        {
            int errorsCount = 4;
            var testApplicantVM = new EditApplicantVM(null, null);

            testApplicantVM.Validate();

            Assert.AreEqual(errorsCount, testApplicantVM.Errors.Count);
        }
        [TestMethod()]
        public void ValidateEmptyTest()
        {
            int errorsCount = 4;
            var testApplicantVM = new EditApplicantVM(null, null);


            testApplicantVM.Name = "";
            testApplicantVM.Description = "";
            testApplicantVM.Salary = "";

            testApplicantVM.Validate();

            Assert.AreEqual(errorsCount, testApplicantVM.Errors.Count);
        }

        [TestMethod()]
        public void ValidateTest()
        {
            int errorsCount = 0;
            var testApplicantVM = new EditApplicantVM(null, null);


            testApplicantVM.Name = "a";
            testApplicantVM.Description = "a";
            testApplicantVM.SelectedRole = new();
            testApplicantVM.Salary = "50";

            testApplicantVM.Validate();

            Assert.AreEqual(errorsCount, testApplicantVM.Errors.Count);
        }
        [TestMethod()]
        public void ValidateBadSalaryTest()
        {
            var testApplicantVM = new EditApplicantVM(null, null);
            string errorName = nameof(testApplicantVM.Salary);
            int errorsCount = 1;


            testApplicantVM.Name = "a";
            testApplicantVM.Description = "a";
            testApplicantVM.SelectedRole = new();
            testApplicantVM.Salary = "не цифровое значение";

            testApplicantVM.Validate();

            Assert.AreEqual(errorsCount, testApplicantVM.Errors.Count);
            Assert.AreEqual(errorName, testApplicantVM.Errors.First().Key);
        }
    }
}