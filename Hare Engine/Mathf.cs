using System;
using OpenTK;

namespace HareEngine {

    public class Mathf {

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

        public static float Sqrt(float n) {
            float root = n / 3f;
            float last;
            float diff = 1f;
            if (n <= 0f) {
                return 0f;
            }
            do {
                last = root;
                root = (root + n / root) / 2f;
                diff = root - last;
            } while (diff > 2.25e-308f || diff < -2.25e-308f);
            return root;
        }

        public static float Pow(float n, int p) {
            if (p == 0) {
                return 1f;
            }
            if (p == 1) {
                return n;
            }
            if (p < 0) {
                return 1f / Pow(n, -p);
            }
            return Pow(n * n, p - 1);
        }

        public static float Factorial(int n) {
            if (n < 0) {
                return 0f;
            }
            if (n == 0) {
                return 1f;
            }
            return n * Factorial(n - 1);
        }

        public static Vector3 ApplyRotation(Vector3 vector, Quaternion rotation) {
            return 2f * Vector3.Dot(rotation.Xyz, vector) * rotation.Xyz +
                (rotation.W * rotation.W - Vector3.Dot(rotation.Xyz, vector)) * vector +
                2f * rotation.W * Vector3.Cross(rotation.Xyz, vector);
        }

        public static Vector3 GetEulerAngles(Quaternion q) {
            return new Vector3(
                    ToDegrees(Atan2(q.X * q.Z + q.Y * q.W, q.X * q.W - q.Y * q.Z)),
                    ToDegrees(Acos(-(q.X * q.X) - (q.Y * q.Y) + (q.Z * q.Z) + (q.W * q.W))),
                    ToDegrees(Atan2(q.X * q.Z - q.Y * q.W, q.Y * q.Z + q.X * q.W))
                );
        }

        public static float Sin(float a) {
            return (float)Math.Sin((double)a);
        }

        public static float Cos(float a) {
            return (float)Math.Cos((double)a);
        }

        public static float Tan(float a) {
            return (float)Math.Tan((double)a);
        }

        public static float Asin(float a) {
            return (float)Math.Asin((double)a);
        }

        public static float Acos(float a) {
            return (float)Math.Acos((double)a);
        }

        public static float Atan(float a) {
            return (float)Math.Atan((double)a);
        }

        public static float Atan2(float a, float b) {
            return (float)Math.Atan2(a, b);
        }

        public static float Sinh(float a) {
            return (float)Math.Sinh((double)a);
        }

        public static float Cosh(float a) {
            return (float)Math.Cosh((double)a);
        }

        public static float Tanh(float a) {
            return (float)Math.Tanh((double)a);
        }

        public static float Abs(float a) {
            if (a >= 0f) {
                return a;
            }
            return -a;
        }

        public static float Floor(float a) {
            return (float)((int)a);
        }

        public static float Ceiling(float a) {
            if (a > (int)a) {
                return (float)((int)a) + 1f;
            }
            return (float)((int)a);
        }

        public static float Round(float a) {
            float control = ((int)a) + 0.5f;
            if (a >= control) {
                return (int)a + 1f;
            } else {
                return (int)a;
            }
        }

    }

}
