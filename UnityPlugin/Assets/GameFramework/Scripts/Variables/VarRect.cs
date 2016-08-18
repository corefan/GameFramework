using GameFramework;
using UnityEngine;

namespace UnityGameFramework.Runtime
{
    public class VarRect : Variable<Rect>
    {
        public VarRect()
        {

        }

        public VarRect(Rect value)
            : base(value)
        {

        }

        public static implicit operator VarRect(Rect value)
        {
            return new VarRect(value);
        }

        public static implicit operator Rect(VarRect value)
        {
            return value.Value;
        }
    }
}
