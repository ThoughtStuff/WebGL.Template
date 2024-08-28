attribute vec4 aVertexPosition;
attribute vec4 aVertexColor;
varying lowp vec4 vColor;

void main(void) {
    gl_Position = aVertexPosition;
    vColor = aVertexColor;
}
