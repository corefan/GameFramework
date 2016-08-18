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
    /// <summary>
    /// Color 变量类。
    /// </summary>
    public class VarColor : Variable<Color>
    {
        /// <summary>
        /// 初始化 Color 变量类的新实例。
        /// </summary>
        public VarColor()
        {

        }

        /// <summary>
        /// 初始化 Color 变量类的新实例。
        /// </summary>
        /// <param name="value">值。</param>
        public VarColor(Color value)
            : base(value)
        {

        }

        /// <summary>
        /// 从 Color 到 Color 变量类的隐式转换。
        /// </summary>
        /// <param name="value">值。</param>
        public static implicit operator VarColor(Color value)
        {
            return new VarColor(value);
        }

        /// <summary>
        /// 从 Color 变量类到 Color 的隐式转换。
        /// </summary>
        /// <param name="value">值。</param>
        public static implicit operator Color(VarColor value)
        {
            return value.Value;
        }
    }
}
