﻿using System.Collections.Generic;

namespace MusicStore.Lib.Repositories.Abstractions
{
    public interface IRepository<TEntity> where TEntity : class
    {
        void Add( TEntity entity );
        void AddRange( List<TEntity> entities );
        void Remove( TEntity entity );
    }
}
