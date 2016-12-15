//------------------------------------------------------------
// Game Framework v3.x
// Copyright © 2013-2017 Jiang Yin. All rights reserved.
// Homepage: http://gameframework.cn/
// Feedback: mailto:jiangyin@gameframework.cn
//------------------------------------------------------------

using GameFramework;
using GameFramework.Resource;
using GameFramework.Scene;
using UnityEngine;
using UnityEngine.SceneManagement;

namespace UnityGameFramework.Runtime
{
    /// <summary>
    /// 场景组件。
    /// </summary>
    [AddComponentMenu("Game Framework/Scene")]
    public sealed class SceneComponent : GameFrameworkComponent
    {
        private ISceneManager m_SceneManager = null;
        private EventComponent m_EventComponent = null;
        private Camera m_MainCamera = null;
        private Scene m_GameFrameworkScene = default(Scene);

        [SerializeField]
        private bool m_EnableLoadSceneSuccessEvent = true;

        [SerializeField]
        private bool m_EnableLoadSceneFailureEvent = true;

        [SerializeField]
        private bool m_EnableLoadSceneUpdateEvent = true;

        [SerializeField]
        private bool m_EnableLoadSceneDependencyAssetEvent = true;

        [SerializeField]
        private bool m_EnableUnloadSceneSuccessEvent = true;

        [SerializeField]
        private bool m_EnableUnloadSceneFailureEvent = true;

        /// <summary>
        /// 获取当前场景主摄像机。
        /// </summary>
        public Camera MainCamera
        {
            get
            {
                return m_MainCamera;
            }
        }

        /// <summary>
        /// 游戏框架组件初始化。
        /// </summary>
        protected internal override void Awake()
        {
            base.Awake();

            m_SceneManager = GameFrameworkEntry.GetModule<ISceneManager>();
            if (m_SceneManager == null)
            {
                Log.Fatal("Scene manager is invalid.");
                return;
            }

            m_SceneManager.LoadSceneSuccess += OnLoadSceneSuccess;
            m_SceneManager.LoadSceneFailure += OnLoadSceneFailure;
            m_SceneManager.LoadSceneUpdate += OnLoadSceneUpdate;
            m_SceneManager.LoadSceneDependencyAsset += OnLoadSceneDependencyAsset;
            m_SceneManager.UnloadSceneSuccess += OnUnloadSceneSuccess;
            m_SceneManager.UnloadSceneFailure += OnUnloadSceneFailure;

            m_GameFrameworkScene = SceneManager.GetSceneAt(BaseComponent.GameFrameworkSceneId);
            if (!m_GameFrameworkScene.IsValid())
            {
                Log.Fatal("Game framework scene is invalid.");
                return;
            }
        }

        private void Start()
        {
            BaseComponent baseComponent = GameEntry.GetComponent<BaseComponent>();
            if (baseComponent == null)
            {
                Log.Fatal("Base component is invalid.");
                return;
            }

            m_EventComponent = GameEntry.GetComponent<EventComponent>();
            if (m_EventComponent == null)
            {
                Log.Fatal("Event component is invalid.");
                return;
            }

            if (baseComponent.EditorResourceMode)
            {
                m_SceneManager.SetResourceManager(baseComponent.EditorResourceHelper);
            }
            else
            {
                m_SceneManager.SetResourceManager(GameFrameworkEntry.GetModule<IResourceManager>());
            }
        }

        /// <summary>
        /// 获取场景是否已加载。
        /// </summary>
        /// <param name="sceneName">场景名称。</param>
        /// <returns>场景是否已加载。</returns>
        public bool SceneIsLoaded(string sceneName)
        {
            return m_SceneManager.SceneIsLoaded(sceneName);
        }

        /// <summary>
        /// 获取已加载场景的名称。
        /// </summary>
        /// <returns></returns>
        public string[] GetLoadedSceneNames()
        {
            return m_SceneManager.GetLoadedSceneNames();
        }

        /// <summary>
        /// 获取场景是否正在加载。
        /// </summary>
        /// <param name="sceneName">场景名称。</param>
        /// <returns>场景是否正在加载。</returns>
        public bool SceneIsLoading(string sceneName)
        {
            return m_SceneManager.SceneIsLoading(sceneName);
        }

