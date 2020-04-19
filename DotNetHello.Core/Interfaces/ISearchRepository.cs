using System;
using System.Collections.Generic;
using DotNetHello.Core.Entities;

namespace DotNetHello.Core.Interfaces
{
    public interface ISearchRepository
    {

        Search GetById(string id);
        void Add(Search item);
        void DeleteById(string id);
        int Count();
        bool Save();
        IList<Search> GetAll();


    }
}
