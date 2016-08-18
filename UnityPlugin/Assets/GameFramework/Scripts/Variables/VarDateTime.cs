using GameFramework;
using System;

namespace UnityGameFramework.Runtime
{
    public class VarDateTime : Variable<DateTime>
    {
        public VarDateTime()
        {

        }

        public VarDateTime(DateTime value)
            : base(value)
        {

        }

        public static implicit operator VarDateTime(DateTime value)
        {
            return new VarDateTime(value);
        }

        public static implicit operator DateTime(VarDateTime value)
        {
            return value.Value;
        }
    }
}
