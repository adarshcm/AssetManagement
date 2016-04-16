$(document).ready(function () {



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
                    institutionName: {
                        validators: {
                            notEmpty: {
                                message: 'The institution name is required'
                            }
                        }
                    },
                    address: {
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
                                format: 'MM/DD/YYYY',
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
                                format: 'MM/DD/YYYY',
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
                                format: 'MM/DD/YYYY',
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
                                format: 'MM/DD/YYYY',
                                message: 'The date is not a valid'
                            }
                        }
                    }


                }
            })

            .bootstrapWizard({
                tabClass: 'nav nav-pills',
                onTabClick: function (tab, navigation, index) {
                    return validateTab(index);
                },
                onNext: function (tab, navigation, index) {
                    var numTabs = $('#installationForm').find('.tab-pane').length,
                        isValidTab = validateTab(index - 1);
                    if (!isValidTab) {
                        return false;
                    }

                    if (index === numTabs) {
                        // We are at the last tab

                        // Uncomment the following line to submit the form using the defaultSubmit() method
                        $('#installationForm').formValidation('defaultSubmit');


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
            format: 'mm/dd/yyyy'
        })
        .on('changeDate', function (e) {
            // Revalidate the date field
            $('#installationForm').formValidation('revalidateField', 'advisoryRegDate');
        });

    $('#pickAdvisoryExpDate')
    .datepicker({
        format: 'mm/dd/yyyy'
    })
    .on('changeDate', function (e) {
        // Revalidate the date field
        $('#installationForm').formValidation('revalidateField', 'advisoryExpDate');
    });

    $('#pickGnDate')
    .datepicker({
        format: 'mm/dd/yyyy'
    })
    .on('changeDate', function (e) {
        // Revalidate the date field
        $('#installationForm').formValidation('revalidateField', 'gnDate');
    });

    $('#pickCrDate')
    .datepicker({
        format: 'mm/dd/yyyy'
    })
    .on('changeDate', function (e) {
        // Revalidate the date field
        $('#installationForm').formValidation('revalidateField', 'crDate');
    });

    $('#pickManagementAdvisoryRegDate')
    .datepicker({
        format: 'mm/dd/yyyy'
    })
    .on('changeDate', function (e) {
        // Revalidate the date field
        $('#installationForm').formValidation('revalidateField', 'managementRegDate');
    });

    $('#pickManagementAdvisoryExpDate')
   .datepicker({
       format: 'mm/dd/yyyy'
   })
   .on('changeDate', function (e) {
       // Revalidate the date field
       $('#installationForm').formValidation('revalidateField', 'managementExpDate');
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


    $('#assetStatusUpload').click(function () {

        var divs = $('body').find('div[id="divAssetStatusUpload"]');

        $.each(divs, function (index, divItem) {
            $(divItem).remove();
        });

        //add new div
        $('body').append('<div id="divAssetStatusUpload"></div>');

        $.ajax({
            type: 'Post',
            url: '/AssetAccount/OpenAssetStatusUpload',
            success: function (data) {
                $('#divAssetStatusUpload').html(data);
            }
        });

        var widthAppWindow = $(window).width();
        var heightAppWindow = $(window).height();


        widthAppWindow = parseInt(widthAppWindow) - parseInt(700);
        heightAppWindow = parseInt(heightAppWindow) - parseInt(400);

        $('#divAssetStatusUpload').dialog({
            modal: true,
            width: widthAppWindow,
            height: heightAppWindow,
            autoOpen: false,
            title: "Upload",

        });

        $('#divAssetStatusUpload').dialog('open');

    })

    



}); // end of main function