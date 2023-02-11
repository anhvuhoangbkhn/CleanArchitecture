using Domain.Common.Entities;
using Domain.Common.Entities.Models;

namespace Domain.Catalog.Models
{
    public class Author : Entity<int>, IAggregateRoot
    {
        internal Author(string name, string description) 
        {
            this.Name = name;
            this.Description = description;
        }
        public string Name { get;private set; }
        public string Description { get;private set; }

        public Author UpdateName(string name)
        {
            this.Name = name; return this;
        }
        public Author UpdateDescription(string description)
        {
            this.Description = description; return this;
        }
    }
}
