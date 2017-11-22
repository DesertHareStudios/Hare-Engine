using OpenTK.Graphics.OpenGL;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HareEngine {

    public class ShaderProgram {

        public int ID { get; protected set; }
        public Shader VertexShader { get; protected set; }
        public Shader FragmentShader { get; protected set; }
        public int AttributeCount { get; protected set; }
        public int UniformCount { get; protected set; }
        public Dictionary<String, AttributeInfo> Attributes = new Dictionary<string, AttributeInfo>();
        public Dictionary<String, UniformInfo> Uniforms = new Dictionary<string, UniformInfo>();
        public Dictionary<String, uint> Buffers = new Dictionary<string, uint>();

        public ShaderProgram() {
            ID = GL.CreateProgram();
        }

        public ShaderProgram(Shader vertex, Shader fragment) {
            ID = GL.CreateProgram();
            AddShader(vertex);
            AddShader(fragment);
            Link();
            GenBuffers();
        }

        public bool AddShader(Shader shader) {
            switch (shader.Type) {
                case ShaderType.VertexShader:
                    VertexShader = shader;
                    return true;
                case ShaderType.FragmentShader:
                    FragmentShader = shader;
                    return true;
            }
            return false;
        }
        public void Link() {
            GL.LinkProgram(ID);

            Console.WriteLine(GL.GetProgramInfoLog(ID));
            int ac, uc;
            GL.GetProgram(ID, ProgramParameter.ActiveAttributes, out ac);
            GL.GetProgram(ID, ProgramParameter.ActiveUniforms, out uc);
            AttributeCount = ac;
            UniformCount = uc;

            for (int i = 0; i < AttributeCount; i++) {
                AttributeInfo info = new AttributeInfo();
                int length = 0;
                StringBuilder name = new StringBuilder();
                GL.GetActiveAttrib(ID, i, 256, out length, out info.size, out info.type, name);
                info.name = name.ToString();
                info.address = GL.GetAttribLocation(ID, info.name);
                Attributes.Add(name.ToString(), info);
            }

            for (int i = 0; i < UniformCount; i++) {
                UniformInfo info = new UniformInfo();
                int length = 0;
                StringBuilder name = new StringBuilder();
                GL.GetActiveUniform(ID, i, 256, out length, out info.size, out info.type, name);
                info.name = name.ToString();
                Uniforms.Add(name.ToString(), info);
                info.address = GL.GetUniformLocation(ID, info.name);
            }
        }

        public void GenBuffers() {
            for (int i = 0; i < Attributes.Count; i++) {
                uint buffer = 0;
                GL.GenBuffers(1, out buffer);

                Buffers.Add(Attributes.Values.ElementAt(i).name, buffer);
            }

            for (int i = 0; i < Uniforms.Count; i++) {
                uint buffer = 0;
                GL.GenBuffers(1, out buffer);

                Buffers.Add(Uniforms.Values.ElementAt(i).name, buffer);
            }
        }

        public void EnableVertexAttribArrays() {
            for (int i = 0; i < Attributes.Count; i++) {
                GL.EnableVertexAttribArray(Attributes.Values.ElementAt(i).address);
            }
        }

        public void DisableVertexAttribArrays() {
            for (int i = 0; i < Attributes.Count; i++) {
                GL.DisableVertexAttribArray(Attributes.Values.ElementAt(i).address);
            }
        }

        public int GetAttribute(string name) {
            if (Attributes.ContainsKey(name)) {
                return Attributes[name].address;
            } else {
                return -1;
            }
        }

        public int GetUniform(string name) {
            if (Uniforms.ContainsKey(name)) {
                return Uniforms[name].address;
            } else {
                return -1;
            }
        }

        public uint GetBuffer(string name) {
            if (Buffers.ContainsKey(name)) {
                return Buffers[name];
            } else {
                return 0;
            }
        }

    }

    public class AttributeInfo {
        public String name = "";
        public int address = -1;
        public int size = 0;
        public ActiveAttribType type;
    }

    public class UniformInfo {
        public String name = "";
        public int address = -1;
        public int size = 0;
        public ActiveUniformType type;
    }

}
