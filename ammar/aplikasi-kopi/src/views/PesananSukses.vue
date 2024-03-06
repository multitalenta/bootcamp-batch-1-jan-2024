<template>
  <Navbar/>
  <div class="container">
    <div class="justify-content-center mt-10 mb-16 lg:mt-5 lg:mb-5">
        <div class="text-center">
            <h2 class="text-2xl">
                <strong>Sukses !!!</strong>
            </h2>
            <h3 class="text-2xl">
                <strong>Pesanan Anda Segera Di Proses Silahkan Menenunggu...</strong>
            </h3>
        </div>
    </div>
    <div class="w-full mx-auto self-end mb-28 lg:mb-5 px-4 lg:w-1/2 group">
        <div class="mt-5 lg:mt-10  group-hover:animate-pulse transition duration-100">
            <img src="../assets/img/2.svg" alt=""  class=""/>
        </div> 
    </div>
  </div>
  <Footer/>
</template>

<script>
import Navbar from '@/components/Navbar.vue';
import Footer from '@/components/Footer.vue';

export default {
    name: 'pesanan-sukses',
    components: {
        Navbar,
        Footer,
    },

}
</script>

<style>

</style>