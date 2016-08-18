//------------------------------------------------------------
// Game Framework v2.x
// Copyright © 2014-2016 Jiang Yin. All rights reserved.
// Homepage: http://gameframework.cn/
// Feedback: mailto:jiangyin@gameframework.cn
//------------------------------------------------------------

using GameFramework;

namespace UnityGameFramework.Runtime
{
    public class VarFloat : Variable<float>
    {
        public VarFloat()
        {

        }

        public VarFloat(float value)
            : base(value)
        {

        }

        public static implicit operator VarFloat(float value)
        {
            return new VarFloat(value);
        }

        public static implicit operator float(VarFloat value)
        {
            return value.Value;
        }
    }
}
