namespace Fpl.Client.Validation
{
    public interface IValidations
    {
        bool IsValid { get; }
        void Validate();
        IEnumerable<string> Messages { get; }
    }
}
