using OpenTK;
using OpenTK.Input;

namespace HareEngine {

    public class Input {

        private static KeyboardState ks;
        private static KeyboardState prevks;
        private static JoystickState js;
        private static JoystickState prevjs;
        private static MouseState ms;
        private static MouseState prevms;

        public static void UpdateData() {
            prevks = ks;
            ks = Keyboard.GetState();
            prevjs = js;
            js = Joystick.GetState(0);
            prevms = ms;
            ms = Mouse.GetState();
        }

        public static bool GetButton(Key button) {
            return ks.IsKeyDown(button);
        }
        public static bool GetButtonDown(Key button) {
            return ks.IsKeyDown(button) && prevks.IsKeyUp(button);
        }

        public static bool GetButtonUp(Key button) {
            return ks.IsKeyUp(button) && prevks.IsKeyDown(button);
        }

        public static bool GetButton(JoystickButton button) {
            return js.IsButtonDown(button);
        }
        public static bool GetButtonDown(JoystickButton button) {
            return js.IsButtonDown(button) && prevjs.IsButtonUp(button);
        }

        public static bool GetButtonUp(JoystickButton button) {
            return js.IsButtonUp(button) && prevjs.IsButtonDown(button);
        }

        public static bool GetButton(MouseButton button) {
            return ms.IsButtonDown(button);
        }
        public static bool GetButtonDown(MouseButton button) {
            return ms.IsButtonDown(button) && prevms.IsButtonUp(button);
        }

        public static bool GetButtonUp(MouseButton button) {
            return ms.IsButtonUp(button) && prevms.IsButtonDown(button);
        }

        public static float MouseScroll {
            get {
                return ms.WheelPrecise - prevms.WheelPrecise;
            }
        }

        public static Vector2 MousePosition {
            get {
                MouseState mcs = Mouse.GetCursorState();
                return new Vector2(mcs.X, mcs.Y);
            }
        }

    }

}
