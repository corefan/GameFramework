//------------------------------------------------------------
// Game Framework v2.x
// Copyright © 2014-2016 Jiang Yin. All rights reserved.
// Homepage: http://gameframework.cn/
// Feedback: mailto:jiangyin@gameframework.cn
//------------------------------------------------------------

using GameFramework;
using GameFramework.ObjectPool;
using GameFramework.Resource;
using GameFramework.Sound;
using UnityEngine;

namespace UnityGameFramework.Runtime
{
    /// <summary>
    /// 声音组件。
    /// </summary>
    [AddComponentMenu("Game Framework/Sound")]
    public sealed partial class SoundComponent : GameFrameworkComponent
    {
        private ISoundManager m_SoundManager = null;
        private EventComponent m_EventComponent = null;

        [SerializeField]
        private int m_AssetCapacity = 4;

        [SerializeField]
        private Transform m_InstanceRoot = null;

        [SerializeField]
        private SoundGroupHelperBase m_SoundGroupHelperTemplate = null;

        [SerializeField]
        private SoundAgentHelperBase m_SoundAgentHelperTemplate = null;

        [SerializeField]
        private SoundHelperBase m_SoundHelper = null;

        [SerializeField]
        private SoundGroup[] m_SoundGroups = null;

        /// <summary>
        /// 获取声音组数量。
        /// </summary>
        public int SoundGroupCount
        {
            get
            {
                return m_SoundManager.SoundGroupCount;
            }
        }

        /// <summary>
        /// 获取或设置声音资源对象池的容量。
        /// </summary>
        public int AssetCapacity
        {
            get
            {
                return m_SoundManager.AssetCapacity;
            }
            set
            {
                m_SoundManager.AssetCapacity = m_AssetCapacity = value;
            }
        }

        /// <summary>
        /// 游戏框架组件初始化。
        /// </summary>
        protected internal override void Awake()
        {
            base.Awake();

            m_SoundManager = GameFrameworkEntry.GetModule<ISoundManager>();
            if (m_SoundManager == null)
            {
                Log.Fatal("Sound manager is invalid.");
                return;
            }

            m_SoundManager.PlaySoundSuccess += OnPlaySoundSuccess;
            m_SoundManager.PlaySoundFailure += OnPlaySoundFailure;
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
                m_SoundManager.SetResourceManager(baseComponent.EditorResourceHelper);
            }
            else
            {
                m_SoundManager.SetResourceManager(GameFrameworkEntry.GetModule<IResourceManager>());
            }

            m_SoundManager.SetObjectPoolManager(GameFrameworkEntry.GetModule<IObjectPoolManager>());
            m_SoundManager.AssetCapacity = m_AssetCapacity;

            if (m_SoundHelper == null)
            {
                m_SoundHelper = (new GameObject()).AddComponent<DefaultSoundHelper>();
                m_SoundHelper.name = string.Format("Sound Helper");
                Transform transform = m_SoundHelper.transform;
                transform.SetParent(this.transform);
                transform.localScale = Vector3.one;
            }

            m_SoundManager.SetSoundHelper(m_SoundHelper);

            if (m_InstanceRoot == null)
            {
                m_InstanceRoot = (new GameObject("Sound Instances")).transform;
                m_InstanceRoot.SetParent(gameObject.transform);
            }

            foreach (SoundGroup soundGroup in m_SoundGroups)
            {
                if (!AddSoundGroup(soundGroup.Name, soundGroup.AvoidBeingReplacedBySamePriority, soundGroup.Mute, soundGroup.Volume, soundGroup.AgentHelperCount))
                {
                    Log.Warning("Add sound group '{0}' failed.", soundGroup.Name);
                    continue;
                }
            }
        }

        /// <summary>
        /// 是否存在指定声音组。
        /// </summary>
        /// <param name="soundGroupName">声音组名称。</param>
        /// <returns>指定声音组是否存在。</returns>
        public bool HasSoundGroup(string soundGroupName)
        {
            return m_SoundManager.HasSoundGroup(soundGroupName);
        }

        /// <summary>
        /// 获取指定声音组。
        /// </summary>
        /// <param name="soundGroupName">声音组名称。</param>
        /// <returns>要获取的声音组。</returns>
        public ISoundGroup GetSoundGroup(string soundGroupName)
        {
            return m_SoundManager.GetSoundGroup(soundGroupName);
        }

