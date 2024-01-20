using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using BookStoreApi.Services;
using DineSmartWEBAPI.Models;
using Microsoft.AspNetCore.Mvc;

namespace DineSmartWEBAPI.Controller
{
    [ApiController]
    [Route("api/[controller]")]
    public class UserController : ControllerBase
    {
        private readonly UserService _restaurantService;

    public UserController(UserService UserService) =>
        _restaurantService = UserService;

    [HttpGet]
    public async Task<List<User>> Get() =>
        await _restaurantService.GetAsync();

    [HttpGet("{id:length(24)}")]
    public async Task<ActionResult<User>> Get(string id)
    {
        var User = await _restaurantService.GetAsync(id);

        if (User is null)
        {
            return NotFound();
        }

        return User;
    }

    [HttpPost]
    public async Task<IActionResult> Post(User newBook)
    {
        await _restaurantService.CreateAsync(newBook);

        return CreatedAtAction(nameof(Get), new { id = newBook.Id }, newBook);
    }

    [HttpPut("{id:length(24)}")]
    public async Task<IActionResult> Update(string id, User updatedBook)
    {
        var User = await _restaurantService.GetAsync(id);

        if (User is null)
        {
            return NotFound();
        }

        updatedBook.Id = User.Id;

        await _restaurantService.UpdateAsync(id, updatedBook);

        return NoContent();
    }

    [HttpDelete("{id:length(24)}")]
    public async Task<IActionResult> Delete(string id)
    {
        var User = await _restaurantService.GetAsync(id);

        if (User is null)
        {
            return NotFound();
        }

        await _restaurantService.RemoveAsync(id);

        return NoContent();
    }
    }
}