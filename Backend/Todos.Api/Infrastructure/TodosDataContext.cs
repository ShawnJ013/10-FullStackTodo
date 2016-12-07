using System;
using System.Collections.Generic;
using System.Data.Entity;
using Todos.Api.Models;
using System.Linq;
using System.Web;

namespace Todos.Api.Infrastructure
{
    public class TodosDataContext : DbContext
    {
        public TodosDataContext() : base("Todos")
            {

            }
            
            public IDbSet<Todo> Todos { get; set; }
    }
}