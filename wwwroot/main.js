import { dotnet } from "./_framework/dotnet.js";

// Get WebGL context from the canvas
const canvas = document.getElementById("canvas");
const gl =
  canvas.getContext("webgl") || canvas.getContext("experimental-webgl");
console.assert(gl, "WebGL is not available");

// GUI Overlay elements
const fpsElement = document.getElementById("fps");
const errorsContainer = document.getElementById("errors");
const errorMessageElement = document.getElementById("errorMessage");
const clearErrorsElement = document.getElementById("clearErrors");

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
  overlay: {
    setFPS: (fps) => {
      fpsElement.textContent = fps;
    },
    setErrorMessage: (message) => {
      if (message) {
        errorMessageElement.textContent = message;
        errorsContainer.style.display = "block";
      } else {
        errorsContainer.style.display = "none";
      }
    },
  },
});

const config = getConfig();
const exports = await getAssemblyExports(config.mainAssemblyName);

// Interop events on overlay GUI elements
clearErrorsElement.addEventListener("click", () => {
  exports.Overlay.ClearErrorMessage();
});

// Setup input interop for keyboard
const keyDown = (e) => {
  e.stopPropagation();
  const shift = e.shiftKey;
  const ctrl = e.ctrlKey;
  const alt = e.altKey;
  const repeat = e.repeat;
  const code = e.code;

  exports.InputInterop.OnKeyDown(code, shift, ctrl, alt, repeat);
};

const keyUp = (e) => {
  e.stopPropagation();
  const shift = e.shiftKey;
  const ctrl = e.ctrlKey;
  const alt = e.altKey;
  const code = e.code;

  exports.InputInterop.OnKeyUp(code, shift, ctrl, alt);
};

/** Convert client pixel coordinates to normalized coordinates
 * with the origin at bottom left corner of the canvas
 */
function normalize(clientX, clientY) {
  return {
    x: clientX / canvas.clientWidth,
    y: 1 - clientY / canvas.clientHeight,
  };
}

const mouseMove = (e) => {
  e.preventDefault();
  e.stopPropagation();
  const { x, y } = normalize(e.clientX, e.clientY);
  exports.InputInterop.OnMouseMove(x, y);
};

const mouseDown = (e) => {
  e.preventDefault();
  e.stopPropagation();
  const { x, y } = normalize(e.clientX, e.clientY);
  const shift = e.shiftKey;
  const ctrl = e.ctrlKey;
  const alt = e.altKey;
  const button = e.button;

  exports.InputInterop.OnMouseDown(shift, ctrl, alt, button, x, y);
};

const mouseUp = (e) => {
  e.preventDefault();
  e.stopPropagation();
  const { x, y } = normalize(e.clientX, e.clientY);
  const shift = e.shiftKey;
  const ctrl = e.ctrlKey;
  const alt = e.altKey;
  const button = e.button;

  exports.InputInterop.OnMouseUp(shift, ctrl, alt, button, x, y);
};

const touchStart = (e) => {
  e.preventDefault();
  e.stopPropagation();

  const touch = e.touches[0];
  const { x, y } = normalize(touch.clientX, touch.clientY);
  exports.InputInterop.OnTouchStart(x, y);
};

const touchMove = (e) => {
  e.preventDefault();
  e.stopPropagation();

  const touch = e.touches[0];
  const { x, y } = normalize(touch.clientX, touch.clientY);

  exports.InputInterop.OnTouchMove(x, y);
};

const touchEnd = (e) => {
  e.preventDefault();
  e.stopPropagation();

  exports.InputInterop.OnTouchEnd();
};

canvas.addEventListener("keydown", keyDown, false);
canvas.addEventListener("keyup", keyUp, false);
canvas.addEventListener("mousemove", mouseMove, false);
canvas.addEventListener("mousedown", mouseDown, false);
canvas.addEventListener("mouseup", mouseUp, false);
canvas.addEventListener("touchstart", touchStart, false);
canvas.addEventListener("touchmove", touchMove, false);
canvas.addEventListener("touchend", touchEnd, false);
canvas.tabIndex = 1000;

// Auto-resize canvas so framebuffer is always the same size as the canvas
function resizeCanvasToDisplaySize() {
  // The canvas is styled to fill the window,
  // but the framebuffer resolution is independent of the style
  // and must be set on the canvas element directly.
  // The webgl viewport must also be updated to match the framebuffer size.
  var devicePixelRatio = window.devicePixelRatio || 1.0;
  var displayWidth = canvas.clientWidth * devicePixelRatio;
  var displayHeight = canvas.clientHeight * devicePixelRatio;
  if (canvas.width != displayWidth || canvas.height != displayHeight) {
    canvas.width = displayWidth;
    canvas.height = displayHeight;
    gl.viewport(0, 0, canvas.width, canvas.height);
  }
}
window.addEventListener("resize", resizeCanvasToDisplaySize);
resizeCanvasToDisplaySize();

// Setup render loop
function renderFrame() {
  exports.RenderLoop.Render();
  requestAnimationFrame(renderFrame);
}
requestAnimationFrame(renderFrame);

await dotnet.run();
