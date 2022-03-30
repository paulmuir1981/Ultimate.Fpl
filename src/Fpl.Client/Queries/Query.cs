using System.ComponentModel.DataAnnotations;

namespace Fpl.Client.Queries
{
    public abstract class Query<TResponse> : IQuery<TResponse>
    {
        private const string UriBase = "https://fantasy.premierleague.com/api/";
        public virtual string Uri => UriBase;
        public void Validate()
        {
            Validator.ValidateObject(this, new ValidationContext(this), true);
        }
    }
}