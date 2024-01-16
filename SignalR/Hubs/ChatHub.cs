using Microsoft.AspNetCore.SignalR;
using SignalR.Models;

namespace SignalR.Hubs
{
    public class ChatHub : Hub
    {
        private readonly AppDbContext db;

        public ChatHub( AppDbContext db )
        {
            this.db = db;
        }

        
        public void sendMessage(Chat c)
        {
            Clients.All.SendAsync("newMessage", c);
            db.Chats.Add( c );
            db.SaveChanges();
           
        }

        public void joinGroup(string groupname , string name)
        {
            Groups.AddToGroupAsync(Context.ConnectionId, groupname);
            Clients.OthersInGroup(groupname).SendAsync("newmember",name , groupname);
        }

        public void sendToGroup( string group  , string message, string name)
        {
            //db store 
             
            Clients.Group(group).SendAsync( "newmessagegroup",name,group,message);
        }

    }
}
