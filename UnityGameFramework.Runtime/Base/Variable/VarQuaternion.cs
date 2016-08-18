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
    /// Quaternion 变量类。
    /// </summary>
    public class VarQuaternion : Variable<Quaternion>
    {
        /// <summary>
        /// 初始化 Quaternion 变量类的新实例。
        /// </summary>
        public VarQuaternion()
        {

        }

        /// <summary>
        /// 初始化 Quaternion 变量类的新实例。
        /// </summary>
        /// <param name="value">值。</param>
        public VarQuaternion(Quaternion value)
            : base(value)
        {

        }

        /// <summary>
        /// 从 Quaternion 到 Quaternion 变量类的隐式转换。
        /// </summary>
        /// <param name="value">值。</param>
        public static implicit operator VarQuaternion(Quaternion value)
        {
            return new VarQuaternion(value);
        }

        /// <summary>
        /// 从 Quaternion 变量类到 Quaternion 的隐式转换。
        /// </summary>
        /// <param name="value">值。</param>
        public static implicit operator Quaternion(VarQuaternion value)
        {
            return value.Value;
        }
    }
}
