<template>
    <div class="bg-white rounded-xl shadow-lg overflow-hidden mb-10 ">
        <img :src=" '/src/assets/img/' + product.gambar " alt="best-produk" class="w-full h-60 object-cover" />
        <div class="py-8 px-6">
            <h3><a href="#" class="block mb-3 font-semibold text-xl text-drak truncate">
               {{ product.nama }}
            </a></h3>
            <p class="font-medium text-base text-secondary mb-2 truncate">{{ product.desc }} 
                <span></span></p>
            <p class="font-medium text-base text-secondary mb-3"> 
                <a :href="product.link.url" target="_blank">Baca Selengkapnya</a>
            </p>
            <p class="font-medium text-base text-secondary mb-6">{{formattedPrice}}</p> 
            <RouterLink :to="'/detail/'+ product.id" class="font-medium text-sm text-white bg-primary py-4 px-6 rounded-lg hover:opacity-80">
                Pesan
            </RouterLink>
        </div>
    </div>   
</template>

<script>
import { RouterLink } from 'vue-router';

export default {
    name: 'AdminCardProduk',
    props: ['product'],
    components: { RouterLink },
    computed : {
    formattedPrice() {
      const price = this.product.harga || 0;
      return new Intl.NumberFormat('id-ID', { style: 'currency', currency: 'IDR' }).format(price);
    },
  },
}

</script>

<style>

</style>