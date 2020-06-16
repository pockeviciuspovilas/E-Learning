    let url = new URL(window.location.href)
$.getScript('//cdn.quilljs.com/1.3.6/quill.js', function () {
    console.log("loaded")

    if (url.searchParams.has("id")) {
        document.getElementById('saveBtn').innerText = "Update Test"
        loadTest(url.searchParams.get("id"));
    }
});

let testCategories = new Object();
$.ajax({
    type: "GET",
    dataType: "json",
    url: "/Test/GetTestCategories",
    success: function (data) {
        testCategories = data;
        let elem = document.getElementById('testCategories')
        elem.innerHTML = "";
        for (var i = 0; i < testCategories.length; i++) {
            elem.insertAdjacentHTML("beforeend", "<option value = '" + testCategories[i].id + "'>" + testCategories[i].name + "</option>")
        }
    }
})

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
    radioBtn.id = "rb-" + counter;
    radioBtn.onclick = function () {
        this.nextSibling.remove();
        initializeRadio(this.parentElement);
        this.remove();
    };

    let checkBtn = document.createElement("button")
    checkBtn.className = "btn btn-secondary"
    checkBtn.innerText = "Multiple answers"
    checkBtn.id = "cb-" + counter;
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
    btn.id = "ir-" + counter;
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
    btn.id = "ic-" + counter;
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

function createTest() {
    let test = new Test();
    test.name = document.getElementById('testName').value;
    test.duration = document.getElementById('duration').value;
    let editor = document.getElementById('editor').children;

    test.questions = getQuestions(editor)

    var seen = [];

    seen= JSON.stringify(test, function (key, val) {
        if (val != null && typeof val == "object") {
            if (seen.indexOf(val) >= 0) {
                return;
            }
            seen.push(val);
        }
        return val;
    });
    console.log(test)
    console.log(JSON.stringify(test))
    if (url.searchParams.has("id")) {
        $.ajax({
            type: "POST",
            dataType: "json",
            data: {
                name: test.name,
                id: url.searchParams.get("id"),
                categoryId: document.getElementById('testCategories').value,
                duration: test.duration,
                json: JSON.stringify(test),
            },
            url: "/Test/UpdateTest",
            success: function (data) {
                if (data == "OK") {
                    location.href = "/Test"
                }
            }
        })
    }
    else {
        $.ajax({
            type: "POST",
            dataType: "json",
            data: {
                name: test.name,
                categoryId: document.getElementById('testCategories').value,
                duration: test.duration,
                json: JSON.stringify(test),
            },
            url: "/Test/CreateTest",
            success: function (data) {
                if (data == "OK") {
                    location.href = "/Test"
                }
            }
        })
    }
}

function getQuestions(editorNodes) {
    let questions = new Array();
    for (var i = 0; i < editorNodes.length; i++) {
        let question = new Question();
        let answers = new Array();
        question.question = editorNodes[i].children[3].children[0].innerHTML
        question.answerType = "NAN"
        if (editorNodes[i].children[4].children[0].innerText == "Add radio answers") {
            question.answerType = "radio"
        }
        else {
            question.answerType = "check"
        }

        for (var n = 1; n < editorNodes[i].children[4].children.length; n++) {
            let answer = new Answer();
            answer.isCorrect = editorNodes[i].children[4].children[n].children[1].checked
            answer.answer = editorNodes[i].children[4].children[n].children[4].children[0].innerHTML
            answers.push(answer)
        }

        question.answers = answers;
        questions.push(question)
    }

    return questions;
}


class Test {
    constructor(name, duration, questions) {
        this.name = name;
        this.duration = duration;
        this.questions = questions;
    }
}

class Question {
    constructor(question, answerType, answers) {
        this.question = question;
        this.answerType = answerType;
        this.answers = answers;
    }
}

class Answer {
    constructor(answer, isCorrect) {
        this.answer = answer;
        this.isCorrect = this.isCorrect;
    }
}




function loadTest(id) {
    $.ajax({
        type: "GET",
        dataType: "json",
        url: "/Test/GetTestEdit",
        data: {
            id: id,
        },
        success: function (data) {
            console.log(data)
            console.log(JSON.parse(data.json))
            let obj = JSON.parse(data.json)

            document.getElementById('testName').value = obj.name
            document.getElementById('duration').value = obj.duration
            document.getElementById('testCategories').value = data.categoryId
            for (var i = 0; i < obj.questions.length; i++) {
               
             
                createQuestion();
                realCount = counter - 1;
                document.getElementById("qs-" + realCount).children[0].innerHTML = obj.questions[i].question
                
                if (obj.questions[i].answerType == "radio") {
                 
                    document.getElementById("rb-" + realCount).click()
                    document.getElementById("ir-" + counter).click()
                    for (var n = 0; n < obj.questions[i].answers.length; n++) {
       
                        document.getElementById("ir-" + counter).click()
                        console.log(document.getElementById("ans-" + realCount + "-" + (answerCounter - 1)).children)
                        document.getElementById("ans-" + realCount + "-" + (answerCounter - 1)).children[0].innerHTML = obj.questions[i].answers[n].answer
                        document.getElementById("ans-" + realCount + "-" + (answerCounter - 1)).parentNode.children[1].checked = obj.questions[i].answers[n].isCorrect 
                    }

                    
                }
                else {
                    document.getElementById("cb-" + realCount).click()
                    document.getElementById("ic-" + counter).click()
                    for (var n = 0; n < obj.questions[i].answers.length; n++) {

                        document.getElementById("ic-" + counter).click()
                        document.getElementById("ans-" + realCount + "-" + (answerCounter - 1)).children[0].innerHTML = obj.questions[i].answers[n].answer
                        document.getElementById("ans-" + realCount + "-" + (answerCounter - 1)).parentNode.children[1].checked = obj.questions[i].answers[n].isCorrect
                    }
                }
            }
        }
    })

}