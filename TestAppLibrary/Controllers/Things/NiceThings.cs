using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TestAppLibrary.Data;

namespace TestAppLibrary.Controllers.Things
{
    public class NiceThings
    {
        private readonly TestDbContext _dbContext;

        public NiceThings(TestDbContext dbContext)
        {
            _dbContext = dbContext;
        }

        public Task<string> DoSomething(int data)
        {
            return Task.FromResult($"Hi, {data} is a nice number!");
        }

        public Task SomethingElse()
        {
            return Task.CompletedTask;
        }

        public void Nope()
        {

        }
    }
}
