//------------------------------------------------------------
// Game Framework v2.x
// Copyright © 2014-2016 Jiang Yin. All rights reserved.
// Homepage: http://gameframework.cn/
// Feedback: mailto:jiangyin@gameframework.cn
//------------------------------------------------------------

using GameFramework.WebRequest;
using System;
using UnityEngine;

namespace UnityGameFramework.Runtime
{
    /// <summary>
    /// Web 请求代理辅助器基类。
    /// </summary>
    public abstract class WebRequestAgentHelperBase : MonoBehaviour, IWebRequestAgentHelper
    {
        /// <summary>
        /// Web 请求代理辅助器完成事件。
        /// </summary>
        protected EventHandler<WebRequestAgentHelperCompleteEventArgs> m_WebRequestAgentHelperCompleteEventHandler = null;

        /// <summary>
        /// Web 请求代理辅助器错误事件。
        /// </summary>
        protected EventHandler<WebRequestAgentHelperErrorEventArgs> m_WebRequestAgentHelperErrorEventHandler = null;

        /// <summary>
        /// Web 请求代理辅助器完成事件。
        /// </summary>
        public event EventHandler<WebRequestAgentHelperCompleteEventArgs> WebRequestAgentHelperComplete
        {
            add
            {
                m_WebRequestAgentHelperCompleteEventHandler += value;
            }
            remove
            {
                m_WebRequestAgentHelperCompleteEventHandler -= value;
            }
        }

        /// <summary>
        /// Web 请求代理辅助器错误事件。
        /// </summary>
        public event EventHandler<WebRequestAgentHelperErrorEventArgs> WebRequestAgentHelperError
        {
            add
            {
                m_WebRequestAgentHelperErrorEventHandler += value;
            }
            remove
            {
                m_WebRequestAgentHelperErrorEventHandler -= value;
            }
        }

        /// <summary>
        /// 通过 Web 请求代理辅助器发送 Web 请求。
        /// </summary>
        /// <param name="webRequestUri">Web 请求地址。</param>
        /// <param name="userData">用户自定义数据。</param>
        public abstract void Request(string webRequestUri, object userData);

        /// <summary>
        /// 通过 Web 请求代理辅助器发送 Web 请求。
        /// </summary>
        /// <param name="webRequestUri">Web 请求地址。</param>
        /// <param name="postData">要发送的数据流。</param>
        /// <param name="userData">用户自定义数据。</param>
        public abstract void Request(string webRequestUri, byte[] postData, object userData);

        /// <summary>
        /// 重置 Web 请求代理辅助器。
        /// </summary>
        public abstract void Reset();
    }
}
