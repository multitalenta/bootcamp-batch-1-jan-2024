<template>
  <NavbarTop :updateKeranjang="keranjang" />

  <div class="container md:py-10 lg:w-3/4 mx-auto mt-12 px-4">
    <div class="flex items-center text-gray-400 font-medium bg-tertier py-4 px-4 rounded">
      <RouterLink to="/" class="hover:text-gray-700">Home</RouterLink>
      <span class="mx-2">/</span>
      <RouterLink to="/foods" class="hover:text-gray-700">Menu</RouterLink>
      <span class="mx-2">/</span>
      <span class="text-gray-700">Keranjang</span>
    </div>
  </div>
  <div class="container mx-auto lg:px-20 font-bold text-3xl mb-5 text-slate-700 px-4 mt-10">
    Keranjang <span class="text-highlight">Saya</span>
  </div>
  <div class="container mx-auto lg:px-20 overflow-x-auto">
    <div class="min-w-full overflow-hidden overflow-x-auto">
      <table class="min-w-full bg-white border-2">
        <thead class="text-center">
          <tr>
            <th class="p-2 border-b">Foto</th>
            <th class="p-2 border-b">Menu</th>
            <th class="p-2 border-b">Keterangan</th>
            <th class="p-2 border-b">Jumlah</th>
            <th class="p-2 border-b">Harga Satuan</th>
            <th class="p-2 border-b">Total Harga</th>
            <th class="p-2 border-b">Hapus</th>
          </tr>
        </thead>
        <tbody class="text-center font-medium">
          <tr v-for="keranjang in keranjang" :key="keranjang.id" class="border-b border-2">
            <td>
              <img :src="'/product/' + keranjang.product.gambar" alt="" class="py-2 px-3 min-w-64 md:max-w-72" />
            </td>

            <td>{{ keranjang.product.nama }}</td>
            <td class=" ">{{ keranjang.catatan ? keranjang.catatan : '-' }}</td>
            <td class=" ">{{ keranjang.qty }}</td>
            <td class=" ">Rp.{{ keranjang.product.harga }}</td>
            <td class="font-extrabold">
              Rp.{{ keranjang.product.harga * keranjang.qty }}
            </td>
            <td>
              <i class="fa-regular fa-trash-can text-red-400 cursor-pointer" @click="hapusKeranjang(keranjang.id)"></i>
            </td>
          </tr>

          <tr class="">
            <td colspan="5" class="text-right text-bold">Total Harga :</td>
            <td>{{ totalHarga }}</td>
          </tr>
        </tbody>
      </table>
    </div>
    <div class="flex justify-end mt-5">
      <div class="w-96 px-4">
        <div class="mt-2">
          <label for="name" class="block text-slate-700 font-medium text-lg">Nama Pelanggan</label>
          <input type="text" id="name" name="name"
            class="mt-1 py-2 px-2 border border-gray-300 rounded-md focus:outline-none focus:ring focus:ring-highlight w-full text-base"
            v-model="pesan.nama" @input="validateName"/>
            <span v-if="!isNameValid" class="text-red-500 text-sm">Nama hanya boleh mengandung huruf.</span>
        </div>
        <div class="mt-2">
          <label for="noMeja" class="block text-slate-700 font-medium text-lg">Nomor Meja</label>
          <input type="text" id="noMeja" name="noMeja"
            class="mt-1 py-2 px-2 border border-gray-300 rounded-md focus:outline-none focus:ring focus:ring-highlight w-full text-base"
            v-model="pesan.noMeja" @input="validateTableNumber"/>
            <span v-if="!isTableNumberValid" class="text-red-500 text-sm">Nomor meja hanya boleh berisi angka.</span>
        </div>
        <button id="checkout" class="button-order mt-3 group float-end" type="submit" @click="checkout">
          <i class="fa-solid fa-cart-arrow-down mr-2 text-white group-hover:text-highlight float"></i>Order
        </button>
      </div>
    </div>
  </div>
