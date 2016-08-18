//------------------------------------------------------------
// Game Framework v2.x
// Copyright © 2014-2016 Jiang Yin. All rights reserved.
// Homepage: http://gameframework.cn/
// Feedback: mailto:jiangyin@gameframework.cn
//------------------------------------------------------------

using GameFramework;

namespace UnityGameFramework.Runtime
{
    public class VarSByte : Variable<sbyte>
    {
        public VarSByte()
        {

        }

        public VarSByte(sbyte value)
            : base(value)
        {

        }

        public static implicit operator VarSByte(sbyte value)
        {
            return new VarSByte(value);
        }

        public static implicit operator sbyte(VarSByte value)
        {
            return value.Value;
        }
    }
}
