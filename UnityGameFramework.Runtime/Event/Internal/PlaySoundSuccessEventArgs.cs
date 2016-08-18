//------------------------------------------------------------
// Game Framework v2.x
// Copyright © 2014-2016 Jiang Yin. All rights reserved.
// Homepage: http://gameframework.cn/
// Feedback: mailto:jiangyin@gameframework.cn
//------------------------------------------------------------

using GameFramework.Event;
using GameFramework.Sound;

namespace UnityGameFramework.Runtime
{
    /// <summary>
    /// 播放声音成功事件。
    /// </summary>
    public sealed class PlaySoundSuccessEventArgs : GameEventArgs
    {
        /// <summary>
        /// 初始化播放声音成功事件的新实例。
        /// </summary>
        /// <param name="e">内部事件。</param>
        public PlaySoundSuccessEventArgs(GameFramework.Sound.PlaySoundSuccessEventArgs e)
        {
            PlaySoundInfo playSoundInfo = e.UserData as PlaySoundInfo;
            SerialId = e.SerialId;
            SoundAssetName = e.SoundAssetName;
            SoundAgent = e.SoundAgent;
            BindingEntity = playSoundInfo.BindingEntity;
            UserData = playSoundInfo.UserData;
        }

        /// <summary>
        /// 获取播放声音成功事件编号。
        /// </summary>
        public override int Id
        {
            get
            {
                return (int)EventId.PlaySoundSuccess;
            }
        }

        /// <summary>
        /// 获取声音的序列编号。
        /// </summary>
        public int SerialId
        {
            get;
            private set;
        }

        /// <summary>
        /// 获取声音资源名称。
        /// </summary>
        public string SoundAssetName
        {
            get;
            private set;
        }

        /// <summary>
        /// 获取用于播放的声音代理。
        /// </summary>
        public ISoundAgent SoundAgent
        {
            get;
            private set;
        }

        /// <summary>
        /// 获取声音绑定的实体。
        /// </summary>
        public Entity BindingEntity
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
