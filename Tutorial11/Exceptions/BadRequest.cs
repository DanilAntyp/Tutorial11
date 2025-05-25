namespace Tutorial11.Exceptions;

public class BadRequest(string message) : Exception(message)
{ }