let users = new Object()
let aspRoles = new Object()
let unitRoles = new Object()
let url = new URL(window.location.href)
let unitCategories = new Object();
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
                    $.ajax({
                        type: "GET",
                        dataType: "json",
                        url: "/User/GetUnitCategories",
                        success: function (data) {
                            console.log(data)
                            unitCategories = data;
                            let testCategoriesTBody = document.getElementById('unitCategoriesTBody')
                            testCategoriesTBody.innerHTML = "";
                            for (var i = 0; i < unitCategories.length; i++) {
                                testCategoriesTBody.insertAdjacentHTML("beforeend", "<tr> <td>" + unitCategories[i].name + "</td> <td><button class='btn btn-danger' onclick='RemoveUnitCategory(" + unitCategories[i].id + ")'> Delete </button> </td>  <td><button class='btn btn-warning' onclick='EditUnitCategory(" + unitCategories[i].id + ")' > Edit </button> </td>  </tr>")
                            }
                        }
                    })

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
                    for (var i = 0; i < unitCategories.length; i++) {
                        unitRolesSelect.insertAdjacentHTML("beforeend", "<option value='" + unitCategories[i].id + "'> " + unitCategories[i].name + " </option>")
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
            unitId: unitRolesSelect.value,
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



let globalId = -1;
function OpenModal() {
    document.getElementById('unitCategoryModalLabel').innerText = "Create unit category"
    document.getElementById('categoryInput').value = null;
    $('#unitCategoryModal').modal('show');
    globalId = -1;
}

function EditUnitCategory(id) {
    document.getElementById('unitCategoryModalLabel').innerText = "Edit unit category"
    for (var i = 0; i < unitCategories.length; i++) {
        if (unitCategories[i].id == id) {
            document.getElementById('categoryInput').value = unitCategories[i].name;
            break;
        }

    }

    $('#unitCategoryModal').modal('show');
    globalId = id;
}

function RemoveUnitCategory(id) {
    let confirmation = confirm("Are you sure that you want to delete this category?");
    if (confirmation == true) {
        $.ajax({
            type: "POST",
            dataType: "json",
            url: "/User/RemoveUnitCategory",
            data: {
                id: id,
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

function createUnitCategory() {
    if (globalId == -1) {
        $.ajax({
            type: "POST",
            dataType: "json",
            data: {
                name: document.getElementById('categoryInput').value,

            },
            url: "/User/CreateUnitCategory",
            success: function (data) {
                if (data == "OK") {
                    location.reload()
                }
            }
        })
    }
    else {
        $.ajax({
            type: "POST",
            dataType: "json",
            data: {
                name: document.getElementById('categoryInput').value,
                id: globalId,
            },
            url: "/User/EditUnitCategory",
            success: function (data) {
                if (data == "OK") {
                    location.reload()
                }
            }
        })
    }
}
