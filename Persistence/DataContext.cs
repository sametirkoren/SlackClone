using System;
using Domain;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;

namespace Persistence
{
    public class DataContext : IdentityDbContext<AppUser>
    {
        public DataContext(DbContextOptions options) : base(options){

        }


        public DbSet<Channel> Channels{get;set;}
        public DbSet<Message> Messages{get;set;}

        public DbSet<TypingNotification> TypingNotification {get;set;}


       protected override void OnModelCreating(ModelBuilder modelBuilder)
       {
           base.OnModelCreating(modelBuilder);
           modelBuilder
           .Entity<Channel>()
           .HasData
           (
               new Channel
            {
               Id = Guid.NewGuid(),
               Name="DotNetCore",
               Description=".Net Core Kanalı"
           },
             new Channel
            {
               Id = Guid.NewGuid(),
               Name="Angular",
               Description="Angular Kanalı"
           },
             new Channel
            {
               Id = Guid.NewGuid(),
               Name="React",
               Description="React Kanalı"
           }

           
           );

           modelBuilder.Entity<Message>()
           .HasOne(x=>x.Sender)
           .WithMany(x=>x.Messages)
           .HasForeignKey(x=>x.SenderId);


           modelBuilder.Entity<AppUser>().HasOne(a=> a.TypingNotification).WithOne(b=>b.Sender).HasForeignKey<TypingNotification>(b=>b.Id);
       }
        
    }
}