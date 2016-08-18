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
    public class VarTransform : Variable<Transform>
    {
        public VarTransform()
        {

        }

        public VarTransform(Transform value)
            : base(value)
        {

        }

        public static implicit operator VarTransform(Transform value)
        {
            return new VarTransform(value);
        }

        public static implicit operator Transform(VarTransform value)
        {
            return value.Value;
        }
    }
}
