using OpenTK.Graphics.OpenGL;
using OpenTK.Graphics;
using OpenTK;
using System.Threading;

namespace HareEngine {

    public class Window : GameWindow {

        private bool init = true;

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

        public void ReloadScene() {
            init = true;
            //TODO do more changes
        }

        protected override void OnUpdateFrame(FrameEventArgs e) {
            if (Hare.currentScene != null) {
                Hare.currentScene.FixedUpdate();
                int sleep = (int)(1000 * (Time.fixedDeltaTime - e.Time));
                if (sleep > 0) {
                    Thread.Sleep(sleep);
                }
            }
        }

        protected override void OnRenderFrame(FrameEventArgs e) {
            GL.ClearColor(Hare.clearColor.r, Hare.clearColor.g, Hare.clearColor.b, Hare.clearColor.a);
            GL.Clear(ClearBufferMask.ColorBufferBit | ClearBufferMask.DepthBufferBit);
            if (init) {
                init = false;
                Hare.currentScene.Awake();
                Hare.currentScene.Start();
            }
            Hare.currentScene.Update();
            Hare.currentScene.LateUpdate();
            Hare.currentScene.Render();
            this.SwapBuffers();
        }

    }

}
