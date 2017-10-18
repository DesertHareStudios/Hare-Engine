using System.Collections.Generic;

namespace HareEngine.Geometry {

    public class GeoNode {

        private GeoNode previous;
        private GeoNode next;

        public Vector position;
        public GeoNode Next {
            get {
                return next;
            }
            set {
                next = value;
                next.previous = this;
            }
        }
        public GeoNode Previous {
            get {
                return previous;
            }
            set {
                previous = value;
                previous.next = this;
            }
        }

        public GeoNode() {
            position = new Vector();
        }

        public GeoNode(Vector position) {
            this.position = position;
        }

        public GeoNode(Vector position, GeoNode next) {
            this.position = position;
            Next = next;
        }

        public void Add(Vector position) {
            if (next == null) {
                next = new GeoNode(position);
                next.previous = this;
            } else {
                next.Add(position);
            }
        }

        public float EnteringRatio(Vector point, Vector context, Quaternion rotation) {
            float counter = 0f;
            float inside = 0f;
            GeoNode node = this;
            while (node.next != null) {
                counter += 1f;
                Vector p1 = (node.position + context).Rotated(rotation);
                Vector p2 = (node.next.position + context).Rotated(rotation);
                if (point.x >= p1.x && point.x <= p2.x) {
                    inside += 1f;
                } else if (point.x <= p1.x && point.x >= p2.x) {
                    inside += 1f;
                }
                if (point.y >= p1.y && point.y <= p2.y) {
                    inside += 1f;
                } else if (point.y <= p1.y && point.y >= p2.y) {
                    inside += 1f;
                }
                if (point.z >= p1.z && point.z <= p2.z) {
                    inside += 1f;
                } else if (point.z <= p1.z && point.z >= p2.z) {
                    inside += 1f;
                }
            }
            if (counter == 0f) {
                return 0f;
            }
            return inside / (counter * 3f);
        }
    }

}
