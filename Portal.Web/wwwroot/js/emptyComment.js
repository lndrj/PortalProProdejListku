//Ošetření prázdného input pole u přidávání příspěvků   
document.addEventListener('DOMContentLoaded', function () {
    var commentTextarea = document.getElementById('commentTextArea');
    var submitButton = document.getElementById('commentSubmit');

    // Zkontroluje stav textarea při načtení stránky
    submitButton.disabled = commentTextarea.value.trim() === '';

    commentTextarea.addEventListener('input', function () {
        submitButton.disabled = commentTextarea.value.trim() === '';
    });
});