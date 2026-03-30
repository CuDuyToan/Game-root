using CoreSystem.Configuration;

namespace CoreSystem.Data
{
    [System.Serializable]
    public class LayoutData
    {
        public JoystickType joystickType = JoystickType.Floating;

        public Vector2Data joystickPos = new Vector2Data(0,0);

        public Vector2Data activeZone = new Vector2Data(0,0);

        public float joystickSize = 50f;

        public float transparencyUI = 50f;
    }
}