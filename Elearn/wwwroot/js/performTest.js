let assign = new Object();
let url = new URL(window.location.href)
let test = new Object();

$.getScript('//cdn.quilljs.com/1.3.6/quill.js', function () {
    console.log("loaded")

    $.ajax({
        type: "GET",
        dataType: "json",
        data: {
            assignId: url.searchParams.get("id"),
        },
        url: "/Test/GetTest",
        success: function (data) {
            assign = data
            console.log(assign)
            test = JSON.parse(assign.test.json)
            console.log(test)
            buildTest()
            jQuery(function ($) {
                display = $('#time');
                startTimer(60 * test.duration, display);
            });


        }
    })

});

let usedTime = 0;

function startTimer(duration, display) {
    var timer = duration, minutes, seconds;
    setInterval(function () {
        minutes = parseInt(timer / 60, 10)
        seconds = parseInt(timer % 60, 10);

        minutes = minutes < 10 ? "0" + minutes : minutes;
        seconds = seconds < 10 ? "0" + seconds : seconds;

        display.text(minutes + ":" + seconds);
        usedTime = timer
        if (timer == 0) {
            endTest()
        }

        if (--timer < 0) {
            timer = duration;

        }
    }, 1000);
}

function buildTest() {
    let testContainer = document.getElementById('testContainer')

    testContainer.innerHTML = "";

    for (var i = 0; i < test.questions.length; i++) {

        testContainer.insertAdjacentHTML("beforeend", "<div id='q-" + i + "'>    <div class='quill-question' ><div id='qs-" + i + "'>  </div>      <div id='answers-" + i + "'>  </div>  </div>")
        createQuillQuestion(i)
        document.getElementById('qs-' + i).children[0].innerHTML = test.questions[i].question

        for (var n = 0; n < test.questions[i].answers.length; n++) {


            let answersDiv = document.getElementById('answers-' + i);
            if (test.questions[i].answerType == "radio") {
                answersDiv.insertAdjacentHTML("beforeend", " <div class='quill-answer' ><input type='radio' name='" + i + "' /><div id='ans-" + i + "-" + n + "'>    </div> </div>")
            } else {
                answersDiv.insertAdjacentHTML("beforeend", " <div class='quill-answer' ><input type='checkbox' name='" + i + "' /><div id='ans-" + i + "-" + n + "'>    </div> </div>")

            }
            createQuillAnswer(i + "-" + n)
            document.getElementById('ans-' + i + '-' + n).children[0].innerHTML = test.questions[i].answers[n].answer


        }

    }


}


function createQuillQuestion(id) {

    new Quill(`#qs-${id}`, {
        readOnly: true
    });
}

function createQuillAnswer(id) {

    new Quill(`#ans-${id}`, {
        readOnly: true
    });
}



function endTest() {
    let testContainer = document.getElementById('testContainer')
    let answers = new Array()
    for (var i = 0; i < testContainer.children.length; i++) {
        let ansArr = new Array();
        for (var n = 0; n < testContainer.children[i].children[0].children[1].children.length; n++) {
            let answer = testContainer.children[i].children[0].children[1].children[n].children[0].checked
            ansArr.push(answer)
        }
        answers.push(ansArr)
    }
    calculateMark(answers)
}

function calculateMark(answers) {
    let goodCount = 0;
    for (var i = 0; i < answers.length; i++) {
        let isOk = true;
        for (var n = 0; n < answers[i].length; n++) {
            if (test.questions[i].answers[n].isCorrect != answers[i][n]) {
                isOk = false;
                break;
            }
        }
        if (isOk == true) {
            goodCount++;
        }
    }
    alert("Your mark: " + goodCount / answers.length * 10 + "!")


    $.ajax({
        type: "GET",
        dataType: "json",
        data: {
            assignId: url.searchParams.get("id"),
            json: JSON.stringify(answers),
            mark: goodCount / answers.length * 10,
            usedTime: (test.duration * 60) - usedTime,
        },
        url: "/Test/SaveResults",
        success: function (data) {
            location.href = '../Home/UserPage'
        }
    })

}