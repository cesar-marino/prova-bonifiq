
namespace ProvaPub.Domain.Exceptions
{
    public class EntityValidationException(
        string? message = "Error validating entity",
        Exception? innerException = null) : DomainException("entity-validation", message, innerException)
    {
    }
}
