using OpenTK.Graphics.OpenGL;
using OpenTK.Graphics;
using OpenTK;

namespace HareEngine {

    public class Window : GameWindow {

        public Window(int width, int height, string title) : base(
            width,
            height,
            GraphicsMode.Default,
            title,
            GameWindowFlags.Default,
            DisplayDevice.Default,
            3,
            0,
            GraphicsContextFlags.ForwardCompatible) { }

        public float AspectRatio {
            get {
                return (float)Width / (float)Height;
            }
        }

        protected override void OnUpdateFrame(FrameEventArgs e) {
            if (Hare.currentScene != null) {
                Hare.currentScene.Update();
                Hare.currentScene.LateUpdate();
            }
        }

        protected override void OnRenderFrame(FrameEventArgs e) {
            GL.ClearColor(Hare.clearColor.r, Hare.clearColor.g, Hare.clearColor.b, Hare.clearColor.a);
            GL.Clear(ClearBufferMask.ColorBufferBit | ClearBufferMask.DepthBufferBit);

            this.SwapBuffers();
        }

    }

}
