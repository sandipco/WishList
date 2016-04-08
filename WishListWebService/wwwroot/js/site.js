(function () {



    var ele = $("#username");
    ele.text("Sandip Timsina");

    var main = $("main");
    main.on("mouseenter", function () {
        main.style = "background-color: #888;";
    });
    main.on("mouseleave",function () {
        main.style = "";
    });

})();