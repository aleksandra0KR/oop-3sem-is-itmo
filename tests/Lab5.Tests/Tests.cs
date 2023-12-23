using Application.Bills;
using Application.Models.Bills;
using Application.Models.Result;
using Itmo.ObjectOrientedProgramming.Lab5.Repositories;
using NSubstitute;
using Xunit;

namespace Itmo.ObjectOrientedProgramming.Lab5.Tests;

public class Tests
{
    private readonly IBillRepository _billRepository;
    private readonly BillService _billService;

    public Tests()
    {
        _billRepository = Substitute.For<IBillRepository>();
        ILogRepository logRepository = Substitute.For<ILogRepository>();
        _billService = new BillService(_billRepository, logRepository);
    }

    [Fact]
    public void WithdrawMoneyTest()
    {
        var bill = new Bill(10, 10, 1000, 10);
        _billRepository.FindBillById(10).Returns(bill);

        Result<string> result = _billService.WithdrawMoney(10, 10, 100);
        _billRepository.Received(1).UpdateBill(bill with { Money = 900 });

        Assert.Equal(ResultValues.Success, result.Type);
    }

    [Fact]
    public void WithdrawMoneyNegativeTest()
    {
        var bill = new Bill(10, 10, 100, 10);
        _billRepository.FindBillById(10).Returns(bill);

        Result<string> result = _billService.WithdrawMoney(10, 10, 1000);
        _billRepository.DidNotReceiveWithAnyArgs().UpdateBill(Arg.Any<Bill>());

        Assert.Equal(ResultValues.NotFound, result.Type);
    }

    [Fact]
    public void PutMoneyTest()
    {
        var bill = new Bill(10, 10, 0, 10);
        _billRepository.FindBillById(10).Returns(bill);

        Result<string> result = _billService.PutMoney(10, 100);
        _billRepository.Received(1).UpdateBill(bill with { Money = 100 });

        Assert.Equal(ResultValues.Success, result.Type);
    }
}