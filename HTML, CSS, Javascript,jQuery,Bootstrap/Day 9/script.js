
document.addEventListener('DOMContentLoaded', () => {
    const authButton = document.getElementById('authButton');
    const welcomeMessage = document.getElementById('welcomeMessage');

    function updateHeader() {
        const loggedInUser = localStorage.getItem('loggedInUser'); 

        if (loggedInUser) {
            authButton.classList.add('d-none'); 
            welcomeMessage.classList.remove('d-none'); 
            welcomeMessage.innerHTML = `Hi, ${loggedInUser}! <a href="#" id="logoutLink" class="btn btn-sm btn-outline-danger ms-2">Logout</a>`;

            const logoutLink = document.getElementById('logoutLink');
            if (logoutLink) {
                logoutLink.addEventListener('click', (event) => {
                    event.preventDefault(); 
                    localStorage.removeItem('loggedInUser');
                    updateHeader(); 
                });
            }

        } else {
            
            authButton.classList.remove('d-none'); 
            welcomeMessage.classList.add('d-none'); 
            welcomeMessage.innerHTML = ''; 
    }
    }
    updateHeader();

});

