using System;

namespace UtilsLib.Unsafe
{
    public sealed class ValPtr<T> where T : struct
    {
        readonly Func<T> _getter;
        readonly Action<T> _setter;

        public ValPtr(Func<T> g, Action<T> s)
        {
            _getter = g;
            _setter = s;
        }

        public T Deref
        {
            get { return _getter(); }
            set { _setter(value); }
        }
    }
}
