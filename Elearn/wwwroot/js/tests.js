function createTestCategory() {
    if (globalId == -1) {
        $.ajax({
            type: "POST",
            dataType: "json",
            data: {
                name: document.getElementById('categoryInput').value,

            },
            url: "/Test/CreateTestCategory",
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
            url: "/Test/EditTestCategory",
            success: function (data) {
                if (data == "OK") {
                    location.reload()
                }
            }
        })
    }
}

let globalId = -1;
let testCategories = new Object();
let tests = new Object();
$.ajax({
    type: "GET",
    dataType: "json",
    url: "/Test/GetTestCategories",
    success: function (data) {
        console.log(data)
        testCategories = data;
        let testCategoriesTBody = document.getElementById('testCategoriesTBody')
        testCategoriesTBody.innerHTML = "";
        for (var i = 0; i < testCategories.length; i++) {
            testCategoriesTBody.insertAdjacentHTML("beforeend", "<tr> <td>" + testCategories[i].name + "</td> <td><button class='btn btn-danger' onclick='RemoveTestCategory(" + testCategories[i].id + ")'> Delete </button> </td>  <td><button class='btn btn-warning' onclick='EditTestCategory(" + testCategories[i].id + ")' > Edit </button> </td>  </tr>")
        }

        $.ajax({
            type: "GET",
            dataType: "json",
            url: "/Test/GetTests",
            success: function (data) {
                console.log(data)
                tests = data;
                let testsTBody = document.getElementById('testsTBody')
                testsTBody.innerHTML = "";
                for (var i = 0; i < tests.length; i++) {
                    let testUser = null;
                    if (tests[i].user != null) {
                        testUser = tests[i].user.userName
                    }
                    let category = null;
                    for (var n = 0; n < testCategories.length; n++) {
                        if (testCategories[n].id == tests[i].categoryId) {
                            category = testCategories[i].name
                            break;
                        }
                    }
                    testsTBody.insertAdjacentHTML("beforeend", "<tr> <td>" + tests[i].name + "</td> <td>" + testUser + "</td> <td>" + tests[i].insertTime.replace("T", " ") + "</td> <td>" + tests[i].updateUserId + "</td> <td>" + tests[i].updateTime + "</td> <td>" + category + "</td> <td><button class='btn btn-danger' onclick='RemoveTest(" + tests[i].id + ")'> Delete </button> </td>  <td><button class='btn btn-warning' onclick='EditTest(" + tests[i].id + ")' > Edit </button> </td>  </tr>")
                }
            }
        })


    }
})

function OpenModal() {
    document.getElementById('testCategoryModalLabel').innerText = "Create test category"
    document.getElementById('categoryInput').value = null;
    $('#testCategoryModal').modal('show');
    globalId = -1;
}

function EditTestCategory(id) {
    document.getElementById('testCategoryModalLabel').innerText = "Edit test category"
    for (var i = 0; i < testCategories.length; i++) {
        if (testCategories[i].id == id) {
            document.getElementById('categoryInput').value = testCategories[i].name;
            break;
        }

    }

    $('#testCategoryModal').modal('show');
    globalId = id;
}

function RemoveTestCategory(id) {
    let confirmation = confirm("Are you sure that you want to delete this category? All tests asociated with this category will be deleted too!");
    if (confirmation == true) {
        $.ajax({
            type: "POST",
            dataType: "json",
            url: "/Test/RemoveTestCategory",
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

function RemoveTest(id) {
    let confirmation = confirm("Are you sure that you want to delete this test? All asociations with this test will be deleted too!");
    if (confirmation == true) {
        $.ajax({
            type: "POST",
            dataType: "json",
            url: "/Test/RemoveTest",
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