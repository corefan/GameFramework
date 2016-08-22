//------------------------------------------------------------
// Game Framework v2.x
// Copyright © 2014-2016 Jiang Yin. All rights reserved.
// Homepage: http://gameframework.cn/
// Feedback: mailto:jiangyin@gameframework.cn
//------------------------------------------------------------

using GameFramework;
using System;
using System.Collections.Generic;
using UnityEngine;

namespace UnityGameFramework.Runtime
{
    /// <summary>
    /// 游戏入口。
    /// </summary>
    public static class GameEntry
    {
        private const string UnityGameFrameworkVersion = "2.1.0823";
        private static readonly LinkedList<GameFrameworkComponent> s_GameFrameworkComponents = new LinkedList<GameFrameworkComponent>();

        /// <summary>
        /// 获取 Unity 游戏框架版本号。
        /// </summary>
        public static string Version
        {
            get
            {
                return UnityGameFrameworkVersion;
            }
        }

        /// <summary>
        /// 获取游戏框架组件。
        /// </summary>
        /// <typeparam name="T">要获取的游戏框架组件类型。</typeparam>
        /// <returns>要获取的游戏框架组件。</returns>
        public static T GetComponent<T>() where T : GameFrameworkComponent
        {
            return GetComponent(typeof(T)) as T;
        }

        /// <summary>
        /// 获取游戏框架组件。
        /// </summary>
        /// <param name="type">要获取的游戏框架组件类型。</param>
        /// <returns>要获取的游戏框架组件。</returns>
        public static GameFrameworkComponent GetComponent(Type type)
        {
            foreach (GameFrameworkComponent component in s_GameFrameworkComponents)
            {
                if (component.GetType() == type)
                {
                    return component;
                }
            }

            return null;
        }

        /// <summary>
        /// 获取游戏框架组件。
        /// </summary>
        /// <param name="typeName">要获取的游戏框架组件类型名称。</param>
        /// <returns>要获取的游戏框架组件。</returns>
        public static GameFrameworkComponent GetComponent(string typeName)
        {
            foreach (GameFrameworkComponent component in s_GameFrameworkComponents)
            {
                Type type = component.GetType();
                if (type.FullName == typeName || type.Name == typeName)
                {
                    return component;
                }
            }

            return null;
        }

        /// <summary>
        /// 注册游戏框架组件。
        /// </summary>
        /// <param name="gameFrameworkComponent">要注册的游戏框架组件。</param>
        internal static void RegisterComponent(GameFrameworkComponent gameFrameworkComponent)
        {
            if (gameFrameworkComponent == null)
            {
                throw new GameFrameworkException("Game framework component is invalid.");
            }

            Type type = gameFrameworkComponent.GetType();
            foreach (GameFrameworkComponent component in s_GameFrameworkComponents)
            {
                if (component.GetType() == type)
                {
                    throw new GameFrameworkException(string.Format("Game framework component type '{0}' is already exist.", type.FullName));
                }
            }

            s_GameFrameworkComponents.AddLast(gameFrameworkComponent);
        }

        /// <summary>
        /// 重启游戏。
        /// </summary>
        public static void Restart()
        {
            Log.Info("Restart Game Framework...");
            BaseComponent baseComponent = GetComponent<BaseComponent>();
            if (baseComponent != null)
            {
                baseComponent.Shutdown();
            }

            s_GameFrameworkComponents.Clear();

            if (baseComponent != null)
            {
                baseComponent.Reload();
            }
        }

        /// <summary>
        /// 关闭游戏。
        /// </summary>
        public static void Shutdown()
        {
            Log.Info("Shutdown Game Framework...");
            BaseComponent baseComponent = GetComponent<BaseComponent>();
            if (baseComponent != null)
            {
                baseComponent.Shutdown();
            }

            s_GameFrameworkComponents.Clear();

            Application.Quit();
        }
    }
}
