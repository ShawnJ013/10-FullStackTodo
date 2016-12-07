using System.Data.Entity;
using System.Linq;
using System.Web.Http;
using Todos.Api.Infrastructure;
using Todos.Api.Models;

namespace Todos.Api.Controllers
{
    public class TodoesController : ApiController
    {
        private TodosDataContext db = new TodosDataContext();

        // GET: api/todos
        public IQueryable<Todo> GetAll()
        {
            
            return db.Todos;
        }

        // GET: api/todos/1
        public IHttpActionResult GetById(string id)
        {
            Todo t = db.Todos.Find(id);

            if(t == null)
            {
                return NotFound();
            }
            else
            {
                return Ok(t);
            }
        }
        // POST: api/todos
        public IHttpActionResult Create(Todo todo)
        {
            // Server side validation
            if (ModelState.IsValid == false)
            {
                return BadRequest(ModelState);
            }

           Todo copy = db.Todos.Add(todo);

            db.SaveChanges();

            return Ok(copy);
        }

        // PUT: api/todos/1
        public IHttpActionResult Update(int id, Todo todo)
        {
            if (ModelState.IsValid == false)
            {
                return BadRequest(ModelState);
            }

            db.Entry(todo).State = EntityState.Modified;
            db.SaveChanges();

            return Ok();
        }


        // DELETE: api/todos/1
        public IHttpActionResult Delete(int id)
        {
            var todo = db.Todos.Find(id);

            if (todo == null)
            {
                return NotFound();
            }
            else
            {

                db.Todos.Remove(todo);

                db.SaveChanges();

                return Ok(todo);
            }

        }

        protected override void Dispose(bool disposing)
        {
            db.Dispose();

            base.Dispose(disposing);
        }
    }
}
