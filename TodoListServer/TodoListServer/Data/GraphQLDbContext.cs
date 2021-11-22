using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using TodoListServer.Models;
namespace TodoListServer.Data
{
    public class GraphQLDbContext : DbContext
    {
        public GraphQLDbContext(DbContextOptions<GraphQLDbContext> options) : base(options)
        {

        }

        public DbSet<TodoItem> TodoList { get; set; }
    }
}
