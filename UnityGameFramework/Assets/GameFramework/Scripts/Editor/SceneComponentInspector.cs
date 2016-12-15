//------------------------------------------------------------
// Game Framework v3.x
// Copyright © 2013-2017 Jiang Yin. All rights reserved.
// Homepage: http://gameframework.cn/
// Feedback: mailto:jiangyin@gameframework.cn
//------------------------------------------------------------

using UnityEditor;
using UnityEngine;
using UnityGameFramework.Runtime;

namespace UnityGameFramework.Editor
{
    [CustomEditor(typeof(SceneComponent))]
    internal sealed class SceneComponentInspector : GameFrameworkInspector
    {
        private SerializedProperty m_EnableLoadSceneSuccessEvent = null;
        private SerializedProperty m_EnableLoadSceneFailureEvent = null;
        private SerializedProperty m_EnableLoadSceneUpdateEvent = null;
        private SerializedProperty m_EnableLoadSceneDependencyAssetEvent = null;
        private SerializedProperty m_EnableUnloadSceneSuccessEvent = null;
        private SerializedProperty m_EnableUnloadSceneFailureEvent = null;

        public override void OnInspectorGUI()
        {
            base.OnInspectorGUI();

            serializedObject.Update();

            SceneComponent t = target as SceneComponent;

            EditorGUILayout.PropertyField(m_EnableLoadSceneSuccessEvent);
            EditorGUILayout.PropertyField(m_EnableLoadSceneFailureEvent);
            EditorGUILayout.PropertyField(m_EnableLoadSceneUpdateEvent);
            EditorGUILayout.PropertyField(m_EnableLoadSceneDependencyAssetEvent);
            EditorGUILayout.PropertyField(m_EnableUnloadSceneSuccessEvent);
            EditorGUILayout.PropertyField(m_EnableUnloadSceneFailureEvent);

            serializedObject.ApplyModifiedProperties();

            if (EditorApplication.isPlaying)
            {
                EditorGUILayout.LabelField("Loaded Scene Names", GetSceneNameString(t.GetLoadedSceneNames()));
                EditorGUILayout.LabelField("Loading Scene Names", GetSceneNameString(t.GetLoadingSceneNames()));
                EditorGUILayout.ObjectField("Main Camera", t.MainCamera, typeof(Camera), true);

                Repaint();
            }
        }

        private void OnEnable()
        {
            m_EnableLoadSceneSuccessEvent = serializedObject.FindProperty("m_EnableLoadSceneSuccessEvent");
            m_EnableLoadSceneFailureEvent = serializedObject.FindProperty("m_EnableLoadSceneFailureEvent");
            m_EnableLoadSceneUpdateEvent = serializedObject.FindProperty("m_EnableLoadSceneUpdateEvent");
            m_EnableLoadSceneDependencyAssetEvent = serializedObject.FindProperty("m_EnableLoadSceneDependencyAssetEvent");
            m_EnableUnloadSceneSuccessEvent = serializedObject.FindProperty("m_EnableUnloadSceneSuccessEvent");
            m_EnableUnloadSceneFailureEvent = serializedObject.FindProperty("m_EnableUnloadSceneFailureEvent");
        }

        private string GetSceneNameString(string[] sceneNames)
        {
            return sceneNames == null || sceneNames.Length <= 0 ? "<Empty>" : string.Join(", ", sceneNames);
        }
    }
}
