using GameFramework;

namespace UnityGameFramework.Runtime
{
    public class VarByte : Variable<byte>
    {
        public VarByte()
        {

        }

        public VarByte(byte value)
            : base(value)
        {

        }

        public static implicit operator VarByte(byte value)
        {
            return new VarByte(value);
        }

        public static implicit operator byte(VarByte value)
        {
            return value.Value;
        }
    }
}
