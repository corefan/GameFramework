//------------------------------------------------------------
// Game Framework v2.x
// Copyright © 2014-2016 Jiang Yin. All rights reserved.
// Homepage: http://gameframework.cn/
// Feedback: mailto:jiangyin@gameframework.cn
//------------------------------------------------------------

using GameFramework;
using GameFramework.Download;
using GameFramework.ObjectPool;
using GameFramework.Resource;
using System;
using System.Collections.Generic;

#if UNITY_EDITOR

using UnityEditor;

#endif

using UnityEngine;
using UnityEngine.SceneManagement;

namespace UnityGameFramework.Runtime
{
    /// <summary>
    /// 编辑器资源组件。
    /// </summary>
    public class EditorResourceComponent : MonoBehaviour, IResourceManager
    {
        private string m_ReadOnlyPath = null;
        private string m_ReadWritePath = null;
        private List<LoadSceneInfo> m_LoadSceneInfos = null;

        private void Awake()
        {
            m_ReadOnlyPath = null;
            m_ReadWritePath = null;
            m_LoadSceneInfos = new List<LoadSceneInfo>();

            BaseComponent baseComponent = GetComponent<BaseComponent>();
            if (baseComponent == null)
            {
                Log.Error("Can not find base component.");
                return;
            }

            if (baseComponent.EditorResourceMode)
            {
                baseComponent.EditorResourceHelper = this;
                enabled = true;
            }
            else
            {
                enabled = false;
            }
        }

        private void Update()
        {
            if (m_LoadSceneInfos.Count <= 0)
            {
                return;
            }

            LoadSceneInfo[] loadSceneInfos = m_LoadSceneInfos.ToArray();
            for (int i = 0; i < loadSceneInfos.Length; i++)
            {
                if (loadSceneInfos[i].AsyncOperation.isDone)
                {
                    if (loadSceneInfos[i].AsyncOperation.allowSceneActivation)
                    {
                        if (loadSceneInfos[i].LoadSceneSuccessCallback != null)
                        {
                            loadSceneInfos[i].LoadSceneSuccessCallback(loadSceneInfos[i].SceneName, loadSceneInfos[i].SceneAssetName, loadSceneInfos[i].UserData);
                        }
                    }
                    else
                    {
                        if (loadSceneInfos[i].LoadSceneFailureCallback != null)
                        {
                            loadSceneInfos[i].LoadSceneFailureCallback(loadSceneInfos[i].SceneName, loadSceneInfos[i].SceneAssetName, LoadResourceStatus.NotExist, "Can not load this scene from asset database.", loadSceneInfos[i].UserData);
                        }
                    }

                    m_LoadSceneInfos.Remove(loadSceneInfos[i]);
                }
                else
                {
                    if (loadSceneInfos[i].LoadSceneUpdateCallback != null)
                    {
                        loadSceneInfos[i].LoadSceneUpdateCallback(loadSceneInfos[i].SceneName, loadSceneInfos[i].SceneAssetName, loadSceneInfos[i].AsyncOperation.progress, loadSceneInfos[i].UserData);
                    }
                }
            }
        }

        /// <summary>
        /// 获取资源只读区路径。
        /// </summary>
        public string ReadOnlyPath
        {
            get
            {
                return m_ReadOnlyPath;
            }
        }

        /// <summary>
        /// 获取资源读写区路径。
        /// </summary>
        public string ReadWritePath
        {
            get
            {
                return m_ReadWritePath;
            }
        }

        /// <summary>
        /// 获取资源模式。
        /// </summary>
        public ResourceMode ResourceMode
        {
            get
            {
                return ResourceMode.Unspecified;
            }
        }

        /// <summary>
        /// 获取当前变体。
        /// </summary>
        public string CurrentVariant
        {
            get
            {
                return null;
            }
        }

        /// <summary>
        /// 获取当前资源适用的游戏版本号。
        /// </summary>
        public string ApplicableGameVersion
        {
            get
            {
                throw new NotSupportedException("ApplicableGameVersion");
            }
        }

