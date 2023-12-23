using Application.Models.Bills;
using Application.Models.Result;

namespace Application.Contracts.Bills;

public interface IBillService
{
    IEnumerable<Bill> GetClientBills(long clientId);

    Result<string> CreateBill(long clientId, int pinCode);

    Result<Bill?> FindBillById(long billId);

    Result<string> WithdrawMoney(long billId, int pinCode, decimal money);

    Result<string> PutMoney(long billId, decimal money);
}