using System;
using System.Collections.Generic;
using OpenTK.Graphics.OpenGL;
using OpenTK.Graphics;
using OpenTK;
using OpenTK.Input;

namespace HareEngine {

    public class Window : GameWindow {

        private bool init = false;
        private Scene _currentScene;
        public Scene currentScene {
            get {
                return _currentScene;
            }
            set {
                _currentScene = value;
                init = true;
                //TODO do more changes
            }
        }
        private List<Key> keysd = new List<Key>();
        private List<Key> keysu = new List<Key>();
        private List<MouseButton> mbd = new List<MouseButton>();
        private List<MouseButton> mbu = new List<MouseButton>();

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

        protected override void OnLoad(EventArgs e) {
            base.OnLoad(e);
            GL.Enable(EnableCap.Blend);
        }

        protected override void OnResize(EventArgs e) {
            base.OnResize(e);
            GL.Viewport(X, Y, Width, Height);
        }

        protected override void OnUpdateFrame(FrameEventArgs e) {
            base.OnUpdateFrame(e);
            Time.fixedDeltaTime = (float)e.Time;
            if (currentScene != null) {
                currentScene.FixedUpdate();
            }
        }

        protected override void OnRenderFrame(FrameEventArgs e) {
            base.OnRenderFrame(e);
            foreach (Key k in keysd) {
                Input.keysd.Add(k);
            }
            foreach (Key k in keysu) {
                Input.keysu.Add(k);
            }
            foreach (MouseButton mb in mbd) {
                Input.mbd.Add(mb);
            }
            foreach (MouseButton mb in mbu) {
                Input.mbu.Add(mb);
            }
            keysd.Clear();
            keysu.Clear();
            mbd.Clear();
            mbu.Clear();
            Time.deltaTime = (float)e.Time;
            Time.time += Time.deltaTime;
            float dump = Random.Value;
            GL.ClearColor(Hare.clearColor.r, Hare.clearColor.g, Hare.clearColor.b, Hare.clearColor.a);
            GL.Clear(ClearBufferMask.ColorBufferBit | ClearBufferMask.DepthBufferBit);
            if (currentScene != null) {
                if (init) {
                    init = false;
                    currentScene.Preload?.Invoke();
                    currentScene.Awake();
                    currentScene.Start();
                }
                currentScene.Update();
                currentScene.LateUpdate();
                currentScene.Render();
            }
            this.SwapBuffers();
            Input.keysd.Clear();
            Input.keysu.Clear();
            Input.mb.Clear();
            Input.mbd.Clear();
            Input.mbu.Clear();
        }

        protected override void OnMouseDown(MouseButtonEventArgs e) {
            base.OnMouseDown(e);
            Input.mb.Add(e.Button);
            mbd.Add(e.Button);
        }

        protected override void OnMouseEnter(EventArgs e) {
            base.OnMouseEnter(e);
            Input.isMouseInside = true;
        }

        protected override void OnMouseLeave(EventArgs e) {
            base.OnMouseLeave(e);
            Input.isMouseInside = false;
        }

        protected override void OnMouseMove(MouseMoveEventArgs e) {
            base.OnMouseMove(e);
            Input.mousePosition = new Vector2(e.Position.X, e.Position.Y);
        }

        protected override void OnMouseUp(MouseButtonEventArgs e) {
            base.OnMouseUp(e);
            Input.mb.Remove(e.Button);
            mbu.Add(e.Button);
        }

        protected override void OnMouseWheel(MouseWheelEventArgs e) {
            base.OnMouseWheel(e);
            Input.scrollDelta = e.DeltaPrecise;
        }

        protected override void OnKeyDown(KeyboardKeyEventArgs e) {
            base.OnKeyDown(e);
            Input.keys.Add(e.Key);
            keysd.Add(e.Key);
        }

        protected override void OnKeyUp(KeyboardKeyEventArgs e) {
            base.OnKeyUp(e);
            Input.keys.Remove(e.Key);
            keysu.Add(e.Key);
        }

    }

}
