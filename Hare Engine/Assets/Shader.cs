using System;
using OpenTK.Graphics.OpenGL;
using System.IO;

namespace HareEngine {

    public class Shader {

        public static int defaultProgramID;
        public static int defaultVertexShaderID;
        public static int defaultFragmentShaderID;
        public static int attribute_vpos;
        public static int attribute_vcol;
        public static int uniform_mview;

        public static void LoadDefaultShaders() {
            defaultProgramID = GL.CreateProgram();
            defaultVertexShaderID = LoadFromString(
                @"#version 330
                in vec3 vPosition;
                in  vec4 vColor;
                out vec4 color;
                uniform mat4 modelview;

                void main() {
                    gl_Position = modelview * vec4(vPosition, 1.0);
                    color = vec4(vColor, 1.0);
                }", ShaderType.VertexShader, defaultProgramID);
            defaultFragmentShaderID = LoadFromString(
                @"#version 330

                in vec4 color;
                out vec4 outputColor;

                void main() {
                    outputColor = color;
                }
                ", ShaderType.FragmentShader, defaultProgramID);
            GL.LinkProgram(defaultProgramID);
            Debug.Log(GL.GetProgramInfoLog(defaultProgramID));
            attribute_vpos = GL.GetAttribLocation(defaultProgramID, "vPosition");
            attribute_vcol = GL.GetAttribLocation(defaultProgramID, "vColor");
            uniform_mview = GL.GetUniformLocation(defaultProgramID, "modelview");

            GL.GenBuffers(1, out Hare.vbo_position);
            GL.GenBuffers(1, out Hare.vbo_color);
            GL.GenBuffers(1, out Hare.vbo_mview);
            GL.GenBuffers(1, out Hare.ibo_elements);
        }

        public static int LoadFromString(string code, ShaderType type, int program) {
            int address = GL.CreateShader(type);
            GL.ShaderSource(address, code);
            GL.CompileShader(address);
            GL.AttachShader(program, address);
            Debug.Log(GL.GetShaderInfoLog(address));
            return address;
        }

        public static int LoadFromFile(string filename, ShaderType type, int program) {
            int address = GL.CreateShader(type);
            using (StreamReader sr = new StreamReader(filename)) {
                GL.ShaderSource(address, sr.ReadToEnd());
            }
            GL.CompileShader(address);
            GL.AttachShader(program, address);
            Debug.Log(GL.GetShaderInfoLog(address));
            return address;
        }
    }

}
