//Logout from site form
$("#aLogout").click(function () {
    $("#formLogout").submit();
});

//Rollup car create form in list
$(document).ready(function () {
    $("#btnCreateCar").click(function () {
        $("#formCreateCar").slideToggle("fast");
    });
});

//Show uploaded file name
$(".custom-file-input").on("change", function () {
    var fileName = $(this).val().split("\\").pop();
    $(this).siblings(".custom-file-label").addClass("selected").html(fileName);
});

//Bootstrap form validate
(function () {
    'use strict';
    window.addEventListener('load', function () {
        var forms = document.getElementsByClassName('needs-validation');
        var validation = Array.prototype.filter.call(forms, function (form) {
            form.addEventListener('submit', function (event) {
                if (form.checkValidity() === false) {
                    event.preventDefault();
                    event.stopPropagation();
                }
                form.classList.add('was-validated');
            }, false);
        });
    }, false);
})();