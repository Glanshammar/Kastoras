using System;
using System.Collections.ObjectModel;
using System.Drawing;
using System.ComponentModel.DataAnnotations;
using Kastoras.Enums;
using ReactiveUI;

namespace Kastoras.Models;

public class FinancialSummary : ReactiveObject
{
    [Key]
    public decimal TotalIncome { get; set; }
    public decimal TotalExpenses { get; set; }
    public decimal DebtProgress { get; set; }
    public decimal TotalDebt { get; set; }
}

// Transaction.cs
public class Transaction : ReactiveObject
{
    [Key]
    public string Id { get; set; }
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

// Category.cs
public class Category : ReactiveObject
{
    [Key]
    public string Id { get; set; }
    public string Name { get; set; }
    public CategoryType Type { get; set; } // Income/Expense
    public string Icon { get; set; }
    public Color Color { get; set; }
}

// Budget.cs
public class Budget : ReactiveObject
{
    [Key]
    public string Id { get; set; }
    public string CategoryId { get; set; }
    public decimal Limit { get; set; }
    public TimeSpan Period { get; set; } // Monthly, Weekly, etc
    public decimal CurrentSpending { get; set; }
}

// FinancialReport.cs
public class FinancialReport
{
    public ReportType Type { get; set; }
    public DateTime StartDate { get; set; }
    public DateTime EndDate { get; set; }
    public ObservableCollection<ReportDataPoint> Data { get; set; }
}

// Forecast.cs
public class Forecast
{
    public ForecastType Type { get; set; }
    public DateTime StartDate { get; set; }
    public DateTime EndDate { get; set; }
    public ObservableCollection<Projection> Projections { get; set; }
}

// RecurringPayment.cs
public class RecurringPayment
{
    public string Name { get; set; }
    public decimal Amount { get; set; }
    public DateTime NextDueDate { get; set; }
    public PaymentInterval Interval { get; set; }
}

// SavingsGoal.cs
public class SavingsGoal
{
    public string Name { get; set; }
    public decimal TargetAmount { get; set; }
    public decimal CurrentAmount { get; set; }
    public DateTime TargetDate { get; set; }
}

// Debt.cs
public class Debt
{
    public string Name { get; set; }
    public decimal TotalAmount { get; set; }
    public decimal InterestRate { get; set; }
    public PaymentStrategy Strategy { get; set; }
    public ObservableCollection<PaymentSchedule> PaymentSchedule { get; set; }
}

// Investment.cs
public class Investment
{
    public string Symbol { get; set; }
    public decimal Quantity { get; set; }
    public decimal CurrentPrice { get; set; }
    public InvestmentType Type { get; set; }
}

// NetWorth.cs
public class NetWorth
{
    public DateTime Date { get; set; }
    public decimal Assets { get; set; }
    public decimal Liabilities { get; set; }
    public decimal NetValue => Assets - Liabilities;
}

// TaxCategory.cs
public class TaxCategory
{
    public string Name { get; set; }
    public decimal DeductibleAmount { get; set; }
    public TaxYear Year { get; set; }
}

// Models/ReportDataPoint.cs
public class ReportDataPoint
{
    public string Label { get; set; }
    public decimal Value { get; set; }
    public DateTime Date { get; set; }
}

// Models/Projection.cs
public class Projection
{
    public DateTime Date { get; set; }
    public decimal ProjectedValue { get; set; }
    public decimal ConfidenceInterval { get; set; }
}

// Models/PaymentSchedule.cs
public class PaymentSchedule
{
    public DateTime DueDate { get; set; }
    public decimal AmountDue { get; set; }
    public bool IsPaid { get; set; }
}