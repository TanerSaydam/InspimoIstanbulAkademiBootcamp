function gotoContact(){
    const el = document.querySelector("app-root");

    el.innerHTML = `
    <h1>Contact Page</h1>
    <form action="">
        <div>
            Subject
            <input type="text">
        </div>
        <div>
            Email
            <input type="text">
        </div>
        <div>
            Content
            <textarea name="" id="" cols="30" rows="10"></textarea>
        </div>
        <div>
            <button>Send</button>
        </div>
    </form>`
}