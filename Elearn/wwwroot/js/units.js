let units = new Object()

function getUsers() {
    $.ajax({
        type: "GET",
        dataType: "json",
        url: "/Unit/GetUnits",
        success: function (data) {
            console.log(data)
            units = data
         generateTable(units)
        }
    })
}
getUsers()

function generateTable(units) {
    let usersTbody = document.getElementById('unitsTbody');
    usersTbody.innerHTML = "";
    for (var i = 0; i < units.length; i++) {
        if (units[i].user != null) {
            usersTbody.insertAdjacentHTML("beforeend", "<tr> <td> " + units[i].name + " </td>   <td> " + units[i].description + " </td> <td>" + units[i].user.userName + "</td>  <td>" + units[i].createTime.replace("T", " ") + "</td> <td><button onclick='RemoveUnit(" + i + ")' class='btn btn-danger'>Delete </button> </td>  <td><button class='btn btn-secondary'>Edit </button> </td> </tr>");

        }
        else {
            usersTbody.insertAdjacentHTML("beforeend", "<tr> <td> " + units[i].name + " </td>   <td> " + units[i].description + " </td> <td>No User</td>  <td>" + units[i].createTime.replace("T", " ") + "</td> <td><button onclick='RemoveUnit(" + i + ")' class='btn btn-danger'>Delete </button> </td>  <td><button class='btn btn-secondary'>Edit </button> </td> </tr>");

        }
   }

}

function RemoveUnit(index) {
    let confirmation = confirm("Are you sure that you want to delete unit " + units[index].name + "?");
    if (confirmation == true) {
        $.ajax({
            type: "POST",
            dataType: "json",
            url: "/Unit/RemoveUnit",
            data: {
                postUnit: JSON.stringify(units[index]),
            },
            success: function (data) {
                if (data != "BAD") {
                    location.reload();
                }
                else {
                    alert('Something went wrong..')
                }

            }
        })
    }
}