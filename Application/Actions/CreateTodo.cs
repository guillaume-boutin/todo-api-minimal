using Application.Models;
using Application.Repositories;
using Domain.Entities;

namespace Application.Actions
{
    public class CreateTodo
    {
        private readonly ITodoRepository _repo;

        public CreateTodo(ITodoRepository repo)
        {
            _repo = repo;
        }

        public async Task<Todo> Run(WriteTodoModel model)
        {
            return await _repo.Create(model);
        }
    }
}