using Domain.Common.Exceptions;

namespace Domain.Catalog.Exceptions.Authors
{
    public class InvalidAuthorException : BaseDomainException
    {
        public InvalidAuthorException() { }
        public InvalidAuthorException(string error) => this.Error = error;
    }
}
