//------------------------------------------------------------
// Game Framework v2.x
// Copyright © 2014-2016 Jiang Yin. All rights reserved.
// Homepage: http://gameframework.cn/
// Feedback: mailto:jiangyin@gameframework.cn
//------------------------------------------------------------

using GameFramework;

namespace UnityGameFramework.Runtime
{
    public class VarByte : Variable<byte>
    {
        public VarByte()
        {

        }

        public VarByte(byte value)
            : base(value)
        {

        }

        public static implicit operator VarByte(byte value)
        {
            return new VarByte(value);
        }

        public static implicit operator byte(VarByte value)
        {
            return value.Value;
        }
    }
}
