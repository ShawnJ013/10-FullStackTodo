using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace Todos.Api.Models
{
    public class Todo
    {
        // Properties
        public int Id { get; set; }
        public string Name { get; set; }
        public string Priority { get; set; }

    }
}