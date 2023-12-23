namespace Application.Models.Bills;

public record Bill(long Id, long UserId, decimal Money, int PinCode);