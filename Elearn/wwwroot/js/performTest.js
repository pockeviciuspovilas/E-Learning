let test = new Object();
let url = new URL(window.location.href)

$.ajax({
    type: "GET",
    dataType: "json",
    data: {
        assignId: url.searchParams.get("id"),
    },
    url: "/Test/GetTest",
    success: function (data) {
        test = data
        console.log(test)
    }
})