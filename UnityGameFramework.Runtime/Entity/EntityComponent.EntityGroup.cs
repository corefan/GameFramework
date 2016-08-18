//------------------------------------------------------------
// Game Framework v2.x
// Copyright © 2014-2016 Jiang Yin. All rights reserved.
// Homepage: http://gameframework.cn/
// Feedback: mailto:jiangyin@gameframework.cn
//------------------------------------------------------------

using System;
using UnityEngine;

namespace UnityGameFramework.Runtime
{
    public partial class EntityComponent
    {
        [Serializable]
        private sealed class EntityGroup
        {
            [SerializeField]
            private string m_Name = null;

            [SerializeField]
            private int m_InstanceCapacity = 4;

            public string Name
            {
                get
                {
                    return m_Name;
                }
            }

            public int InstanceCapacity
            {
                get
                {
                    return m_InstanceCapacity;
                }
            }
        }
    }
}
