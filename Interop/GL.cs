using System.Runtime.InteropServices.JavaScript;

public static partial class GL
{
    [JSImport("gl.getContextAttributes", "main.js")]
    internal static partial JSObject GetContextAttributes();

    [JSImport("gl.isContextLost", "main.js")]
    internal static partial bool IsContextLost();

    [JSImport("gl.getSupportedExtensions", "main.js")]
    internal static partial JSObject GetSupportedExtensions();

    [JSImport("gl.getExtension", "main.js")]
    internal static partial JSObject GetExtension(string name);

    [JSImport("gl.drawingBufferStorage", "main.js")]
    internal static partial void DrawingBufferStorage(int sizedFormat, int width, int height);

    [JSImport("gl.activeTexture", "main.js")]
    internal static partial void ActiveTexture(int texture);

    [JSImport("gl.attachShader", "main.js")]
    internal static partial void AttachShader(JSObject program, JSObject shader);

    [JSImport("gl.bindAttribLocation", "main.js")]
    internal static partial void BindAttribLocation(JSObject program, int index, string name);

    [JSImport("gl.bindBuffer", "main.js")]
    internal static partial void BindBuffer(int target, JSObject buffer);

    [JSImport("gl.bindFramebuffer", "main.js")]
    internal static partial void BindFramebuffer(int target, JSObject framebuffer);

    [JSImport("gl.bindRenderbuffer", "main.js")]
    internal static partial void BindRenderbuffer(int target, JSObject renderbuffer);

    [JSImport("gl.bindTexture", "main.js")]
    internal static partial void BindTexture(int target, JSObject texture);

    [JSImport("gl.blendColor", "main.js")]
    internal static partial void BlendColor(float red, float green, float blue, float alpha);

    [JSImport("gl.blendEquation", "main.js")]
    internal static partial void BlendEquation(int mode);

    [JSImport("gl.blendEquationSeparate", "main.js")]
    internal static partial void BlendEquationSeparate(int modeRGB, int modeAlpha);

    [JSImport("gl.blendFunc", "main.js")]
    internal static partial void BlendFunc(int sFactor, int dFactor);

    [JSImport("gl.blendFuncSeparate", "main.js")]
    internal static partial void BlendFuncSeparate(int srcRGB, int dstRGB, int srcAlpha, int dstAlpha);

    [JSImport("gl.checkFramebufferStatus", "main.js")]
    internal static partial int CheckFramebufferStatus(int target);

    [JSImport("gl.clear", "main.js")]
    internal static partial void Clear(int mask);

    [JSImport("gl.clearColor", "main.js")]
    internal static partial void ClearColor(float red, float green, float blue, float alpha);

    [JSImport("gl.clearDepth", "main.js")]
    internal static partial void ClearDepth(float depth);

    [JSImport("gl.clearStencil", "main.js")]
    internal static partial void ClearStencil(int s);

    [JSImport("gl.colorMask", "main.js")]
    internal static partial void ColorMask(bool red, bool green, bool blue, bool alpha);

    [JSImport("gl.compileShader", "main.js")]
    internal static partial void CompileShader(JSObject shader);

    [JSImport("gl.copyTexImage2D", "main.js")]
    internal static partial void CopyTexImage2D(int target, int level, int internalFormat, int x, int y, int width, int height, int border);

    [JSImport("gl.copyTexSubImage2D", "main.js")]
    internal static partial void CopyTexSubImage2D(int target, int level, int xOffset, int yOffset, int x, int y, int width, int height);

    [JSImport("gl.createBuffer", "main.js")]
    internal static partial JSObject CreateBuffer();

    [JSImport("gl.createFramebuffer", "main.js")]
    internal static partial JSObject CreateFramebuffer();

    [JSImport("gl.createProgram", "main.js")]
    internal static partial JSObject CreateProgram();

    [JSImport("gl.createRenderbuffer", "main.js")]
    internal static partial JSObject CreateRenderbuffer();

    [JSImport("gl.createShader", "main.js")]
    internal static partial JSObject CreateShader(int type);

    [JSImport("gl.createTexture", "main.js")]
    internal static partial JSObject CreateTexture();

    [JSImport("gl.cullFace", "main.js")]
    internal static partial void CullFace(int mode);

    [JSImport("gl.deleteBuffer", "main.js")]
    internal static partial void DeleteBuffer(JSObject buffer);

    [JSImport("gl.deleteFramebuffer", "main.js")]
    internal static partial void DeleteFramebuffer(JSObject framebuffer);

    [JSImport("gl.deleteProgram", "main.js")]
    internal static partial void DeleteProgram(JSObject program);

