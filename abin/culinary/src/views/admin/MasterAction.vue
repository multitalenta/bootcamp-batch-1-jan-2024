<template>
    <div class="overflow-x-auto">
      <h1 class="text-2xl font-bold text-center mt-5 mb-20 tracking-widest">CULINARY</h1>
      <div class="container mx-auto">
        <div class="flex">
          <div>
        <router-link to="admin/tambah-menu" class="py-3 px-5 bg-tertier mb-4 rounded-md font-medium text-dark hover:bg-white hover:border-2 hover:border-tertier">
          Tambah Menu Baru
        </router-link>
      </div>
      <div class="">
        <router-link to="admin/history-pesan" class="py-3 px-5 bg-highlight text-dark font-medium hover:bg-white hover:border-2 hover:border-highlight rounded-md ml-5">
          History Pemesanan
        </router-link>
      </div>
      </div>
        <table class="min-w-full divide-y divide-gray-200 mt-8">
          <thead class="bg-gray-50">
            <tr>
            <th scope="col"
              class="px-6 py-3 text-left text-xs font-medium text-gray-500 uppercase tracking-wider">
              No.
            </th>
              <th scope="col"
                class="px-6 py-3 text-left text-xs font-medium text-gray-500 uppercase tracking-wider">
                Nama Produk
              </th>
              <th scope="col"
                class="px-6 py-3 text-left text-xs font-medium text-gray-500 uppercase tracking-wider">
                Harga Produk
              </th>
              <th scope="col"
                class="px-6 py-3 text-left text-xs font-medium text-gray-500 uppercase tracking-wider">
                Deskripsi
              </th>
              <th scope="col"
                class="px-6 py-3 text-left text-xs font-medium text-gray-500 uppercase tracking-wider">
                Stock
              </th>
              <th scope="col"
                class="px-6 py-3 text-left text-xs font-medium text-gray-500 uppercase tracking-wider">
                Action
              </th>
            </tr>
          </thead>
          <tbody class="bg-white divide-y divide-gray-200">
            <tr v-for="(product, index) in product" :key="product.id">
              <td class="px-6 py-4 whitespace-nowrap">
              <div class="text-sm text-gray-900">{{ index + 1 }}</div>
            </td>
              <td class="px-6 py-4 whitespace-nowrap">
                <div class="text-sm text-gray-900">{{ product.nama }}</div>
              </td>
              <td class="px-6 py-4 whitespace-nowrap">
                <div class="text-sm text-gray-900">Rp. {{ product.harga }}</div>
              </td>
              <td class="px-6 py-4 whitespace-nowrap">
                <div class="text-sm text-gray-900">{{ product.keterangan }}</div>
              </td>
              <td class="px-6 py-4 whitespace-nowrap">
                <div class="text-sm text-gray-900">{{ product.stok }}</div>
              </td>
              <td class="px-6 py-4 whitespace-nowrap">
                <div class="text-sm text-gray-900 flex space-x-2">
                  <router-link :to="'admin/edit-menu/' +product.id" class="">
                    <i class="fa-regular fa-pen-to-square text-lg cursor-pointer hover:scale-90"></i>
                  </router-link>
                  <i class="fa-regular fa-trash-can text-red-700 text-lg cursor-pointer hover:scale-90 transition-all" @click="hapusProduct(product.id)"></i>
                </div>
              </td>
            </tr>
          </tbody>
        </table>
      </div>
    </div>
  </template>
  
  <script>
  import axios from 'axios'
  
  export default {
    Name: 'MasterAction',
    created() {
      document.title = 'Culinary Master';
    },
    data() {
      return {
        product: [],
      };
    },
    methods: {
      setProduct(data) {
        this.product = data
      },
      hapusProduct(id){
        axios
        .delete('https://localhost:7038/api/Product/'+ id)
        .then(() =>{
          this.$toast.error('Berhasil Menghapus Menu',{
            type:'error',
            position:'top-right',
            duration: 3000,
            dismissible:true
          })

          axios
          .get('https://localhost:7038/api/Product/')
          .then((response) => this.setProduct(response.data))
          .catch((error) => console.log(error))
        })
        .catch ((error)=>console.log(error))
      }
    },
    mounted() {
      axios
        .get('https://localhost:7038/api/Product')
        .then(response => {
          const modifiedResponse = response.data.map(product => {
            // Jika is_ready true, ubah menjadi stok: ready
            if (product.isReady === true) {
              product.stok = "Ready";
              delete product.isReady;
            } else {
              product.stok = "Tidak Ready"
            }
            return product;
          });
          this.setProduct(modifiedResponse);
        })
        .catch(error => {
          console.error('Error fetching products:', error);
        });
    }
  }
  </script>
  
  <style>
  
  </style>
  