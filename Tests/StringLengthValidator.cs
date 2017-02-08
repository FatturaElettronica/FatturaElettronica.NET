using FluentValidation.TestHelper;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace Tests
{
    [TestClass]
    public class StringLengthValidator 
    {
        [TestMethod]
        public void StringMinMaxLength()
        {
            var validator = new FatturaElettronica.Validators.StringLengthValidator(1, 200);

            var challenge = new string('x', 201);
            validator.ShouldHaveValidationErrorFor(x => x, objectToTest:challenge);
            challenge = new string('x', 1);
            validator.ShouldNotHaveValidationErrorFor(x => x, objectToTest:challenge);
            challenge = new string('x', 200);
            validator.ShouldNotHaveValidationErrorFor(x => x, objectToTest:challenge);
        }
    }
}
