using OpenTK.Graphics.OpenGL;
using OpenTK.Graphics;
using OpenTK;
using System;

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

        protected override void OnLoad(EventArgs e) {
            base.OnLoad(e);
        }

        protected override void OnResize(EventArgs e) {
            base.OnResize(e);
            GL.Viewport(X, Y, Width, Height);
        }

        protected override void OnUpdateFrame(FrameEventArgs e) {
            base.OnUpdateFrame(e);
            Time.fixedDeltaTime = (float)e.Time;
            if (Hare.currentScene != null) {
                Hare.currentScene.FixedUpdate();
            }
        }

        protected override void OnRenderFrame(FrameEventArgs e) {
            base.OnRenderFrame(e);
            Time.deltaTime = (float)e.Time;
            Time.time += Time.deltaTime;
            float dump = Random.Value;
            GL.ClearColor(Hare.clearColor.r, Hare.clearColor.g, Hare.clearColor.b, Hare.clearColor.a);
            GL.Clear(ClearBufferMask.ColorBufferBit | ClearBufferMask.DepthBufferBit);
            if (Hare.currentScene != null) {
                if (init) {
                    init = false;
                    Hare.currentScene.Awake();
                    Hare.currentScene.Start();
                }
                Hare.currentScene.Update();
                Hare.currentScene.LateUpdate();
                Hare.currentScene.Render();
            }
            this.SwapBuffers();
        }

    }

}
