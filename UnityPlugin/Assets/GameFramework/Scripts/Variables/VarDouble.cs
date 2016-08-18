//------------------------------------------------------------
// Game Framework v2.x
// Copyright © 2014-2016 Jiang Yin. All rights reserved.
// Homepage: http://gameframework.cn/
// Feedback: mailto:jiangyin@gameframework.cn
//------------------------------------------------------------

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
