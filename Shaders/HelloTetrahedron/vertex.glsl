attribute vec3 aPosition;
attribute vec3 aColor;

uniform mat4 uModelViewMatrix;  // Combined Model-View Matrix
uniform mat4 uProjectionMatrix; // Projection Matrix

varying vec3 vColor;

void main()
{
    // Apply the model-view and projection transformation
    gl_Position = uProjectionMatrix * uModelViewMatrix * vec4(aPosition, 1.0);

    // Pass the vertex color to the fragment shader
    vColor = aColor;
}
