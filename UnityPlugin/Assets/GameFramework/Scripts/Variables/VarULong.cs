//------------------------------------------------------------
// Game Framework v2.x
// Copyright © 2014-2016 Jiang Yin. All rights reserved.
// Homepage: http://gameframework.cn/
// Feedback: mailto:jiangyin@gameframework.cn
//------------------------------------------------------------

using GameFramework;

namespace UnityGameFramework.Runtime
{
    public class VarULong : Variable<ulong>
    {
        public VarULong()
        {

        }

        public VarULong(ulong value)
            : base(value)
        {

        }

        public static implicit operator VarULong(ulong value)
        {
            return new VarULong(value);
        }

        public static implicit operator ulong(VarULong value)
        {
            return value.Value;
        }
    }
}
