using UnityEngine;

namespace Core.Core
{
    public static class Vector2Extension
    {
        public static Vector2 ToRightAngleDirection(this Vector2 value)
        {
            if (value == Vector2.zero)
                return value;
            
            Vector2 normalValue = value.normalized;
            
            if (normalValue.y >= 0.5f) return Vector2.up;
            if (normalValue.y < -0.5f) return Vector2.down;
            if (normalValue.x >= 0.5f) return Vector2.right;
            if (normalValue.x < -0.5f) return Vector2.left;
            return Vector2.zero;
        }
    }
}