using DataAccess.Entitys;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection.Emit;
using System.Text;
using System.Threading.Tasks;

namespace DataAccess.DataContexts
{
    public class ContactsManagerContext: IdentityDbContext<UserEntity>
    {
        public ContactsManagerContext(DbContextOptions<ContactsManagerContext> options) : base(options) { }

        public DbSet<ContactEntity> Contacts { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);

            modelBuilder.Entity<ContactEntity>()
                .HasOne(c => c.OwnerUser)
                .WithMany(u => u.AssociatedContacts)
                .HasForeignKey(c => c.Owner)
                .IsRequired();

            modelBuilder.Entity<ContactEntity>()
                .HasIndex(c => c.Email)
                .IsUnique();
        }
    }
}
