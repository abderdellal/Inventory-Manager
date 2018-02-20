using Microsoft.VisualStudio.TestTools.UnitTesting;
using Logic.ViewModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Logic.Core;
using Logic.Core.Domain;
using Moq;

namespace Logic.ViewModels.Tests
{
    [TestClass()]
    public class EditProductViewModelTests
    {
        private Product product;
        Mock<IUnitOfWork> contextMoq;

        [TestInitialize]
        public void testInitialize()
        {
            product = new Product(0, "name", 100, 200, null, null);
        }
        

        [TestMethod()]
        public void CanSaveValidProductTest()
        {
            
            contextMoq = new Mock<IUnitOfWork>();
            EditProductViewModel vm = new EditProductViewModel(contextMoq.Object);
            vm.FormProduct = product;
            Assert.IsTrue(vm.CanSaveProduct());
        }

        [TestMethod()]
        public void CantSaveInvalidProductTest()
        {
            var InvalidProduct = new Product(0, "", 100, 200, null, null);
            contextMoq = new Mock<IUnitOfWork>();
            EditProductViewModel vm = new EditProductViewModel(contextMoq.Object);
            vm.FormProduct = InvalidProduct;
            Assert.IsFalse(vm.CanSaveProduct());
        }
    }
}