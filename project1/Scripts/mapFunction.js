let map;

function initMap() {
    
    const uluru = { lat: 62.909449, lng: 17.086168 };

    const map = new google.maps.Map(document.getElementById("map"), {
        zoom: 8,
        center: uluru,
    });

};