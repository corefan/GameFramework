//------------------------------------------------------------
// Game Framework v2.x
// Copyright © 2014-2016 Jiang Yin. All rights reserved.
// Homepage: http://gameframework.cn/
// Feedback: mailto:jiangyin@gameframework.cn
//------------------------------------------------------------

using GameFramework;
using UnityEngine;

namespace UnityGameFramework.Runtime
{
    public class VarColor : Variable<Color>
    {
        public VarColor()
        {

        }

        public VarColor(Color value)
            : base(value)
        {

        }

        public static implicit operator VarColor(Color value)
        {
            return new VarColor(value);
        }

        public static implicit operator Color(VarColor value)
        {
            return value.Value;
        }
    }
}
