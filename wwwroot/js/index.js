
const toggleBtn = document.getElementById("toggleBtn");
const body = document.body;

toggleBtn.addEventListener("click", () => {
    body.classList.toggle("dark-mode");

    //text

    if (body.classList.contains("dark-mode")) {
        toggleBtn.textContent = "☀️ ";
    } else {
        toggleBtn.textContent = "🌙 ";
    }
});

//we will also add a event listener for  الدليل الصوتي 


function myVoice() {
    document.getElementById("soundalert").innerHTML = " !!!تم بدأ الدليل الصوتي ";

}