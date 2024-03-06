<template>
  <div>
    <div class="container md:py-3 lg:w-3/4 mx-auto mt-12">
      <div class="flex items-center text-gray-400 ml-5 font-medium py-4 px-4 rounded">
        <RouterLink to="/admin" href="#" class="hover:text-gray-700">Tambah Menu</RouterLink>
        <span class="mx-2">/</span>
        <span class="text-gray-700">Tambah Menu</span>
      </div>
    </div>
    <h1 class="text-3xl text-center mt-5 mb-10">Tambah Menu</h1>
    <div class="container md:flex md:mx-auto w-full">
      <form class="md:w-1/3 mx-auto px-5" @submit.prevent="tambahMenu">
        <div class="mt-5 flex flex-col">
          <label for="nama-produk" class="text-dark font-medium">Nama Produk</label>
          <input type="text" id="nama-produk" name="nama-produk" v-model="tambah.nama"
            class="px-2 border rounded-md py-2 focus:outline-none focus:ring focus:ring-highlight w-full" />
        </div>
        <div class="mt-5 flex flex-col">
          <label for="harga-produk" class="text-dark font-medium">Harga Produk</label>
          <input type="text" id="harga-produk" name="harga-produk" v-model="tambah.harga"
            class="px-2 border rounded-md py-2 focus:outline-none focus:ring focus:ring-highlight w-full" />
        </div>
        <div class="mt-5 flex flex-col">
          <label for="keterangan-produk" class="text-dark font-medium">Deskripsi</label>
          <textarea id="keterangan-produk" name="keterangan-produk" v-model="tambah.keterangan"
            class="px-2 border rounded-md focus:outline-none focus:ring focus:ring-highlight w-full"
            rows="5"></textarea>
        </div>
        <div class="mt-5 flex flex-col">
          <label for="stok" class="text-dark font-medium">Status :</label>
          <select id="stok" name="stok" v-model="tambah.isReady" class="border rounded-md p-1 w-full">
            <option value="null">Pilih</option>
            <option value="true">Ready</option>
            <option value="false">Tidak Ready</option>
          </select>
        </div>
        <button type="submit"
          class="bg-highlight py-3 rounded-lg mt-5 text-dark font-bold cursor-pointer w-full text-center">
          <i class="fa-solid fa-plus text-white mr-2"></i>Tambah Menu
        </button>
      </form>
    </div>
  </div>
</template>

<script>
import axios from 'axios';
import { RouterLink } from 'vue-router';

export default {
  name: 'TambahMenu',
  components: {
    RouterLink
  },
  data() {
    return {
      tambah: {
        nama: '',
        harga: '',
        isReady: null,
        keterangan: ''
      }
    };
  },
  created() {
    document.title = 'Culinary Tambah Menu';
  },
  methods: {
    async tambahMenu() {
  if (!this.validateForm()) {
    return;
  }

  if (this.tambah.isReady === null) {
    alert('Pilih status stok terlebih dahulu.');
    return;
  }

  this.tambah.isReady = this.tambah.isReady === 'true';

  try {
    const response = await axios.post('https://localhost:7038/api/Product', this.tambah);
    console.log('produk berhasil ditambah:', response.data);

    this.resetForm();
    this.$toast.success("Sukses Menambahkan Menu", {
      type: 'success',
      position: 'top-right',
      duration: 3000,
      dismissible: true,
    });
  } catch (error) {
    console.error('Terjadi kesalahan saat menambah data:', error);
    this.$toast.error("Terjadi kesalahan saat menambah data", {
      type: 'error',
      position: 'top-right',
      duration: 3000,
      dismissible: true,
    });
  }
},
validateForm() {
  if (!this.tambah.nama || !this.tambah.harga || this.tambah.isReady === null || !this.tambah.keterangan) {
    this.$toast.error("Harap lengkapi semua field", {
      type: 'error',
      position: 'top-right',
      duration: 3000,
      dismissible: true,
    });
    return false;
  }
  return true;
},
resetForm() {
  this.tambah.nama = '';
  this.tambah.harga = '';
  this.tambah.isReady = null;
  this.tambah.keterangan = '';
}

  }
};
</script>

<style>
input[type="file"] {
  padding: 0.5rem 1rem;
}
</style>
