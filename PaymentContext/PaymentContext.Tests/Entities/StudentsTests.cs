using Microsoft.VisualStudio.TestTools.UnitTesting;
using PaymentContext.Domain.Entities;

namespace PaymentContext.Tests
{
  [TestClass]
  public class StudentTests
  {
    [TestMethod]
    public void AdicionarAssinatura()
    {
      var subscription = new Subscription(null);
      var student = new Student("Teste", "Testando", "135151524534", "teste@teste.com");

      student.AddSubscription(subscription);
    }
  }
}