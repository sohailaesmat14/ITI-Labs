self.onmessage = async function() {
    try {
        const response = await fetch("https://jsonplaceholder.typicode.com/users/1");
        const data = await response.json();
        self.postMessage(data);
    } catch (err) {
        self.postMessage("Error");
    }
}