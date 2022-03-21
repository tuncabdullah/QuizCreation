$(document).ready(function () {
    $('#titleSelected').on('change', function (e) {
        let val = $(this).val();
        $.ajax({
            type: 'POST',
            url: '/Exam/GetDescription',
            data: { Id: val }
        }).then(function (data) {
            $("#description").val(data.description);
            $("#title").val(data.title);
        })
    })
    
});
//Seçilen şıklar ve değişim 
function clickChoice(element, color) {
    const parent = document.getElementById(element.parentNode.id)
    let elements = parent.getElementsByClassName("choice");
    let elemId = element.id;
    for (var i = 0; i < elements.length; i++) {
        if (elements[i].id == elemId) {
            elements[i].style.backgroundColor = color;
        } else {
            elements[i].style.backgroundColor = "white";
        }
    }
}



$(document).on('click', '.btnCompleteTheExam', function (e) {
    let val = $(this).val();
    $.ajax({
        type: 'GET',
        url: '/Exam/GetQuestionList',
        data: { Id: val }
    }).then(function (data) {
        console.log(data)
         
        const form = document.getElementById("form")
        let elements = form.getElementsByClassName("choice");
      
        for (var i = 0; i < elements.length; i++) {
            if (elements[i].style.backgroundColor == 'gray') {
                const parent = document.getElementById(elements[i].parentNode.id);
                const quest = data.find(elm => elm.id == elements[i].parentNode.id);
                var tru = elements[i].id.includes(quest.trueOption);
                if (tru) {
                    elements[i].style.backgroundColor = "green";
                } else {
                    elements[i].style.backgroundColor = "red";
                }
            }
        }
    })
});