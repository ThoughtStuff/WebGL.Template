#version 100

attribute vec4 a_VertexPosition;
attribute vec4 a_VertexColor;

uniform mat4 u_ModelViewMatrix;     // Combined Model-View Matrix
uniform mat4 u_ProjectionMatrix;    // Projection Matrix

varying mediump vec4 v_Color;

void main()
{
    // Apply the model-view and projection transformation
    gl_Position = u_ProjectionMatrix * u_ModelViewMatrix * a_VertexPosition;

    // Pass the vertex color to the fragment shader
    v_Color = a_VertexColor;
}
