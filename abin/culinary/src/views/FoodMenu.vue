<template>
  <NavbarTop/>
  <div>
    <div class="container md:px-6 mx-auto mt-12">
      <div class="flex flex-wrap mx-auto justify-center md:justify-between">
        <div class="text-3xl md:ml-12 mb-5 sm:mr-12">Culinary <span class="font-bold">Menu</span></div>
        <div class="">
          <input 
            v-model="searchQuery" 
            type="search" 
            placeholder="Cari Makanan" 
            class="px-8 py-2 border-2 border-slate-500 rounded-lg lg:mr-20 focus:ring focus:ring-highlight focus:outline-none" 
            @input="searchFood"> <!-- Gunakan event @input untuk memanggil searchFood saat input berubah -->
        </div>
      </div>
      <div class="flex flex-wrap mt-10 justify-evenly sm:mr-[3px]">
        <div class="" v-for="product in filteredProducts" :key="product.id"> <!-- Gunakan filteredProducts untuk menampilkan hasil pencarian -->
          <CardProduct :product="product" />
        </div>
      </div>
    </div>
  </div>
</template>

<script>
import CardProduct from '@/components/CardProduct.vue'
import axios from 'axios'
import NavbarTop from '@/components/NavbarTop.vue'

export default {
  name : 'FoodMenu',
  components: {
    CardProduct,
    NavbarTop
  },
  data() {
    return {
      product: [],
      searchQuery: '' // Tambahkan properti searchQuery
    };
  },
  methods: {
    setProduct(data) {
      this.product = data;
    },
    searchFood() {
      // Method ini akan memfilter produk berdasarkan searchQuery
      // Jika searchQuery kosong, akan menampilkan semua produk
      // Jika tidak, akan menampilkan produk yang cocok dengan query
      this.filteredProducts = this.product.filter(product => 
        product.nama.toLowerCase().includes(this.searchQuery.toLowerCase())
      );
    }
  },
  computed: {
    filteredProducts() {
      // Compute untuk menyaring produk berdasarkan searchQuery
      if (!this.searchQuery) {
        return this.product;
      }
      return this.product.filter(product => 
        product.nama.toLowerCase().includes(this.searchQuery.toLowerCase())
      );
    }
  },

  mounted() {
    axios
      .get('https://localhost:7038/api/Product')
      .then((response) =>{
        const readyProducts = response.data.filter(product => product.isReady === true);
      this.setProduct(readyProducts);
    })
    .catch((error) => console.log(error))
  }
}
</script>
