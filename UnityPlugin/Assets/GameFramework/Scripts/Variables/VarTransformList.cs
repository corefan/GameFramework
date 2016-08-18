using GameFramework;
using System.Collections.Generic;
using UnityEngine;

namespace UnityGameFramework.Runtime
{
    public class VarTransformList : Variable<List<Transform>>
    {
        public VarTransformList()
        {

        }

        public VarTransformList(List<Transform> value)
            : base(value)
        {

        }

        public static implicit operator VarTransformList(List<Transform> value)
        {
            return new VarTransformList(value);
        }

        public static implicit operator List<Transform>(VarTransformList value)
        {
            return value.Value;
        }
    }
}
