using System;
using System.Collections.Generic;
using System.Linq;
using DotNetHello.Core.Entities;
using DotNetHello.Core.Interfaces;

namespace DotNetHello.Infrastructure.Repositories
{
    public class SearchRepository : ISearchRepository
    {

        private readonly SearchDbContext _searchDbContext;

        public SearchRepository(SearchDbContext searchDbContext)
        {
            _searchDbContext = searchDbContext;
        }

        public void Add(Search item)
        {
            _searchDbContext.SearchItems.Add(item);
        }

        public int Count()
        {
            return _searchDbContext.SearchItems.Count();
        }

        public void DeleteById(string id)
        {
            Search item = GetById(id);
            _searchDbContext.SearchItems.Remove(item);
        }

        public IList<Search> GetAll()
        {
            IList<Search> list = null;

            using (var ctx = _searchDbContext)
            {
                list = ctx.SearchItems.ToList();
            }
            return list;
        }

        public Search GetById(string id)
        {
            return _searchDbContext.SearchItems.FirstOrDefault(x => x.Isbn == id);
        }

        public bool Save()
        {
            return (_searchDbContext.SaveChanges() >= 0);
        }
    }
}