        /// <summary>
        /// 获取当前资源内部版本号。
        /// </summary>
        public int InternalResourceVersion
        {
            get
            {
                throw new NotSupportedException("InternalResourceVersion");
            }
        }

        /// <summary>
        /// 获取已准备完毕资源数量。
        /// </summary>
        public int AssetCount
        {
            get
            {
                throw new NotSupportedException("AssetCount");
            }
        }

        /// <summary>
        /// 获取已准备完毕资源数量。
        /// </summary>
        public int ResourceCount
        {
            get
            {
                throw new NotSupportedException("ResourceCount");
            }
        }

        /// <summary>
        /// 获取资源组个数。
        /// </summary>
        public int ResourceGroupCount
        {
            get
            {
                throw new NotSupportedException("ResourceGroupCount");
            }
        }

        /// <summary>
        /// 获取或设置资源更新下载地址。
        /// </summary>
        public string UpdatePrefixUri
        {
            get
            {
                throw new NotSupportedException("UpdatePrefixUri");
            }
            set
            {
                throw new NotSupportedException("UpdatePrefixUri");
            }
        }

        /// <summary>
        /// 获取或设置资源更新重试次数。
        /// </summary>
        public int UpdateRetryCount
        {
            get
            {
                throw new NotSupportedException("UpdateRetryCount");
            }
            set
            {
                throw new NotSupportedException("UpdateRetryCount");
            }
        }

        /// <summary>
        /// 获取等待更新资源个数。
        /// </summary>
        public int UpdateWaitingCount
        {
            get
            {
                throw new NotSupportedException("UpdateWaitingCount");
            }
        }

        /// <summary>
        /// 获取正在更新资源个数。
        /// </summary>
        public int UpdatingCount
        {
            get
            {
                throw new NotSupportedException("UpdatingCount");
            }
        }

        /// <summary>
        /// 获取加载资源代理总个数。
        /// </summary>
        public int LoadTotalAgentCount
        {
            get
            {
                throw new NotSupportedException("LoadTotalAgentCount");
            }
        }

        /// <summary>
        /// 获取可用加载资源代理个数。
        /// </summary>
        public int LoadFreeAgentCount
        {
            get
            {
                throw new NotSupportedException("LoadFreeAgentCount");
            }
        }

        /// <summary>
        /// 获取工作中加载资源代理个数。
        /// </summary>
        public int LoadWorkingAgentCount
        {
            get
            {
                throw new NotSupportedException("LoadWorkingAgentCount");
            }
        }

        /// <summary>
        /// 获取等待加载资源任务个数。
        /// </summary>
        public int LoadWaitingTaskCount
        {
            get
            {
                throw new NotSupportedException("LoadWaitingTaskCount");
            }
        }

        /// <summary>
        /// 获取或设置加载资源对象池的容量。
        /// </summary>
        public int ResourceCapacity
        {
            get
            {
                throw new NotSupportedException("ResourceCapacity");
            }
            set
            {
                throw new NotSupportedException("ResourceCapacity");
            }
        }

#pragma warning disable 0414

        /// <summary>
        /// 资源初始化完成事件。
        /// </summary>
        public event EventHandler<GameFramework.Resource.ResourceInitCompleteEventArgs> ResourceInitComplete = null;

        /// <summary>
        /// 版本资源列表更新成功事件。
        /// </summary>
        public event EventHandler<GameFramework.Resource.VersionListUpdateSuccessEventArgs> VersionListUpdateSuccess = null;

        /// <summary>
        /// 版本资源列表更新失败事件。
        /// </summary>
        public event EventHandler<GameFramework.Resource.VersionListUpdateFailureEventArgs> VersionListUpdateFailure = null;

        /// <summary>
        /// 资源检查完成事件。
        /// </summary>
        public event EventHandler<GameFramework.Resource.ResourceCheckCompleteEventArgs> ResourceCheckComplete = null;

        /// <summary>
        /// 资源更新开始事件。
        /// </summary>
        public event EventHandler<GameFramework.Resource.ResourceUpdateStartEventArgs> ResourceUpdateStart = null;

