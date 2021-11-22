using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace TodoListServer.Models
{
    public class TodoItem
    {
        public int Id { get; set; }

        public string Title { get; set; }

        public DateTime CreatedAt { get; set; }

        public bool IsCompleted { get; set; }
    }
}
