using HotChocolate;
using HotChocolate.Data;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using TodoListServer.Data;
using TodoListServer.Models;


namespace TodoListServer.GraphQL.Query
{
    public class GraphQLQuery
    {

        [UseDbContext(typeof(GraphQLDbContext))]
        
        public IQueryable<TodoItem> GetTodoList([ScopedService] GraphQLDbContext context) =>
            context.TodoList;

    }
}
