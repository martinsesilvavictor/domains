using Flunt.Notifications;
using Flunt.Validations;
using PaymentContext.Shared.ValueObjects;

namespace PaymentContext.Domain.ValueObjects
{
  public class Name : ValueObject
  {
    public Name (string firstName, string lastName)
    {
      FirstName = firstName;
      LastName = lastName;

      AddNotifications(new Contract<Notification>()
          .Requires()
          .IsGreaterThan(FirstName, 3, "FirstName", "O primeiro nome deve ter no minimo 3 caracteres")
          .IsGreaterThan(LastName, 3, "LastName", "O sobrenome deve ter no minimo 3 caracteres")
          .IsLowerThan(FirstName, 40, "FirstName", "O primeiro nome deve ter no máximo 40 caracteres")
      );
    }

    public string FirstName { get; private set; }
    public string LastName { get; private set; }
  }
}