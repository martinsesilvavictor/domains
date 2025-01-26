using Flunt.Notifications;
using Flunt.Validations;
using PaymentContext.Domain.Enums;
using PaymentContext.Shared.ValueObjects;

namespace PaymentContext.Domain.ValueObjects
{
  public class Document : ValueObject
  {
    public Document(string number, EDocmentType type){
      Number = number;
      Type = type;

      AddNotifications(new Contract<Notification>()
        .Requires()
        .IsTrue(Validate(), "Document.Number", "O documento é inválido!")
      );
    }

    public string Number {get; private set;}
    public EDocmentType Type { get; set; }

    private bool Validate(){
      if(Type == EDocmentType.CNPJ && Number.Length == 14)
        return true;
      if(Type == EDocmentType.CPF && Number.Length == 11)
        return true;
      
      return false;
    }
  }
}