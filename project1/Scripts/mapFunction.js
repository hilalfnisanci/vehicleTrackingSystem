let map;

function initMap() {
    
    map = new google.maps.Map(document.getElementById("map"), {
        center: { lat: 62.909449, lng: 17.086168 },
        zoom: 8,
    });
};