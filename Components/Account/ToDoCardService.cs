using BlueStone_Admin.Data;
using Microsoft.EntityFrameworkCore;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace BlueStone_Admin.Components.Account
{
    public class ToDoCardService
    {
        private readonly ApplicationDbContext _dbContext;

        public ToDoCardService(ApplicationDbContext dbContext)
        {
            _dbContext = dbContext;
        }

       

        public List<ToDoContext> GetToDoItemsForUserSync(string userEmail)
        {
            return _dbContext.ToDoItems
                .Where(item => item.EmailId == userEmail)
                .ToList();
        }
    }
}

