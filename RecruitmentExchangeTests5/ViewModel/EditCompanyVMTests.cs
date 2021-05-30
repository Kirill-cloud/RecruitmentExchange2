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
    public class EditCompanyVMTests
    {
        [TestMethod()]
        public void ValidateNullTest()
        {
            int errorsCount = 4; 
            var testCompanyVM = new EditCompanyVM(null,null);

            testCompanyVM.Validate();

            Assert.AreEqual(errorsCount, testCompanyVM.Errors.Count);
        }
        [TestMethod()]
        public void ValidateEmptyTest()
        {
            int errorsCount = 4;
            var testCompanyVM = new EditCompanyVM(null, null);

            testCompanyVM.Name = "";
            testCompanyVM.Focus = "";
            testCompanyVM.Address = "";
            testCompanyVM.Phone = "";

            testCompanyVM.Validate();

            Assert.AreEqual(errorsCount, testCompanyVM.Errors.Count);
        }
        [TestMethod()]
        public void ValidateTest()
        {
            int errorsCount = 0;
            var testCompanyVM = new EditCompanyVM(null, null);



            testCompanyVM.Name = "a";
            testCompanyVM.Focus = "a";
            testCompanyVM.Address = "a";
            testCompanyVM.Phone = "a";

            testCompanyVM.Validate();

            Assert.AreEqual(errorsCount, testCompanyVM.Errors.Count);
        }
    }
}