        /// <summary>
        /// 获取所有声音组。
        /// </summary>
        /// <returns>所有声音组。</returns>
        public ISoundGroup[] GetAllSoundGroups()
        {
            return m_SoundManager.GetAllSoundGroups();
        }

        /// <summary>
        /// 增加声音组。
        /// </summary>
        /// <param name="soundGroupName">声音组名称。</param>
        /// <param name="soundGroupAvoidBeingReplacedBySamePriority">声音组中的声音是否避免被同优先级声音替换。</param>
        /// <param name="soundGroupMute">声音组是否静音。</param>
        /// <param name="soundGroupVolume">声音组音量。</param>
        /// <param name="soundAgentHelperCount">声音代理辅助器数量。</param>
        /// <returns>是否增加声音组成功。</returns>
        public bool AddSoundGroup(string soundGroupName, bool soundGroupAvoidBeingReplacedBySamePriority, bool soundGroupMute, float soundGroupVolume, int soundAgentHelperCount)
        {
            if (m_SoundManager.HasSoundGroup(soundGroupName))
            {
                return false;
            }

            SoundGroupHelperBase helper = null;
            if (m_SoundGroupHelperTemplate != null)
            {
                helper = Instantiate(m_SoundGroupHelperTemplate);
            }
            else
            {
                helper = (new GameObject()).AddComponent<DefaultSoundGroupHelper>();
            }

            helper.name = string.Format("Sound Group - {0}", soundGroupName);
            Transform transform = helper.transform;
            transform.SetParent(m_InstanceRoot);
            transform.localScale = Vector3.one;

            if (!m_SoundManager.AddSoundGroup(soundGroupName, soundGroupAvoidBeingReplacedBySamePriority, soundGroupMute, soundGroupVolume, helper))
            {
                return false;
            }

            for (int i = 0; i < soundAgentHelperCount; i++)
            {
                SoundAgentHelperBase agentHelper = null;
                if (m_SoundAgentHelperTemplate != null)
                {
                    agentHelper = Instantiate(m_SoundAgentHelperTemplate);
                }
                else
                {
                    agentHelper = (new GameObject()).AddComponent<DefaultSoundAgentHelper>();
                }

                agentHelper.name = string.Format("Sound Agent Helper - {0} - {1}", soundGroupName, i.ToString());
                Transform agentTransform = agentHelper.transform;
                agentTransform.SetParent(transform);
                agentTransform.localScale = Vector3.one;
                m_SoundManager.AddSoundAgentHelper(soundGroupName, agentHelper);
            }

            return true;
        }

        /// <summary>
        /// 播放声音。
        /// </summary>
        /// <param name="soundAssetName">声音资源名称。</param>
        /// <param name="soundGroupName">声音组名称。</param>
        /// <returns>声音的序列编号。</returns>
        public int PlaySound(string soundAssetName, string soundGroupName)
        {
            return PlaySound(soundAssetName, soundGroupName, null, null, null);
        }

        /// <summary>
        /// 播放声音。
        /// </summary>
        /// <param name="soundAssetName">声音资源名称。</param>
        /// <param name="soundGroupName">声音组名称。</param>
        /// <param name="playSoundParams">播放声音参数。</param>
        /// <returns>声音的序列编号。</returns>
        public int PlaySound(string soundAssetName, string soundGroupName, PlaySoundParams playSoundParams)
        {
            return PlaySound(soundAssetName, soundGroupName, playSoundParams, null, null);
        }

        /// <summary>
        /// 播放声音。
        /// </summary>
        /// <param name="soundAssetName">声音资源名称。</param>
        /// <param name="soundGroupName">声音组名称。</param>
        /// <param name="bindingEntity">声音绑定的实体。</param>
        /// <returns>声音的序列编号。</returns>
        public int PlaySound(string soundAssetName, string soundGroupName, Entity bindingEntity)
        {
            return PlaySound(soundAssetName, soundGroupName, null, bindingEntity, null);
        }

        /// <summary>
        /// 播放声音。
        /// </summary>
        /// <param name="soundAssetName">声音资源名称。</param>
        /// <param name="soundGroupName">声音组名称。</param>
        /// <param name="userData">用户自定义数据。</param>
        /// <returns>声音的序列编号。</returns>
        public int PlaySound(string soundAssetName, string soundGroupName, object userData)
        {
            return PlaySound(soundAssetName, soundGroupName, null, null, userData);
        }

