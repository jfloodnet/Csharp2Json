$(function () {
    $('#generate').click(function () {
        clearErrors();

        post($('#csharp').val())
            .done(function (json) {
                $('#json').text(JSON.stringify(json, undefined, 2));
                $('#generated-json').show();
            })
            .error(function (data) {
                var compileErrors = JSON.parse(data.responseText);
                showErrors(compileErrors);
        });
    });

    function post(csharp){
        return $.ajax
        ({
            type: "POST",        
            url: '/',
            dataType: 'json',            
            async: false,
            data: csharp
        });
    }

    $("#copy").click(function () {
        if ($("#copy").text() === "Back") {
            undocopy()
        } else {
            $("#copyCode").val($("#json").text().trim());
            $("#json").hide();
            prepare("#copyCode");
            $("#copy").text("Back");
            $("#copyHelp").show();
            $("#copyCode").show();
            presentForCopying("copyCode")
        }
    });

    var undocopy = function () {
        $("#copyCode").hide();
        $("#copyHelp").hide();
        $("#json").show();
        $("#copy").text("Copy")
    };
    var presentForCopying = function (a) {        
        var code = document.getElementById(a);
        if (document.body.createTextRange) {
            var text = document.body.createTextRange();
            text.moveToElementText(code);
            text.select()
        } else if (window.getSelection) {
            var selection = window.getSelection();
            if (selection.setBaseAndExtent) {
                selection.setBaseAndExtent(code, 0, code, 1)
            } else {
                var text = document.createRange();
                text.selectNodeContents(code);
                selection.removeAllRanges();
                selection.addRange(text)
            }
        }
    };
    var prepare = function (a) {
        var b = $(a).val();
        var c = b.split("\n").length;
        $(a).attr("rows", c)
    }

    $('.close').click(function () {
        var id = $(this).data('parent-id');
        $('#' + id).hide();
    });

    function clearErrors() {
        $('#compile-error').hide();
        $('#compile-error .error').remove();
    }

    function showErrors(compileErrors) {
        var html = "";
        $.each(compileErrors, function (i, error) {
            html += '<p class="error">' + error + '</p>';
        });
        $('#compile-error .alert-message').append(html);
        $('#compile-error').show();
    }

});