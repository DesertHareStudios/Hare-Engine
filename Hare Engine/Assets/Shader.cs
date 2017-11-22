using OpenTK.Graphics.OpenGL;
using System.IO;

namespace HareEngine {

    public class Shader : Asset {

        public ShaderType Type { get; protected set; }

        public int ID { get; protected set; }

        public Shader(string filepath, string name, ShaderType type) : base(filepath, name) {
            Type = type;
            ID = LoadFromFile(filepath, type);
        }

        public void Attach(int programID) {
            GL.AttachShader(programID, ID);
        }

        public static Shader DefaultVertexShader {
            get {
                Shader shad = Shader.Get<Shader>("defaultVertexShader");
                if (shad == null) {
                    Shader defaultVertexShader = new Shader("", "defaultVertexShader", ShaderType.VertexShader);
                    defaultVertexShader.ID = LoadFromString(
                    @"#version 330
                    in vec3 position;
                    in  vec4 tint;
                    out vec4 color;
                    uniform mat4 modelview;

                    void main() {
                        gl_Position = modelview * vec4(position, 1.0);
                        color = tint;
                    }", ShaderType.VertexShader);
                    return defaultVertexShader;
                }
                return shad;
            }
        }

        public static Shader DefaultFragmentShader {
            get {
                Shader shad = Shader.Get<Shader>("defaultVertexShader");
                if (shad == null) {
                    Shader defaultVertexShader = new Shader("", "defaultVertexShader", ShaderType.VertexShader);
                    defaultVertexShader.ID = LoadFromString(
                    @"#version 330

                    in vec4 tint;
                    out vec4 color;

                    void main() {
                        color = tint;
                    }", ShaderType.VertexShader);
                    return defaultVertexShader;
                }
                return shad;
            }
        }

        private static int LoadFromString(string code, ShaderType type) {
            int address = GL.CreateShader(type);
            GL.ShaderSource(address, code);
            GL.CompileShader(address);
            Debug.Log(GL.GetShaderInfoLog(address));
            return address;
        }

        private static int LoadFromFile(string filename, ShaderType type) {
            if (filename != "") {
                int address = GL.CreateShader(type);
                using (StreamReader sr = new StreamReader(filename)) {
                    GL.ShaderSource(address, sr.ReadToEnd());
                }
                GL.CompileShader(address);
                Debug.Log(GL.GetShaderInfoLog(address));
                return address;
            }
            return -1;
        }
    }

}
