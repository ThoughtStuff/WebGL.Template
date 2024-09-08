attribute vec3 aPosition;
attribute vec3 aColor;

uniform mat4 uModelTransform;

varying vec3 vColor;

void main()
{
    gl_Position = uModelTransform * vec4(aPosition, 1.0);
    vColor = aColor;
}
