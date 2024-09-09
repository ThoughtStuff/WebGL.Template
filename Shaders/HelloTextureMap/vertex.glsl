#version 100

attribute vec2 a_VertexPosition;
attribute vec2 a_TextureCoord;

varying mediump vec2 v_TextureCoord;

void main(void)
{
    gl_Position = vec4(a_VertexPosition, 0.0, 1.0);
    v_TextureCoord = a_TextureCoord;
}
