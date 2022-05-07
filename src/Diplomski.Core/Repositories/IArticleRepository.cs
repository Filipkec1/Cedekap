using Diplomski.Core.Models.Entities;
using System;

namespace Diplomski.Core.Repositories
{
    /// <summary>
    /// Defines article repository interface.
    /// </summary>
    public interface IArticleRepository : IRepository<Article, Guid>
    {

    }
}
