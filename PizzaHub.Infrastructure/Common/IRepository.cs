﻿namespace PizzaHub.Infrastructure.Common
{
    public interface IRepository
    {
        IQueryable<T> All<T>() where T : class;

        IQueryable<T> AllReadOnly<T>() where T : class;

        Task AddAsync<T>(T entity) where T : class;

        Task AddRangeAsync<T>(IEnumerable<T> entity) where T : class;

        Task RemoveRange<T>(IEnumerable<T> entities) where T : class;

        Task<bool> Remove<T>(T entity) where T : class;

        Task<int> SaveChangesAsync();
        
    }
}
