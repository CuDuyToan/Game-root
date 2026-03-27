using CoreSystem.Configuration;
using CoreSystem.Data;
using System.IO;
using UnityEngine;

namespace CoreSystem.Configuration
{
    public class LayoutConfig: Config
    {
        public JoystickType joystickType = JoystickType.Dynamic;

        public Vector2Data joystickPos = new Vector2Data(0,0);

        public Vector2Data activeZone = new Vector2Data(0, 0);

        public float joystickSize = 100;

        public float transparencyUI = 100;

        public LayoutConfig()
        {
        }

        public LayoutConfig(LayoutData data)
        {
            if(data != null) LoadData(data);
        }

        private void LoadData(LayoutData data)
        {
            joystickType = data.joystickType;
            joystickPos = data.joystickPos;
            activeZone = data.activeZone;
            joystickSize = data.joystickSize;
            transparencyUI = data.transparencyUI;
        }

        public LayoutData getData()
        {
            LayoutData data = new LayoutData();
            data.joystickType = joystickType;
            data.joystickPos = new Vector2Data(joystickPos.x, joystickPos.y);
            data.activeZone = new Vector2Data(activeZone.x, activeZone.y);
            data.joystickSize = joystickSize;
            data.transparencyUI = transparencyUI;
            return data;
        }
    }
}