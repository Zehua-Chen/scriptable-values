using System.Collections.Generic;
using UnityEngine;

namespace ScriptableValues
{
    public class ScriptableList<T> : ScriptableValue
    {
        public List<T> RuntimeValue
        {
            get
            {
                if (_runtimeValue == null)
                {
                    _runtimeValue = new List<T>(_defaultValue);
                }

                return _runtimeValue;
            }
        }

        [SerializeField]
        private T[] _defaultValue;
        private List<T> _runtimeValue = null;

        protected override void Reset()
        {
            base.Reset();
            _runtimeValue = null;
        }
    }
}
