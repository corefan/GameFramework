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
    public class VarQuaternion : Variable<Quaternion>
    {
        public VarQuaternion()
        {

        }

        public VarQuaternion(Quaternion value)
            : base(value)
        {

        }

        public static implicit operator VarQuaternion(Quaternion value)
        {
            return new VarQuaternion(value);
        }

        public static implicit operator Quaternion(VarQuaternion value)
        {
            return value.Value;
        }
    }
}
