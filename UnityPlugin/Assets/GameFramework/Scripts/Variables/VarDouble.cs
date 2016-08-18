using GameFramework;

namespace UnityGameFramework.Runtime
{
    public class VarDouble : Variable<double>
    {
        public VarDouble()
        {

        }

        public VarDouble(double value)
            : base(value)
        {

        }

        public static implicit operator VarDouble(double value)
        {
            return new VarDouble(value);
        }

        public static implicit operator double(VarDouble value)
        {
            return value.Value;
        }
    }
}
