let url = new URL(window.location.href)
if (url.searchParams.has("id")) {
let categories = new Object();
    $.ajax({
        type: "GET",
        dataType: "json",
        url: "/User/GetCategoriesByUnit",
        data: {
            unitId: url.searchParams.get("id")
        },
        success: function (data) {
            categories = data;
            let unitCategoriesSelect = document.getElementById('unitCategoriesSelect');
            unitCategoriesSelect.innerHTML = "";
            for (var i = 0; i < categories.length; i++) {
                unitCategoriesSelect.insertAdjacentHTML("beforeend", "<option value='"+categories[i].id+"'>"+categories[i].name+"</option>")
            }
        }
    })
}
