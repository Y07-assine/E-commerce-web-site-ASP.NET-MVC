const navOpen = document.querySelector(".nav__hamburger");
const find = document.querySelector(".nav-search");
const navClose = document.querySelector(".close__toggle");
const menu = document.querySelector(".nav__menu");
const navContainer = document.querySelector(".nav__menu");
const menu_search = document.querySelector(".search-bar");
const Close = document.querySelector(".close__search");

navOpen.addEventListener("click", function () {
    
    menu.classList.add("open");
    document.body.classList.add("active");
    navContainer.style.left = "-100px";
    navContainer.style.width = "30rem";
});
navClose.addEventListener("click", function () {
    menu.classList.remove("open");
    document.body.classList.remove("active");
    menu.removeAttribute("style");
});

find.addEventListener("click", function () {
    console.log("test");
    menu_search.classList.add("open");
    document.body.classList.add("active");
    menu_search.style.width = "100%";
    menu_search.style.height = "7rem";

});
Close.addEventListener("click", function () {
    menu_search.classList.remove("open");
    document.body.classList.remove("active");
    menu_search.removeAttribute("style");
});



//=============
//slider-banner
//=============

$('.slider-one')
    .not('.slick-initialized')
    .slick({
        autoplay: true,
        autoplaySpeed: 3000,
        dots: true,
        nextArrow: ".item-slider .slider-btn .next",
        prevArrow: ".item-slider .slider-btn .prev"
        
    });
//=================
//end-slider-banner
//=================



function dropdown(button) {
    var x = button.id;
    switch (x) {
        case 'drop1':
            document.getElementById("myDropdown1").classList.toggle("show_content"); break;
        case 'drop2':
            document.getElementById("myDropdown2").classList.toggle("show_content"); break;
        case 'drop3':
            document.getElementById("myDropdown3").classList.toggle("show_content"); break;
        case 'drop4':
            document.getElementById("myDropdown4").classList.toggle("show_content"); break;

    }
}

window.onclick = (event) => {
    if (!event.target.matches('.dropbtn')) {
        var dropdowns = document.getElementsByTagName("dropdown-content");
        for (var i = 0; i < dropdowns.length; i++) {
            var openDropdown = dropdowns[i];
            if (openDropdown.classList.contains('show_content'))
                openDropdown.classList.remove('show_content');

        }
    }
}


$("#list_product .owl-carousel").owlCarousel({
    loop: true,
    nav: true,
    dots: false,
    responsive: {
        0: {
            items: 2
        },
        600: {
            items: 3
        },
        1000: {
            items: 5
        }
    }
});

//=========
//quantité
//=========

let $qty_up = $(".augmente_qt");
let $qty_down = $(".diminue_qt");

$qty_up.click(function (e) {
    let $input = $(`#quantite[data-id='${$(this).data("id")}']`);
    if ($input.val() >= 1 && $input.val() <= 9) {
        $input.val(function (i, oldval) {
            return ++oldval;
        });
    }

});
$qty_down.click(function (e) {
    let $input = $(`#quantite[data-id='${$(this).data("id")}']`);
    if ($input.val() > 1 && $input.val() <= 10) {
        $input.val(function (i, oldval) {
            return --oldval;
        });
    }

});


