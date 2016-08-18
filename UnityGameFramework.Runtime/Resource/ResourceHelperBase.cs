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
        /// 获取 AssetBundleManifest。
        /// </summary>
        protected internal AssetBundleManifest AssetBundleManifest
        {
            get;
            internal set;
        }

        /// <summary>
        /// 直接从指定文件路径读取数据流。
        /// </summary>
        /// <param name="fileUri">文件路径。</param>
        /// <param name="loadBytesCallback">读取数据流回调函数。</param>
        public abstract void LoadBytes(string fileUri, LoadBytesCallback loadBytesCallback);

        /// <summary>
        /// 获取依赖资源。
        /// </summary>
        /// <param name="resourceName">资源名称。</param>
        /// <returns>被依赖的资源名称。</returns>
        public abstract string[] GetDependencies(string resourceName);

        /// <summary>
        /// 实例化资源。
        /// </summary>
        /// <param name="asset">要实例化的资源。</param>
        /// <returns>实例化后的资源。</returns>
        public abstract object Instantiate(object asset);

        /// <summary>
        /// 卸载场景。
        /// </summary>
        /// <param name="sceneName">场景名称。</param>
        /// <returns>是否成功卸载场景。</returns>
        public abstract bool UnloadScene(string sceneName);

        /// <summary>
        /// 释放资源。
        /// </summary>
        /// <param name="resource">要释放的资源。</param>
        public abstract void ReleaseResource(object resource);
    }
}
