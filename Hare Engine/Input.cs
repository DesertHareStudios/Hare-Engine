using OpenTK;
using OpenTK.Input;
using System.Collections.Generic;

namespace HareEngine {

    public class Input {

        public static Vector2 mousePosition = new Vector2();
        public static bool isMouseInside = true;
        public static float scrollDelta = 0;
        public static List<MouseButton> mb = new List<MouseButton>();
        public static List<MouseButton> mbd = new List<MouseButton>();
        public static List<MouseButton> mbu = new List<MouseButton>();

        public static List<Key> keys = new List<Key>();
        public static List<Key> keysd = new List<Key>();
        public static List<Key> keysu = new List<Key>();

        public static bool GetKey(Key key) {
            foreach (Key k in keys) {
                if (key.Equals(k)) {
                    return true;
                }
            }
            return false;
        }

        public static bool GetKeyDown(Key key) {
            foreach (Key k in keysd) {
                if (key.Equals(k)) {
                    return true;
                }
            }
            return false;
        }

        public static bool GetKeyUp(Key key) {
            foreach (Key k in keysu) {
                if (key.Equals(k)) {
                    return true;
                }
            }
            return false;
        }
        public static bool GetMouseButton(MouseButton b) {
            foreach (MouseButton k in mb) {
                if (b.Equals(k)) {
                    return true;
                }
            }
            return false;
        }

        public static bool GetMouseButtonDown(MouseButton b) {
            foreach (MouseButton k in mbd) {
                if (b.Equals(k)) {
                    return true;
                }
            }
            return false;
        }

        public static bool GetMouseButtonUp(MouseButton b) {
            foreach (MouseButton k in mbu) {
                if (b.Equals(k)) {
                    return true;
                }
            }
            return false;
        }

    }

}
