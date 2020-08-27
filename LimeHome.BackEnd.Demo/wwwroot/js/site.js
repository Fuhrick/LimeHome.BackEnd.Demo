let todos = [];

function getProperties() {
    const latitude = document.getElementById('get-properties-latitude').value;
    const longitude = document.getElementById('get-properties-longitude').value;

    fetch(`api/Properties/?at=${latitude},${longitude}`)
        .then(response => response.json())
        .then(data => _displayItems(data))
        .catch(error => console.error('Unable to get items.', error));
}

function getBookings() {
    const hotelId = document.getElementById('get-bookings-hotel-id').value;

    fetch(`api/Properties/${hotelId}/bookings`)
        .then(response => response.json())
        .then(data => _displayBookings(data))
        .catch(error => console.error('Unable to get items.', error));
}

function _displayBookings(data) {
    const tBody = document.getElementById('bookings');
    tBody.innerHTML = '';

    console.log(data);

    data.forEach(item => {
        let tr = tBody.insertRow();

        let td1 = tr.insertCell(0);
        let textNode = document.createTextNode(item.firstName);
        td1.appendChild(textNode);

        let td2 = tr.insertCell(1);
        let textNode2 = document.createTextNode(item.lastName);
        td2.appendChild(textNode2);

        let td3 = tr.insertCell(2);
        let textNode3 = document.createTextNode(item.hotelId);
        td3.appendChild(textNode3);

        let td4 = tr.insertCell(3);
        let textNode4 = document.createTextNode(item.fromDate);
        td4.appendChild(textNode4);

        let td5 = tr.insertCell(4);
        let textNode5 = document.createTextNode(item.toDate);
        td5.appendChild(textNode5);
    });

    todos = data;
}

function _displayItems(data) {
    const tBody = document.getElementById('todos');
    tBody.innerHTML = '';

    console.log(data);

    data.forEach(item => {
        let tr = tBody.insertRow();

        let td1 = tr.insertCell(0);
        let textNode = document.createTextNode(item.id);
        td1.appendChild(textNode);

        let td2 = tr.insertCell(1);
        let textNode2 = document.createTextNode(item.title);
        td2.appendChild(textNode2);
    });

    todos = data;
}

function addItem() {
    const addFirstNameTextbox = document.getElementById('add-first-name');
    const addLastNameTextbox = document.getElementById('add-last-name');
    const addHotelIdTextbox = document.getElementById('add-hotel-id');
    const addFromDateTextbox = document.getElementById('add-from-date');
    const addToDateTextbox = document.getElementById('add-to-date');


    const item = {
        firstName: addFirstNameTextbox.value.trim(),
        lastName: addLastNameTextbox.value.trim(),
        hotelId: addHotelIdTextbox.value.trim(),
        fromDate: addFromDateTextbox.value.trim(),
        todate: addToDateTextbox.value.trim()
    };

    fetch("api/Bookings", {
            method: 'POST',
            headers: {
                'Accept': 'application/json',
                'Content-Type': 'application/json'
            },
            body: JSON.stringify(item)
        })
        .catch(error => console.error('Unable to add item.', error));
}