#version 100
precision mediump float;

varying vec2 v_TextureCoord;

uniform sampler2D u_Texture;

void main()
{
    gl_FragColor = texture2D(u_Texture, v_TextureCoord);
}
