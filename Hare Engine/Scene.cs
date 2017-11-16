using OpenTK;
using OpenTK.Graphics.OpenGL;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading;

namespace HareEngine {

    public class Scene {
        public string Name = "";
        public List<GameObject> gameObjects = new List<GameObject>();
        public Action Preload;

        protected List<Renderer> renderers {
            get {
                List<Renderer> output = new List<Renderer>();
                foreach (GameObject go in gameObjects) {
                    if (go.Active) {
                        foreach (Behaviour b in go.behaviours) {
                            if (b.Active) {
                                if (b.GetType().IsSubclassOf(typeof(Renderer))) {
                                    output.Add((Renderer)b);
                                }
                            }
                        }
                    }
                }
                return output;
            }
        }

        protected List<Camera> cameras {
            get {
                List<Camera> output = new List<Camera>();
                foreach (GameObject go in gameObjects) {
                    if (go.Active) {
                        foreach (Behaviour b in go.behaviours) {
                            if (b.Active) {
                                if (b.GetType().IsSubclassOf(typeof(Camera)) || b.GetType() == typeof(Camera)) {
                                    output.Add((Camera)b);
                                }
                            }
                        }
                    }
                }
                return output;
            }
        }

        public Scene(string name) {
            this.Name = name;
            gameObjects = new List<GameObject>();
        }

        public Scene() {
            this.Name = "New Scene";
            gameObjects = new List<GameObject>();
        }

        public void Awake() {
            if (gameObjects == null) {
                gameObjects = new List<GameObject>();
                return;
            }
            List<Thread> threads = new List<Thread>();
            foreach (GameObject go in gameObjects) {
                foreach (Behaviour b in go.behaviours) {
                    Thread t = new Thread(new ThreadStart(() => {
                        try {
                            b.Awake();
                        } catch (Exception e) {
                            Console.WriteLine(e.Message);
                            Console.WriteLine(e.StackTrace);
                        }
                    }));
                    t.IsBackground = true;
                    threads.Add(t);
                    threads.Last().Start();
                }
            }
            foreach (Thread t in threads) {
                t.Join();
            }
        }

        public void Start() {
            if (gameObjects == null) {
                gameObjects = new List<GameObject>();
                return;
            }
            List<Thread> threads = new List<Thread>();
            foreach (GameObject go in gameObjects) {
                if (go.Active) {
                    foreach (Behaviour b in go.behaviours) {
                        if (b.Active) {
                            Thread t = new Thread(new ThreadStart(() => {
                                try {
                                    b.Start();
                                } catch (Exception e) {
                                    Console.WriteLine(e.Message);
                                    Console.WriteLine(e.StackTrace);
                                }
                            }));
                            t.IsBackground = true;
                            threads.Add(t);
                            threads.Last().Start();
                        }
                    }
                }
            }
            foreach (Thread t in threads) {
                t.Join();
            }
        }

        public void Update() {
            if (gameObjects == null) {
                gameObjects = new List<GameObject>();
                return;
            }
            List<Thread> threads = new List<Thread>();
            foreach (GameObject go in gameObjects) {
                if (go.Active) {
                    foreach (Behaviour b in go.behaviours) {
                        if (b.Active) {
                            Thread t = new Thread(new ThreadStart(() => {
                                try {
                                    b.Update();
                                } catch (Exception e) {
                                    Console.WriteLine(e.Message);
                                    Console.WriteLine(e.StackTrace);
                                }
                            }));
                            t.IsBackground = true;
                            threads.Add(t);
                            threads.Last().Start();
                        }
                    }
                }
            }
            foreach (Thread t in threads) {
                t.Join();
            }
        }

