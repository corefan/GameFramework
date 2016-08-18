using GameFramework;

namespace UnityGameFramework.Runtime
{
    public class VarObject : Variable<object>
    {
        public VarObject()
        {

        }

        public VarObject(object value)
            : base(value)
        {

        }
    }
}