</template>

<script>
import axios from 'axios'
import NavbarTop from '@/components/NavbarTop.vue'
export default {
  name: 'CartItem',
  components: {
    NavbarTop
  },
  data() {
    return {
      keranjang: [],
      pesan: {},
      jumlah_pesanan:0
    }
  },
  methods: {
    showToastError() {
  this.$toast.error(this.errorMessage, {
    type: 'error',
    position: 'top-right',
    duration: 3000,
    dismissible: true
  });
},

    setKeranjang(data) {
      this.keranjang = data;
      this.jumlah_pesanan = data.length;
    },
  
    validateName() {
  const regex = /^[A-Za-z\s]+$/;
  if (!regex.test(this.pesan.nama)) {
    this.errorMessage = 'Nama hanya boleh mengandung huruf.';
    this.showToastError();
    this.isNameValid = false;
  } else {
    this.errorMessage = '';
    this.isNameValid = true;
  }
},
validateTableNumber() {
  const regex = /^[0-9]+$/;
  if (!regex.test(this.pesan.noMeja)) {
    this.errorMessage = 'Nomor meja hanya boleh berisi angka.';
    this.showToastError();
    this.isTableNumberValid = false;
  } else {
    this.errorMessage = '';
    this.isTableNumberValid = true;
  }
},

    hapusKeranjang(id) {
      axios
        .delete('https://localhost:7038/api/CartDetail/' + id)
        .then(() => {
          this.$toast.error('Berhasil Menghapus Pesanan', {
            type: 'error',
            position: 'top-right',
            duration: 3000,
            dismissible: true
          })

          // update data keranjang
          axios
            .get('https://localhost:7038/api/CartDetail/')
            .then((response) => this.setKeranjang(response.data))
            .catch((error) => console.log(error))
        })
        .catch((error) => console.log(error))
    },
    // Di dalam metode checkout()
    checkout() {
      if (this.pesan.nama && this.pesan.noMeja) {
        this.pesan.keranjang = this.keranjang;
        axios
          .post("https://localhost:7038/api/Order", this.pesan)
          .then((orderResponse) => {
            const orderId = orderResponse.data.id;

            // Menambahkan pernyataan log
            console.log("Order berhasil dibuat. ID pesanan:", orderId);

            if (this.keranjang.length > 0) {
              // Untuk setiap item dalam keranjang
              this.keranjang.forEach((item) => {
                // Kirim data OrderDetail untuk setiap item dalam keranjang ke API
                axios
                  .post("https://localhost:7038/api/OrderDetail", {
                    order_id: orderId,
                    product_id: item.product.id,
                    qty: item.qty,
                    catatan: item.catatan
                  })
                  .then(() => {
                    // Setelah berhasil membuat OrderDetail, hapus item dari keranjang
                    axios
                      .delete("https://localhost:7038/api/CartDetail/" + item.id)
                      .catch((error) => console.log(error));
                  })
                  .catch((error) => console.log(error));
              });
            }

            this.$router.push({ path: "/order-created", state: {reload:true} })
            this.$toast.success("Sukses Melakukan Pembelian", {
              type: 'success',
              position: 'top-right',
              duration: 3000,
              dismissible: true,
            });
          })
          .catch((err) => console.log(err));
      } else {
        this.$toast.error("Nama Pemesan Dan Nomor Meja Harus Diisi...", {
          type: 'error',
          position: 'top-right',
          duration: 3000,
          dismissible: true,
        });
      }
    }

  },
  mounted() {
    axios
      .get('https://localhost:7038/api/CartDetail')
      .then((response) => this.setKeranjang(response.data))
      .catch((error) => console.log(error))
  },
  computed: {
    totalHarga() {
      const total = this.keranjang.reduce(
        (items, data) => items + data.product.harga * data.qty,
        0
      )
      return total.toLocaleString('id-ID', { style: 'currency', currency: 'IDR' })
    }
  }
}
</script>

