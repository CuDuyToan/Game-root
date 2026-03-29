using CoreSystem.Data;
using UnityEngine;

namespace CoreSystem
{
    public static class TimeManager
    {
        public static float convertToSecond(int hour, int minute, float second)
        {
            return hour * 3600 + minute * 60 + second;
        }

        public static string convertTotalTimeToString(float totalTime)
        {
            int hour = (int)(totalTime / 3600);
            int minute = (int)((totalTime % 3600) / 60);
            float second = totalTime % 60;
            return $"{hour:D2}:{minute:D2}:{second:F2}";
        }
    }
}
