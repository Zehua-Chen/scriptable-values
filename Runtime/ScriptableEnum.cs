#nullable enable

using System;
using UnityEngine;

namespace ScriptableValues
{
    public class ScriptableEnum : ScriptableObject, IEquatable<ScriptableEnum>
    {
        public override int GetHashCode()
        {
            return GetInstanceID().GetHashCode();
        }

        public override bool Equals(object other)
        {
            if (other is ScriptableEnum)
            {
                var otherEnum = (ScriptableEnum)other;
                return GetInstanceID() == otherEnum.GetInstanceID();
            }

            return false;
        }

        public bool Equals(ScriptableEnum other)
        {
            return GetInstanceID() == other.GetInstanceID();
        }

        public static bool operator==(ScriptableEnum lhs, ScriptableEnum rhs)
        {
            Debug.Log("== called");
            return lhs.GetInstanceID() == rhs.GetInstanceID();
        }

        public static bool operator !=(ScriptableEnum lhs, ScriptableEnum rhs)
        {
            return lhs.GetInstanceID() != rhs.GetInstanceID();
        }
    }
}