    [JSImport("gl.deleteRenderbuffer", "main.js")]
    internal static partial void DeleteRenderbuffer(JSObject renderbuffer);

    [JSImport("gl.deleteShader", "main.js")]
    internal static partial void DeleteShader(JSObject shader);

    [JSImport("gl.deleteTexture", "main.js")]
    internal static partial void DeleteTexture(JSObject texture);

    [JSImport("gl.depthFunc", "main.js")]
    internal static partial void DepthFunc(int func);

    [JSImport("gl.depthMask", "main.js")]
    internal static partial void DepthMask(bool flag);

    [JSImport("gl.depthRange", "main.js")]
    internal static partial void DepthRange(float zNear, float zFar);

    [JSImport("gl.detachShader", "main.js")]
    internal static partial void DetachShader(JSObject program, JSObject shader);

    [JSImport("gl.disable", "main.js")]
    internal static partial void Disable(int cap);

    [JSImport("gl.disableVertexAttribArray", "main.js")]
    internal static partial void DisableVertexAttribArray(int index);

    [JSImport("gl.drawArrays", "main.js")]
    internal static partial void DrawArrays(int mode, int first, int count);

    [JSImport("gl.drawElements", "main.js")]
    internal static partial void DrawElements(int mode, int count, int type, int offset);

    [JSImport("gl.enable", "main.js")]
    internal static partial void Enable(int cap);

    [JSImport("gl.enableVertexAttribArray", "main.js")]
    internal static partial void EnableVertexAttribArray(int index);

    [JSImport("gl.finish", "main.js")]
    internal static partial void Finish();

    [JSImport("gl.flush", "main.js")]
    internal static partial void Flush();

    [JSImport("gl.framebufferRenderbuffer", "main.js")]
    internal static partial void FramebufferRenderbuffer(int target, int attachment, int renderBufferTarget, JSObject renderbuffer);

    [JSImport("gl.framebufferTexture2D", "main.js")]
    internal static partial void FramebufferTexture2D(int target, int attachment, int texTarget, JSObject texture, int level);

    [JSImport("gl.frontFace", "main.js")]
    internal static partial void FrontFace(int mode);

    [JSImport("gl.generateMipmap", "main.js")]
    internal static partial void GenerateMipmap(int target);

    [JSImport("gl.getActiveAttrib", "main.js")]
    internal static partial JSObject GetActiveAttrib(JSObject program, int index);

    [JSImport("gl.getActiveUniform", "main.js")]
    internal static partial JSObject GetActiveUniform(JSObject program, int index);

    [JSImport("gl.getAttachedShaders", "main.js")]
    internal static partial JSObject GetAttachedShaders(JSObject program);

    [JSImport("gl.getAttribLocation", "main.js")]
    internal static partial int GetAttribLocation(JSObject program, string name);

    [JSImport("gl.getBufferParameter", "main.js")]
    internal static partial JSObject GetBufferParameter(int target, int pName);

    [JSImport("gl.getParameter", "main.js")]
    internal static partial bool GetParameterBool(int pName);

    [JSImport("gl.getParameter", "main.js")]
    internal static partial string GetParameterString(int pName);

    [JSImport("gl.getError", "main.js")]
    internal static partial int GetError();

    [JSImport("gl.getFramebufferAttachmentParameter", "main.js")]
    internal static partial JSObject GetFramebufferAttachmentParameter(int target, int attachment, int pName);

    [JSImport("gl.getProgramParameter", "main.js")]
    internal static partial bool GetProgramParameterBool(JSObject program, int pName);

    [JSImport("gl.getProgramInfoLog", "main.js")]
    internal static partial string GetProgramInfoLog(JSObject program);

    [JSImport("gl.getRenderbufferParameter", "main.js")]
    internal static partial JSObject GetRenderbufferParameter(int target, int pName);

    [JSImport("gl.getShaderParameter", "main.js")]
    internal static partial bool GetShaderParameterBool(JSObject shader, int pName);

    [JSImport("gl.getShaderPrecisionFormat", "main.js")]
    internal static partial JSObject GetShaderPrecisionFormat(int shaderType, int precisionType);

    [JSImport("gl.getShaderInfoLog", "main.js")]
    internal static partial string GetShaderInfoLog(JSObject shader);

    [JSImport("gl.getShaderSource", "main.js")]
    internal static partial string GetShaderSource(JSObject shader);

    [JSImport("gl.getTexParameter", "main.js")]
    internal static partial JSObject GetTexParameter(int target, int pName);

    [JSImport("gl.getUniform", "main.js")]
    internal static partial JSObject GetUniform(JSObject program, JSObject location);

