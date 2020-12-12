$(document).ready(function(){  

    var myMap = L.map('myMap').setView([-34.603792, -58.562181], 13)

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
                L.marker([response[i].latitud, response[i].longitud]).addTo(myMap);
            }       
        },
        
        failure: function(error) {
          console.log(error);
        }
        
    });        

});
