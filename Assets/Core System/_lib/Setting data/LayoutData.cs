using CoreSystem.Configuration;

namespace CoreSystem.Data
{
    [System.Serializable]
    public class LayoutData
    {
        public JoystickType joystickType;

        public Vector2Data joystickPos;

        public Vector2Data activeZone;

        public float joystickSize;

        public float transparencyUI;
    }
}