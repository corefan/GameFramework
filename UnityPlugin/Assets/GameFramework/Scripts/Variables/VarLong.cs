//------------------------------------------------------------
// Game Framework v2.x
// Copyright © 2014-2016 Jiang Yin. All rights reserved.
// Homepage: http://gameframework.cn/
// Feedback: mailto:jiangyin@gameframework.cn
//------------------------------------------------------------

using GameFramework;

namespace UnityGameFramework.Runtime
{
    public class VarLong : Variable<long>
    {
        public VarLong()
        {

        }

        public VarLong(long value)
            : base(value)
        {

        }

        public static implicit operator VarLong(long value)
        {
            return new VarLong(value);
        }

        public static implicit operator long(VarLong value)
        {
            return value.Value;
        }
    }
}
