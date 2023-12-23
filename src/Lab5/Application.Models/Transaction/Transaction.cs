namespace Application.Models.Transaction;

public record Transaction(long Id, long BillId, int MoneyChanged);