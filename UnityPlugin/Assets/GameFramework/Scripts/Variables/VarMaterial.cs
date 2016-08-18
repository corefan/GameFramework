using GameFramework;
using UnityEngine;

namespace UnityGameFramework.Runtime
{
    public class VarMaterial : Variable<Material>
    {
        public VarMaterial()
        {

        }

        public VarMaterial(Material value)
            : base(value)
        {

        }

        public static implicit operator VarMaterial(Material value)
        {
            return new VarMaterial(value);
        }

        public static implicit operator Material(VarMaterial value)
        {
            return value.Value;
        }
    }
}
