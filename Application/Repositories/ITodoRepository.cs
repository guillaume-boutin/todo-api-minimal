using Application.Models;
using Domain.Entities;

namespace Application.Repositories
{
    public interface ITodoRepository
    {
        Task<bool> Exists(int id);

        Task<List<Todo>> List();

        Task<Todo?> Get(int id);

        Task<Todo> Create(WriteTodoModel model);

        Task<Todo> Update(int id, WriteTodoModel model);
    }
}