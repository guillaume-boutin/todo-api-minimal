using Application.Repositories;
using Domain.Entities;

namespace Application.Actions
{
    public class ListTodos
    {
        private readonly ITodoRepository _repo;

        public ListTodos(ITodoRepository repo)
        {
            _repo = repo;
        }

        public async Task<List<Todo>> Run()
        {
            return await _repo.List();
        }
    }
}