using MyApp.Application.Interfaces;
using MyApp.Domain.Entities;
using MyApp.Domain.Interfaces;

namespace MyApp.Application.Services;

public class UserService : IUserService
{
    private readonly IRepository<User> _repo;

    public UserService(IRepository<User> repo)
    {
        _repo = repo;
    }

    public Task<IEnumerable<User>> GetAllAsync() => _repo.GetAllAsync();
    public Task<IEnumerable<User>> FindAsync(Func<User, bool> predicate)
        => Task.FromResult(_repo.GetAllAsync().Result.Where(predicate));

    public Task<User?> GetByIdAsync(int id) => _repo.GetByIdAsync(id);

    public Task<User> CreateAsync(User User) => _repo.AddAsync(User);

    public async Task UpdateAsync(User User)
    {
        await _repo.UpdateAsync(User);
    }

    public async Task DeleteAsync(int id)
    {
        var User = await _repo.GetByIdAsync(id);
        if (User != null)
            await _repo.DeleteAsync(User);
    }
}
