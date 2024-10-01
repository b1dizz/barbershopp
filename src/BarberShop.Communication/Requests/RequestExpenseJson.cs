﻿using BarberShop.Communication.Enums;

namespace BarberShop.Communication.Requests;

public class RequestExpenseJson
{
    public string Title { get; set; } = String.Empty;
    public string Description { get; set; } = String.Empty;
    public DateTime Date { get; set; }
    public decimal Amount { get; set; }
    public PaymentType PaymentType { get; set; }
}
