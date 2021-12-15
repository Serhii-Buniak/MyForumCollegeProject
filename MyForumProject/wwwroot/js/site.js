document.querySelectorAll(".comment__answer").forEach((button) => button.addEventListener("click", () => {
    const comment = button.closest(".comment");
    const username = comment.querySelector(".comment__username-wrapper u").textContent;
    const post = comment.closest(".post");
    const textarea = post.querySelector(".post__answer-textarea");
    textarea.append('@' + username + ' ');
    textarea.focus();
    textarea.setSelectionRange(textarea.value.length, textarea.value.length);
}))

document.querySelectorAll(".comment__content").forEach(c => {
    const text = c.innerText;
    let whiteSpaceIndex;
    if (text[0] === "@") {
        for (let index = 0; index < text.length; index++) {

            if (text[index] === ' ') {
                whiteSpaceIndex = index
                break;
            }
        }
       
        const username = text.substring(0, whiteSpaceIndex);
        const otherText = text.substring(whiteSpaceIndex, text.length);
        const span = document.createElement("span");
        span.style.color = "blue";
        span.append(username);
        c.innerText = "";
        c.append(span);
        c.append(otherText);
        

    }
})
