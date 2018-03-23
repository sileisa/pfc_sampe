


$(".button-collapse").sideNav();

$(document).ready(function(){
	$('.carousel').carousel();
});

$(document).ready(function(){
  $('.target').pushpin({
    top: 0,
    bottom: 1000,
    offset: 0
  });
});



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