        /// <summary>
        /// 播放声音。
        /// </summary>
        /// <param name="soundAssetName">声音资源名称。</param>
        /// <param name="soundGroupName">声音组名称。</param>
        /// <param name="playSoundParams">播放声音参数。</param>
        /// <param name="bindingEntity">声音绑定的实体。</param>
        /// <returns>声音的序列编号。</returns>
        public int PlaySound(string soundAssetName, string soundGroupName, PlaySoundParams playSoundParams, Entity bindingEntity)
        {
            return PlaySound(soundAssetName, soundGroupName, playSoundParams, bindingEntity, null);
        }

        /// <summary>
        /// 播放声音。
        /// </summary>
        /// <param name="soundAssetName">声音资源名称。</param>
        /// <param name="soundGroupName">声音组名称。</param>
        /// <param name="playSoundParams">播放声音参数。</param>
        /// <param name="userData">用户自定义数据。</param>
        /// <returns>声音的序列编号。</returns>
        public int PlaySound(string soundAssetName, string soundGroupName, PlaySoundParams playSoundParams, object userData)
        {
            return PlaySound(soundAssetName, soundGroupName, playSoundParams, null, userData);
        }

        /// <summary>
        /// 播放声音。
        /// </summary>
        /// <param name="soundAssetName">声音资源名称。</param>
        /// <param name="soundGroupName">声音组名称。</param>
        /// <param name="bindingEntity">声音绑定的实体。</param>
        /// <param name="userData">用户自定义数据。</param>
        /// <returns>声音的序列编号。</returns>
        public int PlaySound(string soundAssetName, string soundGroupName, Entity bindingEntity, object userData)
        {
            return PlaySound(soundAssetName, soundGroupName, null, bindingEntity, userData);
        }

        /// <summary>
        /// 播放声音。
        /// </summary>
        /// <param name="soundAssetName">声音资源名称。</param>
        /// <param name="soundGroupName">声音组名称。</param>
        /// <param name="playSoundParams">播放声音参数。</param>
        /// <param name="bindingEntity">声音绑定的实体。</param>
        /// <param name="userData">用户自定义数据。</param>
        /// <returns>声音的序列编号。</returns>
        public int PlaySound(string soundAssetName, string soundGroupName, PlaySoundParams playSoundParams, Entity bindingEntity, object userData)
        {
            return m_SoundManager.PlaySound(soundAssetName, soundGroupName, playSoundParams, new PlaySoundInfo(bindingEntity, userData));
        }

        /// <summary>
        /// 停止播放声音。
        /// </summary>
        /// <param name="serialId">要停止播放声音的序列编号。</param>
        /// <returns>是否停止播放声音成功。</returns>
        public bool StopSound(int serialId)
        {
            return m_SoundManager.StopSound(serialId);
        }

        /// <summary>
        /// 停止所有声音。
        /// </summary>
        /// <param name="soundGroupName">声音组名称。</param>
        public void StopAllSounds(string soundGroupName)
        {
            m_SoundManager.StopAllSounds(soundGroupName);
        }

        /// <summary>
        /// 停止所有声音。
        /// </summary>
        public void StopAllSounds()
        {
            m_SoundManager.StopAllSounds();
        }

        private void OnPlaySoundSuccess(object sender, GameFramework.Sound.PlaySoundSuccessEventArgs e)
        {
            PlaySoundInfo playSoundInfo = e.UserData as PlaySoundInfo;
            if (playSoundInfo != null && playSoundInfo.BindingEntity != null)
            {
                e.SoundAgent.SetBindingEntity(playSoundInfo.BindingEntity);
            }

            m_EventComponent.Fire(this, new PlaySoundSuccessEventArgs(e));
        }

        private void OnPlaySoundFailure(object sender, GameFramework.Sound.PlaySoundFailureEventArgs e)
        {
            string logMessage = string.Format("Play sound failure, asset name '{0}', sound group name '{1}', error code '{2}', error message '{3}'.", e.SoundAssetName, e.SoundGroupName, e.ErrorCode.ToString(), e.ErrorMessage);
            if (e.ErrorCode == PlaySoundErrorCode.IgnoredDueToLowPriority)
            {
                Log.Info(logMessage);
            }
            else
            {
                Log.Warning(logMessage);
            }

            m_EventComponent.Fire(this, new PlaySoundFailureEventArgs(e));
        }
    }
}
