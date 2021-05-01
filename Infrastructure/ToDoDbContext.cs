using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace TodoList.Infrastructure
{
    public class ToDoDbContext : DbContext, IUnitOfWork
    {
        public ToDoDbContext( DbContextOptions<ToDoDbContext> options )
            : base (options)
        { }

        void IUnitOfWork.Commit()
        {
            this.SaveChanges();
        }

        protected override void OnModelCreating( ModelBuilder modelBuilder )
        {
            modelBuilder.ApplyConfiguration( new ToDoEntityConfiguration() );
        }
    }
}
