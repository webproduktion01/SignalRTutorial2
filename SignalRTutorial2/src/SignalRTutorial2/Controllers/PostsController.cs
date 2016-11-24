using System.Collections.Generic;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.SignalR.Infrastructure;
using SignalRTutorial2.Data;
using SignalRTutorial2.Models;
using SignalRTutorial2.Services;

public class PostsController : Controller
{
    private IPostRepository _postRepository { get; set; }
    private IConnectionManager _connectionManager { get; set; }

    public PostsController(IPostRepository postRepository, IConnectionManager connectionManager)
    {
        _postRepository = postRepository;
        _connectionManager = connectionManager;
    }

    [HttpGet]
    public List<Post> GetPosts()
    {


            Post post = new Post();
            post.Id = 99;
            post.Text = Request.HttpContext.Connection.RemoteIpAddress+ "retrieved Post index!";
            post.UserName = "System";
        _connectionManager.GetHubContext<PostsHub>();

        
        return _postRepository.GetAll();
    }

    [HttpGet]
    public Post GetPost(int id)
    {

        return _postRepository.GetPost(id);
    }

    [HttpPost]
    public void AddPost(Post post)
    {
        _postRepository.AddPost(post);
        _connectionManager.GetHubContext<PostsHub>().Clients.All.publishPost(post);
    }
}

