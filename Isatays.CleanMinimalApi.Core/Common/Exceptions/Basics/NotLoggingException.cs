﻿namespace Isatays.CleanMinimalApi.Core.Common.Exceptions.Basics;

/// <summary>Базовое исключение для ошибок не подлежащих логгированию</summary>
public abstract class NotLoggingException : DomainException
{
    /// <inheritdoc />
    protected NotLoggingException(string message) : base(message) { }

    /// <inheritdoc />
    protected NotLoggingException(string message, Exception ex) : base(message, ex) { }
}
