#nullable enable

using System;
using System.Runtime.CompilerServices;
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

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public bool Equals(ScriptableEnum other)
        {
            return GetInstanceID() == other.GetInstanceID();
        }

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static bool operator==(ScriptableEnum lhs, ScriptableEnum rhs)
        {
            Debug.Log("== called");
            return lhs.GetInstanceID() == rhs.GetInstanceID();
        }

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static bool operator !=(ScriptableEnum lhs, ScriptableEnum rhs)
        {
            return lhs.GetInstanceID() != rhs.GetInstanceID();
        }
    }
}
