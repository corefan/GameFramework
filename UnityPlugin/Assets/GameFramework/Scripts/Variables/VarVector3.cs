using GameFramework;
using UnityEngine;

namespace UnityGameFramework.Runtime
{
    public class VarVector3 : Variable<Vector3>
    {
        public VarVector3()
        {

        }

        public VarVector3(Vector3 value)
            : base(value)
        {

        }

        public static implicit operator VarVector3(Vector3 value)
        {
            return new VarVector3(value);
        }

        public static implicit operator Vector3(VarVector3 value)
        {
            return value.Value;
        }
    }
}
