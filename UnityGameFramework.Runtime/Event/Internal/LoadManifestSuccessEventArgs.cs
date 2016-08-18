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
    /// 读取资源清单成功事件。
    /// </summary>
    public sealed class LoadManifestSuccessEventArgs : GameEventArgs
    {
        /// <summary>
        /// 初始化读取资源清单成功事件的新实例。
        /// </summary>
        /// <param name="manifestAssetName">资源清单名称。</param>
        public LoadManifestSuccessEventArgs(string manifestAssetName)
        {
            ManifestAssetName = manifestAssetName;
        }

        /// <summary>
        /// 获取读取资源清单成功事件编号。
        /// </summary>
        public override int Id
        {
            get
            {
                return (int)EventId.LoadManifestSuccess;
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
    }
}
