#version 100

attribute vec3 a_VertexPosition;
attribute vec3 a_VertexColor;

uniform mat4 u_ModelViewMatrix;     // Combined Model-View Matrix
uniform mat4 u_ProjectionMatrix;    // Projection Matrix

varying mediump vec4 v_Color;

void main()
{
    // Apply the model-view and projection transformation
    gl_Position = u_ProjectionMatrix * u_ModelViewMatrix * vec4(a_VertexPosition, 1.0);

    // Pass the vertex color to the fragment shader
    v_Color = vec4(a_VertexColor, 1);
}
