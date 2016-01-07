jQuery("#select tr")
.on("mouseenter",
function () {
    jQuery(this).addClass("hover");
})

.on("mouseleave",
function () {
    jQuery(this).removeClass("hover");
});