        /// <summary>
        /// 资源更新改变事件。
        /// </summary>
        public event EventHandler<GameFramework.Resource.ResourceUpdateChangedEventArgs> ResourceUpdateChanged = null;

        /// <summary>
        /// 资源更新成功事件。
        /// </summary>
        public event EventHandler<GameFramework.Resource.ResourceUpdateSuccessEventArgs> ResourceUpdateSuccess = null;

        /// <summary>
        /// 资源更新失败事件。
        /// </summary>
        public event EventHandler<GameFramework.Resource.ResourceUpdateFailureEventArgs> ResourceUpdateFailure = null;

        /// <summary>
        /// 资源更新全部完成事件。
        /// </summary>
        public event EventHandler<GameFramework.Resource.ResourceUpdateAllCompleteEventArgs> ResourceUpdateAllComplete = null;

#pragma warning restore 0414

        /// <summary>
        /// 设置资源只读区路径。
        /// </summary>
        /// <param name="readOnlyPath">资源只读区路径。</param>
        public void SetReadOnlyPath(string readOnlyPath)
        {
            if (string.IsNullOrEmpty(readOnlyPath))
            {
                throw new GameFrameworkException("Readonly path is invalid.");
            }

            m_ReadOnlyPath = readOnlyPath;
        }

        /// <summary>
        /// 设置资源读写区路径。
        /// </summary>
        /// <param name="readWritePath">资源读写区路径。</param>
        public void SetReadWritePath(string readWritePath)
        {
            if (string.IsNullOrEmpty(readWritePath))
            {
                throw new GameFrameworkException("Read-write path is invalid.");
            }

            m_ReadWritePath = readWritePath;
        }

        /// <summary>
        /// 设置资源模式。
        /// </summary>
        /// <param name="resourceMode">资源模式。</param>
        public void SetResourceMode(ResourceMode resourceMode)
        {
            throw new NotSupportedException("SetResourceMode");
        }

        /// <summary>
        /// 设置当前变体。
        /// </summary>
        /// <param name="currentVariant">当前变体。</param>
        public void SetCurrentVariant(string currentVariant)
        {
            throw new NotSupportedException("SetCurrentVariant");
        }

        /// <summary>
        /// 设置对象池管理器。
        /// </summary>
        /// <param name="objectPoolManager">对象池管理器。</param>
        public void SetObjectPoolManager(IObjectPoolManager objectPoolManager)
        {
            throw new NotSupportedException("SetObjectPoolManager");
        }

        /// <summary>
        /// 设置下载管理器。
        /// </summary>
        /// <param name="downloadManager">下载管理器。</param>
        public void SetDownloadManager(IDownloadManager downloadManager)
        {
            throw new NotSupportedException("SetDownloadManager");
        }

        /// <summary>
        /// 设置解密资源回调函数。
        /// </summary>
        /// <param name="decryptResourceCallback">要设置的解密资源回调函数。</param>
        /// <remarks>如果不设置，将使用默认的解密资源回调函数。</remarks>
        public void SetDecryptResourceCallback(DecryptResourceCallback decryptResourceCallback)
        {
            throw new NotSupportedException("SetDecryptResourceCallback");
        }

        /// <summary>
        /// 设置资源辅助器。
        /// </summary>
        /// <param name="resourceHelper">资源辅助器。</param>
        public void SetResourceHelper(IResourceHelper resourceHelper)
        {
            throw new NotSupportedException("SetResourceHelper");
        }

        /// <summary>
        /// 增加加载资源代理辅助器。
        /// </summary>
        /// <param name="loadResourceAgentHelper">要增加的加载资源代理辅助器。</param>
        public void AddLoadResourceAgentHelper(ILoadResourceAgentHelper loadResourceAgentHelper)
        {
            throw new NotSupportedException("AddLoadResourceAgentHelper");
        }

        /// <summary>
        /// 使用单机模式并初始化资源。
        /// </summary>
        public void InitResources()
        {
            throw new NotSupportedException("InitResources");
        }

