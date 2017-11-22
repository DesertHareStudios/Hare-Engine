using OpenTK;

namespace HareEngine {

    public class CubeRenderer : Renderer {

        public override Matrix4 ModelMatrix {
            get {
                return Matrix4.CreateScale(transform.AbsoluteScale) * Matrix4.CreateFromQuaternion(transform.rotation) * Matrix4.CreateTranslation(transform.position);
            }
        }

        public CubeRenderer(GameObject gameObject) : base(gameObject) { }

        public override int[] GetIndices(int offset = 0) {
            int[] inds = new int[] {
                //left
                0,1,2,0,3,1,
 
                //back
                4,5,6,4,6,7,
 
                //right
                8,9,10,8,10,11,
 
                //top
                13,14,12,13,15,14,
 
                //front
                16,17,18,16,19,17,
 
                //bottom
                20,21,22,20,22,23
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
            //Vector2[] uvs = new Vector2[] {
            //    new Vector2(0, 1),
            //    new Vector2(1, 0),
            //    new Vector2(1, 0),
            //    new Vector2(0, 0),
            //    new Vector2(0, 1),
            //    new Vector2(1, 0),
            //    new Vector2(1, 0),
            //    new Vector2(0, 0)
            //};
            //int[] ind = GetIndices();
            //Vector2[] output = new Vector2[ind.Length];
            //for (int i = 0; i < ind.Length; i++) {
            //    output[i] = uvs[ind[i]];
            //}
            //return output;
            return new Vector2[] {
                // left
                new Vector2(0.0f, 1.0f),
                new Vector2(-1.0f, 0.0f),
                new Vector2(-1.0f, 1.0f),
                new Vector2(0.0f, 0.0f),
 
                // back
                new Vector2(0.0f, 1.0f),
                new Vector2(0.0f, 0.0f),
                new Vector2(-1.0f, 0.0f),
                new Vector2(-1.0f, 1.0f),
 
                // right
                new Vector2(-1.0f, 1.0f),
                new Vector2(0.0f, 1.0f),
                new Vector2(0.0f, 0.0f),
                new Vector2(-1.0f, 0.0f),
 
                // top
                new Vector2(0.0f, 1.0f),
                new Vector2(0.0f, 0.0f),
                new Vector2(-1.0f, 1.0f),
                new Vector2(-1.0f, 0.0f),
 
                // front
                new Vector2(0.0f, 1.0f),
                new Vector2(1.0f, 0.0f),
                new Vector2(0.0f, 0.0f),
                new Vector2(1.0f, 1.0f),
 
                // bottom
                new Vector2(0.0f, 1.0f),
                new Vector2(0.0f, 0.0f),
                new Vector2(-1.0f, 0.0f),
                new Vector2(-1.0f, 1.0f)
            };
        }

        public override Vector3[] GetVerts() {
            Vector3[] v = new Vector3[] {
                //left
                new Vector3(-0.5f, -0.5f,  -0.5f),
                new Vector3(0.5f, 0.5f,  -0.5f),
                new Vector3(0.5f, -0.5f,  -0.5f),
                new Vector3(-0.5f, 0.5f,  -0.5f),
 
                //back
                new Vector3(0.5f, -0.5f,  -0.5f),
                new Vector3(0.5f, 0.5f,  -0.5f),
                new Vector3(0.5f, 0.5f,  0.5f),
                new Vector3(0.5f, -0.5f,  0.5f),
 
                //right
                new Vector3(-0.5f, -0.5f,  0.5f),
                new Vector3(0.5f, -0.5f,  0.5f),
                new Vector3(0.5f, 0.5f,  0.5f),
                new Vector3(-0.5f, 0.5f,  0.5f),
 
                //top
                new Vector3(0.5f, 0.5f,  -0.5f),
                new Vector3(-0.5f, 0.5f,  -0.5f),
                new Vector3(0.5f, 0.5f,  0.5f),
                new Vector3(-0.5f, 0.5f,  0.5f),
 
                //front
                new Vector3(-0.5f, -0.5f,  -0.5f),
                new Vector3(-0.5f, 0.5f,  0.5f),
                new Vector3(-0.5f, 0.5f,  -0.5f),
                new Vector3(-0.5f, -0.5f,  0.5f),
 
                //bottom
                new Vector3(-0.5f, -0.5f,  -0.5f),
                new Vector3(0.5f, -0.5f,  -0.5f),
                new Vector3(0.5f, -0.5f,  0.5f),
                new Vector3(-0.5f, -0.5f,  0.5f)
            };
            VertCount = v.Length;
            return v;
        }
    }

}
