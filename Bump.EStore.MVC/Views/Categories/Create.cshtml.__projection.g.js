/* BEGIN EXTERNAL SOURCE */


        //$(document).ready(function() {
        //   ��ť�Ĥ@�ӿ�檺�ܤ�
        //    $('#selectCategory').change(function() {
        //    var selectedValue = $(this).val();  // ����������

        //     �M�ŲĤG�ӿ��
        //        $('#categoryName').empty();

        //     �ھڿ�����ȥͦ��������ﶵ
        //        if (selectedValue === 'firstCategory') {
        //            $("#categoryName").prop('disabled', true);
        //        } else if (selectedValue === 'secondCategory') {
        //            $('#categoryName').append('<option value="�k�n">�k�n</option>');
        //            $("#categoryName").prop('disabled', false);
        //        } else if (selectedValue === 'thirdCategory') {
        //            $('#categoryName').append('<option value="1">�_��</option>');
        //            $('#categoryName').append('<option value="2">����</option>');
        //            $('#categoryName').append('<option value="3">����˳�</option>');
        //            $('#categoryName').append('<option value="4">÷��</option>');
        //            $('#categoryName').append('<option value="5">�B���k</option>');
        //            $('#categoryName').append('<option value="6">�ҷ�</option>');
        //            $("#categoryName").prop('disabled', false);
        //        }

        //  });
        //});
        var options = /******************/;
        var options2 = /*******************/;
        $(document).ready(function () {
            // ��ť�Ĥ@�ӿ�檺�ܤ�
            $('#selectCategory').change(function () {
                var selectedValue = $(this).val();  // ����������

                // �M�ŲĤG�ӿ��
                $('#categoryName').empty();

                // �ھڿ�����ȥͦ��������ﶵ
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
