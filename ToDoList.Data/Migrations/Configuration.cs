namespace ToDoList.Data.Migrations
{
    using Entities;
    using System;
    using System.Data.Entity;
    using System.Data.Entity.Migrations;
    using System.Linq;
    using ToDoList.Data;
    internal sealed class Configuration : DbMigrationsConfiguration<ToDoContext>
    {
        public Configuration()
        {
            AutomaticMigrationsEnabled = false;
        }

        protected override void Seed(ToDoContext context)
        {
            context.ToDoItems.AddOrUpdate(new Data.Entities.ToDoItem()
            {
                Task="Do your Laundry",
                Deadline=DateTime.Now.AddMinutes(2),
                MoreDetails="Clothes are starting to smell real bad."

            });
            //  This method will be called after migrating to the latest version.

            //  You can use the DbSet<T>.AddOrUpdate() helper extension method 
            //  to avoid creating duplicate seed data. E.g.
            //
            //    context.People.AddOrUpdate(
            //      p => p.FullName,
            //      new Person { FullName = "Andrew Peters" },
            //      new Person { FullName = "Brice Lambson" },
            //      new Person { FullName = "Rowan Miller" }
            //    );
            //
        }
    }
}
