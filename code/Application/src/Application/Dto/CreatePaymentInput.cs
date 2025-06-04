namespace Application.Dto;

public readonly record struct CreatePaymentInput(int AmountValue, int Exponent, string Currency);