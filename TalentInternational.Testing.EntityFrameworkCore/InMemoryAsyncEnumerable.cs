﻿using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Threading;

namespace TalentInternational.Testing.EntityFrameworkCore
{
    public class InMemoryAsyncEnumerable<T> : EnumerableQuery<T>, IAsyncEnumerable<T>, IQueryable<T>
    {
        public InMemoryAsyncEnumerable(IEnumerable<T> enumerable)
            : base(enumerable)
        {
        }

        public InMemoryAsyncEnumerable(Expression expression)
            : base(expression)
        {
        }

        IQueryProvider IQueryable.Provider => new InMemoryAsyncQueryProvider<T>(this);

        public IAsyncEnumerator<T> GetAsyncEnumerator()
        {
            return new InMemoryDbAsyncEnumerator<T>(this.AsEnumerable().GetEnumerator());
        }

        public IAsyncEnumerator<T> GetAsyncEnumerator(CancellationToken cancellationToken = default)
        {
            throw new System.NotImplementedException();
        }

        public IAsyncEnumerator<T> GetEnumerator()
        {
            return this.GetAsyncEnumerator();
        }
    }
}