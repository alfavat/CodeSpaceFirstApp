using MyApp.Domain.Dtos;
using MyApp.Domain.Entities;

namespace MyApp.Application.Interfaces;

public interface IUserService
{
    Task<IEnumerable<User>> GetAllAsync();
    Task<User?> GetByIdAsync(int id);
    Task<bool> CreateAsync(UserRegisterDto dto);
    Task UpdateAsync(User user);
    Task DeleteAsync(int id);
}
