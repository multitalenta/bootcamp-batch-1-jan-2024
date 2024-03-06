<template>
  <Navbar />
  <Hero />
  
    <!-- start menu baru-->
    <div class="container">
        <div class="w-full px-4">
            <h2 class="font-bold text-3xl md:text-4xl bg-gradient-to-r from-slate-300 to-primary bg-clip-text text-transparent mb-10 px-4"> Menu Baru </h2>
            <div class="flex flex-wrap">
                <div id="Menubaru" class="w-full px-4 lg:w-1/2 xl:w-1/3" v-for="product in newproducts" :key="product.id">
                <Produk :product="product" />
                </div>
        </div>
        </div>
    </div>
    <!-- end menu baru -->

  <!-- start best Produk -->
  <div class="container">
        <div class="w-full px-4">
            <h2 class="font-bold text-3xl md:text-4xl bg-gradient-to-r from-slate-300 to-primary bg-clip-text text-transparent mb-10 px-4"> Best Menu </h2>
            <div class="flex flex-wrap">
                <div id="Bestmenu" class="w-full px-4 lg:w-1/2 xl:w-1/3" v-for="product in bestproducts" :key="product.id">
                <Produk :product="product" />
                </div>
        </div>
        </div>
    </div>
    <!-- end best produk -->

    <Footer />
    
</template>

<script>
import Navbar from '@/components/Navbar.vue';
import Hero from '@/components/Hero.vue';
import Produk from '@/components/CardProduk.vue';
import axios from 'axios';
import Footer from '@/components/Footer.vue';



export default {
    name:"Home",
        components : {
            Navbar,
            Hero,
            Produk,
            Footer

        },
    data() {
        return {
            bestproducts: [],
            newproducts:[],
        };
    },
    methods: {
        setBestProducts(data) {
            this.bestproducts = data;
        },
        setNewProducts(data){
            this.newproducts = data;
        }
    },
    mounted() {
        // best produk
        axios.get('http://localhost:3000/best-produks')
            .then((response) => this.setBestProducts(response.data))
            .catch ((error) =>console.log(error))
        // end best produk

        // produk baru
        axios.get('http://localhost:3000/produks-baru')
            .then((response) => this.setNewProducts(response.data))
            .catch ((error) =>console.log(error))
        // end produk baru 
    }
};
</script>