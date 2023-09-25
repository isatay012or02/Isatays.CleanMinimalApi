namespace Isatays.CleanMinimalApi.Core.Common.Exceptions.Basics;

public abstract class InfrastructureException : Exception
{
    /// <inheritdoc />
    public InfrastructureException(string method) : base(method) { }

    /// <inheritdoc />
    public InfrastructureException(string method, Exception ex) : base(method, ex) { }
}