        public void FixedUpdate() {
            if (gameObjects == null) {
                gameObjects = new List<GameObject>();
                return;
            }
            List<Thread> threads = new List<Thread>();
            foreach (GameObject go in gameObjects) {
                if (go.Active) {
                    foreach (Behaviour b in go.behaviours) {
                        if (b.Active) {
                            Thread t = new Thread(new ThreadStart(() => {
                                try {
                                    b.FixedUpdate();
                                } catch (Exception e) {
                                    Console.WriteLine(e.Message);
                                    Console.WriteLine(e.StackTrace);
                                }
                            }));
                            t.IsBackground = true;
                            threads.Add(t);
                            threads.Last().Start();
                        }
                    }
                }
            }
            foreach (Thread t in threads) {
                t.Join();
            }
        }

        public void LateUpdate() {
            if (gameObjects == null) {
                gameObjects = new List<GameObject>();
                return;
            }
            List<Thread> threads = new List<Thread>();
            foreach (GameObject go in gameObjects) {
                if (go.Active) {
                    foreach (Behaviour b in go.behaviours) {
                        if (b.Active) {
                            Thread t = new Thread(new ThreadStart(() => {
                                try {
                                    b.LateUpdate();
                                } catch (Exception e) {
                                    Console.WriteLine(e.Message);
                                    Console.WriteLine(e.StackTrace);
                                }
                            }));
                            t.IsBackground = true;
                            threads.Add(t);
                            threads.Last().Start();
                        }
                    }
                }
            }
            foreach (Thread t in threads) {
                t.Join();
            }
        }

        public void Render() {
            if (gameObjects == null) {
                gameObjects = new List<GameObject>();
                return;
            }
            foreach (Camera cam in cameras) {
                GL.ClearColor(cam.clearColor.r, cam.clearColor.g, cam.clearColor.b, 1f);
                foreach (Renderer r in renderers) {
                    r.ModelViewProjectionMatrix = r.ModelMatrix * cam.ProjectionMatrix;
                    GL.MatrixMode(MatrixMode.Modelview);
                    GL.LoadMatrix(ref r.ModelViewProjectionMatrix);
                    GL.MatrixMode(MatrixMode.Projection);
                    Matrix4 proj = cam.ProjectionMatrix;
                    GL.LoadMatrix(ref proj);
                    GL.Color4(r.tint.r, r.tint.g, r.tint.b, r.tint.a);
                    foreach (EnableCap ec in r.GetCaps()) {
                        GL.Enable(ec);
                    }
                    foreach (EnableCap ec in r.GetDisabledCaps()) {
                        GL.Disable(ec);
                    }
                    Vector3[] verts = r.GetVerts();
                    Vector2[] uvs = r.GetUVs();
                    GL.Begin(r.vertexType);
                    for (int i = 0; i < verts.Length; i++) {
                        try {
                            if (r.texture != null) {
                                GL.TexCoord2(uvs[i]);
                            }
                        } catch { } // Less UVs than verts
                        GL.Vertex3(verts[i]);
                    }
                    foreach (EnableCap ec in r.GetCaps()) {
                        GL.Disable(ec);
                    }
                    foreach (EnableCap ec in r.GetDisabledCaps()) {
                        GL.Enable(ec);
                    }
                }
            }
            //foreach (GameObject go in gameObjects) {
            //    if (go.Active) {
            //        foreach (Behaviour b in go.behaviours) {
            //            if (b.Active) {
            //                try {
            //                    b.OnPrerender();
            //                } catch (Exception e) {
            //                    Console.WriteLine(e.Message);
            //                    Console.WriteLine(e.StackTrace);
            //                }
            //            }
            //        }
            //    }
            //}
            //foreach (GameObject go in gameObjects) {
            //    if (go.Active) {
            //        foreach (Behaviour b in go.behaviours) {
            //            if (b.Active) {
            //                try {
            //                    b.OnRender();
            //                } catch (Exception e) {
            //                    Console.WriteLine(e.Message);
            //                    Console.WriteLine(e.StackTrace);
            //                }
            //            }
            //        }
            //    }
            //}
        }

    }

}
