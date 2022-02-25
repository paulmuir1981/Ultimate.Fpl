using Fpl.Client.Queries.Entries;
using Fpl.Client.Validation;
using Fpl.Client.Validation.Entries;
using Xunit;

namespace Fpl.Client.Tests.Validation.Entries
{
    public class GetByEntryIdQueryValidationTests
    {
        [Theory]
        [InlineData(1)]
        [InlineData(2)]
        [InlineData(int.MaxValue)]
        public void GetByEntryIdQueryValidation_Validate_True_ReturnsOK(int entryId)
        {
            var validation = GetValidation(entryId);

            validation.Validate();

            Assert.True(validation.IsValid);
        }

        [Theory]
        [InlineData(int.MinValue)]
        [InlineData(-2)]
        [InlineData(-1)]
        [InlineData(0)]
        public void GetByEntryIdQueryValidation_Validate_False_ThrowsValidationException(int entryId)
        {
            var expectedMessage = "EntryId must be at least 1";
            var validation = GetValidation(entryId);

            var exception = Assert.Throws<ValidationException>(() => validation.Validate());

            Assert.Equal(expectedMessage, exception.Message);
            Assert.Equal(expectedMessage, validation.Message);
            Assert.False(validation.IsValid);
        }

        private static IValidation GetValidation(int entryId)
        {
            var query = new GetByEntryIdQuery { EntryId = entryId };
            return new GetByEntryIdQueryValidation(query);
        }

        private class GetByEntryIdQuery : IGetByEntryIdQuery
        {
            public int EntryId { get; init; }

            public string Uri => throw new System.NotImplementedException();
        }
    }
}