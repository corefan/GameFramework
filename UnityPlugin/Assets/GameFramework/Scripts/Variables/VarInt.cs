using GameFramework;

namespace UnityGameFramework.Runtime
{
    public class VarInt : Variable<int>
    {
        public VarInt()
        {

        }

        public VarInt(int value)
            : base(value)
        {

        }

        public static implicit operator VarInt(int value)
        {
            return new VarInt(value);
        }

        public static implicit operator int(VarInt value)
        {
            return value.Value;
        }
    }
}
