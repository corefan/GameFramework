//------------------------------------------------------------
// Game Framework v2.x
// Copyright © 2014-2016 Jiang Yin. All rights reserved.
// Homepage: http://gameframework.cn/
// Feedback: mailto:jiangyin@gameframework.cn
//------------------------------------------------------------

using GameFramework;

namespace UnityGameFramework.Runtime
{
    public class VarShort : Variable<short>
    {
        public VarShort()
        {

        }

        public VarShort(short value)
            : base(value)
        {

        }

        public static implicit operator VarShort(short value)
        {
            return new VarShort(value);
        }

        public static implicit operator short(VarShort value)
        {
            return value.Value;
        }
    }
}
