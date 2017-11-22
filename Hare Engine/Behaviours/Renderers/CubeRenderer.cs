using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using OpenTK;

namespace HareEngine {

    public class CubeRenderer : Renderer {

        public Color color;

        public CubeRenderer(GameObject gameObject) : base(gameObject) {
            color = new Color(1f, 1f, 1f, 1f);
        }

        public override Matrix4 ModelMatrix {
            get {
                return Matrix4.CreateScale(transform.AbsoluteScale) * Matrix4.CreateFromQuaternion(transform.rotation) * Matrix4.CreateTranslation(transform.position);
            }
        }

        public override Vector4[] GetColors() {
            return new Vector4[] {
                color.Vector4,
                color.Vector4,
                color.Vector4,
                color.Vector4,
                color.Vector4,
                color.Vector4,
                color.Vector4,
                color.Vector4
            };
        }

        public override int[] GetIndices(int offset = 0) {
            int[] inds = new int[] {
                //left
                0, 2, 1,
                0, 3, 2,
                //back
                1, 2, 6,
                6, 5, 1,
                //right
                4, 5, 6,
                6, 7, 4,
                //top
                2, 3, 6,
                6, 3, 7,
                //front
                0, 7, 3,
                0, 4, 7,
                //bottom
                0, 1, 5,
                0, 5, 4
            };

            if (offset != 0) {
                for (int i = 0; i < inds.Length; i++) {
                    inds[i] += offset;
                }
            }
            IndiceCount = inds.Length;

            return inds;
        }

        public override Vector2[] GetUVs() {
            throw new NotImplementedException();
        }

        public override Vector3[] GetVerts() {
            Vector3[] v = new Vector3[] {
                new Vector3(-0.5f, -0.5f,  -0.5f),
                new Vector3(0.5f, -0.5f,  -0.5f),
                new Vector3(0.5f, 0.5f,  -0.5f),
                new Vector3(-0.5f, 0.5f,  -0.5f),
                new Vector3(-0.5f, -0.5f,  0.5f),
                new Vector3(0.5f, -0.5f,  0.5f),
                new Vector3(0.5f, 0.5f,  0.5f),
                new Vector3(-0.5f, 0.5f,  0.5f),
            };
            VertCount = v.Length;
            return v;
        }
    }

}
