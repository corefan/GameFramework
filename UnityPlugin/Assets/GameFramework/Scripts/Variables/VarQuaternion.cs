using GameFramework;
using UnityEngine;

namespace UnityGameFramework.Runtime
{
    public class VarQuaternion : Variable<Quaternion>
    {
        public VarQuaternion()
        {

        }

        public VarQuaternion(Quaternion value)
            : base(value)
        {

        }

        public static implicit operator VarQuaternion(Quaternion value)
        {
            return new VarQuaternion(value);
        }

        public static implicit operator Quaternion(VarQuaternion value)
        {
            return value.Value;
        }
    }
}
