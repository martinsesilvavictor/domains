using Flunt.Notifications;
using Flunt.Validations;
using PaymentContext.Shared.ValueObjects;

namespace PaymentContext.Domain.ValueObjects
{
  public class Address : ValueObject
  {
    public Address(string street, string number, string neighbor, string city, string state, string country, string zipCode)
    {
      Street = street;
      Number = number;
      Neighbor = neighbor;
      City = city;
      State = state;
      Country = country;
      ZipCode = zipCode;

       AddNotifications(new Contract<Notification>()
          .Requires()
          .IsGreaterThan(Street, 3, "Address.Street", "A rua deve conter mais de 3 caracteres!")
          .AreNotEquals(ZipCode, 8, "Address.ZipCode", "O cep deve conter 8 caracteres!")
      );
    }

    public string Street { get; set; }
    public string Number { get; set; }
    public string Neighbor { get; set; }
    public string City { get; set; }
    public string State { get; set; }
    public string Country { get; set; }
    public string ZipCode { get; set; }
  }
}