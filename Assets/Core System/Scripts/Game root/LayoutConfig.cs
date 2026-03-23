using CoreSystem.Configuration;
using CoreSystem.Data;
using System.IO;
using UnityEngine;

namespace CoreSystem.Configuration
{
    public class LayoutConfig: Config
    {
        private JoystickType joystickType = JoystickType.Dynamic;
        public JoystickType JoystickType => joystickType;

        private Vector2Data joystickPos = new Vector2Data(0,0);
        public Vector2Data JoystickPos => joystickPos;

        private Vector2Data activeZone = new Vector2Data(0, 0);
        public Vector2Data ActiveZone => activeZone;

        private float joystickSize = 100;
        public float JoystickSize => joystickSize;

        private float transparencyUI = 100;
        public float TransparencyUI => transparencyUI;

        public LayoutConfig()
        {
        }

        public LayoutConfig(string path, LayoutData data)
        {
            DataPath(path);

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

        #region set value
        public void setJoystickType(JoystickType type)
        {
            joystickType = type;
        }

        public void setJoystickPos(Vector2Data value)
        {
            this.joystickPos = value;
        }

        public void setActiveZone(Vector2Data value)
        {
            this.activeZone = value; 
        }

        public void setJoystickSize(float value)
        {
            this.joystickSize = value;
        }

        public void setTransparencyUI(float value)
        {
            this.transparencyUI = value;
        }
        #endregion set value
    }
}