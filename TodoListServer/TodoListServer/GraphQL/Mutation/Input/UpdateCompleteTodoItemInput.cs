using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace TodoListServer.GraphQL.Mutation.Input
{
    public class UpdateCompleteTodoItemInput
    {
        public bool IsCompleted { get; set; }
    }
}
