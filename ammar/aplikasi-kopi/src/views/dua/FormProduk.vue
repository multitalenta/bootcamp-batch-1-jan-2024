<template>
     <!-- start breadcumb -->
     <div class="container">
        <div class="flex items-center text-primary md:ml-5 font-medium bg-primary py-4 px-4 rounded mt-10 mb-10">
            <RouterLink to="/" href="#" class="hover:text-opacity-80 text-white">Produk</RouterLink>
            <span class="mx-2 text-white">/</span>
            <RouterLink to="/menu" href="#" class=" text-white hover:text-opacity-80">Form Produk</RouterLink>
        </div>
    </div>
    <!-- end breadcumb -->

    <!-- start Tabel -->
    <div class="container relative ">
        <div class="overflow-x-auto mb-5 mt-10">
            <h1 class="text-4xl font-semibold text-primary mb-5">Tabel Produk</h1>
            <a href="/tambahproduk" class=" text-green-500 underline" >Tambah Produk</a>

            <div class="min-w-full border-2 border-slate-950">
                <div class="bg-gradient-to-r from-white to-slate-300 hidden text-center sm:grid md:grid lg:grid xl:grid grid-cols-6">
                    <div class="py-2 px-4 border-b  border-slate-950">#</div>
                    <div class="py-2 px-4 border-b  border-slate-950">Kode Produk </div>
                    <div class="py-2 px-4 border-b  border-slate-950">Nama Produk</div>
                    <div class="py-2 px-4 border-b  border-slate-950">Harga</div>
                    <div class="py-2 px-4 border-b  border-slate-950">Stok</div>
                    <!-- <div class="py-2 px-4 border-b  border-slate-950" style = "display : none">Deskripsi</div>
                    <div class="py-2 px-4 border-b  border-slate-950" style = "display : none">Link Info</div>
                    <div class="py-2 px-4 border-b  border-slate-950 " style="display : none">Gambar</div> -->
                    <div class="py-2 px-4 border-b  border-slate-950">Aksi</div>
                </div>

                <div v-for="(produks, index) in produk" :key="produks.id" class="text-center sm:grid md:grid lg:grid xl:grid grid-cols-6">
                    <div align="justify-center" class="border-b border-slate-950">{{ index + 1 }}</div>
                    <div align="justify-center" class="border-b border-slate-950">{{ produks.kode }}</div>
                    <div align="justify-center" class="py-2 px-4 border-b border-slate-950"> {{ produks.nama }}</div>
                    <div align="justify-center" class="py-2 px-4 border-b border-slate-950"><strong>{{
                        formattedPrice(produks.harga) }}</strong></div>
                    <div align="justify-center" class="py-2 px-4 border-b border-slate-950">{{  produks.isReady ? 'Ready' : 'Kosong'  }}</div>
                    <!-- <div align="justify-center" class="py-2 px-4 border-b border-slate-950">{{ produks.desc }} </div>
                    <div align="justify-center" class="py-2 px-4 border-b border-slate-950">{{ produks.link }} </div>
                    <div class=" flex items-center py-2 px-4 border-b border-slate-950">
                        <img :src="'/src/assets/img/' + produks.gambar" alt="best-produk"
                            class="w-[100px] h-[50px] md:w-[320px] md:h-[200px] object-cover" />
                    </div> -->

                    <!-- start aksi -->
                    <div  class="py-2 px-4 border-b border-slate-950 flex justify-end ">
                        <button @click="hapusProduks(produks.id)"
                            class="flex items-center bg-red-500 hover:bg-red-700 text-white font-bold py-2 px-4 rounded mr-2">
                            <span class="justify-center">
                                <i class="fas fa-trash"></i>
                            </span>
                        </button>
                        <router-link :to="'/editproduk/'+ produks.id">
                        <button 
                            class="flex bg-blue-500 hover:bg-blue-700 text-white font-bold py-2 px-4 rounded">
                            <span class="justify-center">
                                <i class="fas fa-edit"></i>
                            </span>
                        </button>
                        </router-link>
                    </div>
                    <!-- End Aksi -->
                </div>
            </div>
        </div>
    </div>
    <!-- end tabel -->


</template>


<script>
import axios from 'axios';

export default {
    name: "FormProduk",
    components: {

        axios

    },
    data() {
        return {
            produk : [],
        }
    },
    methods: {
        setProduks(data) {
            this.produk = data
        },
        hapusProduks(id) {
            // Show a confirmation alert before deleting
            const isConfirmed = window.confirm("Apakah Anda yakin ingin menghapus item ini dari Produks?");

            if (!isConfirmed) {
                // User cancelled the deletion, do nothing
                return;
            }
            axios
                .delete("https://localhost:7038/api/Product/" + id)
                .then(() => {
                    this.$toast.error("Sukses Menghapus Menu", {
                        type: 'error',
                        position: 'top-right',
                        duration: 3000,
                        dismissible: true,
                    });
                    axios
                        .get("https://localhost:7038/api/Product/")
                        .then((response) => this.setProduks(response.data))
                        .catch((error) => console.log(error))
                })
                .catch((error) => console.log(error))
        },
    },
    mounted() {
        axios
            .get("https://localhost:7038/api/Product")
            .then((response) => this.setProduks(response.data))
            .catch((error) => console.log(error))
    },
    computed: {
        formattedPrice() {
            return (harga) => {
                return new Intl.NumberFormat('id-ID', { style: 'currency', currency: 'IDR' }).format(harga || 0);
            };
        }
    }
};

</script>

