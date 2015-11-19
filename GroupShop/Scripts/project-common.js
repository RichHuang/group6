$(document).ready(function () {

    //bootstrap-select buty buty select ui 
    $('select').select2();

    $(".select2-tag").select2({ tags: [] });


    ////////////////////////////
    $(".productbasetext").typeahead({
        name: 'ProductBase',
        valueKey: 'Barcode',
        prefetch: '/api/ProductBase/',
        remote: '/api/ProductBase/?term=%QUERY',
        template: '<p><strong>{{Barcode}}</strong> – {{Name}}</p>',
        engine: Hogan
    }).addClass("form-control").keypress(function (e) {
        if (e.keyCode == 13) {
            productbaseAddClick($(this).val());
        }

    });

        //.on('typeahead:selected', function (e, datum) {
        //$(this).parent().parent().parent().find(".productbaseselected").append("<li><span class='label label-info'>" + datum.cname +  "<a href='#' class='removebutton-2'>x</a></span></li>");
    //});


    $(this).delegate(".productbaseaddbutton", "click", function() {
        var text = $(this).parent().parent().find(".productbasetext").val();
        productbaseAddClick(text);
    });

    $(this).delegate(".productbasetext", "typeahead:selected", function (e, datum) {

        productbaseSelected(e, datum);
    });
    ////////////////////////



    $(".storeproducttext").typeahead({
        name: 'StoreProduct',
        valueKey: 'Barcode',
        prefetch: '/api/StoreProduct/',
        remote: '/api/StoreProduct/?term=%QUERY',
        template: '<p><strong>{{Barcode}}</strong> – {{Name}}</p>',
        engine: Hogan
    }).addClass("form-control").keypress(function (e) {
        if (e.keyCode == 13) {
            storeproductAddClick($(this).val());
        }

    });


    $(this).delegate(".storeproductaddbutton", "click", function () {
        var text = $(this).parent().parent().find(".storeproducttext").val();
        storeproductAddClick(text);
    });

    $(this).delegate(".storeproducttext", "typeahead:selected", function (e, datum) {

        storeproductSelected(e, datum);
    });

    
    




    //$(".removebutton-2").click(function (e) {
    //    alert();
    //    $(this).parent().parent().remove();
    //    return false;
    //});

    //$.ui.autocomplete.prototype._renderMenu = function (ul, items) {
    //    var that = this;
    //    $.each(items, function (index, item) {
    //        that._renderItemData(ul, item);
    //    });
    //    $(ul).find("li:odd").addClass("odd");
    //};

    //$.ui.autocomplete.prototype._renderItem = function (ul, item) {
    //    return $("<li>")
    //      .attr("data-value", item.medno)
    //      .append($("<a>").text(item.cname))
    //      .appendTo(ul);
    //};



    //$("#add_productId").autocomplete({
    //source: "/api/MedicineBase/",
    //    minLength: 4,
    //    select: function (event, ui) {
    //        $(this).val(ui.item.med_no);
    //    },
    //    messages: {
    //        noResults: '',
    //        results: function () { }
    //    }
    //});


});