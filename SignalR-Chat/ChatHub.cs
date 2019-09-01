using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using Microsoft.AspNet.SignalR;

namespace SignalR_Chat
{
    public class ChatHub : Hub
    {
        public void SendToUser(string to, string message)
        {
            Clients.User(to).gotMessage(Context.User.Identity.Name, message);
        }
    }
}