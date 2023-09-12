/* BEGIN EXTERNAL SOURCE */


        //$(document).ready(function() {
        //   監聽第一個選單的變化
        //    $('#selectCategory').change(function() {
        //    var selectedValue = $(this).val();  // 獲取選取的值

        //     清空第二個選單
        //        $('#categoryName').empty();

        //     根據選取的值生成對應的選項
        //        if (selectedValue === 'firstCategory') {
        //            $("#categoryName").prop('disabled', true);
        //        } else if (selectedValue === 'secondCategory') {
        //            $('#categoryName').append('<option value="攀登">攀登</option>');
        //            $("#categoryName").prop('disabled', false);
        //        } else if (selectedValue === 'thirdCategory') {
        //            $('#categoryName').append('<option value="1">鉤環</option>');
        //            $('#categoryName').append('<option value="2">器械</option>');
        //            $('#categoryName').append('<option value="3">身體裝備</option>');
        //            $('#categoryName').append('<option value="4">繩索</option>');
        //            $('#categoryName').append('<option value="5">冰雪攀</option>');
        //            $('#categoryName').append('<option value="6">朔溪</option>');
        //            $("#categoryName").prop('disabled', false);
        //        }

        //  });
        //});
        var options = /******************/;
        var options2 = /*******************/;
        $(document).ready(function () {
            // 監聽第一個選單的變化
            $('#selectCategory').change(function () {
                var selectedValue = $(this).val();  // 獲取選取的值

                // 清空第二個選單
                $('#categoryName').empty();

                // 根據選取的值生成對應的選項
                if (selectedValue === 'firstCategory') {
                    $("#categoryName").prop('disabled', true);
                } else if (selectedValue === 'secondCategory') {
                    for (var i = 0; i < options.length; i++) {
                        var option = $("<option>").val(options[i].FirstCategoryId).text(options[i].FirstCategoryName);
                        $("#categoryName").append(option);
                    }
                    $('#categoryName').append(<input type="hidden" id="firstCategory" name="firstCategory" value="firstCategory" />);
                    $('form').append('<input type="hidden" name="categoryLevel">')
                    $("#categoryName").prop('disabled', false);
                } else if (selectedValue === 'thirdCategory') {
                    for (var i = 0; i < options2.length; i++) {
                        var option2 = $("<option>").val(options2[i].SecondCategoryId).text(options2[i].SecondCategoryName);
                        $("#categoryName").append(option2);
                    }
                    $('#categoryName').append(<input type="hidden" id="secondCategory" name="secondCategory" value="secondCategory" />);
                    $("#categoryName").prop('disabled', false);
                }

            });
        });

        

    
/* END EXTERNAL SOURCE */
