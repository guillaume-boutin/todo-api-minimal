using Application.Models;
using Application.Repositories;
using AutoMapper;
using Domain.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Internal;

namespace Infrastructure.MySQL.Repositories
{
    public class TodoRepository : ITodoRepository
    {
        private readonly MySQLContext _db;
        private readonly IMapper _mapper;

        public TodoRepository(MySQLContext db, IMapper mapper)
        {
            _db = db;
            _mapper = mapper;
        }

        public async Task<bool> Exists(int id)
        {
            return await _db.Todos.AnyAsync(t => t.Id == id);
        }

        public async Task<List<Todo>> List()
        {
            return await _db.Todos.ToListAsync();
        }

        public async Task<Todo?> Get(int id)
        {
            return await _db.Todos.FindAsync(id);
        }

        public async Task<Todo> Create(WriteTodoModel model)
        {
            var todo = _mapper.Map<WriteTodoModel, Todo>(model);
            _db.Todos.Add(todo);
            await _db.SaveChangesAsync();

            return todo;
        }

        public async Task<Todo> Update(int id, WriteTodoModel model)
        {
            var todo = await _db.Todos.FindAsync(id);
            if (todo is null) throw new Exception("Todo not found.");

            todo = _mapper.Map<WriteTodoModel, Todo>(model, todo);
            await _db.SaveChangesAsync();

            return todo;
        }
    }
}