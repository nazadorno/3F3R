$(document).ready(function(){  

  var myMap = L.map('myMap').setView([-34.603792, -58.562181], 12)

  L.tileLayer(`https://maps.wikimedia.org/osm-intl/{z}/{x}/{y}.png`, { 
   maxZoom: 18,
  }).addTo(myMap);

  var marker = L.marker([-34.603792, -58.562181]).addTo(myMap);

  var searchControl = L.esri.Geocoding.geosearch().addTo(myMap);

  var results = L.layerGroup().addTo(myMap);

  searchControl.on('results', function (data) {
    results.clearLayers();
    for (var i = data.results.length - 1; i >= 0; i--) {
      myMap.setView(data.results[i].latlng, 14);
      $.ajax({
        url: '/AltaPuestos/ZonaConsultada',
        method: 'POST',
        dataType: "json",
        data: {
          latitud: data.results[i].latlng.lat,
          longitud: data.results[i].latlng.lng
        },
        success: (data) => {
          console.log(data);
        },

        failure: function(error){
          console.log(error);
        }
      });
    }
  });

    
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