        /// <summary>
        /// 检查版本资源列表。
        /// </summary>
        /// <param name="latestInternalResourceVersion">最新的资源内部版本号。</param>
        /// <returns>检查版本资源列表结果。</returns>
        public CheckVersionListResult CheckVersionList(int latestInternalResourceVersion)
        {
            throw new NotSupportedException("CheckVersionList");
        }

        /// <summary>
        /// 更新版本资源列表。
        /// </summary>
        /// <param name="versionListLength">版本资源列表大小。</param>
        /// <param name="versionListHashCode">版本资源列表哈希值。</param>
        /// <param name="versionListZipLength">版本资源列表压缩后大小。</param>
        /// <param name="versionListZipHashCode">版本资源列表压缩后哈希值。</param>
        public void UpdateVersionList(int versionListLength, int versionListHashCode, int versionListZipLength, int versionListZipHashCode)
        {
            throw new NotSupportedException("UpdateVersionList");
        }

        /// <summary>
        /// 检查资源。
        /// </summary>
        public void CheckResources()
        {
            throw new NotSupportedException("CheckResources");
        }

        /// <summary>
        /// 更新资源。
        /// </summary>
        public void UpdateResources()
        {
            throw new NotSupportedException("UpdateResources");
        }

        /// <summary>
        /// 异步加载资源。
        /// </summary>
        /// <param name="assetName">要加载资源的名称。</param>
        /// <param name="loadAssetSuccessCallback">加载资源成功回调函数。</param>
        /// <param name="loadAssetFailureCallback">加载资源失败回调函数。</param>
        public void LoadAsset(string assetName, LoadAssetSuccessCallback loadAssetSuccessCallback, LoadAssetFailureCallback loadAssetFailureCallback)
        {
            LoadAsset(assetName, loadAssetSuccessCallback, loadAssetFailureCallback, null);
        }

        /// <summary>
        /// 异步加载资源。
        /// </summary>
        /// <param name="assetName">要加载资源的名称。</param>
        /// <param name="loadAssetSuccessCallback">加载资源成功回调函数。</param>
        /// <param name="loadAssetFailureCallback">加载资源失败回调函数。</param>
        /// <param name="userData">用户自定义数据。</param>
        public void LoadAsset(string assetName, LoadAssetSuccessCallback loadAssetSuccessCallback, LoadAssetFailureCallback loadAssetFailureCallback, object userData)
        {
#if UNITY_EDITOR
            UnityEngine.Object asset = AssetDatabase.LoadMainAssetAtPath(assetName);
            if (asset != null)
            {
                if (loadAssetSuccessCallback != null)
                {
                    loadAssetSuccessCallback(assetName, asset, userData);
                }

                return;
            }

            if (loadAssetFailureCallback != null)
            {
                loadAssetFailureCallback(assetName, LoadResourceStatus.NotExist, "Can not load this resource from asset database.", userData);
            }
#endif
        }

        /// <summary>
        /// 异步加载并实例化资源。
        /// </summary>
        /// <param name="assetName">要加载资源的名称。</param>
        /// <param name="loadAndInstantiateAssetSuccessCallback">加载资源成功回调函数。</param>
        /// <param name="loadAssetFailureCallback">加载资源失败回调函数。</param>
        public void LoadAndInstantiateAsset(string assetName, LoadAndInstantiateAssetSuccessCallback loadAndInstantiateAssetSuccessCallback, LoadAssetFailureCallback loadAssetFailureCallback)
        {
            LoadAndInstantiateAsset(assetName, loadAndInstantiateAssetSuccessCallback, loadAssetFailureCallback, null);
        }

