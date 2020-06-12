let users = new Object()
let aspRoles = new Object()
let unitRoles = new Object()
let url = new URL(window.location.href)
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

                    if (!url.searchParams.has("id")) {
                        generateTable(users, aspRoles)
                    }
                    else {

                        addDataToForm()
                    }
                    console.log(aspRoles)
                }
            })
        }
    })
}
getUsers()
let user = new Object();
function addDataToForm() {
    $.ajax({
        type: "GET",
        dataType: "json",
        url: "/Role/GetUnitCategories",
        data: {
            userId: url.searchParams.get("id"),
        },
        success: function (data) {
            unitRoles = data
            console.log(unitRoles)
            user = new Object();
            for (var i = 0; i < users.length; i++) {
                if (users[i].id == url.searchParams.get("id")) {
                    user = users[i]
                    document.getElementById('username').innerHTML = "Edit user " + user.userName
                    let rolesSelect = document.getElementById('rolesSelect')
                    let unitRolesSelect = document.getElementById('unitRolesSelect')
                    rolesSelect.innerHTML = unitRolesSelect.innerHTML = ""
                    for (var i = 0; i < aspRoles.length; i++) {
                        rolesSelect.insertAdjacentHTML("beforeend", "<option value='" + aspRoles[i].id + "'> " + aspRoles[i].name + " </option>")
                    }
                    for (var i = 0; i < unitRoles.length; i++) {
                        unitRolesSelect.insertAdjacentHTML("beforeend", "<option value='" + unitRoles[i].id + "'> " + unitRoles[i].name + " </option>")
                    }

                    break
                }
            }
        }
    })
}

function UpdateUser() {
    let rolesSelect = document.getElementById('rolesSelect')
    let unitRolesSelect = document.getElementById('unitRolesSelect')
    let unitId = unitRolesSelect.options[unitRolesSelect.selectedIndex]
    
    unitId = -1;
 
    $.ajax({
        type: "POST",
        dataType: "json",
        url: "/User/UpdateUser",
        data: {
            userId: user.id,
            roleId: rolesSelect.value,
            unitId: unitId,
        },
        success: function (data) {
            location.href = "/User"
        }
    })
}

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


        usersTbody.insertAdjacentHTML("beforeend", "<tr> <td> " + users[i].userName + " </td>   <td> " + aspRole + " <td>" + unitName + " </td> <td></td>   <td><button onclick='RemoveUser(" + i + ")' class='btn btn-danger'>Delete </button> </td>  <td><button class='btn btn-secondary' onclick='LoadUserEdit(" + i + ")'>Edit </button> </td> </tr>");

    }

}

function LoadUserEdit(index) {
    location.href = 'User/Form?id=' + users[index].id;
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