    [JSImport("gl.getUniformLocation", "main.js")]
    internal static partial JSObject GetUniformLocation(JSObject program, string name);

    [JSImport("gl.getVertexAttrib", "main.js")]
    internal static partial JSObject GetVertexAttrib(int index, int pName);

    [JSImport("gl.getVertexAttribOffset", "main.js")]
    internal static partial int GetVertexAttribOffset(int index, int pName);

    [JSImport("gl.hint", "main.js")]
    internal static partial void Hint(int target, int mode);

    [JSImport("gl.isBuffer", "main.js")]
    internal static partial bool IsBuffer(JSObject buffer);

    [JSImport("gl.isEnabled", "main.js")]
    internal static partial bool IsEnabled(int cap);

    [JSImport("gl.isFramebuffer", "main.js")]
    internal static partial bool IsFramebuffer(JSObject framebuffer);

    [JSImport("gl.isProgram", "main.js")]
    internal static partial bool IsProgram(JSObject program);

    [JSImport("gl.isRenderbuffer", "main.js")]
    internal static partial bool IsRenderbuffer(JSObject renderbuffer);

    [JSImport("gl.isShader", "main.js")]
    internal static partial bool IsShader(JSObject shader);

    [JSImport("gl.isTexture", "main.js")]
    internal static partial bool IsTexture(JSObject texture);

    [JSImport("gl.lineWidth", "main.js")]
    internal static partial void LineWidth(float width);

    [JSImport("gl.linkProgram", "main.js")]
    internal static partial void LinkProgram(JSObject program);

    [JSImport("gl.pixelStorei", "main.js")]
    internal static partial void PixelStorei(int pName, int param);

    [JSImport("gl.polygonOffset", "main.js")]
    internal static partial void PolygonOffset(float factor, float units);

    [JSImport("gl.renderbufferStorage", "main.js")]
    internal static partial void RenderbufferStorage(int target, int internalFormat, int width, int height);

    [JSImport("gl.sampleCoverage", "main.js")]
    internal static partial void SampleCoverage(float value, bool invert);

    [JSImport("gl.scissor", "main.js")]
    internal static partial void Scissor(int x, int y, int width, int height);

    [JSImport("gl.shaderSource", "main.js")]
    internal static partial void ShaderSource(JSObject shader, string source);

    [JSImport("gl.stencilFunc", "main.js")]
    internal static partial void StencilFunc(int func, int refVal, int mask);

    [JSImport("gl.stencilFuncSeparate", "main.js")]
    internal static partial void StencilFuncSeparate(int face, int func, int refVal, int mask);

    [JSImport("gl.stencilMask", "main.js")]
    internal static partial void StencilMask(int mask);

    [JSImport("gl.stencilMaskSeparate", "main.js")]
    internal static partial void StencilMaskSeparate(int face, int mask);

    [JSImport("gl.stencilOp", "main.js")]
    internal static partial void StencilOp(int fail, int zFail, int zPass);

    [JSImport("gl.stencilOpSeparate", "main.js")]
    internal static partial void StencilOpSeparate(int face, int fail, int zFail, int zPass);

    [JSImport("gl.texParameterf", "main.js")]
    internal static partial void TexParameterf(int target, int pName, float param);

    [JSImport("gl.texParameteri", "main.js")]
    internal static partial void TexParameteri(int target, int pName, int param);

    [JSImport("gl.uniform1f", "main.js")]
    internal static partial void Uniform1f(JSObject location, float x);

    [JSImport("gl.uniform2f", "main.js")]
    internal static partial void Uniform2f(JSObject location, float x, float y);

    [JSImport("gl.uniform3f", "main.js")]
    internal static partial void Uniform3f(JSObject location, float x, float y, float z);

    [JSImport("gl.uniform4f", "main.js")]
    internal static partial void Uniform4f(JSObject location, float x, float y, float z, float w);

    [JSImport("gl.uniform1i", "main.js")]
    internal static partial void Uniform1i(JSObject location, int x);

    [JSImport("gl.uniform2i", "main.js")]
    internal static partial void Uniform2i(JSObject location, int x, int y);

    [JSImport("gl.uniform3i", "main.js")]
    internal static partial void Uniform3i(JSObject location, int x, int y, int z);

    [JSImport("gl.uniform4i", "main.js")]
    internal static partial void Uniform4i(JSObject location, int x, int y, int z, int w);

    [JSImport("gl.useProgram", "main.js")]
    internal static partial void UseProgram(JSObject program);

    [JSImport("gl.validateProgram", "main.js")]
    internal static partial void ValidateProgram(JSObject program);

