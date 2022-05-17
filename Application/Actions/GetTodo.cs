using Application.Repositories;
using Domain.Entities;

namespace Application.Actions
{
    public class GetTodo
    {
        private readonly ITodoRepository _repo;

        public GetTodo(ITodoRepository repo)
        {
            _repo = repo;
        }

        public async Task<Todo?> Run(int id)
        {
            return await _repo.Get(id);
        }
    }
}