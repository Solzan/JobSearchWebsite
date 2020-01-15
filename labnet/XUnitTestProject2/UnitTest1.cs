using labnet.Models;
using System;
using Xunit;
using Moq;
using labnet.Controllers;
using Microsoft.AspNetCore.Mvc;
using System.Collections.Generic;
using labnet.EntityFramework;

using Microsoft.Extensions.DependencyInjection;

namespace XUnitTestProject2
{
    public class UnitTest1
    {
        [Fact]
        public void Test1()
        {
            

        }
     
        [Fact]
        public void UnitTest1()
        {
            DataContext db = new DataContext();
            "Server=DESKTOP-3OP1KKI\\SQLEXPRESS;Database=JobOfferDb;Trusted_Connection=True;"

         // arrange
            var service = new Mock<IPersonService>();
            
            var persons = GetFakeData();
            service.Setup(x => x.AllPersons()).Returns(persons);
            var controller = new PersonController(service.Object);
            // Act
            var results = controller.GetPersons();
            var count = results.Count();
            // Assert
            Assert.Equal(count, 26);
        }
    }
}
