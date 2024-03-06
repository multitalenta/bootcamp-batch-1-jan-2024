<template>
    <!-- Start stampilan user -->
    <nav>
        <header
            class="bg-gradient-to-r from-white to-slate-300 absoulte top-0 left-0 w-full flex items-center z-10 justify-evenly">
            <div class="container">
                <div class="flex items-center justify-between relative">
                    <div class="px-4">
                        <RouterLink to="/admin-home" class="font-bold text-xl text-primary block py-6">NgopsBar</RouterLink>
                    </div>

                    <!-- elemen kanan -->
                    <div class="flex items-center">
                        <button id="hamburger" name="hamburger" type="button" class="block absolute right-4 lg:hidden">
                            <span class="hamburger-line transition duration-300 ease-in-out origin-top-left bg-dark"></span>
                            <span class="hamburger-line transition duration-300 ease-in-out bg-dark"></span>
                            <span
                                class="hamburger-line transition duration-300 ease-in-out origin-bottom-left bg-dark"></span>
                        </button>
                        <!-- NAVBAR -->
                        <nav id="nav-menu"
                            class="hidden absolute py-5 bg-white shadow-lg rounded-lg max-w-[250px] w-full  right-4 top-full lg:block lg:static lg:max-w-full lg:bg-transparent lg:shadow-none lg:rounded-none dark:shadow-slate-500">
                            <ul class="block lg:flex">
                                <li class="group">
                                    <RouterLink to="/admin-home"
                                        class="text-base text-dark py-2 mx-8 flex group-hover:text-primary lg:mx-4">Home
                                    </RouterLink>

                                </li>
                                <li class="group">
                                    <RouterLink to=""
                                        class="text-base text-dark py-2 mx-8 flex group-hover:text-primary lg:mx-4">Menu
                                    </RouterLink>
                                </li>
                                <li class="group">
                                    <RouterLink to=""
                                        class="text-base text-dark py-2 mx-8 flex group-hover:text-primary lg:mx-4">Tambah Produk
                                    </RouterLink>
                                </li>
                                <li class="group relative">
                                    <RouterLink to="/keranjang"
                                        class="text-base text-dark py-2 mx-8 flex group-hover:text-primary lg:mx-4">
                                        keranjang<i class="fa-solid fa-cart-shopping text-orange-400"></i>
                                        <span
                                            class="bg-transparent px-2 rounded-full absolute top-0 -mt-2 left-[120px] lg:-mt-2 lg:left-[100px] ">{{updateKeranjang ? updateKeranjang.length : jumlah_pasanans.length}}</span>
                                    </RouterLink>
                                </li>
                            </ul>
                        </nav>

                    </div>
                </div>
            </div>
        </header>
        <!-- HEADER END -->
    </nav>
    <!-- end tampilan user -->
</template>


<script>
import axios from 'axios';

export default {
    name: "AdminNavbar",
    components: {
        axios,
    },
    data(){
        return{
            jumlah_pasanans: []
        }
    },
    props:['updateKeranjang'],
    methods:{
        setJumlah(data){
            this.jumlah_pasanans = data
        }
    },
    mounted(){
        axios.get('http://localhost:3000/keranjangs')
            .then((response) => this.setJumlah(response.data))
            .catch ((error) =>console.log(error))
    }
};
</script>

<script setup>
import { ref, onMounted } from 'vue';



const navbarFixed = ref(false);
const hamburgerActive = ref(false);

onMounted(() => {
    window.addEventListener('scroll', handleScroll);
    const hamburger = document.querySelector('#hamburger');
    const navMenu = document.querySelector('#nav-menu');

    if (hamburger && navMenu) {
        hamburger.addEventListener('click', () => {
            hamburgerActive.value = !hamburgerActive.value;
            navMenu.classList.toggle('hidden', !hamburgerActive.value);
        });
    }
});

function handleScroll() {
    const header = document.querySelector('header');
    const fixedNav = header.offsetTop;

    navbarFixed.value = window.pageYOffset > fixedNav;
}

</script>