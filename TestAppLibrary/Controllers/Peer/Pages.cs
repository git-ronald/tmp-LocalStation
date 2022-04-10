using PeerLibrary.PeerApp.Interfaces.Controllers;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TestAppLibrary.Controllers.Peer
{
    public class Pages : IPagesController
    {
        public Task GetPages()
        {
            return Task.CompletedTask;
        }
    }
}
