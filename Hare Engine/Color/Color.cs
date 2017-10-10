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
                from.r + (to.r - from.r) * t,
                from.g + (to.g - from.g) * t,
                from.b + (to.b - from.b) * t,
                from.a + (to.a - from.a) * t
                );
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
