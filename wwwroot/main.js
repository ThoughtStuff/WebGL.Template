import { dotnet } from "./_framework/dotnet.js";

// Get WebGL context from the canvas
const canvas = document.getElementById("canvas");
const gl =
  canvas.getContext("webgl") || canvas.getContext("experimental-webgl");
console.assert(gl, "WebGL is not available");

const { setModuleImports, getAssemblyExports, getConfig } = await dotnet
  .withDiagnosticTracing(false)
  .withApplicationArgumentsFromQuery()
  .create();

setModuleImports("main.js", {
  gl: gl,
  utility: {
    // Permit passing a MemoryView for the data buffer which gives flexibility for marshalling
    glBufferData: (target, memoryView, usage) => {
      // NOTE: calling _unsafe_create_view is supposed to be ok for immediate usage.
      //       calling slice() is safer, but makes a copy
      //       https://github.com/dotnet/runtime/blob/8cb3bf89e4b28b66bf3b4e2957fd015bf925a787/src/mono/wasm/runtime/marshal.ts#L386C5-L386C24
      gl.bufferData(target, memoryView._unsafe_create_view(), usage);
    },
  },
});

const config = getConfig();
const exports = await getAssemblyExports(config.mainAssemblyName);

// Setup input interop
const keyDown = (e) => {
  e.stopPropagation();
  const shift = e.shiftKey;
  const ctrl = e.ctrlKey;
  const alt = e.altKey;
  const repeat = e.repeat;
  const code = e.keyCode;

  exports.InputInterop.OnKeyDown(shift, ctrl, alt, repeat, code);
};

const keyUp = (e) => {
  e.stopPropagation();
  const shift = e.shiftKey;
  const ctrl = e.ctrlKey;
  const alt = e.altKey;
  const code = e.keyCode;

  exports.InputInterop.OnKeyUp(shift, ctrl, alt, code);
};

const mouseMove = (e) => {
  const x = e.offsetX;
  const y = e.offsetY;

  exports.InputInterop.OnMouseMove(x, y);
};

const mouseDown = (e) => {
  const shift = e.shiftKey;
  const ctrl = e.ctrlKey;
  const alt = e.altKey;
  const button = e.button;

  exports.InputInterop.OnMouseDown(shift, ctrl, alt, button);
};

const mouseUp = (e) => {
  const shift = e.shiftKey;
  const ctrl = e.ctrlKey;
  const alt = e.altKey;
  const button = e.button;

  exports.InputInterop.OnMouseUp(shift, ctrl, alt, button);
};

canvas.addEventListener("keydown", keyDown, false);
canvas.addEventListener("keyup", keyUp, false);
canvas.addEventListener("mousemove", mouseMove, false);
canvas.addEventListener("mousedown", mouseDown, false);
canvas.addEventListener("mouseup", mouseUp, false);
canvas.tabIndex = 1000;

// Auto-resize canvas so framebuffer is always the same size as the canvas
function checkCanvasResize() {
  var devicePixelRatio = window.devicePixelRatio || 1.0;
  var displayWidth = canvas.clientWidth * devicePixelRatio;
  var displayHeight = canvas.clientHeight * devicePixelRatio;
  if (canvas.width != displayWidth || canvas.height != displayHeight) {
    canvas.width = displayWidth;
    canvas.height = displayHeight;
    gl.viewport(0, 0, canvas.width, canvas.height);
  }
}
function checkCanvasResizeLoop() {
  checkCanvasResize();
  requestAnimationFrame(checkCanvasResizeLoop);
}
checkCanvasResizeLoop();

// Setup render loop
function renderFrame() {
  exports.RenderLoop.Render();
  requestAnimationFrame(renderFrame);
}
requestAnimationFrame(renderFrame);

await dotnet.run();
