using Domain.Catalog.Exceptions.Authors;
using Domain.Catalog.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Domain.Catalog.Factories.Authors
{
    internal class AuthorFactory : IAuthorFactory
    {
        private string authorName = default!;
        private string authorDescription = default!;

        private bool isNameSet = false;
        private bool isDescriptionSet = false;
        public Author Build()
        {
            if (!this.isNameSet || !this.isDescriptionSet)
            {
                throw new InvalidAuthorException("Name and description must have a value.");
            }

            return new Author(this.authorName, this.authorDescription);
        }

        public IAuthorFactory WithDescription(string description)
        {
           this.authorDescription = description;
           this.isDescriptionSet= true;

           return this;
        }

        public IAuthorFactory WithName(string name)
        {
            this.authorName = name;
            this.isNameSet= true;

            return this;
        }        
    }
}
