<template>
  <NavbarTop />
  <div class="">
    <div class="container md:py-3 lg:w-3/4 mx-auto mt-12">
      <div class="flex items-center text-gray-400 ml-5 font-medium bg-tertier py-4 px-4 rounded">
        <RouterLink to="/" href="#" class="hover:text-gray-700">Home</RouterLink>
        <span class="mx-2">/</span>
        <RouterLink to="/foods" href="#" class="hover:text-gray-700">Menu</RouterLink>
        <span class="mx-2">/</span>
        <span class="text-gray-700">Food Order</span>
      </div>
    </div>

    <div class="container mx-auto px-4">
      <div class="flex flex-wrap md:mx-auto">
        <div class="mt-12 xl:ml-28">
          <img :src="'/product/' + product.gambar" alt="" class="lg:max-w-[500px] rounded-lg" />
        </div>
        <div class="mt-3 lg:ml-20 text-xl w-2/3 lg:w-1/3">
          <h2 class="font-bold text-4xl">{{ product.nama }}</h2>
          <hr class="mt-3 mb-3" />
          <h3 class="text-2xl mb-4"><span class="font-bold">Rp. </span>{{ product.harga }}</h3>
          <p class="text-slate-500 text-xl">{{ product.keterangan }}</p>

          <form @submit.prevent="pemesanan">
            <div class="mt-2">
              <label for="qty" class="block text-lg">Jumlah Pembelian</label>
              <input type="number" id="qty" name="qty"
                class="mt-1 p-2 border border-gray-300 rounded-md focus:outline-none focus:ring focus:ring-highlight w-full text-base"
                placeholder="Jumlah Pembelian" v-model.number="pesan.qty" />
            </div>
            <div class="mt-2 mb-3">
              <label for="keterangan">Keterangan</label>
              <textarea name="keterangan" id="keterangan" class="w-full border rounded-md text-base text-slate-400 mt-1"
                rows="3" v-model="pesan.catatan">
              </textarea>
            </div>

            <button class="button-order mt-3 group" type="submit">
              <i class="fa-solid fa-cart-arrow-down mr-2 text-white group-hover:text-highlight"></i>Order
            </button>
          </form>
        </div>
      </div>
    </div>
  </div>
</template>

<script>
import NavbarTop from '@/components/NavbarTop.vue'
import axios from 'axios'
export default {
  name: 'FoodDetails',
  components: {
    NavbarTop
  },
  data() {
    return {
      product: {},
      pesan: {}
    }
  },
  computed: {
    formattedPrice() {
      const price = this.product.harga || 0;
      return new Intl.NumberFormat('id-ID', { style: 'currency', currency: 'IDR' }).format(price);
    },
  },
  methods: {
    setProduct(data) {
      this.product = data;
    },
    pemesanan() {
      if (this.pesan.qty && this.pesan.qty > 0) {
        this.pesan.product_id = this.product.id;
        axios
          .post("https://localhost:7038/api/CartDetail", this.pesan)
          .then(() => {
            this.$router.push({ path: "/cart" })
            this.$toast.success("Sukses Menambahkan Ke Keranjang", {
              type: 'success',
              position: 'top-right',
              duration: 3000,
              dismissible: true,
            });
          })
          .catch((err) => console.log(err))
      } else {
        this.$toast.error("Jumlah Pesanan Belum Diisi & tidak boleh negatif", {
          type: 'error',
          position: 'top-right',
          duration: 3000,
          dismissible: true,
        });
      }
    },

  },
  mounted() {
    axios
      .get("https://localhost:7038/api/Product/" + this.$route.params.id)
      .then((response) => this.setProduct(response.data))
      .catch((error) => console.log(error))

  },

}
</script>

