using Fpl.Client.Validation;
using System;
using System.Linq;
using Xunit;

namespace Fpl.Client.Tests.Validation
{
    public class ValidationTests
    {

        [Fact]
        public void Validation_Validate_True_ReturnsOk()
        {
            var validation = GetValidation(true);
            validation.Validate();
            Assert.True(validation.IsValid);
        }

        [Fact]
        public void Validation_Validate_False_ThrowsValidationException()
        {
            var expectedMessage = GenerateString();
            var validation = GetValidation(false, expectedMessage);

            var exception = Assert.Throws<ValidationException>(() => validation.Validate());

            Assert.Equal(expectedMessage, exception.Message);
            Assert.Equal(expectedMessage, validation.Message);
            Assert.False(validation.IsValid);
        }

        [Fact]
        public void Validation_Validate_Null_ThrowsArgumentNullException()
        {
            var exception = Assert.Throws<ArgumentNullException>(() => new TestValidation(null));

            Assert.Equal("context", exception.ParamName);
        }

        [Fact]
        public void Validations_Validate_AllTrue_ReturnsOk()
        {
            var validations = new Validations(new[] { GetValidation(true), GetValidation(true) });

            validations.Validate();

            Assert.True(validations.IsValid);
            Assert.Empty(validations.Messages);
        }

        [Fact]
        public void Validations_Validate_1stInvalid_ThrowsValidationException()
        {
            var expectedMessage = GenerateString();
            var validations = new Validations(new[] { GetValidation(false, expectedMessage), GetValidation(true) });

            var exception = Assert.Throws<ValidationException>(() => validations.Validate());

            Assert.False(validations.IsValid);
            Assert.Single(validations.Messages);
            Assert.Equal(expectedMessage, validations.Messages.First());
            Assert.Equal(expectedMessage, exception.Message);
        }

        [Fact]
        public void Validations_Validate_2ndInvalid_ThrowsValidationException()
        {
            var expectedMessage = GenerateString();
            var validations = new Validations(new[] { GetValidation(true), GetValidation(false, expectedMessage) });

            var exception = Assert.Throws<ValidationException>(() => validations.Validate());

            Assert.False(validations.IsValid);
            Assert.Single(validations.Messages);
            Assert.Equal(expectedMessage, validations.Messages.First());
            Assert.Equal(expectedMessage, exception.Message);
        }

        [Fact]
        public void Validations_Validate_AllInvalid_ThrowsValidationException()
        {
            var expectedMessage1 = GenerateString();
            var expectedMessage2 = GenerateString();
            var validations = new Validations(new[] { GetValidation(false, expectedMessage1), GetValidation(false, expectedMessage2) });

            var exception = Assert.Throws<ValidationException>(() => validations.Validate());

            Assert.False(validations.IsValid);
            var messages = validations.Messages.ToList();
            Assert.Equal(2, messages.Count);
            Assert.Equal(expectedMessage1, messages[0]);
            Assert.Equal(expectedMessage2, messages[1]);
            Assert.Equal(string.Join(Environment.NewLine, expectedMessage1, expectedMessage2), exception.Message);
        }

        private static string GenerateString() 
        {
            return Guid.NewGuid().ToString();
        }

        private static IValidation GetValidation(bool isValid, string message = null)
        {
            return new TestValidation(new TestContext { IsValid = isValid, Message = message });
        }

        private class TestValidation : Validation<TestContext>
        {
            public TestValidation(TestContext context) : base(context) { }

            public override bool IsValid => Context.IsValid;

            public override string Message => Context.Message;
        }

        private class TestContext
        {
            public bool IsValid { get; init; }
            public string Message { get; init; }
        }
    }
}
