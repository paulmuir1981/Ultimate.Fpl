using Microsoft.Extensions.Logging;

namespace Fpl.Client.Validation
{
    public class Validations : List<IValidation>, IValidations
    {
        private readonly ILogger _logger;
        public Validations(IEnumerable<IValidation> collection, ILogger logger = null) : base(collection) 
        {
            _logger = logger;
        }

        public bool IsValid => this.All(v => v.IsValid);

        public void Validate()
        {
            _logger?.LogInformation($"{nameof(Validate)} invoked");
            if (!IsValid)
            {
                var exception = new ValidationException(string.Join(Environment.NewLine, Messages));
                _logger?.LogError(exception, "{message}", exception.Message);
                throw exception;
            }
        }

        public IEnumerable<string> Messages => this.Where(v => !v.IsValid).Select(v => v.Message);
    }
}