using System;
using System.Collections.Generic;
using System.Linq;

namespace WebApp._Internal.Helpers
{
    internal struct Maybe<T>
    {
        public static Maybe<T> Some(T value)
        {
            if (value == null)
                throw new InvalidOperationException();

            return new Maybe<T>(new[] { value });
        }
        public static Maybe<T> None => new Maybe<T>(new T[0]);

        public bool HasValue => _values != null && _values.Any();
        public U Case<U>(Func<T, U> some, Func<U> none) => this.HasValue ? some(Value) : none();

        public T Value
        {
            get
            {
                if (!HasValue)
                    throw new InvalidOperationException("Maybe does not have a value");

                return _values.Single();
            }
        }

        private Maybe(IEnumerable<T> values) => _values = values;
        private readonly IEnumerable<T> _values;
    }
}
