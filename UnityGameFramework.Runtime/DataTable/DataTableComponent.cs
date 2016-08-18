//------------------------------------------------------------
// Game Framework v2.x
// Copyright © 2014-2016 Jiang Yin. All rights reserved.
// Homepage: http://gameframework.cn/
// Feedback: mailto:jiangyin@gameframework.cn
//------------------------------------------------------------

using GameFramework;
using GameFramework.DataTable;
using GameFramework.Resource;
using System;
using UnityEngine;

namespace UnityGameFramework.Runtime
{
    /// <summary>
    /// 数据表组件。
    /// </summary>
    [AddComponentMenu("Game Framework/Data Table")]
    public sealed class DataTableComponent : GameFrameworkComponent
    {
        private IDataTableManager m_DataTableManager = null;
        private EventComponent m_EventComponent = null;

        [SerializeField]
        private DataTableHelperBase m_DataTableHelper = null;

        /// <summary>
        /// 游戏框架组件初始化。
        /// </summary>
        protected internal override void Awake()
        {
            base.Awake();

            m_DataTableManager = GameFrameworkEntry.GetModule<IDataTableManager>();
            if (m_DataTableManager == null)
            {
                Log.Fatal("Data table manager is invalid.");
                return;
            }

            m_DataTableManager.LoadDataTableSuccess += OnLoadDataTableSuccess;
            m_DataTableManager.LoadDataTableFailure += OnLoadDataTableFailure;
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
                m_DataTableManager.SetResourceManager(baseComponent.EditorResourceHelper);
            }
            else
            {
                m_DataTableManager.SetResourceManager(GameFrameworkEntry.GetModule<IResourceManager>());
            }

            if (m_DataTableHelper == null)
            {
                m_DataTableHelper = (new GameObject()).AddComponent<DefaultDataTableHelper>();
                m_DataTableHelper.name = string.Format("Data Table Helper");
                Transform transform = m_DataTableHelper.transform;
                transform.SetParent(this.transform);
                transform.localScale = Vector3.one;
            }

            m_DataTableManager.SetDataTableHelper(m_DataTableHelper);
        }

        /// <summary>
        /// 获取数据表数量。
        /// </summary>
        public int Count
        {
            get
            {
                return m_DataTableManager.Count;
            }
        }

        /// <summary>
        /// 加载数据表。
        /// </summary>
        /// <param name="dataTableName">数据表名称。</param>
        /// <param name="dataTableType">数据表类型。</param>
        /// <param name="dataTableNameInType">数据表类型下的名称。</param>
        /// <param name="dataTableAssetName">数据表资源名称。</param>
        public void LoadDataTable(string dataTableName, Type dataTableType, string dataTableNameInType, string dataTableAssetName)
        {
            LoadDataTable(dataTableName, dataTableType, dataTableNameInType, dataTableAssetName, null);
        }

        /// <summary>
        /// 加载数据表。
        /// </summary>
        /// <param name="dataTableName">数据表名称。</param>
        /// <param name="dataTableType">数据表类型。</param>
        /// <param name="dataTableNameInType">数据表类型下的名称。</param>
        /// <param name="dataTableAssetName">数据表资源名称。</param>
        /// <param name="userData">用户自定义数据。</param>
        public void LoadDataTable(string dataTableName, Type dataTableType, string dataTableNameInType, string dataTableAssetName, object userData)
        {
            if (string.IsNullOrEmpty(dataTableName))
            {
                Log.Error("Data table name is invalid.");
                return;
            }

            if (dataTableType == null)
            {
                Log.Error("Data table type is invalid.");
                return;
            }

            m_DataTableManager.LoadDataTable(dataTableAssetName, new LoadDataTableInfo(dataTableName, dataTableType, dataTableNameInType, userData));
        }

        /// <summary>
        /// 是否存在数据表。
        /// </summary>
        /// <typeparam name="T">数据表行的类型。</typeparam>
        /// <returns>是否存在数据表。</returns>
        public bool HasDataTable<T>() where T : IDataRow
        {
            return m_DataTableManager.HasDataTable<T>();
        }

        /// <summary>
        /// 是否存在数据表。
        /// </summary>
        /// <param name="type">数据表行的类型。</param>
        /// <returns>是否存在数据表。</returns>
        public bool HasDataTable(Type type)
        {
            return m_DataTableManager.HasDataTable(type);
        }

        /// <summary>
        /// 是否存在数据表。
        /// </summary>
        /// <typeparam name="T">数据表行的类型。</typeparam>
        /// <param name="name">数据表名称。</param>
        /// <returns>是否存在数据表。</returns>
        public bool HasDataTable<T>(string name) where T : IDataRow
        {
            return m_DataTableManager.HasDataTable<T>(name);
        }

