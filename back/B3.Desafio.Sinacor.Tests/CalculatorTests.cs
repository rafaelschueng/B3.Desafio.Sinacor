using B3.Desafio.Sinacor.Controllers.Response;
using B3.Desafio.Sinacor.Services;

namespace B3.Desafio.Sinacor.Tests;

public class CalculatorTests
{
    [Fact]
    public void CalculateCDI_ShouldRun()
    {
        decimal income = Calculator.CalculateCDI(10);
        decimal expectedResult = (decimal)10.972; 
        Assert.Equal(expectedResult, income, 2);
    }

    [Fact]
    public void CalculateCDITax_Less6MonthsTax_ShouldRun()
    {
        decimal initialValue = 10;
        decimal income = Calculator.CalculateCDI(10);
        decimal tax = Calculator.CalculateCdiTax(income, initialValue, 1);
        decimal expectedResult = (decimal)0.218;
        Assert.Equal(expectedResult, tax, 2);
    }

    [Fact]
    public void CalculateCDITax_More6MonthsTax_ShouldRun()
    {
        decimal initialValue = 10;
        decimal income = Calculator.CalculateCDI(10);
        decimal tax = Calculator.CalculateCdiTax(income, initialValue, 7);
        decimal expectedResult = (decimal)0.194;
        Assert.Equal(expectedResult, tax, 2);
    }

    [Fact]
    public void CalculateCDITax_More12MonthsTax_ShouldRun()
    {
        decimal initialValue = 10;
        decimal income = Calculator.CalculateCDI(10);
        decimal tax = Calculator.CalculateCdiTax(income, initialValue, 13);
        decimal expectedResult = (decimal)0.170;
        Assert.Equal(expectedResult, tax, 2);
    }

    [Fact]
    public void CalculateCDITax_More24MonthsTax_ShouldRun()
    {
        decimal initialValue = 10;
        decimal income = Calculator.CalculateCDI(10);
        decimal tax = Calculator.CalculateCdiTax(income, initialValue, 25);
        decimal expectedResult = (decimal)0.15;
        Assert.Equal(expectedResult, tax, 2);
    }

    [Fact]
    public void CalculateCdiBy10Months_ShouldRun()
    {
        decimal initialValue = 10;
        List<Incomes> incomes = Calculator.CalculateCDIByMonth(initialValue, 10).ToList();
        int expectedResult = 10;
        Assert.Equal(expectedResult, incomes.Count);
    }

    [Fact]
    public void CalculateCdiBy10Months_ShouldThrowException()
    {
        decimal initialValue = -10;
        Assert.Throws<ArgumentException>(() => Calculator.CalculateCDIByMonth(initialValue, 10));
    }


}