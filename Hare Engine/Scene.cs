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
        Vector3[] vertdata;
        Vector4[] coldata;
        int[] indicedata;

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
                            Debug.Error(e.Message);
                            Debug.Error(e.StackTrace);
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
                                    Debug.Error(e.Message);
                                    Debug.Error(e.StackTrace);
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
                                    Debug.Error(e.Message);
                                    Debug.Error(e.StackTrace);
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
                                    Debug.Error(e.Message);
                                    Debug.Error(e.StackTrace);
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
                                    Debug.Error(e.Message);
                                    Debug.Error(e.StackTrace);
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

            List<Vector3> verts = new List<Vector3>();
            List<int> inds = new List<int>();
            List<Vector4> colors = new List<Vector4>();

            int vertcount = 0;
            foreach (Renderer v in Renderer.All) {
                verts.AddRange(v.GetVerts().ToList());
                inds.AddRange(v.GetIndices(vertcount).ToList());
                colors.AddRange(v.GetColors().ToList());
                vertcount += v.VertCount;
            }

            vertdata = verts.ToArray();
            indicedata = inds.ToArray();
            coldata = colors.ToArray();

            GL.BindBuffer(BufferTarget.ArrayBuffer, Hare.vbo_position);
            GL.BufferData<Vector3>(BufferTarget.ArrayBuffer, (IntPtr)(vertdata.Length * Vector3.SizeInBytes), vertdata, BufferUsageHint.StaticDraw);
            GL.VertexAttribPointer(Shader.attribute_vpos, 3, VertexAttribPointerType.Float, false, 0, 0);

            GL.BindBuffer(BufferTarget.ArrayBuffer, Hare.vbo_color);
            GL.BufferData<Vector4>(BufferTarget.ArrayBuffer, (IntPtr)(coldata.Length * Vector4.SizeInBytes), coldata, BufferUsageHint.StaticDraw);
            GL.VertexAttribPointer(Shader.attribute_vcol, 3, VertexAttribPointerType.Float, true, 0, 0);

            GL.UseProgram(Shader.defaultProgramID);

            GL.BindBuffer(BufferTarget.ArrayBuffer, 0);

            GL.BindBuffer(BufferTarget.ElementArrayBuffer, Hare.ibo_elements);
            GL.BufferData(BufferTarget.ElementArrayBuffer, (IntPtr)(indicedata.Length * sizeof(int)), indicedata, BufferUsageHint.StaticDraw);


            GL.EnableVertexAttribArray(Shader.attribute_vpos);
            GL.EnableVertexAttribArray(Shader.attribute_vcol);
            int indiceat = 0;
            foreach (Camera cam in Camera.All) {
                Hare.clearColor = cam.clearColor;
                foreach (Renderer r in Renderer.All) {
                    r.MVPMatrix = r.ModelMatrix * cam.ViewMatrix * cam.ProjectionMatrix;
                    GL.UniformMatrix4(Shader.uniform_mview, false, ref r.MVPMatrix);
                    GL.DrawElements(BeginMode.Triangles, r.IndiceCount, DrawElementsType.UnsignedInt, indiceat * sizeof(uint));
                    indiceat += r.IndiceCount;
                }
            }
            GL.DisableVertexAttribArray(Shader.attribute_vpos);
            GL.DisableVertexAttribArray(Shader.attribute_vcol);
            GL.Flush();
        }

    }

}
