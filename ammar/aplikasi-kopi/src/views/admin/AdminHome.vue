<template>
    <div>
      <AdminNavbar />
      <AdminHero />
  
      <!-- New Products Section -->
      <section class="container mt-8">
        <h2 class="font-bold text-3xl md:text-4xl mb-4">New Products</h2>
        <div class="flex flex-wrap">
          <div
            v-for="product in newproducts"
            :key="product.id"
            class="w-full px-4 lg:w-1/2 xl:w-1/3 mb-4"
          >
            <AdminCardProduk :product="product" />
          </div>
        </div>
      </section>
  
      <!-- Best Products Section -->
      <section class="container mt-8">
        <h2 class="font-bold text-3xl md:text-4xl mb-4">Best Products</h2>
        <div class="flex flex-wrap">
          <div
            v-for="product in bestproducts"
            :key="product.id"
            class="w-full px-4 lg:w-1/2 xl:w-1/3 mb-4"
          >
            <AdminCardProduk :product="product" />
          </div>
        </div>
      </section>
  
      <AdminFooter />
    </div>
  </template>
  
  <script>
  import AdminNavbar from "../../components/admin/AdminNavbar.vue";
  import AdminHero from "../../components/admin/AdminHero.vue";
  import AdminCardProduk from "../../components/admin/AdminCardProduk.vue";
  import AdminFooter from "../../components/admin/AdminFooter.vue";
  import axios from "axios";
  
  export default {
    name: "AdminHome",
    components: {
      AdminNavbar,
      AdminHero,
      AdminCardProduk,
      AdminFooter,
    },
    data() {
      return {
        bestproducts: [],
        newproducts: [],
      };
    },
    methods: {
      setBestProducts(data) {
        this.bestproducts = data;
      },
      setNewProducts(data) {
        this.newproducts = data;
      },
    },
    mounted() {
      // Fetch Best Products
      axios
        .get("http://localhost:3000/best-produks")
        .then((response) => this.setBestProducts(response.data))
        .catch((error) => console.error(error));
  
      // Fetch New Products
      axios
        .get("http://localhost:3000/produks-baru")
        .then((response) => this.setNewProducts(response.data))
        .catch((error) => console.error(error));
    },
  };
  </script>
  