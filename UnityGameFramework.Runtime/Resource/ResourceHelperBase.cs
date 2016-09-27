//------------------------------------------------------------
// Game Framework v2.x
// Copyright © 2014-2016 Jiang Yin. All rights reserved.
// Homepage: http://gameframework.cn/
// Feedback: mailto:jiangyin@gameframework.cn
//------------------------------------------------------------

using GameFramework.Resource;
using UnityEngine;

namespace UnityGameFramework.Runtime
{
    /// <summary>
    /// 资源辅助器基类。
    /// </summary>
    public abstract class ResourceHelperBase : MonoBehaviour, IResourceHelper
    {
        /// <summary>
        /// 直接从指定文件路径读取数据流。
        /// </summary>
        /// <param name="fileUri">文件路径。</param>
        /// <param name="loadBytesCallback">读取数据流回调函数。</param>
        public abstract void LoadBytes(string fileUri, LoadBytesCallback loadBytesCallback);

        /// <summary>
        /// 卸载场景。
        /// </summary>
        /// <param name="sceneName">场景名称。</param>
        /// <returns>是否成功卸载场景。</returns>
        public abstract bool UnloadScene(string sceneName);

        /// <summary>
        /// 释放资源。
        /// </summary>
        /// <param name="objectToRelease">要释放的资源。</param>
        public abstract void Release(object objectToRelease);
    }
}
