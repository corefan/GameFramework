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
    /// 读取资源清单失败事件。
    /// </summary>
    public sealed class LoadManifestFailureEventArgs : GameEventArgs
    {
        /// <summary>
        /// 初始化读取资源清单失败事件的新实例。
        /// </summary>
        /// <param name="manifestAssetName">资源清单名称。</param>
        /// <param name="errorMessage">错误信息。</param>
        public LoadManifestFailureEventArgs(string manifestAssetName, string errorMessage)
        {
            ManifestAssetName = manifestAssetName;
            ErrorMessage = errorMessage;
        }

        /// <summary>
        /// 获取读取资源清单失败事件编号。
        /// </summary>
        public override int Id
        {
            get
            {
                return (int)EventId.LoadManifestFailure;
            }
        }

        /// <summary>
        /// 获取资源清单名称。
        /// </summary>
        public string ManifestAssetName
        {
            get;
            private set;
        }

        /// <summary>
        /// 获取错误信息。
        /// </summary>
        public string ErrorMessage
        {
            get;
            private set;
        }

    }
}
