namespace ClassLibrary1Infrastructure.DataAccess;

public class ValueException : Exception
{
  public ValueException()
      { }

  public ValueException(string message)
          : base(message + "can't be null")
      { }

  public ValueException(string message, int val)
          : base(message)
      {
          Value = val;
      }

  public ValueException(string message, ValueException innerValueException)
          : base(message, innerValueException)
      { }
  public ValueException(string message, Exception innerException)
        : base(message, innerException)
  {
  }

  public int Value { get; }
}