//------------------------------------------------------------
// Game Framework v2.x
// Copyright © 2014-2016 Jiang Yin. All rights reserved.
// Homepage: http://gameframework.cn/
// Feedback: mailto:jiangyin@gameframework.cn
//------------------------------------------------------------

using GameFramework;
using System;

namespace UnityGameFramework.Runtime
{
    public class VarDateTime : Variable<DateTime>
    {
        public VarDateTime()
        {

        }

        public VarDateTime(DateTime value)
            : base(value)
        {

        }

        public static implicit operator VarDateTime(DateTime value)
        {
            return new VarDateTime(value);
        }

        public static implicit operator DateTime(VarDateTime value)
        {
            return value.Value;
        }
    }
}
