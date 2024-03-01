


  const colorPicker = document.getElementById('colorPicker');
  const textToChange = document.getElementById('textToChange');
  console.log(textToChange);

 
  const storedColor = localStorage.getItem('selectedColor');
  if (storedColor) {
    textToChange.style.color = storedColor;
    colorPicker.value = storedColor;
  }


  
  colorPicker.addEventListener('input', function() {
    localStorage.setItem('selectedColor', colorPicker.value);

  console.log(localStorage.getItem("selectedColor"));

  
    textToChange.style.color = localStorage.getItem("selectedColor");



});