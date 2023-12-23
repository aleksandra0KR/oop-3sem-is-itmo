using Application.Models.Bills;
using Application.Models.Result;

namespace Itmo.ObjectOrientedProgramming.Lab5.Repositories;

public interface IBillRepository
{
    IEnumerable<Bill> GetClientBills(long clientId);
    Bill? FindBillById(long id);
    Result<string> AddBill(long clientId, int pinCode);
    Bill? UpdateBill(Bill bill);
    Result<string> DeleteBillById(long id);
}