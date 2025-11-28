using Microsoft.AspNetCore.Mvc;
using MyApp.API.Models;
using MyApp.Application.Interfaces;
using MyApp.Domain.Dtos;
using MyApp.Domain.Entities;

namespace MyApp.API.Controllers;

[ApiController]
[Route("api/[controller]")]
public class UsersController : ControllerBase
{
    private readonly IUserService _service;

    public UsersController(IUserService service)
    {
        _service = service;
    }

    [HttpGet]
    public async Task<IActionResult> GetAll() =>
        Ok(await _service.GetAllAsync());

    [HttpGet("{id}")]
    public async Task<IActionResult> GetById(int id)
    {
        var User = await _service.GetByIdAsync(id);
        return User is null ? NotFound() : Ok(User);
    }

    [HttpPost]
    public async Task<IActionResult> Create(UserRegisterDto user)
    {
        if (user == null)
        {
            return NotFound(ApiResponse.Failure("User data is null"));
        }

        var created = await _service.CreateAsync(user);

        if (created)
        {
            return Ok(ApiResponse.Ok(message: "User created successfully"));
        }

        return BadRequest(ApiResponse.Failure("User creation failed"));
    }

    [HttpPut("{id}")]
    public async Task<IActionResult> Update(int id, User User)
    {
        if (id != User.Id) return BadRequest();

        await _service.UpdateAsync(User);
        return NoContent();
    }

    [HttpDelete("{id}")]
    public async Task<IActionResult> Delete(int id)
    {
        await _service.DeleteAsync(id);
        return NoContent();
    }
}
