using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace TodoListServer.GraphQL.Mutation.Input
{
    public class DeleteTodoItemInput
    {
        public int Id { get; set; }
    }
}
