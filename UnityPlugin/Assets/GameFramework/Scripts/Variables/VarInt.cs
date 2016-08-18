//------------------------------------------------------------
// Game Framework v2.x
// Copyright © 2014-2016 Jiang Yin. All rights reserved.
// Homepage: http://gameframework.cn/
// Feedback: mailto:jiangyin@gameframework.cn
//------------------------------------------------------------

using GameFramework;

namespace UnityGameFramework.Runtime
{
    public class VarInt : Variable<int>
    {
        public VarInt()
        {

        }

        public VarInt(int value)
            : base(value)
        {

        }

        public static implicit operator VarInt(int value)
        {
            return new VarInt(value);
        }

        public static implicit operator int(VarInt value)
        {
            return value.Value;
        }
    }
}
