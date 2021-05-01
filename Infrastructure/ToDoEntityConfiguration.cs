using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using TodoList.Entities;

namespace TodoList.Infrastructure
{
    public class ToDoEntityConfiguration : IEntityTypeConfiguration<ToDoEntity>
    {
        public void Configure( EntityTypeBuilder<ToDoEntity> builder )
        {
            builder.ToTable("ToDo")
                .HasKey( item => item.Id );

            builder.Property( item => item.Id )
                .HasColumnName( "ToDoId" );
        }
    }
}
