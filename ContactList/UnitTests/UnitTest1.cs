using Microsoft.VisualStudio.TestTools.UnitTesting;
using ContactList;
using System.Collections.Generic;
using Microsoft.AspNetCore.Mvc;

namespace UnitTests
{
    [TestClass]
    public class UnitTest1
    {
        [TestMethod]
        public void GetAllContacts()
        {
            var testPersons = GetTestPersons();
            var controller = new PersonController();

            var result = (List<Person>)(controller.Get() as OkObjectResult).Value;
            Assert.AreEqual(testPersons.Count, result.Count);
        }

        [TestMethod]
        public void GetPerson_ShouldFindPerson() {
            var controller = new PersonController();
            var result = (List<Person>)(controller.Get() as OkObjectResult).Value;


        }

        [TestMethod]
        public void GetPerson_ShouldNotFindPerson()
        {
            var controller = new PersonController();

            var result = controller.Delete(999);
            Assert.IsInstanceOfType(result, typeof(NotFoundObjectResult));
        }
        private List<Person> GetTestPersons()
        {
           var testPersons = new List<Person>();
           testPersons.Add(new Person(0, "Lukas", "Juster", "lukas.juster@gmail.com"));
           testPersons.Add(new Person(1, "Wolfgang", "Bauer", "wolf.bauer@gmail.com"));
           testPersons.Add(new Person(2, "Philipp", "Gusenleitner", "ph.gus@gmail.com"));
            return testPersons; 
        }
    }
}
