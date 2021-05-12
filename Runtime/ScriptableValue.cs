using System;
using System.Runtime.CompilerServices;
using UnityEngine;

namespace ScriptableValues
{
    public class ScriptableValue: ScriptableObject
    {
        public virtual void Reset() { }
    }

    public class ScriptableValue<T> : ScriptableValue
    {
#if UNITY_EDITOR
        /// <summary>
        /// </summary>
        /// <remarks>
        /// Only avaiable when <c>UNITY_EDITOR</c> is defined
        /// </remarks>
        public class UpdateEvent
        {
            public T NewValue;
        }

        /// <summary>
        /// </summary>
        /// <remarks>
        /// Only avaiable when <c>UNITY_EDITOR</c> is defined
        /// </remarks>
        public delegate void UpdateEventHandler(object sender, UpdateEvent e);

        /// <summary>
        /// </summary>
        /// <remarks>
        /// Only avaiable when <c>UNITY_EDITOR</c> is defined
        /// </remarks>
        public event UpdateEventHandler Updated;
#endif

        [SerializeField]
        private T _defaultValue = default;

        [NonSerialized]
        private T _runtimeValue = default;

        [NonSerialized]
        private bool _runtimeValueSet = false;

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

#if UNITY_EDITOR
                if (Updated != null)
                {
                    Updated(this, new UpdateEvent()
                    {
                        NewValue = value
                    });
                }
#endif
            }
        }

        protected virtual void OnEnable()
        {
            this.Reset();
        }

        public override void Reset()
        {
            base.Reset();
            _runtimeValueSet = false;
            _runtimeValue = default;
        }

#if UNITY_EDITOR
        /// <summary>
        /// </summary>
        /// <remarks>
        /// Only avaiable when <c>UNITY_EDITOR</c> is defined
        /// </remarks>
        public void SetValueFromEditor(T newValue)
        {
            _runtimeValue = newValue;
            _runtimeValueSet = true;
        }
#endif
    }
}
