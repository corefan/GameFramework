//------------------------------------------------------------
// Game Framework v2.x
// Copyright © 2014-2016 Jiang Yin. All rights reserved.
// Homepage: http://gameframework.cn/
// Feedback: mailto:jiangyin@gameframework.cn
//------------------------------------------------------------

using GameFramework.Resource;
using System;
using UnityEngine;

namespace UnityGameFramework.Runtime
{
    /// <summary>
    /// 加载资源代理辅助器基类。
    /// </summary>
    public abstract class LoadResourceAgentHelperBase : MonoBehaviour, ILoadResourceAgentHelper
    {
        /// <summary>
        /// 加载资源代理辅助器异步加载资源更新事件。
        /// </summary>
        protected EventHandler<LoadResourceAgentHelperUpdateEventArgs> m_LoadResourceAgentHelperUpdateEventHandler = null;

        /// <summary>
        /// 加载资源代理辅助器异步读取资源文件完成事件。
        /// </summary>
        protected EventHandler<LoadResourceAgentHelperReadFileCompleteEventArgs> m_LoadResourceAgentHelperReadFileCompleteEventHandler = null;

        /// <summary>
        /// 加载资源代理辅助器异步读取资源二进制流完成事件。
        /// </summary>
        protected EventHandler<LoadResourceAgentHelperReadBytesCompleteEventArgs> m_LoadResourceAgentHelperReadBytesCompleteEventHandler = null;

        /// <summary>
        /// 加载资源代理辅助器异步将资源二进制流转换为加载对象完成事件。
        /// </summary>
        protected EventHandler<LoadResourceAgentHelperParseBytesCompleteEventArgs> m_LoadResourceAgentHelperParseBytesCompleteEventHandler = null;

        /// <summary>
        /// 加载资源代理辅助器异步加载资源完成事件。
        /// </summary>
        protected EventHandler<LoadResourceAgentHelperLoadCompleteEventArgs> m_LoadResourceAgentHelperLoadCompleteEventHandler = null;

        /// <summary>
        /// 加载资源代理辅助器错误事件。
        /// </summary>
        protected EventHandler<LoadResourceAgentHelperErrorEventArgs> m_LoadResourceAgentHelperErrorEventHandler = null;

        /// <summary>
        /// 加载资源代理辅助器异步加载资源更新事件。
        /// </summary>
        public event EventHandler<LoadResourceAgentHelperUpdateEventArgs> LoadResourceAgentHelperUpdate
        {
            add
            {
                m_LoadResourceAgentHelperUpdateEventHandler += value;
            }
            remove
            {
                m_LoadResourceAgentHelperUpdateEventHandler -= value;
            }
        }

        /// <summary>
        /// 加载资源代理辅助器异步读取资源文件完成事件。
        /// </summary>
        public event EventHandler<LoadResourceAgentHelperReadFileCompleteEventArgs> LoadResourceAgentHelperReadFileComplete
        {
            add
            {
                m_LoadResourceAgentHelperReadFileCompleteEventHandler += value;
            }
            remove
            {
                m_LoadResourceAgentHelperReadFileCompleteEventHandler -= value;
            }
        }

        /// <summary>
        /// 加载资源代理辅助器异步读取资源二进制流完成事件。
        /// </summary>
        public event EventHandler<LoadResourceAgentHelperReadBytesCompleteEventArgs> LoadResourceAgentHelperReadBytesComplete
        {
            add
            {
                m_LoadResourceAgentHelperReadBytesCompleteEventHandler += value;
            }
            remove
            {
                m_LoadResourceAgentHelperReadBytesCompleteEventHandler -= value;
            }
        }

        /// <summary>
        /// 加载资源代理辅助器异步将资源二进制流转换为加载对象完成事件。
        /// </summary>
        public event EventHandler<LoadResourceAgentHelperParseBytesCompleteEventArgs> LoadResourceAgentHelperParseBytesComplete
        {
            add
            {
                m_LoadResourceAgentHelperParseBytesCompleteEventHandler += value;
            }
            remove
            {
                m_LoadResourceAgentHelperParseBytesCompleteEventHandler -= value;
            }
        }

        /// <summary>
        /// 加载资源代理辅助器异步加载资源完成事件。
        /// </summary>
        public event EventHandler<LoadResourceAgentHelperLoadCompleteEventArgs> LoadResourceAgentHelperLoadComplete
        {
            add
            {
                m_LoadResourceAgentHelperLoadCompleteEventHandler += value;
            }
            remove
            {
                m_LoadResourceAgentHelperLoadCompleteEventHandler -= value;
            }
        }

        /// <summary>
        /// 加载资源代理辅助器错误事件。
        /// </summary>
        public event EventHandler<LoadResourceAgentHelperErrorEventArgs> LoadResourceAgentHelperError
        {
            add
            {
                m_LoadResourceAgentHelperErrorEventHandler += value;
            }
            remove
            {
                m_LoadResourceAgentHelperErrorEventHandler -= value;
            }
        }

        /// <summary>
        /// 通过加载资源代理辅助器开始异步读取资源文件。
        /// </summary>
        /// <param name="fullPath">要加载资源的完整路径名。</param>
        public abstract void ReadFile(string fullPath);

        /// <summary>
        /// 通过加载资源代理辅助器开始异步读取资源二进制流。
        /// </summary>
        /// <param name="fullPath">要加载资源的完整路径名。</param>
        /// <param name="loadType">资源加载方式。</param>
        public abstract void ReadBytes(string fullPath, int loadType);

        /// <summary>
        /// 通过加载资源代理辅助器开始异步将资源二进制流转换为加载对象。
        /// </summary>
        /// <param name="bytes">要加载资源的二进制流。</param>
        public abstract void ParseBytes(byte[] bytes);

        /// <summary>
        /// 通过加载资源代理辅助器开始异步加载资源。
        /// </summary>
        /// <param name="resource">资源。</param>
        /// <param name="resourceChildName">要加载的子资源名，如果为空，则加载主资源。</param>
        public abstract void LoadAsset(object resource, string resourceChildName);

        /// <summary>
        /// 通过加载资源代理辅助器开始异步加载资源并实例化。
        /// </summary>
        /// <param name="resource">资源。</param>
        /// <param name="resourceChildName">要加载的子资源名，如果为空，则加载主资源。</param>
        public abstract void LoadAndInstantiateAsset(object resource, string resourceChildName);

        /// <summary>
        /// 通过加载资源代理辅助器开始异步加载场景。
        /// </summary>
        /// <param name="resource">资源。</param>
        /// <param name="sceneName">场景名称。</param>
        public abstract void LoadScene(object resource, string sceneName);

        /// <summary>
        /// 重置加载资源代理辅助器。
        /// </summary>
        public abstract void Reset();
    }
}
