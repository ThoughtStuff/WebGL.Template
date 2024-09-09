#version 100

attribute vec4 a_VertexPosition;
attribute vec4 a_VertexColor;

varying mediump vec4 v_Color;

void main(void) {
    gl_Position = a_VertexPosition;
    v_Color = a_VertexColor;
}
