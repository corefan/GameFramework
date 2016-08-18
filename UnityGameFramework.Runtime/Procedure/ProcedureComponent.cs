//------------------------------------------------------------
// Game Framework v2.x
// Copyright © 2014-2016 Jiang Yin. All rights reserved.
// Homepage: http://gameframework.cn/
// Feedback: mailto:jiangyin@gameframework.cn
//------------------------------------------------------------

using GameFramework;
using GameFramework.Fsm;
using GameFramework.Procedure;
using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace UnityGameFramework.Runtime
{
    /// <summary>
    /// 流程组件。
    /// </summary>
    [AddComponentMenu("Game Framework/Procedure")]
    public sealed class ProcedureComponent : GameFrameworkComponent
    {
        private IProcedureManager m_ProcedureManager = null;
        private ProcedureBase m_FirstProcedure = null;

        [SerializeField]
        private List<string> m_ProcedureClassNames = null;

        [SerializeField]
        private string m_FirstProcedureClassName = null;

        /// <summary>
        /// 获取当前流程。
        /// </summary>
        public ProcedureBase CurrentProcedure
        {
            get
            {
                return m_ProcedureManager.CurrentProcedure;
            }
        }

        /// <summary>
        /// 游戏框架组件初始化。
        /// </summary>
        protected internal override void Awake()
        {
            base.Awake();

            m_ProcedureManager = GameFrameworkEntry.GetModule<IProcedureManager>();
            if (m_ProcedureManager == null)
            {
                Log.Fatal("Procedure manager is invalid.");
                return;
            }
        }

        private IEnumerator Start()
        {
            IFsmManager fsmManager = GameFrameworkEntry.GetModule<IFsmManager>();

            ProcedureBase[] procedures = new ProcedureBase[m_ProcedureClassNames.Count];
            for (int i = 0; i < m_ProcedureClassNames.Count; i++)
            {
                Type procedureType = Utility.Assembly.GetTypeWithinLoadedAssemblies(m_ProcedureClassNames[i]);
                if (procedureType == null)
                {
                    throw new GameFrameworkException(string.Format("Can not find procedure type '{0}'.", m_ProcedureClassNames[i]));
                }

                procedures[i] = Activator.CreateInstance(procedureType) as ProcedureBase;
                if (procedures[i] == null)
                {
                    throw new GameFrameworkException(string.Format("Can not create procedure instance '{0}'.", m_ProcedureClassNames[i]));
                }

                if (m_ProcedureClassNames[i] == m_FirstProcedureClassName)
                {
                    m_FirstProcedure = procedures[i];
                }
            }

            m_ProcedureManager.Initialize(fsmManager, procedures);

            yield return new WaitForEndOfFrame();
            StartProcedure();
        }

        internal void StartProcedure()
        {
            if (m_FirstProcedure == null)
            {
                throw new GameFrameworkException("First procedure is invalid.");
            }

            m_ProcedureManager.StartProcedure(m_FirstProcedure.GetType());
        }

        /// <summary>
        /// 是否存在流程。
        /// </summary>
        /// <typeparam name="T">流程类型。</typeparam>
        /// <returns>是否存在流程。</returns>
        public bool HasProcedure<T>() where T : ProcedureBase
        {
            return m_ProcedureManager.HasProcedure<T>();
        }

        /// <summary>
        /// 获取流程。
        /// </summary>
        /// <returns>要获取的流程。</returns>
        /// <typeparam name="T">流程类型。</typeparam>
        public ProcedureBase GetProcedure<T>() where T : ProcedureBase
        {
            return m_ProcedureManager.GetProcedure<T>() as ProcedureBase;
        }
    }
}
