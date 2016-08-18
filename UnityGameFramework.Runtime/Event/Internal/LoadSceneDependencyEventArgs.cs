//------------------------------------------------------------
// Game Framework v2.x
// Copyright © 2014-2016 Jiang Yin. All rights reserved.
// Homepage: http://gameframework.cn/
// Feedback: mailto:jiangyin@gameframework.cn
//------------------------------------------------------------

using GameFramework.Event;

namespace UnityGameFramework.Runtime
{
    /// <summary>
    /// 加载场景依赖资源事件。
    /// </summary>
    public sealed class LoadSceneDependencyEventArgs : GameEventArgs
    {
        /// <summary>
        /// 初始化加载场景依赖资源事件的新实例。
        /// </summary>
        /// <param name="e">内部事件。</param>
        public LoadSceneDependencyEventArgs(GameFramework.Scene.LoadSceneDependencyEventArgs e)
        {
            SceneName = e.SceneName;
            SceneAssetName = e.SceneAssetName;
            DependencyResourceName = e.DependencyResourceName;
            LoadedCount = e.LoadedCount;
            TotalCount = e.TotalCount;
            UserData = e.UserData;
        }

        /// <summary>
        /// 获取加载场景更新事件编号。
        /// </summary>
        public override int Id
        {
            get
            {
                return (int)EventId.LoadSceneDependency;
            }
        }

        /// <summary>
        /// 获取场景名称。
        /// </summary>
        public string SceneName
        {
            get;
            private set;
        }

        /// <summary>
        /// 获取场景资源名称。
        /// </summary>
        public string SceneAssetName
        {
            get;
            private set;
        }

        /// <summary>
        /// 获取被加载的依赖资源名称。
        /// </summary>
        public string DependencyResourceName
        {
            get;
            private set;
        }

        /// <summary>
        /// 获取当前已加载依赖资源数量。
        /// </summary>
        public int LoadedCount
        {
            get;
            private set;
        }

        /// <summary>
        /// 获取总共加载依赖资源数量。
        /// </summary>
        public int TotalCount
        {
            get;
            private set;
        }

        /// <summary>
        /// 获取用户自定义数据。
        /// </summary>
        public object UserData
        {
            get;
            private set;
        }
    }
}
