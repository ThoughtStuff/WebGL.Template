#version 100

attribute vec2 a_VertexPosition;
attribute vec2 a_TextureCoord;
attribute vec2 a_InstanceTranslation;   // Per-instance translation
attribute vec2 a_InstanceTransformRow0; // First row of 2x2 transformation matrix
attribute vec2 a_InstanceTransformRow1; // Second row of 2x2 transformation matrix
attribute float a_InstanceFrameIndex;   // Per-instance sprite frame index

uniform float u_SpriteSheetColumnCount;
uniform float u_SpriteSheetRowCount;
uniform float u_PaddingRight;           // wasted space on the right of the sprite sheet
uniform float u_PaddingBottom;          // wasted space on the bottom of the sprite sheet

varying mediump vec2 v_TextureCoord;

void main(void) {
    // Apply the 2x2 transformation matrix to the position
    vec2 transformedPosition = vec2(
        dot(a_VertexPosition, a_InstanceTransformRow0),
        dot(a_VertexPosition, a_InstanceTransformRow1)
    );
    vec2 worldPosition = transformedPosition + a_InstanceTranslation;
    gl_Position = vec4(worldPosition, 0.0, 1.0);

    // Adjusted sprite dimensions accounting for padding
    float spriteWidth = (1.0 - u_PaddingRight) / u_SpriteSheetColumnCount;
    float spriteHeight = (1.0 - u_PaddingBottom) / u_SpriteSheetRowCount;

    // Calculate column and row from sprite index
    float column = mod(a_InstanceFrameIndex, u_SpriteSheetColumnCount);
    float row = floor(a_InstanceFrameIndex / u_SpriteSheetColumnCount);

    // Calculate texture offset
    vec2 spriteOffset = vec2(column * spriteWidth, row * spriteHeight);

    // Adjust texture coordinates based on sprite index, accounting for padding
    v_TextureCoord = a_TextureCoord * vec2(spriteWidth, spriteHeight) + spriteOffset;
}
