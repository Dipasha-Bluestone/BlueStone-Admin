using BlueStone_Admin.Data;
using Microsoft.EntityFrameworkCore;

namespace BlueStone_Admin.Components.Account
{
    public class ToDoService
    {
        private readonly ApplicationDbContext _dbContext;

        public ToDoService(ApplicationDbContext dbContext)
        {
            _dbContext = dbContext;
        }

       
        public List<ToDoContext> GetToDoItemsForUserSync(string userEmail)
        {
            return _dbContext.ToDoItems
                .Where(item => item.EmailId == userEmail)
                .ToList();
        }

        public async Task<List<ToDoContext>> GetCompletedToDoItemsForUser(string userEmail)
        {
            return await _dbContext.ToDoItems
                .Where(item => item.EmailId == userEmail && item.IsCompleted)
                .ToListAsync();
        }
        public async Task<List<ToDoContext>> GetUncompletedToDoItemsForUser(string userEmail)
        {
            return await _dbContext.ToDoItems
                .Where(item => item.EmailId == userEmail && !item.IsCompleted) 
                .ToListAsync();
        }

        public async Task SaveToDoItem(ToDoContext todoItem)
        {
            _dbContext.ToDoItems.Add(todoItem);
            await _dbContext.SaveChangesAsync();
        }

        public async Task DeleteToDoItem(string userEmail)
        {
            var todoItem = await _dbContext.ToDoItems.FindAsync(userEmail);
            if (todoItem != null)
            {
                _dbContext.ToDoItems.Remove(todoItem);
                await _dbContext.SaveChangesAsync();
            }
        }
    }
}
