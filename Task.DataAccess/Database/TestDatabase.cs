using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Text;
using Test.Data;
using Test.Data.Models;

namespace Test.DataAccess.Database
{
    public class TestDatabase : DbContext
    {
        public TestDatabase()
            :base()
        {
            
        }

        public TestDatabase(DbContextOptions<TestDatabase> options)
            :base(options)
        {
            if(Database.EnsureCreated())
            {
                List<User> UsersList = new List<User>()
                {
                    new User()
                    {
                        LastName = "Иванов",
                        FirstName = "Иван",
                        DateOfCreation = new DateTime(2021, 05, 1),
                        DateOfLastChange = new DateTime(2021, 05, 11),
                        UserStatus = UserStatuses.Active
                    },
                    new User()
                    {
                        LastName = "Петров",
                        FirstName = "Петр",
                        DateOfCreation = new DateTime(2021, 05, 2),
                        DateOfLastChange = new DateTime(2021, 05, 12),
                        UserStatus = UserStatuses.Disabled
                    },
                    new User()
                    {
                        LastName = "Дмитриев",
                        FirstName = "Дмитрий",
                        DateOfCreation = new DateTime(2021, 05, 3),
                        DateOfLastChange = new DateTime(2021, 05, 13),
                        UserStatus = UserStatuses.Locked
                    }
                };

                for (int i = 1; i < 3; i++)
                {
                    UsersList.Add(new User()
                    {
                        LastName = "LastName" + i,
                        FirstName = "FirstName" + i,
                        DateOfCreation = new DateTime(2021, 05, i),
                        DateOfLastChange = new DateTime(2021, 05, 2 + i),
                        UserStatus = UserStatuses.Active
                    });
                }

                UsersList.ForEach(u => Users.Add(u));

                List<Task> TaskList = new List<Task>()
                {
                    new Task()
                    {
                        Name = "Name1",
                        Description = "Description1",
                        DateOfCreation = new DateTime(2021, 05, 1),
                        DateOfLastChange = new DateTime(2021, 05, 21),
                        TaskStatus = TaskStatuses.NotStarted,
                        SetterID = 2,
                        PerformerID = 1
                    },
                    new Task()
                    {
                        Name = "Name2",
                        Description = "Description2",
                        DateOfCreation = new DateTime(2021, 05, 1),
                        DateOfLastChange = new DateTime(2021, 05, 21),
                        TaskStatus = TaskStatuses.InProgress,
                        SetterID = 1,
                        PerformerID = 2
                    },
                    new Task()
                    {
                        Name = "Name3",
                        Description = "Description3",
                        DateOfCreation = new DateTime(2021, 05, 1),
                        DateOfLastChange = new DateTime(2021, 05, 21),
                        TaskStatus = TaskStatuses.Accomplished,
                        SetterID = 3,
                        PerformerID = 1
                    },
                    new Task()
                    {
                        Name = "Name4",
                        Description = "Description4",
                        DateOfCreation = new DateTime(2021, 05, 1),
                        DateOfLastChange = new DateTime(2021, 05, 21),
                        TaskStatus = TaskStatuses.Canceled,
                        SetterID = 1,
                        PerformerID = 3
                    },
                    new Task()
                    {
                        Name = "Name5",
                        Description = "Description5",
                        DateOfCreation = new DateTime(2021, 05, 1),
                        DateOfLastChange = new DateTime(2021, 05, 21),
                        TaskStatus = TaskStatuses.Rejected,
                        SetterID = 4,
                        PerformerID = 1
                    }
                };

                for (int i = 1; i < 20; i++)
                {
                    TaskList.Add(new Task()
                    {
                        Name = "Name" + i,
                        Description = "Description" + i,
                        DateOfCreation = new DateTime(2021, 04, i),
                        DateOfLastChange = new DateTime(2021, 05, i)
                    });
                }

                TaskList.ForEach(c => Tasks.Add(c));

                SaveChanges();
            }
        }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            if (!optionsBuilder.IsConfigured)
            {
                var connectionString = "Server=(localdb)\\mssqllocaldb; Database=TestDatabase; Trusted_Connection=true;";
                optionsBuilder.UseSqlServer(connectionString);
            }
        }

        public DbSet<User> Users { get; set; }
        public DbSet<Task> Tasks { get; set; }
    }
}
