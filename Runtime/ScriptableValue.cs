using System;
using System.Runtime.CompilerServices;
using UnityEngine;

namespace ScriptableValues
{
    public class ScriptableValue: ScriptableObject
    {
        protected virtual void Reset() { }
    }

    public class ScriptableValue<T> : ScriptableValue
    {
        public T Value
        {
            [MethodImpl(MethodImplOptions.AggressiveInlining)]
            get
            {
                if (!_runtimeValueSet)
                {
                    _runtimeValueSet = true;
                    _runtimeValue = _defaultValue;
                }

                return _runtimeValue;
            }

            [MethodImpl(MethodImplOptions.AggressiveInlining)]
            set
            {
                _runtimeValueSet = true;
                _runtimeValue = value;
            }
        }

        [SerializeField]
        private T _defaultValue = default;

        [NonSerialized]
        private T _runtimeValue = default;

        [NonSerialized]
        private bool _runtimeValueSet = false;

        protected virtual void OnEnable()
        {
            this.Reset();
        }

        protected override void Reset()
        {
            base.Reset();
            _runtimeValueSet = false;
            _runtimeValue = default;
        }
    }
}
