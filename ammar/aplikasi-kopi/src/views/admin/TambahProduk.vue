<template>
    <AdminNavbar />

    <!-- start Tabel -->
    <div class="container relative">
        <div class="overflow-x-auto mb-5">
            <h2 class="text-2xl font-semibold text-primary mb-5">Tambah Produk</h2>

            <div class="min-w-full bg-gradient-to-r from-white to-slate-300 border-2 border-slate-950">
                <div class="hidden text-center sm:grid md:grid lg:grid xl:grid grid-cols-6">
                    <div class="py-2 px-4 border-b  border-slate-950">Id</div>
                    <div class="py-2 px-4 border-b  border-slate-950">Kode Produk </div>
                    <div class="py-2 px-4 border-b  border-slate-950">Nama Produk</div>
                    <div class="py-2 px-4 border-b  border-slate-950">Harga</div>
                    <div class="py-2 px-4 border-b  border-slate-950">Stok</div>
                    <!-- <div class="py-2 px-4 border-b  border-slate-950" style = "display : none">Deskripsi</div>
                    <div class="py-2 px-4 border-b  border-slate-950" style = "display : none">Link Info</div>
                    <div class="py-2 px-4 border-b  border-slate-950 " style="display : none">Gambar</div> -->
                    <div class="py-2 px-4 border-b  border-slate-950">Aksi</div>
                </div>

                <div v-for="produks in produk" :key="produks.id" class="text-center sm:grid md:grid lg:grid xl:grid grid-cols-6">
                    <div align="justify-center" class="border-b border-slate-950">{{ produks.id }}</div>
                    <div align="justify-center" class="border-b border-slate-950">{{ produks.kode }}</div>
                    <div align="justify-center" class="py-2 px-4 border-b border-slate-950"> {{ produks.nama }}</div>
                    <div align="justify-center" class="py-2 px-4 border-b border-slate-950"><strong>{{
                        formattedPrice(produks.harga) }}</strong></div>
                    <div align="justify-center" class="py-2 px-4 border-b border-slate-950">{{ produks.is_ready }}</div>
                    <!-- <div align="justify-center" class="py-2 px-4 border-b border-slate-950">{{ produks.desc }} </div>
                    <div align="justify-center" class="py-2 px-4 border-b border-slate-950">{{ produks.link }} </div>
                    <div class=" flex items-center py-2 px-4 border-b border-slate-950">
                        <img :src="'/src/assets/img/' + produks.gambar" alt="best-produk"
                            class="w-[100px] h-[50px] md:w-[320px] md:h-[200px] object-cover" />
                    </div> -->

                    <!-- start aksi -->
                    <div align="justify-center" class="py-2 px-4 border-b border-slate-950 flex justify-end items-center">
                        <button @click="hapusProduks(produks.id)"
                            class="flex items-center bg-red-500 hover:bg-red-700 text-white font-bold py-2 px-4 rounded mr-2">
                            <span class="justify-center">
                                <i class="fas fa-trash"></i>
                            </span>
                        </button>
                        <button @click="editproduks(produks.id)"
                            class="flex items-center bg-blue-500 hover:bg-blue-700 text-white font-bold py-2 px-4 rounded">
                            <span class="justify-center">
                                <i class="fas fa-edit"></i>
                            </span>
                        </button>
                    </div>
                    <!-- End Aksi -->
                </div>
            </div>
        </div>
    </div>
    <!-- end tabel -->


    <AdminFooter />
</template>


<script>
import AdminNavbar from '@/components/admin/AdminNavbar.vue';
import AdminFooter from '@/components/admin/AdminFooter.vue';
import axios from 'axios';

export default {
    name: "TambahProduk",
    components: {
        AdminFooter,
        AdminNavbar,
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
                .delete("http://localhost:3000/produks/" + id)
                .then(() => {
                    this.$toast.error("Sukses Menghapus Menu", {
                        type: 'error',
                        position: 'top-right',
                        duration: 3000,
                        dismissible: true,
                    });
                    axios
                        .get("http://localhost:3000/produks/")
                        .then((response) => this.setProduks(response.data))
                        .catch((error) => console.log(error))
                })
                .catch((error) => console.log(error))
        },
    },
    mounted() {
        axios
            .get("http://localhost:3000/produks")
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

