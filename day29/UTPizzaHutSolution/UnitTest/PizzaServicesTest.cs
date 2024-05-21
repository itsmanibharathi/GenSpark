using Microsoft.EntityFrameworkCore;
using Moq;
using PizzaHutAPI.Context;
using PizzaHutAPI.Controllers;
using PizzaHutAPI.Interfaces;
using PizzaHutAPI.Models;
using PizzaHutAPI.Repositories;
using PizzaHutAPI.Services;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace UnitTest
{
    internal class PizzaServicesTest
    {
        public DBPizzaHutContext context;

        [SetUp]
        public void Setup()
        {
            DbContextOptionsBuilder optionsBuilder = new DbContextOptionsBuilder()
                                            .UseInMemoryDatabase("dummyDB");
            context = new DBPizzaHutContext(optionsBuilder.Options);
        }
        [Test]
        public void GetPizza()
        {
            //Arrange
            IRepository<int,Pizza> repository = new PizzaRepository(context);
            IPizzaService service = new PizzaService(repository);
            service.Add(new Pizza { Name = "demo" });

            //Action
            var res = service.Get().Result;
            Console.WriteLine(res);
            Assert.IsNotNull(res);

        }
    }
}
