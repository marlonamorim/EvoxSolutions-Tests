using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using EvoxSolutions.WebApi.Models;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace EvoxSolutions.Tests
{
    [TestClass]
    public class CategoryTest
    {
        [TestMethod]
        public void Should_Return_Success_When_Invalid_Model()
        {
            var model = new Category();
            model.Title = "";

            var context = new ValidationContext(model, null, null);
            var results = new List<ValidationResult>();
            TypeDescriptor.AddProviderTransparent(new AssociatedMetadataTypeTypeDescriptionProvider(typeof(Category), typeof(Category)), typeof(Category));

            var isModelStateValid = Validator.TryValidateObject(model, context, results, true);

            Assert.IsFalse(isModelStateValid);
        }

        [TestMethod]
        public void Should_Return_Success_When_Valid_Model()
        {
            var model = new Category();
            model.Title = "João de Barro";

            var context = new ValidationContext(model, null, null);
            var results = new List<ValidationResult>();
            TypeDescriptor.AddProviderTransparent(new AssociatedMetadataTypeTypeDescriptionProvider(typeof(Category), typeof(Category)), typeof(Category));

            var isModelStateValid = Validator.TryValidateObject(model, context, results, true);
            
            Assert.IsTrue(isModelStateValid);
        }
    }
}
