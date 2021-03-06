﻿using OpenTK;

namespace HareEngine {

    public class SpriteRenderer : Renderer {

        public SpriteRenderer(GameObject gameObject) : base(gameObject) {}

        public override Vector2[] GetUVs() {
            Vector2[] output = new Vector2[] {
                new Vector2(1, 1),
                new Vector2(1, 0),
                new Vector2(0, 0),
                new Vector2(0, 1)
            };
            return output;
        }

        public override Vector3[] GetVerts() {
            Vector3[] output = new Vector3[] {
                new Vector3(0.5f, -0.5f, 0f),
                new Vector3(0.5f, 0.5f, 0f),
                new Vector3(-0.5f, 0.5f, 0f),
                new Vector3(-0.5f, -0.5f, 0f)
            };
            VertCount = output.Length;
            return output;
        }

        public override int[] GetIndices(int offset = 0) {
            int[] inds = new int[] {
                0, 2, 1,
                0, 3, 2
            };
            IndiceCount = inds.Length;
            if (offset != 0) {
                for (int i = 0; i < inds.Length; i++) {
                    inds[i] += offset;
                }
            }
            return inds;
        }
    }

}