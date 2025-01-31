using Microsoft.VisualStudio.TestTools.UnitTesting;
using PaymentContext.Domain.Entities;
using PaymentContext.Domain.Enums;
using PaymentContext.Domain.ValueObjects;

namespace PaymentContext.Tests
{
  [TestClass]
  public class StudentTests
  {
    private readonly Name _name;
    private readonly Document _document;
    private readonly Address _address;
    private readonly Email _email;
    private readonly Student _student;
    private readonly Subscription _subscription;

    public StudentTests()
    {
      _name = new Name("Thiago", "Martins");
      _document = new Document("14391243024", EDocmentType.CPF);
      _email = new Email("martins@gmail.com");
      _address = new Address("Rua Augusto", "29", "Bairro Lapa", "Rio de Janeiro", "RJ", "Brasil", "20231250");
      _student = new Student(_name, _document, _email);
      _subscription =  new Subscription(null);
    }

    [TestMethod]
    public void ShouldReturnErrorWhenHadActiveSubscription()
    {
      var payment = new PayPalPayment("12345678",DateTime.Now, DateTime.Now.AddDays(5), 10, 10, _document,"While Inc", _address, _email);
      
      _subscription.AddPayment(payment);

      _student.AddSubscription(_subscription);
      _student.AddSubscription(_subscription);

      Assert.IsTrue(!_student.IsValid);
    }

    [TestMethod]
    public void ShouldReturnErrorWhenSubscriptionHasNoPayment()
    {
      _student.AddSubscription(_subscription);
      Assert.IsTrue(!_student.IsValid);
    }

    [TestMethod]
    public void ShouldReturnSuccessWhenAddSubscription()
    {
      var payment = new PayPalPayment("12345678",DateTime.Now, DateTime.Now.AddDays(5), 
                                      10, 10, _document,"While Inc", _address, _email);
      
      _subscription.AddPayment(payment);
      _student.AddSubscription(_subscription);

      Assert.IsTrue(_student.IsValid);
    }
  }
}