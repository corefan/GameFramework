using GameFramework;

namespace UnityGameFramework.Runtime
{
    public class VarString : Variable<string>
    {
        public VarString()
        {

        }

        public VarString(string value)
            : base(value)
        {

        }

        public static implicit operator VarString(string value)
        {
            return new VarString(value);
        }

        public static implicit operator string(VarString value)
        {
            return value.Value;
        }
    }
}
