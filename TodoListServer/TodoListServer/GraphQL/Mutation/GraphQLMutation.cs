using HotChocolate;
using HotChocolate.Data;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using TodoListServer.Data;
using TodoListServer.GraphQL.Mutation.Input;
using TodoListServer.Models;

namespace TodoListServer.GraphQL.Mutation
{
    public class GraphQLMutation
    {
        private readonly IDbContextFactory<GraphQLDbContext> _contextFactory; 
        
        public GraphQLMutation(IDbContextFactory<GraphQLDbContext> contextFactory)
        {
            _contextFactory = contextFactory;
        }


        public TodoItem Create(CreateTodoItemInput todoItem)
        {
            using var context = _contextFactory.CreateDbContext();
            TodoItem data = new TodoItem { Title = todoItem.Title, CreatedAt = DateTime.Now, IsCompleted = false };
            context.TodoList.Add(data);
            context.SaveChanges();
            return data;
        }

        public TodoItem Update(TodoItem item)
        {
            using var context = _contextFactory.CreateDbContext();
            context.Update(item);
            context.SaveChanges();
            return item;
        }

        public TodoItem Delete(DeleteTodoItemInput todoItem)
        {
            using var context = _contextFactory.CreateDbContext();
            TodoItem data = new() { Id = todoItem.Id };
            context.TodoList.Remove(data);
            context.SaveChanges();
            return data;
        }
    }
}
