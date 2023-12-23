namespace Application.Contracts.Results;

public record Result<T>(ResultValues Type, T Data)
    where T : class?;