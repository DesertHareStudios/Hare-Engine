﻿using OpenTK;

namespace HareEngine {

    public abstract class Renderer : Behaviour {
        public int VertCount { get; protected set; }
        public int IndiceCount { get; protected set; }
        public Matrix4 MVPMatrix;
        public Texture texture;

        public abstract Matrix4 ModelMatrix { get; }

        public Renderer(GameObject gameObject) : base(gameObject) { }

        public void SetMVPMatrix(Camera cam) {
            MVPMatrix = ModelMatrix * cam.ViewMatrix * cam.ProjectionMatrix;
        }

        public abstract Vector3[] GetVerts();
        public abstract int[] GetIndices(int offset = 0);
        public abstract Vector2[] GetUVs();

    }

}
