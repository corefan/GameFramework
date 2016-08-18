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
    /// GameObject 变量类。
    /// </summary>
    public class VarGameObject : Variable<GameObject>
    {
        /// <summary>
        /// 初始化 GameObject 变量类的新实例。
        /// </summary>
        public VarGameObject()
        {

        }

        /// <summary>
        /// 初始化 GameObject 变量类的新实例。
        /// </summary>
        /// <param name="value">值。</param>
        public VarGameObject(GameObject value)
            : base(value)
        {

        }

        /// <summary>
        /// 从 GameObject 到 GameObject 变量类的隐式转换。
        /// </summary>
        /// <param name="value">值。</param>
        public static implicit operator VarGameObject(GameObject value)
        {
            return new VarGameObject(value);
        }

        /// <summary>
        /// 从 GameObject 变量类到 GameObject 的隐式转换。
        /// </summary>
        /// <param name="value">值。</param>
        public static implicit operator GameObject(VarGameObject value)
        {
            return value.Value;
        }
    }
}
