using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading;

namespace HareEngine {

    public class Scene {
        public string Name = "";
        public List<GameObject> gameObjects;

        public Scene(string name) {
            this.Name = name;
            gameObjects = new List<GameObject>();
        }

        public Scene() {
            this.Name = "New Scene";
            gameObjects = new List<GameObject>();
        }

        public void Awake() {
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
