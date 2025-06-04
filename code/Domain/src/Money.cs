namespace Domain;

public readonly record struct Amount(int Amount, int Exponent);

public readonly record struct Currency(string IsoCode);

public sealed record Money(Amount Amount, Currency Currency);
