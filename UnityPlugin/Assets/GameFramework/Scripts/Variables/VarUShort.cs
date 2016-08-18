using GameFramework;

namespace UnityGameFramework.Runtime
{
    public class VarUShort : Variable<ushort>
    {
        public VarUShort()
        {

        }

        public VarUShort(ushort value)
            : base(value)
        {

        }

        public static implicit operator VarUShort(ushort value)
        {
            return new VarUShort(value);
        }

        public static implicit operator ushort(VarUShort value)
        {
            return value.Value;
        }
    }
}
