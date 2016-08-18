//------------------------------------------------------------
// Game Framework v2.x
// Copyright © 2014-2016 Jiang Yin. All rights reserved.
// Homepage: http://gameframework.cn/
// Feedback: mailto:jiangyin@gameframework.cn
//------------------------------------------------------------

using GameFramework;

namespace UnityGameFramework.Runtime
{
    public class VarDecimal : Variable<decimal>
    {
        public VarDecimal()
        {

        }

        public VarDecimal(decimal value)
            : base(value)
        {

        }

        public static implicit operator VarDecimal(decimal value)
        {
            return new VarDecimal(value);
        }

        public static implicit operator decimal(VarDecimal value)
        {
            return value.Value;
        }
    }
}
