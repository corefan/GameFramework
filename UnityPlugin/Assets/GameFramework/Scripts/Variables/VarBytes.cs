//------------------------------------------------------------
// Game Framework v2.x
// Copyright © 2014-2016 Jiang Yin. All rights reserved.
// Homepage: http://gameframework.cn/
// Feedback: mailto:jiangyin@gameframework.cn
//------------------------------------------------------------

using GameFramework;

namespace UnityGameFramework.Runtime
{
    public class VarBytes : Variable<byte[]>
    {
        public VarBytes()
        {

        }

        public VarBytes(byte[] value)
            : base(value)
        {

        }

        public static implicit operator VarBytes(byte[] value)
        {
            return new VarBytes(value);
        }

        public static implicit operator byte[] (VarBytes value)
        {
            return value.Value;
        }
    }
}
