function solve() {
  let text = document.getElementById('text').value;
  let namingConvention = document.getElementById('naming-convention').value;

  let transformed;

  switch (namingConvention) {
    case 'Pascal Case': transformed = toPascalCase(text); break;
    case 'Camel Case': transformed = toCamelCase(text); break;
    default: transformed = 'Error!'; break;
  }

  document.getElementById('result').innerText = transformed;

  function toCamelCase(text) {
    let pascal = toPascalCase(text);
    return pascal.charAt(0).toLowerCase() + pascal.slice(1);
  }
  function toPascalCase(text) {
    return text.toLowerCase()
      .split(" ")
      .reduce((acc, value) => acc + value.charAt(0).toUpperCase() + value.slice(1), "");
  }
}