let users = new Object()
let aspRoles = new Object()

function getUsers() {
    $.ajax({
        type: "GET",
        dataType: "json",
        url: "/User/GetUsers",
        success: function (data) {
            console.log(data)
            users = data
            $.ajax({
                type: "GET",
                dataType: "json",
                url: "/Role/GetAspRoles",
                success: function (data) {
                    aspRoles = data
                    generateTable(users, aspRoles)
                }
            })
        }
    })
}
getUsers()

function generateTable(users, aspRoles) {
    let usersTbody = document.getElementById('usersTbody');
    usersTbody.innerHTML = "";
    for (var i = 0; i < users.length; i++) {

        let unitName = "No unit assigned";
        let aspRole = "No role assigned"
        if (users[i].unit.length > 0) {
            unitName = users[i].unit[0].name;
        }

        if (users[i].aspNetUserRoles.length > 0) {
            aspRole = users[i].aspNetUserRoles[0].role.name;
        }


            usersTbody.insertAdjacentHTML("beforeend", "<tr> <td> " + users[i].userName + " </td>   <td> " + aspRole + " <td>"+unitName+" </td> <td></td>   <td><button onclick='RemoveUser(" + i + ")' class='btn btn-danger'>Delete </button> </td>  <td><button class='btn btn-secondary'>Edit </button> </td> </tr>");
     
    }

}

function RemoveUser(index) {
    let confirmation = confirm("Are you sure that you want to delete user " + users[index].userName + "?");
    if (confirmation == true) {
        $.ajax({
            type: "POST",
            dataType: "json",
            url: "/User/RemoveUser",
            data: {
                postUser: JSON.stringify(users[index]),
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