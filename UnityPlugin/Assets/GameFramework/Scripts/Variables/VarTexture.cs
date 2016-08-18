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
    public class VarTexture : Variable<Texture>
    {
        public VarTexture()
        {

        }

        public VarTexture(Texture value)
            : base(value)
        {

        }

        public static implicit operator VarTexture(Texture value)
        {
            return new VarTexture(value);
        }

        public static implicit operator Texture(VarTexture value)
        {
            return value.Value;
        }
    }
}
