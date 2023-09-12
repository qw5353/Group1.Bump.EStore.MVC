/* BEGIN EXTERNAL SOURCE */

        var options = /******************/;
        var options2 = /*******************/;
        var options3 = /*******************/;

        $("#categoryName1").prop('disabled', true);
        $("#categoryName2").prop('disabled', true);
        $("#categoryName3").prop('disabled', true);


        $(document).ready(function () {
            // 監聽第一個選單的變化
            $('#selectCategory').change(function () {
                var selectedValue = $(this).val();  // 獲取選取的值

                // 根據選取的值生成對應的選項
                if (selectedValue === 'firstCategory') {
                    $("#categoryName1").prop('disabled', false);
                    $("#categoryName2").prop('disabled', true);
                    $("#categoryName3").prop('disabled', true);
                    $('#categoryLevel').val(1);
                    
                } else if (selectedValue === 'secondCategory') {
                    $('#categoryLevel').val(2);
                    $("#categoryName1").prop('disabled', false);
                    $("#categoryName2").prop('disabled', false);
                    $("#categoryName3").prop('disabled', true);
                } else if (selectedValue === 'thirdCategory') {
                    $('#categoryLevel').val(3);
                    $("#categoryName1").prop('disabled', false);
                    $("#categoryName2").prop('disabled', false);
                    $("#categoryName3").prop('disabled', false);
                }
                $('#categoryName1').empty();

                $("#categoryName1").append($('<option value="" disabled selected>第一分類層</option>'));

                for (var i = 0; i < options.length; i++) {
                    var option = $("<option>").val(options[i].FirstCategoryId).text(options[i].FirstCategoryName);
                    $("#categoryName1").append(option);
                }
            });
        });

        $(document).ready(function () {
            // 監聽第二個選單的變化
            $('#categoryName1').change(function () {

                var selectedValue1 = $(this).val();

                // 清空第三個選單
                $('#categoryName2').empty();
                $('#categoryName3').empty();


                for (var i = 0; i < options2.length; i++) {
                    if (+selectedValue1 === +options2[i].FirstCategoryId)
                    {
                        var option2 = $("<option>").val(options2[i].SecondCategoryId).text(options2[i].SecondCategoryName);
                        $("#categoryName2").append(option2);
                    }
                }

                //for (var i = 0; i < options.length; i++) {
                //    var option = $("<option>").val(options[i].FirstCategoryId).text(options[i].FirstCategoryName);
                //    $("#categoryName").append(option);
                //}

            });
        });

        $(document).ready(function () {
            // 監聽第二個選單的變化
            $('#categoryName2').change(function () {

                // 清空第三個選單
                $('#categoryName3').empty();

                for (var i = 0; i < options2.length; i++) {
                    var option2 = $("<option>").val(options2[i].SecondCategoryId).text(options2[i].SecondCategoryId);
                    $("#categoryName2").append(option2);
                }

            });
        });

        $(document).ready(function () {
            // 監聽第二個選單的變化
            $('#categoryName3').change(function () {

                for (var i = 0; i < options3.length; i++) {
                    var option3 = $("<option>").val(options3[i].ThirdCategoryId).text(options3[i].ThirdCategoryName);
                    $("#categoryName3").append(option3);
                }

            });
        });



        //$(document).ready(function () {
        //    // 監聽第二個選單的變化
        //    $('#selectCategory').change(function () {
        //        var selectedValue = $(this).val();  // 獲取選取的值

        //        // 清空第二個選單
        //        $('#categoryName').empty();

        //        // 根據選取的值生成對應的選項
        //        if (selectedValue === 'firstCategory') {
        //            $("#categoryName").prop('disabled', true);
        //            $('#categoryLevel').val(1);
        //        } else if (selectedValue === 'secondCategory') {
        //            for (var i = 0; i < options.length; i++) {
        //                var option = $("<option>").val(options[i].FirstCategoryId).text(options[i].FirstCategoryName);
        //                $("#categoryName").append(option);
        //            }
        //            $('#categoryLevel').val(2);
        //            $("#categoryName").prop('disabled', false);
        //        } else if (selectedValue === 'thirdCategory') {
        //            for (var i = 0; i < options2.length; i++) {
        //                var option2 = $("<option>").val(options2[i].SecondCategoryId).text(options2[i].SecondCategoryName);
        //                $("#categoryName").append(option2);
        //            }
        //            $('#categoryLevel').val(3);
        //            $("#categoryName").prop('disabled', false);
        //        }

        //    });
        //});
    
/* END EXTERNAL SOURCE */
