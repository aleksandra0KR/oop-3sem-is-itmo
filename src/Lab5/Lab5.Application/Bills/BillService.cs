using Application.Contracts.Bills;
using Application.Models.Bills;
using Application.Models.Result;
using Itmo.ObjectOrientedProgramming.Lab3;
using Itmo.ObjectOrientedProgramming.Lab5.Repositories;

namespace Application.Bills;

public class BillService : IBillService
{
    private readonly IBillRepository _billRepository;
    private readonly ILogRepository _logRepository;

    public BillService(IBillRepository clientRepository, ILogRepository logRepository)
    {
        _billRepository = clientRepository ?? throw new ValueException("ClientRepository can't be null");
        _logRepository = logRepository ?? throw new ValueException("LogRepository can't be null");
    }

    public IEnumerable<Bill> GetClientBills(long clientId)
    {
        return _billRepository.GetClientBills(clientId);
    }

    public Result<string> CreateBill(long clientId, int pinCode)
    {
        _billRepository.AddBill(clientId, pinCode);
        return new Result<string>(ResultValues.Success, "Success");
    }

    public Result<Bill?> FindBillById(long billId)
    {
        Bill? bill = _billRepository.FindBillById(billId);
        return bill is null ? new Result<Bill?>(ResultValues.NotFound, bill) : new Result<Bill?>(ResultValues.Success, bill);
    }

    public Result<string> WithdrawMoney(long billId, int pinCode, decimal money)
    {
        Bill? bill = _billRepository.FindBillById(billId);

        if (bill is null)
        {
            return new Result<string>(ResultValues.NotFound, "Account not found");
        }

        if (pinCode != bill.PinCode)
        {
            throw new ValueException("Wrong password");
        }

        if (bill.Money < money)
        {
            return new Result<string>(ResultValues.NotFound, "Not enough money");
        }

        Bill afterTransactionBill = bill with { Money = bill.Money - money };
        _logRepository.AddTransaction(billId, -money);
        _billRepository.UpdateBill(afterTransactionBill);

        return new Result<string>(ResultValues.Success, "Successfully given money");
    }

    public Result<string> PutMoney(long billId, decimal money)
    {
        Bill? bill = _billRepository.FindBillById(billId) ?? throw new ValueException("Empty bill");

        Bill afterTransactionBill = bill with { Money = bill.Money + money };
        _logRepository.AddTransaction(billId, money);
        _billRepository.UpdateBill(afterTransactionBill);

        return new Result<string>(ResultValues.Success, "Successfully added money");
    }
}