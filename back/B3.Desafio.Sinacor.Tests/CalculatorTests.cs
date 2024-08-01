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
    public void CalculateCDITax_SixMonthsTax_ShouldRun()
    {
        decimal initialValue = 10;
        decimal income = Calculator.CalculateCDI(10);
        decimal tax = Calculator.CalculateCdiTax(income, initialValue, 1);
        decimal expectedResult = (decimal)0.218;
        Assert.Equal(expectedResult, tax, 2);
    }


}