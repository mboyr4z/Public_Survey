using AutoMapper;
using Entities.Dtos;
using Entities.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore.Metadata.Internal;
using Services.Contracts;
using Survey.Benimkiler;
using Survey.Components;
using Survey.Models;

namespace Survey.Controllers;

public class InteractionController : Controller
{
    private readonly IMapper _mapper;

    private readonly MainPageModel _mainPageModel;
    private readonly IServiceManager _manager;

    public InteractionController(IServiceManager manager, IMapper mapper, MainPageModel mainPageModel)
    {
        _manager = manager;
        _mapper = mapper;
        _mainPageModel = mainPageModel;
    }

    [HttpPost]
    [ValidateAntiForgeryToken]
    public IActionResult CreatePost([FromForm] PostDto postDto)
    {
        // p.f("content : " + postDto.Content);
        // p.f("isGlobal : " + postDto.IsGlobalString);

        Post newPost = _mapper.Map<Post>(postDto);
        newPost.PublisherId = _mainPageModel.User.Id;
        newPost.PublishTime = DateTime.Now;

        if (postDto.IsGlobalString.ToLower().Contains("global"))
        {
            newPost.IsGlobal = true;
        }
        else
        {
            newPost.IsGlobal = false;
        }


        _manager.PostService.CreatePost(newPost);

        return RedirectToAction("Index","MainPage");
    }
}