        /// <summary>
        /// 异步加载并实例化资源。
        /// </summary>
        /// <param name="assetName">要加载资源的名称。</param>
        /// <param name="loadAndInstantiateAssetSuccessCallback">加载资源成功回调函数。</param>
        /// <param name="loadAssetFailureCallback">加载资源失败回调函数。</param>
        /// <param name="userData">用户自定义数据。</param>
        public void LoadAndInstantiateAsset(string assetName, LoadAndInstantiateAssetSuccessCallback loadAndInstantiateAssetSuccessCallback, LoadAssetFailureCallback loadAssetFailureCallback, object userData)
        {
#if UNITY_EDITOR
            UnityEngine.Object asset = AssetDatabase.LoadMainAssetAtPath(assetName);
            if (asset != null)
            {
                UnityEngine.Object instance = UnityEngine.Object.Instantiate(asset);
                if (instance != null)
                {
                    if (loadAndInstantiateAssetSuccessCallback != null)
                    {
                        loadAndInstantiateAssetSuccessCallback(assetName, asset, instance, userData);
                    }

                    return;
                }
            }

            if (loadAssetFailureCallback != null)
            {
                loadAssetFailureCallback(assetName, LoadResourceStatus.NotExist, "Can not load and instantiate this resource from asset database.", userData);
            }
#endif
        }

        /// <summary>
        /// 异步加载场景。
        /// </summary>
        /// <param name="sceneName">要加载的场景名。</param>
        /// <param name="assetName">要加载场景资源的名称。</param>
        /// <param name="loadSceneSuccessCallback">加载场景成功回调函数。</param>
        /// <param name="loadSceneFailureCallback">加载场景失败回调函数。</param>
        /// <param name="loadSceneUpdateCallback">加载场景更新回调函数。</param>
        /// <param name="loadSceneDependencyCallback">加载场景依赖资源回调函数。</param>
        public void LoadScene(string sceneName, string assetName, LoadSceneSuccessCallback loadSceneSuccessCallback, LoadSceneFailureCallback loadSceneFailureCallback, LoadSceneUpdateCallback loadSceneUpdateCallback, LoadSceneDependencyCallback loadSceneDependencyCallback)
        {
            LoadScene(sceneName, assetName, loadSceneSuccessCallback, loadSceneFailureCallback, loadSceneUpdateCallback, loadSceneDependencyCallback, null);
        }

        /// <summary>
        /// 异步加载场景。
        /// </summary>
        /// <param name="sceneName">要加载的场景名。</param>
        /// <param name="assetName">要加载场景资源的名称。</param>
        /// <param name="loadSceneSuccessCallback">加载场景成功回调函数。</param>
        /// <param name="loadSceneFailureCallback">加载场景失败回调函数。</param>
        /// <param name="loadSceneUpdateCallback">加载场景更新回调函数。</param>
        /// <param name="loadSceneDependencyCallback">加载场景依赖资源回调函数。</param>
        /// <param name="userData">用户自定义数据。</param>
        public void LoadScene(string sceneName, string assetName, LoadSceneSuccessCallback loadSceneSuccessCallback, LoadSceneFailureCallback loadSceneFailureCallback, LoadSceneUpdateCallback loadSceneUpdateCallback, LoadSceneDependencyCallback loadSceneDependencyCallback, object userData)
        {
            if (string.IsNullOrEmpty(sceneName))
            {
                throw new GameFrameworkException("Scene name is invalid.");
            }

            AsyncOperation asyncOperation = SceneManager.LoadSceneAsync(sceneName, LoadSceneMode.Additive);
            if (asyncOperation == null)
            {
                return;
            }

            m_LoadSceneInfos.Add(new LoadSceneInfo(asyncOperation, sceneName, assetName, loadSceneSuccessCallback, loadSceneFailureCallback, loadSceneUpdateCallback, userData));
        }

        /// <summary>
        /// 卸载场景。
        /// </summary>
        /// <param name="sceneName">场景名称。</param>
        /// <returns>是否成功卸载场景。</returns>
        public bool UnloadScene(string sceneName)
        {
            return SceneManager.UnloadScene(sceneName);
        }

        /// <summary>
        /// 实例化资源。
        /// </summary>
        /// <param name="resource">要实例化的资源。</param>
        /// <returns>实例化的资源。</returns>
        public object Instantiate(object resource)
        {
            return UnityEngine.Object.Instantiate(resource as UnityEngine.Object);
        }

