using Microsoft.Extensions.Logging;

namespace Fpl.Client.Validation
{
    public abstract class Validation<T> : IValidation where T : class
    {
        protected T Context { get; private set; }
        private readonly ILogger _logger;

        protected Validation(T context, ILogger logger = null)
        {
            Context = context ?? throw new ArgumentNullException(nameof(context));
            _logger = logger;
        }

        public void Validate()
        {
            _logger?.LogInformation($"{nameof(Validate)} invoked");
            if (!IsValid)
            {
                var exception = new ValidationException(Message);
                _logger?.LogError(exception, "{message}", exception.Message);
                throw exception;
            }
        }

        public abstract bool IsValid { get; }
        public abstract string Message { get; }
    }
}
