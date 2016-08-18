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
    public class VarRect : Variable<Rect>
    {
        public VarRect()
        {

        }

        public VarRect(Rect value)
            : base(value)
        {

        }

        public static implicit operator VarRect(Rect value)
        {
            return new VarRect(value);
        }

        public static implicit operator Rect(VarRect value)
        {
            return value.Value;
        }
    }
}
