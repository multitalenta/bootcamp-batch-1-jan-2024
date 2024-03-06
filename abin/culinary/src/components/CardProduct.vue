<template>
        <div class="">
      <div class="rounded-lg shadow-lg mb-8 overflow-hidden lg:mr-7 mx-auto max-w-80">
        <img :src=" '/product/' + product.gambar" alt="" class="w-80 h-52 cover object-cover">
        <div class="mt-3 px-4 pb-2">
          <h2 class="text-2xl font-semibold">{{ product.nama }}</h2>
          <p class="text-xl mt-2 text-slate-600"> <span class="font-medium ">Rp.</span> {{ product.harga }}</p>
          <p class="mb-7 mt-2 text-slate-500">{{ product.keterangan }}</p>
            <div class="mb-4">
              <RouterLink :to="'/foods/'+product.id" class="button-order group"><i class="fa fa-cart-plus mr-2 text-white   group-hover:text-highlight"></i>Order</RouterLink>
        </div>
    </div>
    </div>


  </div>
</template>

<script>
export default {
    name: 'CardProduct',
    props: ['product']
}   
</script>

<style>

</style>