using GameFramework;
using System.Collections.Generic;

namespace UnityGameFramework.Runtime
{
    public class VarObjectList : Variable<List<object>>
    {
        public VarObjectList()
        {

        }

        public VarObjectList(List<object> value)
            : base(value)
        {

        }

        public static implicit operator VarObjectList(List<object> value)
        {
            return new VarObjectList(value);
        }

        public static implicit operator List<object>(VarObjectList value)
        {
            return value.Value;
        }
    }
}