        /// <summary>
        /// 获取正在加载场景的名称。
        /// </summary>
        /// <returns></returns>
        public string[] GetLoadingSceneNames()
        {
            return m_SceneManager.GetLoadingSceneNames();
        }

        /// <summary>
        /// 加载场景。
        /// </summary>
        /// <param name="sceneName">场景名称。</param>
        /// <param name="sceneAssetName">场景资源名称。</param>
        public void LoadScene(string sceneName, string sceneAssetName)
        {
            m_SceneManager.LoadScene(sceneName, sceneAssetName);
        }

        /// <summary>
        /// 加载场景。
        /// </summary>
        /// <param name="sceneName">场景名称。</param>
        /// <param name="sceneAssetName">场景资源名称。</param>
        /// <param name="userData">用户自定义数据。</param>
        public void LoadScene(string sceneName, string sceneAssetName, object userData)
        {
            m_SceneManager.LoadScene(sceneName, sceneAssetName, userData);
        }

        /// <summary>
        /// 卸载场景。
        /// </summary>
        /// <param name="sceneName">场景名称。</param>
        /// <returns>是否成功卸载场景。</returns>
        public bool UnloadScene(string sceneName)
        {
            return m_SceneManager.UnloadScene(sceneName);
        }

        /// <summary>
        /// 卸载场景。
        /// </summary>
        /// <param name="sceneName">场景名称。</param>
        /// <param name="userData">用户自定义数据。</param>
        /// <returns>是否成功卸载场景。</returns>
        public bool UnloadScene(string sceneName, object userData)
        {
            return m_SceneManager.UnloadScene(sceneName, userData);
        }

        private void OnLoadSceneSuccess(object sender, GameFramework.Scene.LoadSceneSuccessEventArgs e)
        {
            m_MainCamera = Camera.main;
            if (SceneManager.GetActiveScene() == m_GameFrameworkScene)
            {
                Scene scene = SceneManager.GetSceneByName(e.SceneName);
                SceneManager.SetActiveScene(scene);
            }

            if (m_EnableLoadSceneSuccessEvent)
            {
                m_EventComponent.Fire(this, new LoadSceneSuccessEventArgs(e));
            }
        }

        private void OnLoadSceneFailure(object sender, GameFramework.Scene.LoadSceneFailureEventArgs e)
        {
            Log.Warning("Load scene failure, scene name '{0}', asset name '{1}', error message '{2}'.", e.SceneName, e.SceneAssetName, e.ErrorMessage);
            if (m_EnableLoadSceneFailureEvent)
            {
                m_EventComponent.Fire(this, new LoadSceneFailureEventArgs(e));
            }
        }

        private void OnLoadSceneUpdate(object sender, GameFramework.Scene.LoadSceneUpdateEventArgs e)
        {
            if (m_EnableLoadSceneUpdateEvent)
            {
                m_EventComponent.Fire(this, new LoadSceneUpdateEventArgs(e));
            }
        }

        private void OnLoadSceneDependencyAsset(object sender, GameFramework.Scene.LoadSceneDependencyAssetEventArgs e)
        {
            if (m_EnableLoadSceneDependencyAssetEvent)
            {
                m_EventComponent.Fire(this, new LoadSceneDependencyAssetEventArgs(e));
            }
        }

        private void OnUnloadSceneSuccess(object sender, GameFramework.Scene.UnloadSceneSuccessEventArgs e)
        {
            if (m_EnableUnloadSceneSuccessEvent)
            {
                m_EventComponent.Fire(this, new UnloadSceneSuccessEventArgs(e));
            }
        }

        private void OnUnloadSceneFailure(object sender, GameFramework.Scene.UnloadSceneFailureEventArgs e)
        {
            Log.Warning("Unload scene failure, scene name '{0}'.", e.SceneName);
            if (m_EnableUnloadSceneFailureEvent)
            {
                m_EventComponent.Fire(this, new UnloadSceneFailureEventArgs(e));
            }
        }
    }
}
