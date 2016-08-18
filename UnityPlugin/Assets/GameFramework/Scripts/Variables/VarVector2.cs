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
    public class VarVector2 : Variable<Vector2>
    {
        public VarVector2()
        {

        }

        public VarVector2(Vector2 value)
            : base(value)
        {

        }

        public static implicit operator VarVector2(Vector2 value)
        {
            return new VarVector2(value);
        }

        public static implicit operator Vector2(VarVector2 value)
        {
            return value.Value;
        }
    }
}
