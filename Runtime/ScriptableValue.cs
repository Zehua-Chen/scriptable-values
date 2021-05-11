using System;
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
            get
            {
                if (!_runtimeValueSet)
                {
                    _runtimeValueSet = true;
                    _runtimeValue = _defaultValue;
                }

                return _runtimeValue;
            }
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
