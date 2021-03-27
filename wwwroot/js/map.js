$(document).ready(function(){  

  var myMap = L.map('myMap').setView([-34.609440, -58.578713], 13)

  L.tileLayer(`https://maps.wikimedia.org/osm-intl/{z}/{x}/{y}.png`, { 
   maxZoom: 18,
  }).addTo(myMap);

  var marker = L.marker([-34.603792, -58.562181]).addTo(myMap);

  var searchControl = L.esri.Geocoding.geosearch().addTo(myMap);

  var results = L.layerGroup().addTo(myMap); 


  $('#busqueda').on('click', function() {
    
    searchControl.on('results', function (data) {
        results.clearLayers();
        for (var i = data.results.length - 1; i >= 0; i--) {
          myMap.setView(data.results[i].latlng, 14);
          
          $('#lat').val(data.results[i].latlng.lat)
          $('#lon').val(data.results[i].latlng.lng)
        
        }
    });
  });   
  
  
  $('#seleccion').on('click', function() {

    myMap.on('click', onMapClick);
    var popup = L.popup();

    function onMapClick(e) {
        popup
            .setLatLng(e.latlng)
            .setContent("You clicked the map at " + e.latlng.toString())
            .openOn(myMap);

            $('#lat').val(e.latlng.lat)
            $('#lon').val(e.latlng.lng)    
        
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
