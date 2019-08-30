using System.Collections.Generic;
using TestProject.Types;

namespace TestProject
{
    public static class MemoryDatabase
    {
        public static List<User> Items = new List<User>();

        public static void AddItem(User item)
        {
            Items.Add(item);
        }
    }
}
