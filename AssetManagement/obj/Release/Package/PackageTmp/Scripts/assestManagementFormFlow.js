$(document).ready(function () {

    // uncomment to disable click on tabs
    //$(".nav-pills li a[data-toggle=tab]").on("click", function (e) {
    //    //if ($(this).hasClass("disabled")) { 
    //    e.preventDefault();
    //    return false;
    //    //} 
    //});


    $('#installationForm')
            .formValidation({
                framework: 'bootstrap',
                //icon: {
                //    valid: 'glyphicon glyphicon-ok',
                //    invalid: 'glyphicon glyphicon-remove',
                //    validating: 'glyphicon glyphicon-refresh'
                //},
                // This option will not ignore invisible fields which belong to inactive panels
                excluded: ':disabled',
                fields: {
                    assetID: {
                        validators: {
                            notEmpty: {
                                message: 'The institution Id is required'
                            }
                        }
                    },
                    institutionName: {
                        validators: {
                            notEmpty: {
                                message: 'The institution name is required'
                            }
                        }
                    }
                    /* address: {
                         validators: {
                             notEmpty: {
                                 message: 'The address is required'
                             }
                         }
                     },
                     gnNumber: {
                         validators: {
                             notEmpty: {
                                 message: 'The G.N. number is required'
                             }
                         }
                     },
                     gnDate: {
                         validators: {
                             notEmpty: {
                                 message: 'The G.N. date is required'
                             }
                         }
                     },
                     crNumber: {
                         validators: {
                             notEmpty: {
                                 message: 'The C.R. number is required'
                             }
                         }
                     },
                     crDate: {
                         validators: {
                             notEmpty: {
                                 message: 'The C.R. date is required'
                             }
                         }
                     },
                     advisorySocietyName: {
                         validators: {
                             notEmpty: {
                                 message: 'The Advisory Society name is required'
                             }
                         }
                     },
                     advisoryApprovalNumber: {
                         validators: {
                             notEmpty: {
                                 message: 'The Advisory Approval number is required'
                             }
                         }
                     },
                     advisoryRegNumber: {
                         validators: {
                             notEmpty: {
                                 message: 'The Advisory Registration number is required'
                             }
                         }
                     },
                     surveyNo: {
                         validators: {
                             notEmpty: {
                                 message: 'The Survey number is required'
                             }
                         }
                     },
                     khathaNo: {
                         validators: {
                             notEmpty: {
                                 message: 'The Khatha number is required'
                             }
                         }
                     },
                     muncipalNo: {
                         validators: {
                             notEmpty: {
                                 message: 'The Muncipal number is required'
                             }
                         }
                     },
                     estimatedValue: {
                         validators: {
                             notEmpty: {
                                 message: 'The Estimated value  is required'
                             }
                         }
                     },
                     litigationManagement: {
                         validators: {
                             notEmpty: {
                                 message: 'The Litigation Management is required'
                             }
                         }
                     },
                     litigationAsset: {
                         validators: {
                             notEmpty: {
                                 message: 'The Litigation asset is required'
                             }
                         }
                     },
                     extentLand: {
                         validators: {
                             notEmpty: {
                                 message: 'The Extent land is required'
                             }
                         }
                     },
                     advisoryRegDate: {
                         validators: {
                             notEmpty: {
                                 message: 'The Advisory registration date is required'
                             },
                             date: {
                                 format: 'DD/MM/YYYY',
                                 message: 'The date is not a valid'
                             }
                         }
                     },
                     advisoryExpDate: {
                         validators: {
                             notEmpty: {
                                 message: 'The Advisory expiry date is required'
                             },
                             date: {
                                 format: 'DD/MM/YYYY',
                                 message: 'The date is not a valid'
                             }
                         }
                     },
                     gnDate: {
                         validators: {
                             notEmpty: {
                                 message: 'The G.N. date is required'
                             },
                             date: {
                                 format: 'DD/MM/YYYY',
                                 message: 'The date is not a valid'
                             }
                         }
                     },
                     crDate: {
                         validators: {
                             notEmpty: {
                                 message: 'The C.R. date is required'
                             },
                             date: {
                                 format: 'DD/MM/YYYY',
                                 message: 'The date is not a valid'
                             }
                         }
                     }*/


                }
            })

            .bootstrapWizard({
                tabClass: 'nav nav-pills',
                onTabClick: function (tab, navigation, index) {

                    if (assetFlowStatus != "EditAsset") {
                        if (index == 0) {
                            createInstitutionId();
                        }
                    }
                    return validateTab(index);
                },
                onNext: function (tab, navigation, index) {


                    if (assetFlowStatus != "EditAsset") {
                        if (index == 1) {
                            createInstitutionId();
                        }
                    }

                    $(window).scrollTop(0);
                    var numTabs = $('#installationForm').find('.tab-pane').length,
                        isValidTab = validateTab(index - 1);
                    if (!isValidTab) {
                        return false;
                    }

                    if (index === numTabs) {
                        // We are at the last tab

                        $('#installationForm').formValidation('defaultSubmit');
                        clearAllGlobalObjects();

                    }


                    return true;
                },
                onPrevious: function (tab, navigation, index) {
                    return validateTab(index + 1);
                },
                onTabShow: function (tab, navigation, index) {
                    // Update the label of Next button when we are at the last tab
                    var numTabs = $('#installationForm').find('.tab-pane').length;
                    $('#installationForm')
                        .find('.next')
                            .removeClass('disabled')    // Enable the Next button
                            .find('a')
                            .html(index === numTabs - 1 ? 'Save' : 'Next');

                }
            });

    function validateTab(index) {
        var fv = $('#installationForm').data('formValidation'), // FormValidation instance
            // The current tab
            $tab = $('#installationForm').find('.tab-pane').eq(index);

        // Validate the container
        fv.validateContainer($tab);

        var isValidStep = fv.isValidContainer($tab);
        if (isValidStep === false || isValidStep === null) {
            // Do not jump to the target tab
            return false;
        }

        return true;
    }


    function createInstitutionId() {

        institutionId = ($('#selectedState').val()).substring(0, 2);
        institutionId += ($('#selectedDistrict').val()).substring(0, 3);
        institutionId += ($('#selectedTaluk').val()).substring(0, 3);
        institutionId += '00';
        $('#assetID').val(institutionId.toUpperCase());
    }

    $('#rdBtnMPConstituency').click(function () {
        $('#showMPFlow').show();
        $('#showMLAFlow').hide();

    })

    $('#rdBtnMLAConstituency').click(function () {
        $('#showMPFlow').hide();
        $('#showMLAFlow').show();

    })

    $('#rdBtnUrban').click(function () {
        $('#showUrbanFlow').show();
        $('#showRuralFlow').hide();

    })

    $('#rdBtnRural').click(function () {
        $('#showUrbanFlow').hide();
        $('#showRuralFlow').show();

    })

    $('#pickAdvisoryRegDate')
        .datepicker({
            format: 'dd/mm/yyyy'
        })
        .on('changeDate', function (e) {
            // Revalidate the date field
            // $('#installationForm').formValidation('revalidateField', 'advisoryRegDate');
        });

    $('#pickAdvisoryExpDate')
    .datepicker({
        format: 'dd/mm/yyyy'
    })
    .on('changeDate', function (e) {
        // Revalidate the date field
        //$('#installationForm').formValidation('revalidateField', 'advisoryExpDate');
    });

    $('#pickGnDate')
    .datepicker({
        format: 'dd/mm/yyyy'
    })
    .on('changeDate', function (e) {
        // Revalidate the date field
        //$('#installationForm').formValidation('revalidateField', 'gnDate');
    });

    $('#pickCrDate')
    .datepicker({
        format: 'dd/mm/yyyy'
    })
    .on('changeDate', function (e) {
        // Revalidate the date field
        //$('#installationForm').formValidation('revalidateField', 'crDate');
    });


    $('#estimatedDate')
    .datepicker({
        format: 'dd/mm/yyyy'
    })
    .on('changeDate', function (e) {
        // Revalidate the date field
        //$('#installationForm').formValidation('revalidateField', 'advisoryExpDate');
    });

    $('#pickManagementAdvisoryRegDate')
    .datepicker({
        format: 'dd/mm/yyyy'
    })
    .on('changeDate', function (e) {
        // Revalidate the date field
        //$('#installationForm').formValidation('revalidateField', 'managementRegDate');
    });

    $('#pickManagementAdvisoryExpDate')
   .datepicker({
       format: 'dd/mm/yyyy'
   })
   .on('changeDate', function (e) {
       // Revalidate the date field
       //$('#installationForm').formValidation('revalidateField', 'managementExpDate');
   });


    $('#pickManagementTenure')
     .datepicker({
         format: 'dd/mm/yyyy'
     })
     .on('changeDate', function (e) {
         // Revalidate the date field
         // $('#installationForm').formValidation('revalidateField', 'managementTenure');
     });


    $('#pickAdvisoryTenure')
    .datepicker({
        format: 'dd/mm/yyyy'
    })
    .on('changeDate', function (e) {
        // Revalidate the date field
        // $('#installationForm').formValidation('revalidateField', 'advisoryTenure');
    });

    $('#pickAdvisoryAppointmentDate')
    .datepicker({
        format: 'dd/mm/yyyy'
    })
    .on('changeDate', function (e) {
        // Revalidate the date field
        // $('#installationForm').formValidation('revalidateField', 'managementTenure');
    });

    $('#pickManagementAppointmentDate')
    .datepicker({
        format: 'dd/mm/yyyy'
    })
    .on('changeDate', function (e) {
        // Revalidate the date field
        // $('#installationForm').formValidation('revalidateField', 'managementTenure');
    });



    $('#addAsset').click(function () {

        var divs = $('body').find('div[id="divAddAsset"]');

        $.each(divs, function (index, divItem) {
            $(divItem).remove();
        });

        //add new div
        $('body').append('<div id="divAddAsset"></div>');

        $.ajax({
            type: 'Post',
            url: '/AssetAccount/OpenAddAsset',
            success: function (data) {

                $('#divAddAsset').html(data);

            }
        });

        var widthAppWindow = $(window).width();
        var heightAppWindow = $(window).height();


        widthAppWindow = parseInt(widthAppWindow) - parseInt(700);
        heightAppWindow = parseInt(heightAppWindow) - parseInt(400);
        $('#divAddAsset').dialog({

            modal: true,
            width: widthAppWindow,
            height: heightAppWindow,
            autoOpen: false,
            title: "Select Asset Type",
            buttons: {
                OK: function () {
                    var assetType = $('#selectAssetType').val();
                    window.location.href = '/AssetAccount/AddAsset?assetType=' + assetType;
                }
            }
        });

        $('#divAddAsset').dialog('open');


    })


    //$('#selectedManagementType').change(function () {


    //    $.ajax({
    //        type: 'Post',
    //        url: '/AssetAccount/AddManagementDetails',
    //        success: function (data) {

    //            $('#managementCommitteDetails').html(data);

    //        }
    //    });

    //})





    $('#removeAsset').click(function () {

        window.location.href = '/AssetAccount/RemoveAsset';
    })

    $('#editAsset').click(function () {

        //'@Url.Action("{OpenEditAsset}", "{AssetAccount}")'
        window.location.href = '/AssetAccount/OpenEditAsset';
    })



    function popUpForImageUpload(divID, url) {

        var divs = $('body').find('div[id="' + divID + '"]');

        $.each(divs, function (index, divItem) {
            $(divItem).remove();
        });

        //add new div
        $('body').append('<div id="' + divID + '"></div>');

        $.ajax({
            type: 'Post',
            url: url,
            success: function (data) {
                $('#' + divID + '').html(data);
            }
        });

        var widthAppWindow = $(window).width();
        var heightAppWindow = $(window).height();


        widthAppWindow = parseInt(widthAppWindow) - parseInt(600);
        heightAppWindow = parseInt(heightAppWindow) - parseInt(350);

        $('#' + divID + '').dialog({
            modal: true,
            width: widthAppWindow,
            height: heightAppWindow,
            autoOpen: false,
            title: "Upload",

        });

        $('#' + divID + '').dialog('open');
    }


    $('#assetStatusUpload').click(function () {
        popUpForImageUpload('divassetStatusUpload', '/Image/OpenAssetStatusUpload');
    })


    $('#gnNumberUpload').click(function () {
        popUpForImageUpload('divgnNumberUpload', '/Image/OpenGnNumberUpload');
    })

    $('#crNumberUpload').click(function () {
        popUpForImageUpload('divcrNumberUpload', '/Image/OpenCrNumberUpload');
    })

    $('#courtOrderUpload').click(function () {
        popUpForImageUpload('divcourtOrderUpload', '/Image/OpenCourtOrderUpload');
    })

    $('#surveyNoUpload').click(function () {
        popUpForImageUpload('divsurveyNoUpload', '/Image/OpenSurveyNoUpload');
    })

    $('#khathaNoUpload').click(function () {
        popUpForImageUpload('divkhathaNoUpload', '/Image/OpenKhathaNoUpload');
    })

    $('#municipalNoUpload').click(function () {
        popUpForImageUpload('divmunicipalNoUpload', '/Image/OpenMunicipalNoUpload');
    })

    $('#northUpload').click(function () {
        popUpForImageUpload('divnorthUpload', '/Image/OpenNorthUpload');
    })

    $('#eastUpload').click(function () {
        popUpForImageUpload('diveastUpload', '/Image/OpenEastUpload');
    })

    $('#southUpload').click(function () {
        popUpForImageUpload('divsouthUpload', '/Image/OpenSouthUpload');
    })

    $('#westUpload').click(function () {
        popUpForImageUpload('divwestUpload', '/Image/OpenWestUpload');
    })

    $('#estimatedValueUpload').click(function () {
        popUpForImageUpload('divestimatedValueUpload', '/Image/OpenEstimatedValueUpload');
    })

    $('#litigationManagementUpload').click(function () {
        popUpForImageUpload('divlitigationManagementUpload', '/Image/OpenLitigationManagementUpload');
    })

    $('#litigationAssetUpload').click(function () {
        popUpForImageUpload('divlitigationAssetUpload', '/Image/OpenLitigationAssetUpload');
    })

    $('#geoStampedUpload').click(function () {
        popUpForImageUpload('divgeoStampedUpload', '/Image/OpenGeoStampedUpload');
    })

    function clearAllGlobalObjects() {

        assetStatusImageArray = [];
        gnNumberImageArray = [];
        crNumberImageArray = [];
        courtOrderImageArray = [];
        surveyNoImageArray = [];
        khathaNoImageArray = [];
        municipalNoImageArray = [];
        northImageArray = [];
        eastImageArray = [];
        southImageArray = [];
        westImageArray = [];
        estimatedValueImageArray = [];
        litigationManagementUploadImageArray = [];
        litigationAssetUploadImageArray = [];
        geoStampedUploadImageArray = [];
    }




    $('#selectedDivision').change(function () {
        var selVal = $('#selectedDivision').val();

        $.ajax({
            type: 'Post',
            url: '/AssetAccount/GetDistrict',
            data: { 'division': selVal },
            success: function (data) {

                if (data.result != null) {
                    var dd1 = document.getElementById("selectedDistrict");
                    dd1.innerHTML = '';

                    for (i = 0; i < data.result.length; i++) {
                        dd1.options[dd1.length] = new Option(data.result[i], data.result[i]);
                    }
                }

                $('#selectedDistrict').trigger('change');

            }
        });
    })


    $('#selectedDistrict').change(function () {
        var selVal = $('#selectedDistrict').val();

        $.ajax({
            type: 'Post',
            url: '/AssetAccount/GetTaluk',
            data: { 'district': selVal },
            success: function (data) {

                if (data.result != null) {
                    var dd1 = document.getElementById("selectedTaluk");
                    dd1.innerHTML = '';

                    for (i = 0; i < data.result.length; i++) {
                        dd1.options[dd1.length] = new Option(data.result[i], data.result[i]);
                    }
                }
                $('#selectedTaluk').trigger('change');
            }
        });



        $.ajax({
            type: 'Post',
            url: '/AssetAccount/GetMPList',
            data: { 'district': selVal },
            success: function (data) {

                if (data.result != null) {
                    var dd1 = document.getElementById("selectedMPConstituency");
                    dd1.innerHTML = '';

                    for (i = 0; i < data.result.length; i++) {
                        dd1.options[dd1.length] = new Option(data.result[i], data.result[i]);
                    }
                }

            }
        });

        $.ajax({
            type: 'Post',
            url: '/AssetAccount/GetMLAList',
            data: { 'district': selVal },
            success: function (data) {

                if (data.result != null) {
                    var dd1 = document.getElementById("selectedMLAConstituency");
                    dd1.innerHTML = '';

                    for (i = 0; i < data.result.length; i++) {
                        dd1.options[dd1.length] = new Option(data.result[i], data.result[i]);
                    }
                }

            }
        });



    })


    $('#selectedTaluk').change(function () {
        var selVal = $('#selectedTaluk').val();

        var dd1 = document.getElementById("selectedTalukPanchayat");
        dd1.innerHTML = '';
        dd1.options[dd1.length] = new Option(selVal, selVal);

        $('#selectedTalukPanchayat').trigger('change');

    })



    $('#selectedTalukPanchayat').change(function () {
        var selVal = $('#selectedTalukPanchayat').val();

        $.ajax({
            type: 'Post',
            url: '/AssetAccount/GetGramaPanchayath',
            data: { 'talukP': selVal },
            success: function (data) {

                if (data.result != null) {
                    var dd1 = document.getElementById("selectedGramaPanchayat");
                    dd1.innerHTML = '';

                    for (i = 0; i < data.result.length; i++) {
                        dd1.options[dd1.length] = new Option(data.result[i], data.result[i]);
                    }
                }
                $('#selectedGramaPanchayat').trigger('change');
            }
        });
    })



    $('#selectedGramaPanchayat').change(function () {
        var selVal = $('#selectedGramaPanchayat').val();

        $.ajax({
            type: 'Post',
            url: '/AssetAccount/GetVillage',
            data: { 'gramaPanchayat': selVal },
            success: function (data) {

                if (data.result != null) {
                    var dd1 = document.getElementById("selectedVillage");
                    dd1.innerHTML = '';

                    for (i = 0; i < data.result.length; i++) {
                        dd1.options[dd1.length] = new Option(data.result[i], data.result[i]);
                    }
                }
            }
        });
    })



    $('#selectedDistrict').change(function () {

        $('#setDistrictName').text($('#selectedDistrict').val());

    });






    $('#homeBtn').click(function () {
        var status = confirm("Are you sure you want to navigate away from this page?\n\nPress OK to continue, or Cancel to stay on the current page");
        if (status) {
            return true;
        }
        else {
            return false;
        }
    })



    $('#editMasterBtn1').click(function () {

        var divs = $('body').find('div[id="divAddAsset"]');

        $.each(divs, function (index, divItem) {
            $(divItem).remove();
        });

        //add new div
        $('body').append('<div id="divAddAsset"></div>');

        $.ajax({
            type: 'Post',
            url: '/AssetAccount/OpenTestGallery',
            success: function (data) {

                $('#divAddAsset').html(data);

            }
        });

        var widthAppWindow = $(window).width();
        var heightAppWindow = $(window).height();


        widthAppWindow = parseInt(widthAppWindow) - parseInt(300);
        heightAppWindow = parseInt(heightAppWindow) - parseInt(100);
        $('#divAddAsset').dialog({

            modal: true,
            width: widthAppWindow,
            height: heightAppWindow,
            autoOpen: false,
            title: "Select Asset Type",
            buttons: {
                OK: function () {
                }
            }
        });

        $('#divAddAsset').dialog('open');


    })


    $('#selectedAssetTypeList').change(function () {
        var arr = $(this).val();
        if (arr != null) {
            if (arr.indexOf("Others") != -1) {
                $("#showAssetTypeOthers").show();
            }
            else {
                $("#showAssetTypeOthers").hide();
            }
        }
        else {
            $("#showAssetTypeOthers").hide();
        }
    })


    $('#selectedAssetStatusList').change(function () {
        var arr = $(this).val();
        if (arr != null) {
            if (arr.indexOf("Others") != -1) {
                $("#showAssetStatusOthers").show();
            }
            else {
                $("#showAssetStatusOthers").hide();
            }
        }
        else {
            $("#showAssetStatusOthers").hide();
        }
    })

    $('#northToSouth').change(function () {
        var ns = Number($(this).val());
        var ew = Number($('#eastToWest').val());
        $('#total').val(ns * ew);
    })

    $('#eastToWest').change(function () {
        var ew = Number($(this).val());
        var ns = Number($('#northToSouth').val());
        $('#total').val(ns * ew);
    })


}); // end of main function