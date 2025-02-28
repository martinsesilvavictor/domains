using PaymentContext.Domain.Commands;
using PaymentContext.Domain.Entities;
using PaymentContext.Domain.Enums;
using PaymentContext.Domain.Handlers;
using PaymentContext.Domain.Queries;
using PaymentContext.Domain.ValueObjects;
using PaymentContext.Tests.Mooks;

namespace PaymentContext.Tests
{
  [TestClass]
  public class StudentQueriesTest
  {
    private IList<Student> _student;
    public StudentQueriesTest()
    {
      for (int i = 0; i <= 10; i++)
      {
        _student.Add(new Student(
            new Name("Aluno", i.ToString()),
            new Document("1111111111" + i.ToString(), EDocmentType.CPF), 
            new Email(i.ToString() + "@teste.com")
        ));
      }
    }

    [TestMethod]
    public void ShouldReturnNullWhenDocumentNotExists()
    {
      var exp = StudentQueries.GetStudentInfo("12345678911");
      var student = _student.AsQueryable().Where(exp).FirstOrDefault();

      Assert.AreEqual(null, student);
    }

    [TestMethod]
    public void ShouldReturnStudentWhenDocumentExists()
    {
      var exp = StudentQueries.GetStudentInfo("11111111111");
      var student = _student.AsQueryable().Where(exp).FirstOrDefault();

      Assert.AreNotEqual(null, student);
    }
  }
}