using Microsoft.AspNetCore.SignalR;
using SignalRTutorial2.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace SignalRTutorial2.Services
{
    public class PostsHub : Hub
    {
        public void TestMethod()
        {
            Post post = new Post();
            post.Id = 99;
            post.Text = post.Text + "Server added text!";
            post.UserName = "System";
            Clients.Caller.publishPost(post);
        }
    }
}
