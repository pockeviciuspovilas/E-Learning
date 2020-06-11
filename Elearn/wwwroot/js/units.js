let units = new Object()

function getUnits() {
    $.ajax({
        type: "GET",
        dataType: "json",
        url: "/Unit/GetUnits",
        success: function (data) {
            units = data
            generateTable(units)
        }
    })
}

function generateTable(units) {
    let usersTbody = document.getElementById('unitsTbody');
    if (usersTbody != null) {
        usersTbody.innerHTML = "";
        for (var i = 0; i < units.length; i++) {
            if (units[i].user != null) {
                usersTbody.insertAdjacentHTML("beforeend", "<tr> <td> " + units[i].name + " </td>   <td> " + units[i].description + " </td> <td>" + units[i].user.userName + "</td>  <td>" + units[i].createTime.replace("T", " ") + "</td> <td><button onclick='RemoveUnit(" + i + ")' class='btn btn-danger'>Delete </button> </td>  <td><button class='btn btn-secondary' onclick='loadEdit(" + units[i].id + ")'>Edit </button> </td>  <td><button class='btn btn-warning' onclick='editDesign(" + units[i].id + ")'>Design </button> </td> </tr>");

            }
            else {
                usersTbody.insertAdjacentHTML("beforeend", "<tr> <td> " + units[i].name + " </td>   <td> " + units[i].description + " </td> <td>No User</td>  <td>" + units[i].createTime.replace("T", " ") + "</td> <td><button onclick='RemoveUnit(" + i + ")' class='btn btn-danger'>Delete </button> </td>  <td><button class='btn btn-secondary' onclick='loadEdit(" + units[i].id + ")'>Edit </button> </td>   <td><button class='btn btn-warning' onclick='editDesign(" + units[i].id + ")'>Design </button> </td> </tr>");

            }
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

function loadEdit(index) {
    location.href = "Unit/Form?id=" + index
}

function editDesign(index) {
    location.href = "Unit/Design?id=" + index
}

function unitControl() {
    let unitUserSelect = document.getElementById('unitUserSelect')
    getUnits()
    document.getElementById('state').innerText = 'Create Unit'
    document.getElementById('unitCreateButton').innerText = 'Create'
    if (unitUserSelect != null) {
        getAvailableUsers(unitUserSelect);
        let url = new URL(window.location.href)
        if (url.searchParams.has("id")) {
            document.getElementById('state').innerText = 'Update Unit'
            document.getElementById('unitCreateButton').innerText = 'Update'
            setUnit(url.searchParams.get("id"));

        }
    }
}

window.onload = unitControl;

function setUnit(unitId) {
    $.ajax({
        type: "GET",
        dataType: "json",
        url: "/Unit/GetUnit",
        data: {
            unitId: unitId,
        },
        success: function (data) {
  
            let section = document.getElementById('section');
            section.children[0].children[1].value = data.name
            section.children[1].children[1].value = data.description
        }
    })

}


let availableUsers = new Object();
function getAvailableUsers(unitUserSelect) {
    unitUserSelect.innerHTML = "";
    $.ajax({
        type: "GET",
        dataType: "json",
        url: "/User/GetAvailableUsers",
        success: function (data) {
            availableUsers = data;
            for (var i = 0; i < availableUsers.length; i++) {
                unitUserSelect.insertAdjacentHTML("beforeend", "<option val = '" + i + "'>" + availableUsers[i].userName + " </option>")
            }
        }
    })
}

function SaveUnit(parent) {
    let unitUserSelect = document.getElementById('unitUserSelect')
    let name = parent.children[0].children[1].value
    let description = parent.children[1].children[1].value
    let userIndex = unitUserSelect.options[unitUserSelect.selectedIndex].index;

    let url = new URL(window.location.href)
    if (url.searchParams.has("id")) {

        $.ajax({
            type: "POST",
            dataType: "json",
            data: {
                name: name,
                description: description,
                user: JSON.stringify(availableUsers[userIndex]),
                id: url.searchParams.get("id"),
            },
            url: "/Unit/UpdateUnit",
            success: function (data) {
                if (data == "OK") {
                    location.href = "/Unit"
                }
            }
        })

    }
    else {
        $.ajax({
            type: "POST",
            dataType: "json",
            data: {
                name: name,
                description: description,
                user: JSON.stringify(availableUsers[userIndex]),
            },
            url: "/Unit/InsertUnit",
            success: function (data) {
                if (data == "OK") {
                    location.href = "/Unit"
                }
            }
        })
    }

}