    [JSImport("gl.vertexAttrib1f", "main.js")]
    internal static partial void VertexAttrib1f(int index, float x);

    [JSImport("gl.vertexAttrib2f", "main.js")]
    internal static partial void VertexAttrib2f(int index, float x, float y);

    [JSImport("gl.vertexAttrib3f", "main.js")]
    internal static partial void VertexAttrib3f(int index, float x, float y, float z);

    [JSImport("gl.vertexAttrib4f", "main.js")]
    internal static partial void VertexAttrib4f(int index, float x, float y, float z, float w);

    [JSImport("gl.vertexAttrib1fv", "main.js")]
    internal static partial void VertexAttrib1fv(int index, JSObject values);

    [JSImport("gl.vertexAttrib2fv", "main.js")]
    internal static partial void VertexAttrib2fv(int index, JSObject values);

    [JSImport("gl.vertexAttrib3fv", "main.js")]
    internal static partial void VertexAttrib3fv(int index, JSObject values);

    [JSImport("gl.vertexAttrib4fv", "main.js")]
    internal static partial void VertexAttrib4fv(int index, JSObject values);

    [JSImport("gl.vertexAttribPointer", "main.js")]
    internal static partial void VertexAttribPointer(int index, int size, int type, bool normalized, int stride, int offset);

    [JSImport("gl.viewport", "main.js")]
    internal static partial void Viewport(int x, int y, int width, int height);

    [JSImport("gl.bufferData", "main.js")]
    internal static partial void BufferData(int target, int size, int usage);

    [JSImport("gl.bufferData", "main.js")]
    internal static partial void BufferData(int target, JSObject data, int usage);

    [JSImport("gl.bufferSubData", "main.js")]
    internal static partial void BufferSubData(int target, int offset, JSObject data);

    [JSImport("gl.compressedTexImage2D", "main.js")]
    internal static partial void CompressedTexImage2D(int target, int level, int internalFormat, int width, int height, int border, JSObject data);

    [JSImport("gl.compressedTexSubImage2D", "main.js")]
    internal static partial void CompressedTexSubImage2D(int target, int level, int xOffset, int yOffset, int width, int height, int format, JSObject data);

    [JSImport("gl.readPixels", "main.js")]
    internal static partial void ReadPixels(int x, int y, int width, int height, int format, int type, JSObject pixels);

    [JSImport("gl.texImage2D", "main.js")]
    internal static partial void TexImage2D(int target, int level, int internalFormat, int width, int height, int border, int format, int type, JSObject pixels);

    [JSImport("gl.texImage2D", "main.js")]
    internal static partial void TexImage2D(int target, int level, int internalFormat, int format, int type, JSObject source);

    [JSImport("gl.texSubImage2D", "main.js")]
    internal static partial void TexSubImage2D(int target, int level, int xOffset, int yOffset, int width, int height, int format, int type, byte[] pixels);

    [JSImport("gl.texSubImage2D", "main.js")]
    internal static partial void TexSubImage2D(int target, int level, int xOffset, int yOffset, int format, int type, JSObject source);

    [JSImport("gl.uniform1fv", "main.js")]
    internal static partial void Uniform1fv(JSObject location, JSObject v);

    [JSImport("gl.uniform2fv", "main.js")]
    internal static partial void Uniform2fv(JSObject location, JSObject v);

    [JSImport("gl.uniform3fv", "main.js")]
    internal static partial void Uniform3fv(JSObject location, JSObject v);

    [JSImport("gl.uniform4fv", "main.js")]
    internal static partial void Uniform4fv(JSObject location, JSObject v);

    [JSImport("gl.uniform1iv", "main.js")]
    internal static partial void Uniform1iv(JSObject location, JSObject v);

    [JSImport("gl.uniform2iv", "main.js")]
    internal static partial void Uniform2iv(JSObject location, JSObject v);

    [JSImport("gl.uniform3iv", "main.js")]
    internal static partial void Uniform3iv(JSObject location, JSObject v);

    [JSImport("gl.uniform4iv", "main.js")]
    internal static partial void Uniform4iv(JSObject location, JSObject v);

    [JSImport("gl.uniformMatrix2fv", "main.js")]
    internal static partial void UniformMatrix2fv(JSObject location, bool transpose, JSObject value);

    [JSImport("gl.uniformMatrix3fv", "main.js")]
    internal static partial void UniformMatrix3fv(JSObject location, bool transpose, JSObject value);

    [JSImport("gl.uniformMatrix4fv", "main.js")]
    internal static partial void UniformMatrix4fv(JSObject location, bool transpose, JSObject value);
}
