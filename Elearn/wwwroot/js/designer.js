function setNavbarColor(col) {
    console.log(col)
    document.getElementById('navbarColor').style.backgroundColor = col
}

function setHeaderColor(col) {
    console.log(col)
    document.getElementById('thead').style.backgroundColor = col
}

function setDataColor(col) {
    console.log(col)
    document.getElementById('tbody').style.backgroundColor = col
}

function setBackgroundColor(col) {
    console.log(col)
    document.getElementById('container').style.backgroundColor = col
}


function saveDesign() {
    let url = new URL(window.location.href)


    $.ajax({
        type: "POST",
        dataType: "json",
        data: {
            id: url.searchParams.get("id"),
            backgroundColor: document.getElementById('containerColor').value,
            navColor: document.getElementById('navColor').value,
            navbarImage: document.getElementById('blah').src,
            theadColor: document.getElementById('tableHeaderColor').value,
            tbodyColor: document.getElementById('tableDataColor').value,
        },
        url: "/Unit/CreateUnitDesign",
        success: function (data) {
            if (data == "OK") {
                location.href = "/Unit"
            }
        }
    })

}

    function readURL(input) {
            if (input.files && input.files[0]) {
                var reader = new FileReader();

                reader.onload = function (e) {
                    $('#blah')
                        .attr('src', e.target.result)
                        .width(200)
                        .height(100);
                };

                reader.readAsDataURL(input.files[0]);
            }
        }