using UnityEngine;

namespace CoreSystem
{
    public class TimeManager
    {
        public float convertToSecond(int hour, int minute, float second)
        {
            return hour * 3600 + minute * 60 + second;
        }
    }
}
