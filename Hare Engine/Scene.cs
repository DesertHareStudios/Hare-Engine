using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading;

namespace HareEngine {

    public class Scene {
        public string Name = "";
        public List<GameObject> gameObjects = new List<GameObject>();
        public Action Preload;

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
            foreach (GameObject go in gameObjects) {
                if (go.Active) {
                    foreach (Behaviour b in go.behaviours) {
                        if (b.Active) {
                            try {
                                b.OnPrerender();
                            } catch (Exception e) {
                                Console.WriteLine(e.Message);
                                Console.WriteLine(e.StackTrace);
                            }
                        }
                    }
                }
            }
            foreach (GameObject go in gameObjects) {
                if (go.Active) {
                    foreach (Behaviour b in go.behaviours) {
                        if (b.Active) {
                            try {
                                b.OnRender();
                            } catch (Exception e) {
                                Console.WriteLine(e.Message);
                                Console.WriteLine(e.StackTrace);
                            }
                        }
                    }
                }
            }
        }

    }

}
