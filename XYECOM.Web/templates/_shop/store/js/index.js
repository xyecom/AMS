// JavaScript Document
$(document).ready(function () {
    //tabs
    $("div.door_container").tabs("div.tab_con", { tabs: "div.TabTitle li", event: "mouseover", current: "active" })
    $("div.nTab2").tabs("div.tab_con2", { tabs: "div.TabTitle li", event: "mouseover", current: "active" })
    $("ul.adHD").tabs("div.adImg img", { event: "mouseover", effect: "fade", rotate: true }).slideshow({ autoplay: true });
    $("#all-category").tabs("div.kinds", { tabs: "div.category-t a", event: "mouseover" })
    $("#all-category a.primitive").click(function () {
        $("#all-category").data("tabs").click(0);
        $("#all-category .category-t li").removeClass("now").removeClass("normal");
        return false;
    });
    $("#all-category .category-t a").mouseover(function () {
        $("#all-category .category-t li").removeClass("now").addClass("normal");
        $(this).parent().addClass("now");
    });
    $("#tupian").scrollable({ circular: true }).autoscroll({ autoplay: true });
    $("#showCard").mouseover(function () {
        $("#listCartDetail").toggle('slow');
    }).mouseout(function () { $("#listCartDetail").toggle('slow'); })
})