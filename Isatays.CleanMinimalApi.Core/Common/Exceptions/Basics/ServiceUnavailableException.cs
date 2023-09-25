namespace Isatays.CleanMinimalApi.Core.Common.Exceptions.Basics;

public abstract class ServiceUnavailableException : InfrastructureException
{
    /// <inheritdoc />
    protected ServiceUnavailableException(string method) : base(method) { }

    /// <inheritdoc />
    protected ServiceUnavailableException(string method, Exception ex) : base(method, ex) { }
}
