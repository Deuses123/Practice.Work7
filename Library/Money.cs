using Newtonsoft.Json;

namespace Practice.Work7;

using System;

public class Money
{
    public decimal Amount { get; }
    public string Currency { get; }

    public Money(decimal amount, string currency)
    {
        Amount = amount;
        Currency = currency;
    }

    public static Money operator +(Money money1, Money money2)
    {
        if (money1.Currency == money2.Currency)
        {
            return new Money(money1.Amount + money2.Amount, money1.Currency);
        }
        else
        {
            // Используем CurrencyConverter для конвертации
            decimal convertedAmount = CurrencyConverter.Convert(money2, money1.Currency).Result;
            return new Money(money1.Amount + convertedAmount, money1.Currency);
        }
    }

    public static bool operator ==(Money money1, Money money2)
    {
        if (ReferenceEquals(money1, money2))
            return true;

        if (money1 is null || money2 is null)
            return false;

        if (money1.Currency != money2.Currency)
        {
            // Используем CurrencyConverter для сравнения в одной валюте
            decimal convertedAmount = CurrencyConverter.Convert(money2, money1.Currency).Result;
            return money1.Amount == convertedAmount;
        }

        return money1.Amount == money2.Amount;
    }

    public static bool operator !=(Money money1, Money money2)
    {
        return !(money1 == money2);
    }
    public override string ToString()
    {
        return "Ammount: "+Amount + "Currency: " + Currency;
    }
}

class CurrencyConverter
{
    public static async Task<decimal> Convert(Money money, string targetCurrency)
    {
        HttpClient httpClient = new();
        var res = httpClient.GetAsync("https://api.twelvedata.com/currency_conversion?&symbol="
                            + money.Currency + "/" + targetCurrency + "&apikey=539699fdd3604522bb5532f7d9cf30ee");
        string jsonContent = await res.Result.Content.ReadAsStringAsync();

        var conversionResponse = JsonConvert.DeserializeObject<ConversionResponse>(jsonContent);

        decimal rate = conversionResponse!.rate;
        return (rate*money.Amount);
    }

   
}

class ConversionResponse
{
    public decimal rate { get; set; }
}