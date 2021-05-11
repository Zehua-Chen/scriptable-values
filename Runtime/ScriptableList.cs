using System;
using System.Collections.Generic;
using System.Runtime.CompilerServices;
using UnityEngine;

namespace ScriptableValues
{
    public class ScriptableList<T> : ScriptableValue
    {
        public List<T> RuntimeValue
        {
            [MethodImpl(MethodImplOptions.AggressiveInlining)]
            get
            {
                if (_runtimeValue == null)
                {
                    _runtimeValue = new List<T>(_defaultValue);
                }

                return _runtimeValue;
            }

            [MethodImpl(MethodImplOptions.AggressiveInlining)]
            set
            {
                _runtimeValue = value;
            }
        }

        [SerializeField]
        private T[] _defaultValue;

        [NonSerialized]
        private List<T> _runtimeValue = null;

        protected override void Reset()
        {
            base.Reset();
            _runtimeValue = null;
        }
    }
}
