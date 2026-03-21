using UnityEngine;
using System.Collections;

namespace CoreSystem.Data
{
	[System.Serializable]
	public class Vector2Data
	{
		public float x, y;

		public Vector2Data(float x, float y) 
		{
			this.x = x;
			this.y = y;
		}
	}
}