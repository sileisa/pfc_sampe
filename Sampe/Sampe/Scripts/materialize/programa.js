

(function($){
	$(function(){
		$('.button-collapse').sideNav();
		$('.parallax').parallax();
	}); 
})(jQuery); 

$(document).ready(function(){
	$('.carousel').carousel();
});

// Next slide
$('.carousel').carousel('next');
$('.carousel').carousel('next', 3); // Move next n times.

// Previous slide
$('.carousel').carousel('prev');
$('.carousel').carousel('prev', 4); // Move prev n times.

// Set to nth slide
$('.carousel').carousel('set', 4);

// Destroy carousel
$('.carousel').carousel('destroy');
$(document).ready(function(){
	$('.slider').slider();
});

       // Pause slider
       $('.slider').slider('pause');
// Start slider
$('.slider').slider('start');
// Next slide
$('.slider').slider('next');
// Previous slide
$('.slider').slider('prev');


$(document).ready(function(){
  $('.target').pushpin({
    top: 0,
    bottom: 1000,
    offset: 0
  });
});

$(".button-collapse").sideNav();

$('input.autocomplete').autocomplete({
  data: {
    "Marcello": null,
    "Jade": null,
    "Google": 'https://placehold.it/250x250'
  },
    limit: 20, // The max amount of results that can be shown at once. Default: Infinity.
    onAutocomplete: function(val) {
      // Callback function when value is autcompleted.
    },
    minLength: 1, // The minimum length of the input for the autocomplete to start. Default: 1.
  });

Materialize.toast('I am a toast!', 4000)
