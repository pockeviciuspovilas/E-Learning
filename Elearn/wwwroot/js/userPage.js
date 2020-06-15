let assigns = new Object();
$.ajax({
    type: "GET",
    dataType: "json",
    url: "/Assign/GetCurrentAssigns",
    success: function (data) {
        assigns = data
        console.log(assigns)
        let testsTBody = document.getElementById('testsTBody')
        testsTBody.innerHTML = "";
        for (var i = 0; i < assigns.length; i++) {
            testsTBody.insertAdjacentHTML("beforeend", "<tr> <td>"+assigns[i].test.name+"</td>  <td><button class='btn btn-primary' onclick='StartTest("+assigns[i].id+")' btn-primary'>Start test </button></td>   </tr>")
        }
     
    }
})

function StartTest(id) {
    let assign = new Object();
    for (var i = 0; i < assigns.length; i++) {
        if (assigns[i].id == id) {
            assign = assigns[i]
        }
    }
    let confirmation = confirm("Are you sure that you want to start test " + assign.test.name + "? Once you start, you can't go back!");
    if (confirmation == true) {
        location.href = "../Test/Window?id=" + id;
    }
}