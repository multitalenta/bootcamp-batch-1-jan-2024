<template>
  <div class="container flex flex-wrap lg:flex-nowrap justify-evenly lg:mt-20 mx-auto">
    <!-- LEFT -->
    <div class="w-full mx-auto lg:mt-20 px-4 flex flex-col items-center py-5 md:py-12 text-center">
      <h1 class="text-4xl"><strong class="mr-2">Delicious Food Menu's,</strong></h1>
      <h3 class="text-2xl mt-3 lg:ml-40">GRAB IT NOW!</h3>
      <p class="text-lg text-slate-600">Ayo pilih segera makanan favorit anda</p>
      <RouterLink
        to="/foods"
        class="bg-highlight text-white text-lg px-6 py-2 font-bold rounded-xl mt-3 shadow-lg border-2 border-highlight hover:bg-white hover:text-highlight"
        ><i class="fa-solid fa-arrow-right text-slate-900 -ml-2 mr-2"></i>Order Now</RouterLink>
    </div>

    <!-- RIGHT -->
    <div class="w-full lg:ml-20 group">
      <img src="@/assets/img/hero.svg" alt="" class="lg:w-3/4   " />
    </div>
  </div>
  
  <!-- bEST seller menu's -->
  <div class="container mx-auto mt-20 lg:px-28">
    <h1 class="text-3xl text-dark font-semibold text-center lg:text-left">Best Seller Menu's</h1>
    <div class="flex flex-wrap mt-10 justify-evenly">
    <div class="" v-for="product in product" :key="product.id">
        <CardProduct :product="product"/>
    </div>
  </div>
</div>
</template>

<script>
import CardProduct from '@/components/CardProduct.vue'
import axios from 'axios'
export default {
  name: 'HeroItem',

  components: {
    CardProduct
  },
  
  data() {
    return {
      product: []
    }
  },
  methods: {
    setProduct(data) {
      this.product = data
    }
  },
  mounted() {
    axios
      .get('https://localhost:7038/api/Product')
      .then((response) =>this.setProduct(response.data))
      .catch((error) =>console.log(error))

  }
}
</script>

