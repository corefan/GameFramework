//------------------------------------------------------------
// Game Framework v2.x
// Copyright © 2014-2016 Jiang Yin. All rights reserved.
// Homepage: http://gameframework.cn/
// Feedback: mailto:jiangyin@gameframework.cn
//------------------------------------------------------------

using UnityEngine;

namespace UnityGameFramework.Runtime
{
    public partial class DebuggerComponent
    {
        private sealed class OperationSettingsWindow : ScrollableDebuggerWindowBase
        {
            protected override void OnDrawScrollableWindow()
            {
                GUILayout.Label("<b>Operation Settings</b>");
                GUILayout.BeginVertical("box");
                {
                    ObjectPoolComponent objectPoolComponent = GameEntry.GetComponent<ObjectPoolComponent>();
                    if (objectPoolComponent != null)
                    {
                        if (GUILayout.Button("Object Pool Release", GUILayout.Height(30f)))
                        {
                            objectPoolComponent.Release();
                        }

                        if (GUILayout.Button("Object Pool Release All Unused", GUILayout.Height(30f)))
                        {
                            objectPoolComponent.ReleaseAllUnused();
                        }
                    }

                    ResourceComponent resourceCompoent = GameEntry.GetComponent<ResourceComponent>();
                    if (resourceCompoent != null)
                    {
                        if (GUILayout.Button("Unload Unused Assets", GUILayout.Height(30f)))
                        {
                            resourceCompoent.UnloadUnusedAssets(false, "release from debugger");
                        }

                        if (GUILayout.Button("Unload Unused Assets and Garbage Collect", GUILayout.Height(30f)))
                        {
                            resourceCompoent.UnloadUnusedAssets(true, "release from debugger");
                        }
                    }

                    if (GUILayout.Button("Restart Game Framework", GUILayout.Height(30f)))
                    {
                        GameEntry.Restart();
                    }
                    if (GUILayout.Button("Shutdown Game Framework", GUILayout.Height(30f)))
                    {
                        GameEntry.Shutdown();
                    }
                }
                GUILayout.EndVertical();
            }
        }
    }
}
