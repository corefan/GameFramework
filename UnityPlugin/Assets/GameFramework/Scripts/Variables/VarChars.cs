//------------------------------------------------------------
// Game Framework v2.x
// Copyright © 2014-2016 Jiang Yin. All rights reserved.
// Homepage: http://gameframework.cn/
// Feedback: mailto:jiangyin@gameframework.cn
//------------------------------------------------------------

using GameFramework;

namespace UnityGameFramework.Runtime
{
    public class VarChars : Variable<char[]>
    {
        public VarChars()
        {

        }

        public VarChars(char[] value)
            : base(value)
        {

        }

        public static implicit operator VarChars(char[] value)
        {
            return new VarChars(value);
        }

        public static implicit operator char[] (VarChars value)
        {
            return value.Value;
        }
    }
}
