
using PaymentContext.Domain.Enums;
using PaymentContext.Domain.ValueObjects;

namespace PaymentContext.Tests
{
  [TestClass]
  public class DocumentTests
  {
    [TestMethod]
    public void ShouldReturnErrorWhenCNPJIsInvalid()
    {
      var doc = new Document("123", EDocmentType.CNPJ);
      Assert.IsTrue(!doc.IsValid);
    }

    [TestMethod]
    public void ShouldReturnSuccessWhenCNPJIsValid()
    {
      var doc =  new Document("83108193000126", EDocmentType.CNPJ);
      Assert.IsTrue(doc.IsValid);
    }

    [TestMethod]
    public void ShouldReturnErrorWhenCPFIsInvalid()
    {
      var doc =  new Document("123", EDocmentType.CPF);
      Assert.IsTrue(!doc.IsValid);
    }

    [TestMethod]
    public void ShouldReturnSuccessWhenCPFIsValid()
    {
      var doc = new Document("15749136701", EDocmentType.CPF);
      Assert.IsTrue(doc.IsValid);
    }
  }
}