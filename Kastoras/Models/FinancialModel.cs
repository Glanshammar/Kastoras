using System;
using System.Collections.ObjectModel;
using System.Drawing;
using System.ComponentModel.DataAnnotations;
using Kastoras.Enums;
using ReactiveUI;

namespace Kastoras.Models;

public class Account : ReactiveObject
{
    public int Id { get; set; }
    
    [Required]
    public string Name { get; set; }
    
    [Required]
    public decimal Balance { get; set; }
    
    [Required]
    public string Currency { get; set; }
    
    public string PlaidId { get; set; }
    public decimal TotalIncome { get; set; }
    public decimal TotalExpenses { get; set; }
    public decimal DebtProgress { get; set; }
    public decimal TotalDebt { get; set; }
}

public class Transaction : ReactiveObject
{
    public int Id { get; set; }
    public decimal Amount { get; set; }
    public string Description { get; set; }
    public DateTime Date { get; set; }
    public string CategoryId { get; set; }
    public string AccountId { get; set; }
    public string Currency { get; set; }
    public bool IsRecurring { get; set; }
    public string RecurringPaymentId { get; set; }
    public bool IsTaxDeductible { get; set; }
}

public class Category : ReactiveObject
{
    public int Id { get; set; }
    public string Name { get; set; }
    public CategoryType Type { get; set; } // Income/Expense
    public string Icon { get; set; }
    public Color Color { get; set; }
}

public class Budget : ReactiveObject
{
    public int Id { get; set; }
    public string CategoryId { get; set; }
    public decimal Limit { get; set; }
    public TimeSpan Period { get; set; } // Monthly, Weekly, etc
    public decimal CurrentSpending { get; set; }
}

public class FinancialReport
{
    public int Id { get; set; }
    public ReportType Type { get; set; }
    public DateTime StartDate { get; set; }
    public DateTime EndDate { get; set; }
    public ObservableCollection<ReportDataPoint> Data { get; set; }
}

public class Forecast
{
    public int Id { get; set; }
    public ForecastType Type { get; set; }
    public DateTime StartDate { get; set; }
    public DateTime EndDate { get; set; }
    public ObservableCollection<Projection> Projections { get; set; }
}

public class RecurringPayment
{
    public int Id { get; set; }
    public string Name { get; set; }
    public decimal Amount { get; set; }
    public DateTime NextDueDate { get; set; }
    public PaymentInterval Interval { get; set; }
}

public class SavingsGoal
{
    public int Id { get; set; }
    public string Name { get; set; }
    public decimal TargetAmount { get; set; }
    public decimal CurrentAmount { get; set; }
    public DateTime TargetDate { get; set; }
}

public class Debt
{
    public int Id { get; set; }
    public string Name { get; set; }
    public decimal TotalAmount { get; set; }
    public decimal InterestRate { get; set; }
    public PaymentStrategy Strategy { get; set; }
    public ObservableCollection<PaymentSchedule> PaymentSchedule { get; set; }
}

public class Investment
{
    public int Id { get; set; }
    public string Symbol { get; set; }
    public decimal Quantity { get; set; }
    public decimal CurrentPrice { get; set; }
    public InvestmentType Type { get; set; }
}

public class NetWorth
{
    public int Id { get; set; }
    public DateTime Date { get; set; }
    public decimal Assets { get; set; }
    public decimal Liabilities { get; set; }
    public decimal NetValue => Assets - Liabilities;
}

public class TaxCategory
{
    public int Id { get; set; }
    public string Name { get; set; }
    public decimal DeductibleAmount { get; set; }
    public TaxYear Year { get; set; }
}

public class ReportDataPoint
{
    public int Id { get; set; }
    public string Label { get; set; }
    public decimal Value { get; set; }
    public DateTime Date { get; set; }
}

public class Projection
{
    public int Id { get; set; }
    public DateTime Date { get; set; }
    public decimal ProjectedValue { get; set; }
    public decimal ConfidenceInterval { get; set; }
}

public class PaymentSchedule
{
    public int Id { get; set; }
    public DateTime DueDate { get; set; }
    public decimal AmountDue { get; set; }
    public bool IsPaid { get; set; }
}