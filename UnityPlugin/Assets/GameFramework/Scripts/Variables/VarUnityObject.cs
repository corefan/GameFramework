using GameFramework;
using UnityEngine;

namespace UnityGameFramework.Runtime
{
    public class VarUnityObject : Variable<Object>
    {
        public VarUnityObject()
        {

        }

        public VarUnityObject(Object value)
            : base(value)
        {

        }

        public static implicit operator VarUnityObject(Object value)
        {
            return new VarUnityObject(value);
        }

        public static implicit operator Object(VarUnityObject value)
        {
            return value.Value;
        }
    }
}
