
document.addEventListener('DOMContentLoaded', () => {

    let personsData = null;

    const displayMessage = document.getElementById('displaymessage');
    const cityInput = document.getElementById('city');
    const bloodGroupSelect = document.getElementById('bloodgroup');
    const searchResultsDiv = document.getElementById('searchResults');

    async function Display() {
        const apiUrl = 'https://webapps.tekstac.com:8443/WebProjects/PersonService/viewPersonListJSON';
        displayMessage.textContent = 'Fetching data...';
        displayMessage.style.color = 'gray';

        try {
            const response = await fetch(apiUrl);
            if (!response.ok) {
                throw new Error(`Network response was not ok: ${response.status} ${response.statusText}`);
            }
            const data = await response.json();
            personsData = data;
            displayMessage.textContent = 'Data fetched successfully!';
            displayMessage.style.color = 'green';

        } catch (error) {
            console.error('Error fetching data:', error); 
            displayMessage.textContent = 'Failed to fetch data. Please try again.';
            displayMessage.style.color = 'red';
            personsData = null;
        }
    }

    function blooddonors() {
        searchResultsDiv.innerHTML = ''; 

        if (!personsData) {
            searchResultsDiv.innerHTML = '<p class="text-center text-red-600 font-semibold text-lg">Please fetch data from API first.</p>';
            return;
        }

        const selectedBloodGroup = bloodGroupSelect.value;
        const enteredCity = cityInput.value.trim();

        if (!selectedBloodGroup || !enteredCity) {
            searchResultsDiv.innerHTML = '<p class="text-center text-red-600 font-semibold text-lg">Please select a blood group and enter a city.</p>';
            return;
        }

        const foundDonors = personsData.filter(person => {
            const matchesBloodGroup = person.bloodGroup.toLowerCase() === selectedBloodGroup.toLowerCase();
            const matchesCity = person.city.toLowerCase() === enteredCity.toLowerCase();
            return matchesBloodGroup && matchesCity;
        });

        if (foundDonors.length === 0) {
            searchResultsDiv.innerHTML = '<p class="text-center text-red-600 font-semibold text-lg">No donors found in the specified city and blood group.</p>';
        } else {
            let tableHTML = `
                <table id="resultsTable">
                    <thead>
                        <tr>
                            <th>Name</th>
                            <th>Age</th>
                            <th>Gender</th>
                            <th>Blood Group</th>
                            <th>City</th>
                            <th>Mobile Number</th>
                        </tr>
                    </thead>
                    <tbody>
            `;

            foundDonors.forEach(donor => {
                tableHTML += `
                    <tr>
                        <td>${donor.firstName} ${donor.lastName}</td>
                        <td>${donor.age}</td>
                        <td>${donor.gender}</td>
                        <td>${donor.bloodGroup}</td>
                        <td>${donor.city}</td>
                        <td>${donor.phoneNumber}</td>
                    </tr>
                `;
            });

            tableHTML += `
                    </tbody>
                </table>
            `;
            searchResultsDiv.innerHTML = tableHTML;
        }
    }

    window.Display = Display;
    window.blooddonors = blooddonors;

});
