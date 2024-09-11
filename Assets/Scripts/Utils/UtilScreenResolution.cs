namespace ECS.Code.Utils
{
    using UnityEngine;
    
    public class UtilScreenResolution
    {
        /// <summary>
        /// Get Screen Resolution, compatible for both editor viewport and build
        /// </summary>
        /// <returns></returns>
        public static Vector2 GetResolution()
        {
            Vector2 resolution = default;
#if UNITY_EDITOR
            resolution = UnityEditor.Handles.GetMainGameViewSize();
#else
            resolution = new Vector2(Screen.currentResolution.width,Screen.currentResolution.height);
#endif
            return resolution;
        }

        /// <summary>
        /// Remap a screen axis value to support multiple different resolutions
        /// </summary>
        /// <param name="value">What value are you trying to remap based on this screen resolution and reference resolution</param>
        /// <param name="currentAxisValue">Current screen x or y axis value</param>
        /// <param name="referenceAxisValue">Your predefined targeted axis value</param>
        public static float GetAxisDivider(float value, float currentAxisValue, float referenceAxisValue)
        {
            return value * (currentAxisValue / referenceAxisValue);
        }
    }
}