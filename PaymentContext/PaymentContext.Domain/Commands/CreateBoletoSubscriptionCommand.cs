using System.Diagnostics.Contracts;
using Flunt.Notifications;
using Flunt.Validations;
using PaymentContext.Domain.Enums;
using PaymentContext.Shared.Commands;

namespace PaymentContext.Domain.Commands
{
  public class CreateBoletoSubscriptionCommand : Notifiable<Notification>, ICommand
  {
    public string FirstName { get; set; }
    public string LastName { get; set; }
    public string Document { get; set; }
    public string Email { get; set; }

    public string BarCode { get; set; }
    public string BoletoNumber { get; set; }

    public string PaymentNumber { get; set; }
    public DateTime PaidDate { get; set; }
    public DateTime ExpireDate { get; set; }
    public decimal Total { get; set; }
    public decimal TotalPaid { get; set; }
    public string Payer { get; set; }
    public string PayerDocument { get; set; }
    public EDocmentType PaymentDocumentType { get; set; }
    public string PayerEmail { get; set; }

    public string Street { get; set; }
    public string Number { get; set; }
    public string Neighborhood { get; set; }
    public string City { get; set; }
    public string State { get; set; }
    public string Country { get; set; }
    public string ZipCode { get; set; }

    public void Validate()
    {
      AddNotifications(new Contract<Notification>()
          .Requires()
          .IsGreaterThan(FirstName, 3, "FirstName", "O primeiro nome deve ter no minimo 3 caracteres")
          .IsGreaterThan(LastName, 3, "LastName", "O sobrenome deve ter no minimo 3 caracteres")
          .IsLowerThan(FirstName, 40, "FirstName", "O primeiro nome deve ter no máximo 40 caracteres")
      );
    }
  }
}