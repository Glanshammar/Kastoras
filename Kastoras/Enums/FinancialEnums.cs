namespace Kastoras.Enums;

public enum CategoryType
{
    Income,
    Expense
}

public enum ReportType
{
    IncomeStatement,
    BalanceSheet,
    CashFlow,
    SpendingByCategory
}

public enum ForecastType
{
    ShortTerm,
    LongTerm,
    ScenarioBased
}

public enum PaymentInterval
{
    Daily,
    Weekly,
    BiWeekly,
    Monthly,
    Quarterly,
    Yearly
}

public enum PaymentStrategy
{
    Snowball,
    Avalanche,
    Custom
}

public enum InvestmentType
{
    Stock,
    MutualFund,
    ETF,
    Crypto,
    Bond,
    RealEstate
}

public enum TaxYear
{
    Current,
    Previous,
    Next
}