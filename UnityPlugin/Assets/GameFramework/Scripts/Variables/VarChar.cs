//------------------------------------------------------------
// Game Framework v2.x
// Copyright © 2014-2016 Jiang Yin. All rights reserved.
// Homepage: http://gameframework.cn/
// Feedback: mailto:jiangyin@gameframework.cn
//------------------------------------------------------------

using GameFramework;

namespace UnityGameFramework.Runtime
{
    public class VarChar : Variable<char>
    {
        public VarChar()
        {

        }

        public VarChar(char value)
            : base(value)
        {

        }

        public static implicit operator VarChar(char value)
        {
            return new VarChar(value);
        }

        public static implicit operator char(VarChar value)
        {
            return value.Value;
        }
    }
}
