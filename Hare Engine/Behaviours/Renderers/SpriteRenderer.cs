using System;
using OpenTK;
using OpenTK.Graphics.OpenGL;

namespace HareEngine {

    public class SpriteRenderer : Renderer {

        public string TextureName {
            get {
                return texture.Name;
            }
            set {
                Texture tex = (Texture)Asset.Get(value);
                if (tex != null) {
                    texture = tex;
                }
            }
        }

        public override Matrix4 ModelMatrix {
            get {
                return Matrix4.CreateScale(transform.AbsoluteScale) * Matrix4.CreateFromQuaternion(transform.rotation) * Matrix4.CreateTranslation(transform.position);
            }
        }

        public SpriteRenderer(GameObject gameObject) : base(gameObject) {
            vertexType = PrimitiveType.Quads;
            texture = new Texture("", "");
            tint = new Color(1f, 1f, 1f);
        }

        public override Vector2[] GetUVs() {
            return new Vector2[] {
                new Vector2(1, -1),
                new Vector2(1, 1),
                new Vector2(-1, 1),
                new Vector2(-1, -1)
            };
        }

        public override Vector3[] GetVerts() {
            return new Vector3[] {
                new Vector3(0.5f, -0.5f, 0f),
                new Vector3(0.5f, 0.5f, 0f),
                new Vector3(-0.5f, 0.5f, 0f),
                new Vector3(-0.5f, -0.5f, 0f)
            };
        }

        public override EnableCap[] GetCaps() {
            return new EnableCap[] {
                EnableCap.Texture2D
            };
        }

        public override EnableCap[] GetDisabledCaps() {
            return new EnableCap[] {
                EnableCap.Lighting
            };
        }
    }

}