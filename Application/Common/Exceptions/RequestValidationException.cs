using FluentValidation.Results;

namespace Application.Common.Exceptions
{
    public class RequestValidationException : Exception
    {
        public RequestValidationException() 
            : base("One or more")
            => this.Errors = new Dictionary<string, string[]>();

        public RequestValidationException(IEnumerable<ValidationFailure> errors)
        : this()
        {
            var failureGroups = errors
                .GroupBy(e => e.PropertyName, e => e.ErrorMessage);

            foreach (var failureGroup in failureGroups)
            {
                var propertyName = failureGroup.Key;
                var propertyFailures = failureGroup.ToArray();

                this.Errors.Add(propertyName, propertyFailures);
            }
        }

        public IDictionary<string, string[]> Errors { get;}
        
    }
}
