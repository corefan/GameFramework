using GameFramework;

namespace UnityGameFramework.Runtime
{
    public class VarBytes : Variable<byte[]>
    {
        public VarBytes()
        {

        }

        public VarBytes(byte[] value)
            : base(value)
        {

        }

        public static implicit operator VarBytes(byte[] value)
        {
            return new VarBytes(value);
        }

        public static implicit operator byte[] (VarBytes value)
        {
            return value.Value;
        }
    }
}
