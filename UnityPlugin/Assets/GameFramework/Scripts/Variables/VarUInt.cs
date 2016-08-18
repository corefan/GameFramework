using GameFramework;

namespace UnityGameFramework.Runtime
{
    public class VarUInt : Variable<uint>
    {
        public VarUInt()
        {

        }

        public VarUInt(uint value)
            : base(value)
        {

        }

        public static implicit operator VarUInt(uint value)
        {
            return new VarUInt(value);
        }

        public static implicit operator uint(VarUInt value)
        {
            return value.Value;
        }
    }
}
