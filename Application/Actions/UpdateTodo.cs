using Application.Models;
using Application.Repositories;
using Domain.Entities;

namespace Application.Actions
{
    public class UpdateTodo
    {
        private readonly ITodoRepository _repo;

        public UpdateTodo(ITodoRepository repo)
        {
            _repo = repo;
        }

        public async Task<Todo> Run(int id, WriteTodoModel model)
        {
            return await _repo.Update(id, model);
        }
    }
}