using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using EvoxSolutions.WebApi.Models;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace EvoxSolutions.Tests
{
    [TestClass]
    public class ProductTest
    {
        [TestMethod]
        public void Should_Return_Success_When_Invalid_Model()
        {
            var model = new Product();
            model.Title = "";
            model.Description = "";
            model.Price = 0;
            model.CategoryId = 0;

            var context = new ValidationContext(model, null, null);
            var results = new List<ValidationResult>();
            TypeDescriptor.AddProviderTransparent(new AssociatedMetadataTypeTypeDescriptionProvider(typeof(Product), typeof(Product)), typeof(Product));

            var isModelStateValid = Validator.TryValidateObject(model, context, results, true);

            Assert.IsFalse(isModelStateValid);
        }

        [TestMethod]
        public void Should_Return_Success_When_Valid_Model()
        {
            var model = new Product();
            model.Title = "João de Barro";
            model.Description = "Teste";
            model.Price = 30;
            model.CategoryId = 1;

            var context = new ValidationContext(model, null, null);
            var results = new List<ValidationResult>();
            TypeDescriptor.AddProviderTransparent(new AssociatedMetadataTypeTypeDescriptionProvider(typeof(Product), typeof(Product)), typeof(Product));

            var isModelStateValid = Validator.TryValidateObject(model, context, results, true);
            
            Assert.IsTrue(isModelStateValid);
        }
    }
}
