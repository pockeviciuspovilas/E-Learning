
$.getScript('//cdn.quilljs.com/1.3.6/quill.js', function () {
    console.log("loaded")
});
function createQuillQuestion(id) {

    new Quill(`#qs-${id}`, {
        modules: {
            toolbar: [
                ['bold', 'italic', 'underline', 'strike'],
                ['blockquote', 'code-block'],
                [{ 'header': 1 }, { 'header': 2 }],
                [{ 'list': 'ordered' }, { 'list': 'bullet' }],
                [{ 'script': 'sub' }, { 'script': 'super' }],
                [{ 'indent': '-1' }, { 'indent': '+1' }],
                [{ 'direction': 'rtl' }],
                [{ 'size': ['small', false, 'large', 'huge'] }],
                [{ 'header': [1, 2, 3, 4, 5, 6, false] }],
                ['link', 'image', 'video', 'formula'],
                [{ 'align': [] }],
                ['clean']
            ]
        },
        placeholder: 'Write a question..',
        theme: 'snow'
    });


}

function createQuillAnswer(id) {

    new Quill(`#ans-${id}`, {
        modules: {
            toolbar: [
                ['bold', 'italic', 'underline', 'strike'],
                ['blockquote', 'code-block'],
                [{ 'header': 1 }, { 'header': 2 }],
                [{ 'list': 'ordered' }, { 'list': 'bullet' }],
                [{ 'script': 'sub' }, { 'script': 'super' }],
                [{ 'indent': '-1' }, { 'indent': '+1' }],
                [{ 'direction': 'rtl' }],
                [{ 'size': ['small', false, 'large', 'huge'] }],
                [{ 'header': [1, 2, 3, 4, 5, 6, false] }],
                ['link', 'image', 'video', 'formula'],
                [{ 'align': [] }],
                ['clean']
            ]
        },
        placeholder: 'Write an answer..',
        theme: 'snow'
    });


}

let counter = 0;
function createQuestion() {
    let editor = document.getElementById('editor')

    let questionEl = document.createElement("div")
    questionEl.className = "quill-question"
    questionEl.id = counter

    let quillDiv = document.createElement("div")
    quillDiv.id = "qs-" + counter

    let questionName = document.createElement("h4")
    questionName.innerText = "Question"

    let removeQuestionButton = document.createElement("button")
    removeQuestionButton.className = "btn btn-danger"
    removeQuestionButton.innerText = "Remove"
    removeQuestionButton.onclick = function () {
        this.parentElement.remove();
    };


    let radioBtn = document.createElement("button")
    radioBtn.className = "btn btn-secondary"
    radioBtn.innerText = "One answer"
    radioBtn.onclick = function () {
        this.nextSibling.remove();
        initializeRadio(this.parentElement);
        this.remove();
    };

    let checkBtn = document.createElement("button")
    checkBtn.className = "btn btn-secondary"
    checkBtn.innerText = "Multiple answers"
    checkBtn.onclick = function () {
        this.previousSibling.remove();
        initializeCheck(this.parentElement);
        this.remove();
    };
    let answersDiv = document.createElement("div")


    questionEl.insertAdjacentElement("beforeend", questionName)
    questionEl.insertAdjacentElement("beforeend", removeQuestionButton)
    questionEl.insertAdjacentElement("beforeend", quillDiv)
    questionEl.insertAdjacentElement("beforeend", radioBtn)
    questionEl.insertAdjacentElement("beforeend", checkBtn)
    questionEl.insertAdjacentElement("beforeend", answersDiv)
    editor.appendChild(questionEl)
    createQuillQuestion(counter)


    counter++;


}
let answerCounter = 0;


function initializeRadio(parent) {
    let editor = parent.lastElementChild
    let btn = document.createElement("button")
    btn.className = "btn btn-outline-secondary"
    btn.innerText = "Add radio answers"
    btn.onclick = function () {
        btn.onclick = function () {
            parent.lastElementChild.insertAdjacentHTML("beforeend", "<div class='container quill-answer'>  <label for='" + counter + "'> Correct?</label>  <input type='radio'  name='" + counter + "' value='Correct?'> <button class='btn btn-danger' onclick ='this.parentNode.remove()'>-</button> <div id='ans-" + parent.id + "-" + answerCounter + "'></div></div>")
            createQuillAnswer(parent.id + "-" + answerCounter)
            answerCounter++
        };
    };

    editor.appendChild(btn)


}

function initializeCheck(parent) {
    let editor = parent.lastElementChild
    let btn = document.createElement("button")
    btn.className = "btn btn-outline-secondary"
    btn.innerText = "Add check answers"
    btn.onclick = function () {
        btn.onclick = function () {
            parent.lastElementChild.insertAdjacentHTML("beforeend", "<div class='container quill-answer'> <label for='" + counter + "'> Correct?</label>  <input type='checkbox'  name='" + counter + "' value='Correct?'> <button class='btn btn-danger' onclick ='this.parentNode.remove()'>-</button> <div id='ans-" + parent.id + "-" + answerCounter + "'></div></div>")
            createQuillAnswer(parent.id + "-" + answerCounter)
            answerCounter++
        };
    };

    editor.appendChild(btn)

}

function RemoveQuestion(id) {
    document.getElementById(id).remove()
}