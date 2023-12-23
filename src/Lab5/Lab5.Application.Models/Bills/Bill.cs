namespace Lab5.Application.Models;

public record Bill(long Id, long ClientId, decimal Money, int PinCode);