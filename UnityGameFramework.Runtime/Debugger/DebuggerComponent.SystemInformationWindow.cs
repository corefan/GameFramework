//------------------------------------------------------------
// Game Framework v2.x
// Copyright © 2014-2017 Jiang Yin. All rights reserved.
// Homepage: http://gameframework.cn/
// Feedback: mailto:jiangyin@gameframework.cn
//------------------------------------------------------------

using UnityEngine;

namespace UnityGameFramework.Runtime
{
    public partial class DebuggerComponent
    {
        private sealed class SystemInformationWindow : ScrollableDebuggerWindowBase
        {
            protected override void OnDrawScrollableWindow()
            {
                GUILayout.Label("<b>System Information</b>");
                GUILayout.BeginVertical("box");
                {
                    DrawItem("Device Unique ID:", SystemInfo.deviceUniqueIdentifier);
                    DrawItem("Device Name:", SystemInfo.deviceName);
                    DrawItem("Device Type:", SystemInfo.deviceType.ToString());
                    DrawItem("Device Model:", SystemInfo.deviceModel);
                    DrawItem("Processor Type:", SystemInfo.processorType);
                    DrawItem("Processor Count:", SystemInfo.processorCount.ToString());
                    DrawItem("Processor Frequency:", string.Format("{0} MHz", SystemInfo.processorFrequency.ToString()));
                    DrawItem("Memory Size:", string.Format("{0} MB", SystemInfo.systemMemorySize.ToString()));
                    DrawItem("Operating System:", SystemInfo.operatingSystem);
                    DrawItem("Supports Location Service:", SystemInfo.supportsLocationService.ToString());
                    DrawItem("Supports Accelerometer:", SystemInfo.supportsAccelerometer.ToString());
                    DrawItem("Supports Gyroscope:", SystemInfo.supportsGyroscope.ToString());
                    DrawItem("Supports Vibration:", SystemInfo.supportsVibration.ToString());
                    DrawItem("Genuine:", Application.genuine.ToString());
                    DrawItem("Genuine Check Available:", Application.genuineCheckAvailable.ToString());
                }
                GUILayout.EndVertical();
            }
        }
    }
}
