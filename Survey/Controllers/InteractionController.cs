using AutoMapper;
using Entities.Dtos;
using Entities.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore.Metadata.Internal;
using Services.Contracts;
using Survey.Benimkiler;
using Survey.Components;

namespace Survey.Controllers;

public class InteractionController : Controller
{

    private readonly IMapper _mapper;

    private readonly IServiceManager _manager;

    public InteractionController(IServiceManager manager, IMapper mapper)
    {
        _manager = manager;
        _mapper = mapper;
    }

    [HttpPost]
    [ValidateAntiForgeryToken]
    public IActionResult CreatePost([FromForm] PostDto postDto)
    {
        // p.f("content : " + postDto.Content);
        // p.f("isGlobal : " + postDto.IsGlobalString);

        Post newPost = _mapper.Map<Post>(postDto);
        if (postDto.IsGlobalString.ToLower().Contains("global"))
        {
            newPost.IsGlobal = true;
        }
        else
        {
            newPost.IsGlobal = false;
        }


        // _manager.PostService.CreatePost(newPost);

        return View("Success");
    }
}