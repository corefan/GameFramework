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
    public class VarUnityObject : Variable<Object>
    {
        public VarUnityObject()
        {

        }

        public VarUnityObject(Object value)
            : base(value)
        {

        }

        public static implicit operator VarUnityObject(Object value)
        {
            return new VarUnityObject(value);
        }

        public static implicit operator Object(VarUnityObject value)
        {
            return value.Value;
        }
    }
}
