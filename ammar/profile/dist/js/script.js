
// navbar fixed
window.onscroll = function (){
    const header = document.querySelector('header');
    const fixednav = header.offsetTop;

    if(window.pageYOffset > fixednav){
        header.classList.add('navbar-fixed');
        header.classList.remove('navbar-gradient');
    }else{
        header.classList.remove('navbar-fixed');
        header.classList.add('navbar-gradient');
    }
};



// hamburger
const hamburger = document.querySelector('#hamburger');
const navMenu = document.querySelector('#nav-menu');

hamburger.addEventListener('click',function(){
    hamburger.classList.toggle('hamburger-active');
    navMenu.classList.toggle('hidden');

});