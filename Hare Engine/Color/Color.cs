using OpenTK;

namespace HareEngine {

    public class Color {

        public float r;
        public float g;
        public float b;
        public float a;

        public Color(float r, float g, float b, float a) {
            this.r = r;
            this.g = g;
            this.b = b;
            this.a = a;
        }

        public Color(float r, float g, float b) {
            this.r = r;
            this.g = g;
            this.b = b;
            this.a = 1.0f;
        }

        public Color() {
            this.r = 0.0f;
            this.g = 0.0f;
            this.b = 0.0f;
            this.a = 0.0f;
        }

        public static Color Lerp(Color from, Color to, float t) {
            return new Color(
                Mathf.Clamp(from.r + (to.r - from.r) * t, 0f, 1f),
                Mathf.Clamp(from.g + (to.g - from.g) * t, 0f, 1f),
                Mathf.Clamp(from.b + (to.b - from.b) * t, 0f, 1f),
                Mathf.Clamp(from.a + (to.a - from.a) * t, 0f, 1f)
                );
        }

        public static Color Lerp(Color[] colors, float t) {
            float rt = ((float)colors.Length - 1f) * t;
            int a = (int)Mathf.Floor(rt);
            int b = (int)Mathf.Ceiling(rt);
            return Lerp(
                    colors[a],
                    colors[b],
                    rt - (float)a
                );
        }

        public Vector3 Vector3 {
            get {
                return new Vector3(r, g, b);
            }
            set {
                r = value.X;
                g = value.Y;
                b = value.Z;
            }
        }

        public Vector4 Vector4 {
            get {
                return new Vector4(r, g, b, a);
            }
            set {
                r = value.X;
                g = value.Y;
                b = value.Z;
                a = value.W;
            }
        }

        public static Color operator +(Color a, Color b) {
            Color output = new Color();
            output.r = Mathf.Clamp(a.r + b.r, 0f, 1f);
            output.g = Mathf.Clamp(a.g + b.g, 0f, 1f);
            output.b = Mathf.Clamp(a.b + b.b, 0f, 1f);
            output.a = Mathf.Clamp(a.a + b.a, 0f, 1f);
            return output;
        }

        public static Color operator -(Color a, Color b) {
            Color output = new Color();
            output.r = Mathf.Clamp(a.r - b.r, 0f, 1f);
            output.g = Mathf.Clamp(a.g - b.g, 0f, 1f);
            output.b = Mathf.Clamp(a.b - b.b, 0f, 1f);
            output.a = Mathf.Clamp(a.a - b.a, 0f, 1f);
            return output;
        }

        public static Color operator *(Color a, Color b) {
            Color output = new Color();
            output.r = Mathf.Clamp(a.r * b.r, 0f, 1f);
            output.g = Mathf.Clamp(a.g * b.g, 0f, 1f);
            output.b = Mathf.Clamp(a.b * b.b, 0f, 1f);
            output.a = Mathf.Clamp(a.a * b.a, 0f, 1f);
            return output;
        }

        public static Color operator /(Color a, Color b) {
            Color output = new Color();
            output.r = Mathf.Clamp(a.r / b.r, 0f, 1f);
            output.g = Mathf.Clamp(a.g / b.g, 0f, 1f);
            output.b = Mathf.Clamp(a.b / b.b, 0f, 1f);
            output.a = Mathf.Clamp(a.a / b.a, 0f, 1f);
            return output;
        }

    }

}
