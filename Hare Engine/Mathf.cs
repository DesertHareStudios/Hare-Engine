namespace HareEngine {

    class Mathf {

        public static float ToRadians(float degrees) {
            return degrees * (3.14159f / 180.0f);
        }

        public static float ToDegrees(float radians) {
            return radians * (180.0f / 3.14159f);
        }

        public static float Clamp(float value, float min, float max) {
            if (value < min) {
                return min;
            }
            if (value > max) {
                return max;
            }
            return value;
        }

        public static float Lerp(float from, float to, float t) {
            return from + (to - from) * t;
        }

    }

}
