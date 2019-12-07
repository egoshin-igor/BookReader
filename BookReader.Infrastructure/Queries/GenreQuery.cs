using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using BookReader.Application.Queries;
using BookReader.Application.Queries.Dto;
using BookReader.Core.Entities;
using BookReader.Infrastructure.Foundation;
using Microsoft.EntityFrameworkCore;
using MusicStore.Lib.Queries.Abstractions;

namespace BookReader.Infrastructure.Queries
{
    public class GenreQuery : BaseQuery<Genre>, IGenreQuery
    {
        public GenreQuery( BookReaderDbContext dbContext ) : base( dbContext )
        {
        }

        public async Task<List<GenreDto>> GetAll()
        {
            List<Genre> genres = await Query.ToListAsync();

            return genres.Select( g => new GenreDto
            {
                Id = g.Id,
                Name = g.Name
            } ).ToList();
        }
    }
}
