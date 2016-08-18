//------------------------------------------------------------
// Game Framework v2.x
// Copyright © 2014-2016 Jiang Yin. All rights reserved.
// Homepage: http://gameframework.cn/
// Feedback: mailto:jiangyin@gameframework.cn
//------------------------------------------------------------

using GameFramework;

namespace UnityGameFramework.Runtime
{
    public class VarUShort : Variable<ushort>
    {
        public VarUShort()
        {

        }

        public VarUShort(ushort value)
            : base(value)
        {

        }

        public static implicit operator VarUShort(ushort value)
        {
            return new VarUShort(value);
        }

        public static implicit operator ushort(VarUShort value)
        {
            return value.Value;
        }
    }
}
