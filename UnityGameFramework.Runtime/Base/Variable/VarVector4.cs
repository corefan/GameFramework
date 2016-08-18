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
    /// Vector4 变量类。
    /// </summary>
    public class VarVector4 : Variable<Vector4>
    {
        /// <summary>
        /// 初始化 Vector4 变量类的新实例。
        /// </summary>
        public VarVector4()
        {

        }

        /// <summary>
        /// 初始化 Vector4 变量类的新实例。
        /// </summary>
        /// <param name="value">值。</param>
        public VarVector4(Vector4 value)
            : base(value)
        {

        }

        /// <summary>
        /// 从 Vector4 到 Vector4 变量类的隐式转换。
        /// </summary>
        /// <param name="value">值。</param>
        public static implicit operator VarVector4(Vector4 value)
        {
            return new VarVector4(value);
        }

        /// <summary>
        /// 从 Vector4 变量类到 Vector4 的隐式转换。
        /// </summary>
        /// <param name="value">值。</param>
        public static implicit operator Vector4(VarVector4 value)
        {
            return value.Value;
        }
    }
}