        /// <summary>
        /// 获取资源组是否准备完毕。
        /// </summary>
        /// <param name="resourceGroupName">要检查的资源组名称。</param>
        public bool GetResourceGroupReady(string resourceGroupName)
        {
            throw new NotSupportedException("GetResourceGroupReady");
        }

        /// <summary>
        /// 获取资源组资源个数。
        /// </summary>
        /// <param name="resourceGroupName">要检查的资源组名称。</param>
        public int GetResourceGroupResourceCount(string resourceGroupName)
        {
            throw new NotSupportedException("GetResourceGroupResourceCount");
        }

        /// <summary>
        /// 获取资源组已准备完成资源个数。
        /// </summary>
        /// <param name="resourceGroupName">要检查的资源组名称。</param>
        public int GetResourceGroupReadyResourceCount(string resourceGroupName)
        {
            throw new NotSupportedException("GetResourceGroupReadyResourceCount");
        }

        /// <summary>
        /// 获取资源组总大小。
        /// </summary>
        /// <param name="resourceGroupName">要检查的资源组名称。</param>
        public int GetResourceGroupTotalLength(string resourceGroupName)
        {
            throw new NotSupportedException("GetResourceGroupTotalLength");
        }

        /// <summary>
        /// 获取资源组已准备完成总大小。
        /// </summary>
        /// <param name="resourceGroupName">要检查的资源组名称。</param>
        public int GetResourceGroupTotalReadyLength(string resourceGroupName)
        {
            throw new NotSupportedException("GetResourceGroupTotalReadyLength");
        }

        /// <summary>
        /// 获取资源组准备进度。
        /// </summary>
        /// <param name="resourceGroupName">要检查的资源组名称。</param>
        public float GetResourceGroupProgress(string resourceGroupName)
        {
            throw new NotSupportedException("GetResourceGroupProgress");
        }

        private class LoadSceneInfo
        {
            private readonly AsyncOperation m_AsyncOperation;
            private readonly string m_SceneName;
            private readonly string m_SceneAssetName;
            private readonly LoadSceneSuccessCallback m_LoadSceneSuccessCallback;
            private readonly LoadSceneFailureCallback m_LoadSceneFailureCallback;
            private readonly LoadSceneUpdateCallback m_LoadSceneUpdateCallback;
            private readonly object m_UserData;

            public LoadSceneInfo(AsyncOperation asyncOperation, string sceneName, string sceneAssetName, LoadSceneSuccessCallback loadSceneSuccessCallback, LoadSceneFailureCallback loadSceneFailureCallback, LoadSceneUpdateCallback loadSceneUpdateCallback, object userData)
            {
                m_AsyncOperation = asyncOperation;
                m_SceneName = sceneName;
                m_SceneAssetName = sceneAssetName;
                m_LoadSceneSuccessCallback = loadSceneSuccessCallback;
                m_LoadSceneFailureCallback = loadSceneFailureCallback;
                m_LoadSceneUpdateCallback = loadSceneUpdateCallback;
                m_UserData = userData;
            }

            public AsyncOperation AsyncOperation
            {
                get
                {
                    return m_AsyncOperation;
                }
            }

            public string SceneName
            {
                get
                {
                    return m_SceneName;
                }
            }

            public string SceneAssetName
            {
                get
                {
                    return m_SceneAssetName;
                }
            }

            public LoadSceneSuccessCallback LoadSceneSuccessCallback
            {
                get
                {
                    return m_LoadSceneSuccessCallback;
                }
            }

            public LoadSceneFailureCallback LoadSceneFailureCallback
            {
                get
                {
                    return m_LoadSceneFailureCallback;
                }
            }

            public LoadSceneUpdateCallback LoadSceneUpdateCallback
            {
                get
                {
                    return m_LoadSceneUpdateCallback;
                }
            }

            public object UserData
            {
                get
                {
                    return m_UserData;
                }
            }
        }
    }
}
