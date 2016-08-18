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
    public class VarGameObject : Variable<GameObject>
    {
        public VarGameObject()
        {

        }

        public VarGameObject(GameObject value)
            : base(value)
        {

        }

        public static implicit operator VarGameObject(GameObject value)
        {
            return new VarGameObject(value);
        }

        public static implicit operator GameObject(VarGameObject value)
        {
            return value.Value;
        }
    }
}
