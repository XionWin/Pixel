#version 300 es
layout(location = 0) in vec2 position;
layout(location = 2) in vec4 color;
uniform vec2 view_port;
out vec4 vColor;
void main()
{
    gl_Position = vec4(position.x / view_port.x * 2.0 - 1.0, 1.0 - position.y / view_port.y * 2.0, 0.0, 1.0);
    vColor = vec4(0.0, 0.0, 0.0, 1.0);
}