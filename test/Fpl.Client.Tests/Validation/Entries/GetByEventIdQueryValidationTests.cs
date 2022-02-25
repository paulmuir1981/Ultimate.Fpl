using Fpl.Client.Queries.Entries;
using Fpl.Client.Validation;
using Fpl.Client.Validation.Entries;
using Xunit;

namespace Fpl.Client.Tests.Validation.Entries
{
    public class GetByEventIdQueryValidationTests
    {
        [Fact]
        public void GetByEventIdQueryValidation_Validate_True_ReturnsOK()
        {
            for (int entryId = 1; entryId <= 38; entryId++)
            {
                var validation = GetValidation(entryId);

                validation.Validate();

                Assert.True(validation.IsValid);
            }
        }

        [Theory]
        [InlineData(int.MinValue)]
        [InlineData(-2)]
        [InlineData(-1)]
        [InlineData(0)]
        [InlineData(39)]
        [InlineData(40)]
        [InlineData(int.MaxValue)]
        public void GetByEventIdQueryValidation_Validate_False_ThrowsValidationException(int entryId)
        {
            var expectedMessage = "EventId must be between 1 and 38";
            var validation = GetValidation(entryId);

            var exception = Assert.Throws<ValidationException>(() => validation.Validate());

            Assert.Equal(expectedMessage, exception.Message);
            Assert.Equal(expectedMessage, validation.Message);
            Assert.False(validation.IsValid);
        }

        private static IValidation GetValidation(int eventId)
        {
            var query = new GetByEventIdQuery { EventId = eventId };
            return new GetByEventIdQueryValidation(query);
        }

        private class GetByEventIdQuery : IGetByEventIdQuery
        {
            public int EventId { get; init; }

            public string Uri => throw new System.NotImplementedException();
        }
    }
}