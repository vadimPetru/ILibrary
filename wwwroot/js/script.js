let offset = 0;
const SliderLine = document.querySelector('.slider-line');

document.querySelector('.slider-next').addEventListener('click', function() {
  offset += 400;
  if(offset > 2000){
    offset = 0;
  }

  SliderLine.style.left = -offset + 'px';
});


document.querySelector('.slider-prev').addEventListener('click', function() {
  offset -= 400;
  if(offset < 0){
    offset = 2000;
  }
  
  SliderLine.style.left = -offset + 'px';
});