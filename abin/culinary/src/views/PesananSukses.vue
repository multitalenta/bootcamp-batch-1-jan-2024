<template>
  <NavbarTop/>
  <h1 class="text-center text-lg font-medium text-slate-500">Pesanan Sukses</h1>

  <div class="container flex flex-col justify-center mx-auto px-4 md:px-0">
    <h1 class="text-center text-3xl font-bold text-slate-700">Pesananmu Sedang Dibuat, Mohon Tunggu</h1>  
    <img src="../assets/img/waiting.gif" alt="" class="w-[600px] mx-auto mt-3">
  </div>
</template>

<script>
import NavbarTop from '@/components/NavbarTop.vue'

export default {
  name: 'OrderCreated',
  components: {
    NavbarTop
  },

}
  
  
</script>

<style>
/* Style yang mungkin diperlukan */
</style>
