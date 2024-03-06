<template>
    <div class="container md:py-3 lg:w-3/4 mx-auto mt-12">
      <div class="flex items-center text-gray-400 ml-5 font-medium py-4 px-4 rounded">
        <RouterLink to="/admin" href="#" class="hover:text-gray-700">Master Action</RouterLink>
        <span class="mx-2">/</span>
        <span class="text-gray-700">Edit Menu</span>
      </div>
    </div>
    <h1 class="text-center mb-10 text-2xl font-bold mt-5">Edit Menu</h1>
    <div class="container lg:w-3/4 mx-auto px-4">
      <form class="md:w-1/2 mx-auto" @submit.prevent="updateProduct">
        <div class="mt-5 flex flex-col">
          <img v-if="form.gambar" :src="form.gambar" alt="Product Image" class="border rounded-md p-1 focus:outline-none focus:ring-highlight">
        </div>
        <div class="mt-5 flex flex-col">
          <label for="namaMenu" id="namaMenu">Nama Menu :</label>
          <input type="text" id="namaMenu" class="border rounded-md p-1 focus:outline-none focus:ring-highlight" v-model="form.nama">
        </div>
        <div class="mt-5 flex flex-col">
          <label for="harga" id="harga">Harga :</label>
          <input type="text" id="harga" class="border rounded-md p-1 focus:outline-none focus:ring-highlight" v-model="form.harga">
        </div>
        <div class="mt-5 flex flex-col">
          <label for="desc" id="desc">Deskripsi Menu :</label>
          <textarea name="desc" id="desc" cols="30" rows="3" class="border rounded-md p-1 focus:outline-none focus:ring-highlight" v-model="form.keterangan"></textarea>
        </div>
        <div class="mt-5 flex flex-col">
          <label for="stok" id="stok">Stock :</label>
          <select name="stok" id="stok" class="border rounded-md p-1" v-model="form.isReady">
            <option :value="true">Ready</option>
            <option :value="false">Tidak Ready</option>
          </select>
        </div>
        <div class="flex justify-center">
          <router-link to="/admin" class="mr-5">
            <button class="button-order mt-5 text-sm">Cancel</button>
          </router-link>
          <button class="text-slate-800 border-2 border-tertier tracking-wider shadow-lg font-bold px-6 py-2 bg-tertier rounded-lg mt-5 text-md hover:bg-white">Update</button>
        </div>
      </form>
    </div>
  </template>
  
  <script>
import axios from 'axios'

export default {
  name: 'EditMenu',
  props: ['product'],
  data() {
    return {
      form: {
        id: '',
        kode: '',
        nama: '',
        harga: '',
        keterangan: '',
        isReady: false, // Set default value to false
        dateCreated: ''
      }
    }
  },
  methods: {
    async fetchData() {
      try {
        const response = await axios.get('https://localhost:7038/api/Product/' + this.$route.params.id);
        const product = response.data;
        this.form = {
          id: product.id,
          kode: product.kode,
          nama: product.nama,
          harga: product.harga,
          keterangan: product.keterangan,
          isReady: product.isReady, // Use the actual value from the API
          dateCreated: product.DateCreated,
        };
      } catch (error) {
        console.error('Error fetching product:', error);
        this.$toast.error('Terjadi kesalahan saat mengambil data produk', {
          type: 'error',
          position: 'top-right',
          duration: 3000,
          dismissible: true
        });
      }
    },
    async updateProduct() {
      try {
        
        await axios.put('https://localhost:7038/api/Product/' + this.$route.params.id, this.form);
        this.$router.push('/admin');
        this.$toast.success('Produk berhasil diperbarui', {
          type: 'success',
          position: 'top-right',
          duration: 3000,
          dismissible: true
        });
      } catch (error) {
        console.error('Terjadi kesalahan saat memperbarui produk:', error);
        this.$toast.error('Terjadi kesalahan saat memperbarui produk', {
          type: 'error',
          position: 'top-right',
          duration: 3000,
          dismissible: true
        });
      }
    },
  },
  mounted() {
    this.fetchData();
  }
}
</script>

<style></style>
  