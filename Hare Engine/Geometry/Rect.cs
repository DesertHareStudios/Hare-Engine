using OpenTK;

namespace HareEngine {

    public class Rect {

        public float x1;
        public float y1;
        public float x2;
        public float y2;

        public Rect(float x1, float y1, float x2, float y2) {
            this.x1 = x1;
            this.y1 = y1;
            this.x2 = x2;
            this.y2 = y2;
        }

        public Rect(float x, float y) {
            this.x1 = x;
            this.y1 = y;
            this.x2 = x;
            this.y2 = y;
            Width = 1;
            Height = 1;
        }

        public Rect(Vector3 p1, Vector3 p2) {
            this.x1 = p1.X;
            this.y1 = p1.Y;
            this.x2 = p2.X;
            this.y2 = p2.Y;
        }

        public Rect(Vector3 p) {
            this.x1 = p.X;
            this.y1 = p.Y;
            this.x2 = p.X;
            this.y2 = p.Y;
            Width = 1;
            Height = 1;
        }

        public float Width {
            get {
                return x2 - x1;
            }
            set {
                x2 = x1 + value;
            }
        }

        public float Height {
            get {
                return y2 - y1;
            }
            set {
                y2 = y1 + value;
            }
        }

        public bool CollidesWith(Rect b) {
            return x1 < b.x2 && x2 > b.x1 && y1 > b.y2 && y2 < b.y1;
        }

    }

}
