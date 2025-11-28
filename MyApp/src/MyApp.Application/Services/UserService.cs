using MyApp.Application.Interfaces;
using MyApp.Domain.Dtos;
using MyApp.Domain.Entities;
using MyApp.Domain.Interfaces;
using AutoMapper;

namespace MyApp.Application.Services;

public class UserService : IUserService
{
    private readonly IRepository<User> _repo;
    private readonly IMapper _mapper;

    public UserService(IRepository<User> repo, IMapper mapper)
    {
        _repo = repo;
    }

    public Task<IEnumerable<User>> GetAllAsync() => _repo.GetAllAsync();
    public Task<IEnumerable<User>> FindAsync(Func<User, bool> predicate)
        => Task.FromResult(_repo.GetAllAsync().Result.Where(predicate));

    public Task<User?> GetByIdAsync(int id) => _repo.GetByIdAsync(id);

    public async Task<bool> CreateAsync(UserRegisterDto dto)
    {
        var item = _mapper.Map<User>(dto);

        var createdItem = await _repo.AddAsync(item);

        return createdItem != null && createdItem.Id > 0 ;
    }

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
