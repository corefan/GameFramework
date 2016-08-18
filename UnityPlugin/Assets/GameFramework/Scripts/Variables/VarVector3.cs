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
    public class VarVector3 : Variable<Vector3>
    {
        public VarVector3()
        {

        }

        public VarVector3(Vector3 value)
            : base(value)
        {

        }

        public static implicit operator VarVector3(Vector3 value)
        {
            return new VarVector3(value);
        }

        public static implicit operator Vector3(VarVector3 value)
        {
            return value.Value;
        }
    }
}
