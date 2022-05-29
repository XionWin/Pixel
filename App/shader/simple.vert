#version 300 es
layout(location = 0) in vec2 position;
layout(location = 2) in vec4 color;
out vec4 vColor;
void main()
{
    gl_Position = vec4(position.x / 1280.0 * 2.0 - 1.0, 1.0 - position.y / 1024.0 * 2.0, 0.0, 1.0);
    vColor = vec4(0.0, 0.0, 0.0, 1.0);
}