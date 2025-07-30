console.log("\033c\033[40;33m\n")
const fs = require('fs');
const path = require('path');

const wasmPath = path.join(__dirname, 'main.wasm');
const buffer = fs.readFileSync(wasmPath);

WebAssembly.instantiate(buffer).then(result => {
    const { exports } = result.instance;
    console.log("Resultado da função:", exports.sum(5, 3));
});