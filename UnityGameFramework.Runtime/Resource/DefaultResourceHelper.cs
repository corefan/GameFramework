//------------------------------------------------------------
// Game Framework v2.x
// Copyright © 2014-2016 Jiang Yin. All rights reserved.
// Homepage: http://gameframework.cn/
// Feedback: mailto:jiangyin@gameframework.cn
//------------------------------------------------------------

using GameFramework;
using GameFramework.Resource;
using System.Collections;
using UnityEngine;
using UnityEngine.SceneManagement;

namespace UnityGameFramework.Runtime
{
    /// <summary>
    /// 默认资源辅助器。
    /// </summary>
    public class DefaultResourceHelper : ResourceHelperBase
    {
        private ResourceComponent m_ResourceComponent = null;

        /// <summary>
        /// 直接从指定文件路径读取数据流。
        /// </summary>
        /// <param name="fileUri">文件路径。</param>
        /// <param name="loadBytesCallback">读取数据流回调函数。</param>
        public override void LoadBytes(string fileUri, LoadBytesCallback loadBytesCallback)
        {
            StartCoroutine(LoadBytesCo(fileUri, loadBytesCallback));
        }

        /// <summary>
        /// 获取依赖资源。
        /// </summary>
        /// <param name="resourceName">资源名称。</param>
        /// <returns>被依赖的资源名称。</returns>
        public override string[] GetDependencies(string resourceName)
        {
            if (AssetBundleManifest == null)
            {
                return null;
            }

            return AssetBundleManifest.GetAllDependencies(resourceName);
        }

        /// <summary>
        /// 实例化资源。
        /// </summary>
        /// <param name="asset">要实例化的资源。</param>
        /// <returns>实例化后的资源。</returns>
        public override object Instantiate(object asset)
        {
            return Object.Instantiate(asset as Object);
        }

        /// <summary>
        /// 卸载场景。
        /// </summary>
        /// <param name="sceneName">场景名称。</param>
        /// <returns>是否成功卸载场景。</returns>
        public override bool UnloadScene(string sceneName)
        {
            bool retVal = SceneManager.UnloadScene(sceneName);
            if (retVal)
            {
                m_ResourceComponent.UnloadUnusedAssets(false, "release scene");
            }

            return retVal;
        }

        /// <summary>
        /// 释放资源。
        /// </summary>
        /// <param name="resource">要释放的资源。</param>
        public override void ReleaseResource(object resource)
        {
            if (resource == null)
            {
                Log.Warning("Resource is invalid.");
                return;
            }

            AssetBundle assetBundle = resource as AssetBundle;
            if (assetBundle == null)
            {
                Log.Warning("Resource is invalid.");
                return;
            }

            assetBundle.Unload(false);
        }

        private void Start()
        {
            m_ResourceComponent = GameEntry.GetComponent<ResourceComponent>();
            if (m_ResourceComponent == null)
            {
                Log.Fatal("Resource component is invalid.");
                return;
            }
        }

        private IEnumerator LoadBytesCo(string fileUri, LoadBytesCallback loadBytesCallback)
        {
            WWW www = new WWW(fileUri);
            yield return www;

            byte[] bytes = www.bytes;
            string errorMessage = www.error;
            www.Dispose();

            loadBytesCallback?.Invoke(fileUri, bytes, errorMessage);
        }
    }
}
