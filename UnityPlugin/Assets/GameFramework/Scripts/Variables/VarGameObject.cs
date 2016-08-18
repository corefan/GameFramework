using GameFramework;
using UnityEngine;

namespace UnityGameFramework.Runtime
{
    public class VarGameObject : Variable<GameObject>
    {
        public VarGameObject()
        {

        }

        public VarGameObject(GameObject value)
            : base(value)
        {

        }

        public static implicit operator VarGameObject(GameObject value)
        {
            return new VarGameObject(value);
        }

        public static implicit operator GameObject(VarGameObject value)
        {
            return value.Value;
        }
    }
}
