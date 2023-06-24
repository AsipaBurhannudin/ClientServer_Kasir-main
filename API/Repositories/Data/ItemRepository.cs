using API.Context;
using API.Repositories.Interface;
using API.Models;

namespace API.Repositories.Data
{
    public class ItemRepository : GeneralRepository<Item, string, MyContext>, IItem
    {
        public ItemRepository(MyContext context) : base(context) { }
    }
}
