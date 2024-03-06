<template>
  <div>
    <Navbar />

    <!-- Mulai Produk Terbaik -->
    <div class="container">
      <div class="w-full px-4">
        <div class="flex flex-wrap justify-between">
          <h2
            class="font-bold text-3xl md:text-4xl bg-gradient-to-r from-slate-300 to-primary bg-clip-text text-transparent mb-10 px-4 mt-4">
            SEMUA Menu
          </h2>
          <label for="search" class="mt-4 mr-3">
            <input v-model="search" type="text" id="search" placeholder="Cari.." class="px-3 py-2 border "
              @input="searchKopi" />
          </label>
        </div>
        <div class="flex flex-wrap">
          <div id="CardProduk" class="w-full px-4 lg:w-1/2 xl:w-1/3" v-for="product in filteredProducts"
            :key="product.id">
            <Produk :product="product" />
          </div>
        </div>
      </div>
    </div>
    <!-- Akhir Produk Terbaik -->
    <Footer />
  </div>
</template>
  
<script>
import { ref, onMounted } from 'vue';
import Navbar from '@/components/Navbar.vue';
import Produk from '@/components/CardProduk.vue';
import axios from 'axios';
import Footer from '@/components/Footer.vue';

export default {
  name: 'Menu',
  components: {
    Navbar,
    Produk,
    Footer,
  },
  setup() {
    const search = ref('');
    const products = ref([]);
    const filteredProducts = ref([]);

    const setProducts = (data) => {
      products.value = data;
      updateFilteredProducts();
    };

    const searchKopi = async () => {
      try {
        const response = await axios.get(`https://localhost:7038/api/Product?q=${search.value}`);
        setProducts(response.data);
      } catch (error) {
        console.error(error);
      }
    };

    const updateFilteredProducts = () => {
      filteredProducts.value = products.value.filter((product) =>
        product.nama.toLowerCase().includes(search.value.toLowerCase()) && product.isReady
      );
    };

    onMounted(() => {
      axios
        .get('https://localhost:7038/api/Product')
        .then((response) => setProducts(response.data))
        .catch((error) => console.log(error));
    });

    return {
      search,
      filteredProducts,
      searchKopi,
    };
  },
};
</script>

  
<style>/* Gaya Anda dapat ditempatkan di sini */</style>
  