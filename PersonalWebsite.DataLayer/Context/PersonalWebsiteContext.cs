using Microsoft.EntityFrameworkCore;
using PersonalWebsite.DataLayer.Entities.User;
using PersonalWebsite.DataLayer.Entities.Weblog;
using System;
using System.Collections.Generic;
using System.Text;

namespace PersonalWebsite.DataLayer.Context
{
    public class PersonalWebsiteContext : DbContext
    {
        public PersonalWebsiteContext(DbContextOptions<PersonalWebsiteContext> options) : base(options)
        {

        }

        public DbSet<User> Users { get; set; }
        public DbSet<Blog> Blogs { get; set; }
        public DbSet<AboutUser> AboutUsers { get; set; }
        public DbSet<Skill> Skills { get; set; }
        public DbSet<Education> Educations { get; set; }
        public DbSet<Experience> Experiences { get; set; }
        public DbSet<Degree> Degrees { get; set; }
        public DbSet<Project> Projects { get; set; }
        public DbSet<Comment> Comments { get; set; }
        public DbSet<Contact> Contacts { get; set; }
    }
}
