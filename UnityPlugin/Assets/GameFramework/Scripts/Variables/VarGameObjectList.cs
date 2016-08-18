//------------------------------------------------------------
// Game Framework v2.x
// Copyright © 2014-2016 Jiang Yin. All rights reserved.
// Homepage: http://gameframework.cn/
// Feedback: mailto:jiangyin@gameframework.cn
//------------------------------------------------------------

using GameFramework;
using System.Collections.Generic;
using UnityEngine;

namespace UnityGameFramework.Runtime
{
    public class VarGameObjectList : Variable<List<GameObject>>
    {
        public VarGameObjectList()
        {

        }

        public VarGameObjectList(List<GameObject> value)
            : base(value)
        {

        }

        public static implicit operator VarGameObjectList(List<GameObject> value)
        {
            return new VarGameObjectList(value);
        }

        public static implicit operator List<GameObject>(VarGameObjectList value)
        {
            return value.Value;
        }
    }
}
