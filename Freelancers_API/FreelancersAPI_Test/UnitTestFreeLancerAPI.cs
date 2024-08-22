using EntityFrameworkCoreMock;
using Freelancers_API.Controllers;
using Freelancers_API.Models;
using Freelancers_API.Repositories;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace FreelancersAPI_Test
{
    public class UnitTestFreeLancerAPI
    {
        private DbContextMock<FreelancerDbContext> getDbContext(User[] initialEntities)
        {
            DbContextMock<FreelancerDbContext> dbContextMock = new DbContextMock<FreelancerDbContext>(new DbContextOptionsBuilder<FreelancerDbContext>().Options);
            dbContextMock.CreateDbSetMock(x => x.Users, initialEntities);
            return dbContextMock;
        }

        private FreelancerRepository FreelancerRepoInit(DbContextMock<FreelancerDbContext> dbContextMock)
        {
            return new FreelancerRepository(dbContextMock.Object);
        }

        private User[] getInitialDbEntities()
        {
            return new User[]
             {
                new User {Id = 1, UserName ="User1", Mail = "User1@gmail.com" , Hobby ="Book",Skillsets="C#",PhoneNumber ="+60143404982" },
                new User {Id = 2, UserName ="User2", Mail = "User2@gmail.com" , Hobby ="Gardening",Skillsets="F#",PhoneNumber ="+60143404992" },
                new User {Id = 3, UserName ="User3", Mail = "User3@gmail.com" , Hobby ="Movies",Skillsets="Java",PhoneNumber ="+60143404912" },
            };
        }

        [Fact]
        public void GetUserList_Success()
        {
            DbContextMock<FreelancerDbContext> dbContextMock = getDbContext(getInitialDbEntities());
            FreelancerRepository freelancerRepository = FreelancerRepoInit(dbContextMock);

            var result = freelancerRepository.GetUserList();
            List<User> value = result;

            Assert.Equal(3, value.Count);
        }

        

        [Fact]
        public void UpdateUser_Success()
        {
            DbContextMock<FreelancerDbContext> dbContextMock = getDbContext(getInitialDbEntities());
            FreelancerRepository freelancerRepository = FreelancerRepoInit(dbContextMock);
            User tobeUpdated = getInitialDbEntities()[2];
            tobeUpdated.UserName = "new name";
            int id = 3;

            var result = freelancerRepository.UpdateUser(tobeUpdated,id);
            User? updatedItem = dbContextMock.Object.Users.Find(id);

            Assert.Equal(tobeUpdated, updatedItem);

        }

        [Fact]
        public void UpdateUser_invalidInput()
        {
            DbContextMock<FreelancerDbContext> dbContextMock = getDbContext(getInitialDbEntities());
            FreelancerRepository freelancerRepository = FreelancerRepoInit(dbContextMock);
            User tobeUpdated = getInitialDbEntities()[2];
            int id = 2;

            var result = freelancerRepository.UpdateUser(tobeUpdated,id);
            User? updatedItem = dbContextMock.Object.Users.Find(id);

            Assert.NotEqual(tobeUpdated, updatedItem);


        }

        [Fact]
        public void DeleteUser_Success()
        {
            DbContextMock<FreelancerDbContext> dbContextMock = getDbContext(getInitialDbEntities());
            FreelancerRepository freelancerRepository = FreelancerRepoInit(dbContextMock);
            int id = 3;

            var result = freelancerRepository.DeleteUser(id);

            Assert.Equal(0,result);
            
        }

        [Fact]
        public void DeleteUser_InvalidInput()
        {
            DbContextMock<FreelancerDbContext> dbContextMock = getDbContext(getInitialDbEntities());
            FreelancerRepository freelancerRepository = FreelancerRepoInit(dbContextMock);
            int id = 4;

            var result = freelancerRepository.DeleteUser(id);

            Assert.Equal(-1, result);
        }

        [Fact]
        public void RegisterUser_Success()
        {
            DbContextMock<FreelancerDbContext> dbContextMock = getDbContext(getInitialDbEntities());
            FreelancerRepository freelancerRepository = FreelancerRepoInit(dbContextMock);

            User toBeAdded = new User { Id = 4, UserName = "User4", Mail = "User4@gmail.com", Hobby = "Book", Skillsets = "C#", PhoneNumber = "+60143404982" };


            var result = freelancerRepository.RegisterUser(toBeAdded);

            Assert.Equal(toBeAdded, dbContextMock.Object.Users.Find(toBeAdded.Id));
        }
    }
}