        /// <summary>
        /// 是否存在数据表。
        /// </summary>
        /// <param name="type">数据表行的类型。</param>
        /// <param name="name">数据表名称。</param>
        /// <returns>是否存在数据表。</returns>
        public bool HasDataTable(Type type, string name)
        {
            return m_DataTableManager.HasDataTable(type, name);
        }

        /// <summary>
        /// 获取数据表。
        /// </summary>
        /// <typeparam name="T">数据表行的类型。</typeparam>
        /// <returns>要获取的数据表。</returns>
        public IDataTable<T> GetDataTable<T>() where T : IDataRow
        {
            return m_DataTableManager.GetDataTable<T>();
        }

        /// <summary>
        /// 获取数据表。
        /// </summary>
        /// <param name="type">数据表行的类型。</param>
        /// <returns>要获取的数据表。</returns>
        public DataTableBase GetDataTable(Type type)
        {
            return m_DataTableManager.GetDataTable(type);
        }

        /// <summary>
        /// 获取数据表。
        /// </summary>
        /// <typeparam name="T">数据表行的类型。</typeparam>
        /// <param name="name">数据表名称。</param>
        /// <returns>要获取的数据表。</returns>
        public IDataTable<T> GetDataTable<T>(string name) where T : IDataRow
        {
            return m_DataTableManager.GetDataTable<T>(name);
        }

        /// <summary>
        /// 获取数据表。
        /// </summary>
        /// <param name="type">数据表行的类型。</param>
        /// <param name="name">数据表名称。</param>
        /// <returns>要获取的数据表。</returns>
        public DataTableBase GetDataTable(Type type, string name)
        {
            return m_DataTableManager.GetDataTable(type, name);
        }

        /// <summary>
        /// 获取所有数据表。
        /// </summary>
        public DataTableBase[] GetAllDataTables()
        {
            return m_DataTableManager.GetAllDataTables();
        }

        /// <summary>
        /// 创建数据表。
        /// </summary>
        /// <typeparam name="T">数据表行的类型。</typeparam>
        /// <param name="text">要解析的数据表文本。</param>
        /// <returns>要创建的数据表。</returns>
        public IDataTable<T> CreateDataTable<T>(string text) where T : IDataRow, new()
        {
            return m_DataTableManager.CreateDataTable<T>(text);
        }

        /// <summary>
        /// 创建数据表。
        /// </summary>
        /// <typeparam name="T">数据表行的类型。</typeparam>
        /// <param name="name">数据表名称。</param>
        /// <param name="text">要解析的数据表文本。</param>
        /// <returns>要创建的数据表。</returns>
        public IDataTable<T> CreateDataTable<T>(string name, string text) where T : IDataRow, new()
        {
            return m_DataTableManager.CreateDataTable<T>(name, text);
        }

        /// <summary>
        /// 销毁数据表。
        /// </summary>
        /// <typeparam name="T">数据表行的类型。</typeparam>
        /// <returns>是否销毁数据表成功。</returns>
        public bool DestroyDataTable<T>() where T : IDataRow, new()
        {
            return m_DataTableManager.DestroyDataTable<T>();
        }

        /// <summary>
        /// 销毁数据表。
        /// </summary>
        /// <param name="type">数据表行的类型。</param>
        /// <returns>是否销毁数据表成功。</returns>
        public bool DestroyDataTable(Type type)
        {
            return m_DataTableManager.DestroyDataTable(type);
        }

        /// <summary>
        /// 销毁数据表。
        /// </summary>
        /// <typeparam name="T">数据表行的类型。</typeparam>
        /// <param name="name">数据表名称。</param>
        /// <returns>是否销毁数据表成功。</returns>
        public bool DestroyDataTable<T>(string name) where T : IDataRow, new()
        {
            return m_DataTableManager.DestroyDataTable<T>(name);
        }

        /// <summary>
        /// 销毁数据表。
        /// </summary>
        /// <param name="type">数据表行的类型。</param>
        /// <param name="name">数据表名称。</param>
        /// <returns>是否销毁数据表成功。</returns>
        public bool DestroyDataTable(Type type, string name)
        {
            return m_DataTableManager.DestroyDataTable(type, name);
        }

        internal void ReflectionCreateDataTable<T>(string name, string text) where T : IDataRow, new()
        {
            if (CreateDataTable<T>(name, text) == null)
            {
                Log.Warning("Add data table failed in ReflectionCreateDataTable.");
            }
        }

        private void OnLoadDataTableSuccess(object sender, GameFramework.DataTable.LoadDataTableSuccessEventArgs e)
        {
            m_EventComponent.Fire(this, new LoadDataTableSuccessEventArgs(e));
        }

        private void OnLoadDataTableFailure(object sender, GameFramework.DataTable.LoadDataTableFailureEventArgs e)
        {
            Log.Warning("Load data table failure, asset name '{0}', error message '{1}'.", e.DataTableAssetName, e.ErrorMessage);
            m_EventComponent.Fire(this, new LoadDataTableFailureEventArgs(e));
        }
    }
}
