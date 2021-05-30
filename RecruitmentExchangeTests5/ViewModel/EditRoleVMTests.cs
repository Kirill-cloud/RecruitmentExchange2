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
    public class EditRoleVMTests
    {
        [TestMethod()]
        public void ValidateNullTest()
        {
            int errorsCount = 1;
            var testRoleVM = new EditRoleVM(null, null);

            testRoleVM.Validate();

            Assert.AreEqual(errorsCount, testRoleVM.Errors.Count);
        }
        [TestMethod()]
        public void ValidateEmptyTest()
        {
            int errorsCount = 1;
            var testRoleVM = new EditRoleVM(null, null);

            testRoleVM.Name = "";

            testRoleVM.Validate();

            Assert.AreEqual(errorsCount, testRoleVM.Errors.Count);
        }
        [TestMethod()]
        public void ValidateTest()
        {
            int errorsCount = 0;
            var testRoleVM = new EditRoleVM(null, null);

            testRoleVM.Name = "a";

            testRoleVM.Validate();

            Assert.AreEqual(errorsCount, testRoleVM.Errors.Count);
        }
    }

}