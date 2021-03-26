$(document).ready(function(){  

  var myMap = L.map('myMap').setView([-34.609440, -58.578713], 13)

  L.tileLayer(`https://maps.wikimedia.org/osm-intl/{z}/{x}/{y}.png`, { 
   maxZoom: 18,
  }).addTo(myMap);

  var marker = L.marker([-34.603792, -58.562181]).addTo(myMap);
    
  $.ajax({
    url: '/AltaPuestos/ConsultarPuestos',
    method: 'GET',
    dataType: 'json',

    success: function(response) {
      for (var i=0 ; i<response.length ; i++) {
        L.marker([response[i].latitud, response[i].longitud]).bindPopup('<h4>' + response[i].localidad + '</h4>' +
        '<h5>' + response[i].plaza + '</h5>' + '<p>' + response[i].direccion + '</p>').addTo(myMap);
      }       
    },
        
    failure: function(error) {
      console.log(error);
    }
        
  });

});
