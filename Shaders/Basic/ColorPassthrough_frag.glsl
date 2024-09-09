#version 100
precision mediump float;

varying vec4 v_Color;

void main(void) {
    gl_FragColor = v_Color;
}
