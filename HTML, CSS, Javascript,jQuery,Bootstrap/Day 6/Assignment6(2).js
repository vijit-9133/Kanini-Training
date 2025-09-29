

function getUser(id) {
    return axios.get(`https://jsonplaceholder.typicode.com/users/${id}`);
}

function getPostsByUser(userId) {
    return axios.get(`https://jsonplaceholder.typicode.com/posts?userId=${userId}`);
}
document.getElementById("btn1").addEventListener("click", function() {
    const userId1 = document.getElementById("uid").value;
    
    if (!userId1) {
        alert("Please enter a user ID");
        return;
    }

getUser(userId1)
    .then(response => {
        const user = response.data;
        console.log("User:", user.name);
        document.getElementById("para").innerHTML =("The user name is:"+user.name);
        return getPostsByUser(user.id);
    })
    .then(response => {
        const posts = response.data;
        if (posts.length > 0) {
            console.log("First Post Title:", posts[0].title);
            document.getElementById("para1").innerHTML =("First post title:"+posts[0].title);
        } else {
            console.log("No posts found for this user.");
        }
    })
    .catch(error => {
        console.error("Error:", error.message);
    });
});
