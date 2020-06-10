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
        if (users[i].aspNetUserRoles.length > 0) {
            usersTbody.insertAdjacentHTML("beforeend", "<tr> <td> " + users[i].userName + " </td>   <td> " + users[i].aspNetUserRoles[0].role.name + " </td> <td> <td></td>   <td><button onclick='RemoveUser(" + i + ")' class='btn btn-danger'>Delete </button> </td>  <td><button class='btn btn-secondary'>Edit </button> </td> </tr>");
        }
        else {
            usersTbody.insertAdjacentHTML("beforeend", "<tr> <td> " + users[i].userName + " </td>   <td> No role assigned </td> </td> <td> <td></td>  <td><button onclick='RemoveUser(" + i + ")' class='btn btn-danger'>Delete </button> </td>  <td><button class='btn btn-secondary'>Edit </button> </td> </tr>");

        }
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