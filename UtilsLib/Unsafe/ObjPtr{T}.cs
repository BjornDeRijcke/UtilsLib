using System;

namespace UtilsLib.Unsafe
{
    public sealed class ObjPtr<T> where T : class
    {
        readonly Func<T> _getter;
        readonly Action<T> _setter;

        public ObjPtr(Func<T> g, Action<T> s)
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
