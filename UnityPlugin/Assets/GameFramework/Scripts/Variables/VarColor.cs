using GameFramework;
using UnityEngine;

namespace UnityGameFramework.Runtime
{
    public class VarColor : Variable<Color>
    {
        public VarColor()
        {

        }

        public VarColor(Color value)
            : base(value)
        {

        }

        public static implicit operator VarColor(Color value)
        {
            return new VarColor(value);
        }

        public static implicit operator Color(VarColor value)
        {
            return value.Value;
        }
    }
}
