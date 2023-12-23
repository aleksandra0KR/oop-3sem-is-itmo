namespace Application.Models.Result;

public record Result<T>(ResultValues Type, T Data)
    where T : class?;