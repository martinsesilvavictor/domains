using PaymentContext.Domain.Commands;
using PaymentContext.Domain.Enums;
using PaymentContext.Domain.Handlers;
using PaymentContext.Tests.Mooks;

namespace PaymentContext.Tests
{
  [TestClass]
  public class SubscriptionHandlerTests
  {
    [TestMethod]
    public void ShouldReturnErrorWhenDocumentExist()
    {
      var handler = new SubscriptionHandler(new FakeStudentRepository(), new FakeEmailService());
      var command = new CreateBoletoSubscriptionCommand();

      command.FirstName = "Mario";
      command.LastName = "Bros";
      command.Document = "11111111111";
      command.Email = "mario@teste.com";
      command.BarCode = "1234567";
      command.BoletoNumber = "1234567";
      command.PaymentNumber = "1234569";
      command.PaidDate = DateTime.Now;
      command.ExpireDate = DateTime.Now.AddMonths(1);
      command.Total = 60;
      command.TotalPaid = 60;
      command.Payer = "Nintendo";
      command.PayerDocument = "12356799";
      command.PaymentDocumentType = EDocmentType.CPF;
      command.PayerEmail = "bros@nintendo.com";
      command.Street = "fdsafs";
      command.Number = "sdf";
      command.Neighborhood = "sdafasdf";
      command.City = "dsfdfs";
      command.State = "sdffsdaf";
      command.Country = "sf";
      command.ZipCode = "1234467";

      handler.Handle(command);
      Assert.AreEqual(false, handler.IsValid);
    }
  }
}