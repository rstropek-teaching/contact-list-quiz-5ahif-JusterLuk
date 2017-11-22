using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System.Collections;

namespace ContactList
{
    [Route("api/contacts")]
    public class PersonController : Controller
    {
         public static List<Person> persons = new List<Person> {new Person(0, "Lukas", "Juster","lukas.juster@gmail.com"), new Person(1, "Wolfgang", "Bauer", "wolf.bauer@gmail.com"), new Person(2, "Philipp", "Gusenleitner", "ph.gus@gmail.com") };
        // GET: api/contacts
 

        [HttpGet]
        public IActionResult Get()
        {

            return Ok(persons); //How do you give the User a Message with the Status Code like "Successful Operation"?
        }

        // GET: api/contacts/Name
        [HttpGet("findByName/{nameFilter}", Name = "Get")]
        public IActionResult Get(string nameFilter)
        {
            // var temp = new List
            var res = persons.Where(p => p.FirstName.Contains(nameFilter) || p.LastName.Contains(nameFilter));
            if (res.Count() == 0)
            {
                return BadRequest("Invalid or missing name!");
            }
            else
            {
                return Ok(res);
            }
        }

        // POST: api/Person
        [HttpPost]
        public IActionResult Post([FromBody]Person pers)
        {
            persons.Add(pers);
            return Created("GetPerson", "Person was sucessfully created!"); //Which URI should be used? (First Argument)
        }

        // DELETE: api/contacts/{id}
        [HttpDelete("{id}")]
        public IActionResult Delete(int id)
        {
            if (id <= 0 && id > persons.Count)
            {
                return BadRequest("Invalid ID supplied");
            }

            var res = persons.Where(p => p.Id == id);

            if (res.Count() == 0)
            {
                return NotFound("Person not found");
            }
            else
            {
                persons.RemoveAt(id);
                return StatusCode(204, "Successful Operation");
            }



        }
    }
}
