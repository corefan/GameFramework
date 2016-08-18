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
    public class VarUnityObjectList : Variable<List<Object>>
    {
        public VarUnityObjectList()
        {

        }

        public VarUnityObjectList(List<Object> value)
            : base(value)
        {

        }

        public static implicit operator VarUnityObjectList(List<Object> value)
        {
            return new VarUnityObjectList(value);
        }

        public static implicit operator List<Object>(VarUnityObjectList value)
        {
            return value.Value;
        }
    }
}
