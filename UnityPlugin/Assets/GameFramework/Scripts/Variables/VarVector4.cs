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
    public class VarVector4 : Variable<Vector4>
    {
        public VarVector4()
        {

        }

        public VarVector4(Vector4 value)
            : base(value)
        {

        }

        public static implicit operator VarVector4(Vector4 value)
        {
            return new VarVector4(value);
        }

        public static implicit operator Vector4(VarVector4 value)
        {
            return value.Value;
        }
    }
}
