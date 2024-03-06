<template>
    <Navbar :updateKeranjang="keranjangs" />

    <!-- start breadcumb -->
    <div class="container">
        <div class="flex items-center text-primary md:ml-5 font-medium bg-primary py-4 px-4 rounded mt-10 mb-10">
            <RouterLink to="/" href="#" class="hover:text-opacity-80 text-white">Home</RouterLink>
            <span class="mx-2 text-white">/</span>
            <RouterLink to="/menu" href="#" class=" text-white hover:text-opacity-80">Menu</RouterLink>
            <span class="mx-2 text-white">/</span>
            <span class="text-white">Keranjang</span>
        </div>
    </div>
    <!-- end breadcumb -->

    <div class="container relative">
        <div class="overflow-x-auto mb-5">
            <h2 class="text-2xl font-semibold text-primary mb-5">Keranjang Saya</h2>

            <div class="min-w-full bg-gradient-to-r from-white to-slate-300 border-2 border-slate-950">
                <div class="text-center hidden sm:grid md:grid lg:grid xl:grid grid-cols-8">
                    <div class="py-2 px-4 border-b  border-slate-950">#</div>
                    <div class="py-2 px-4 border-b  border-slate-950">Gambar</div>
                    <div class="py-2 px-4 border-b  border-slate-950">Makanan</div>
                    <div class="py-2 px-4 border-b  border-slate-950">Keterangan</div>
                    <div class="py-2 px-4 border-b  border-slate-950">Jumlah</div>
                    <div class="py-2 px-4 border-b  border-slate-950">Harga</div>
                    <div class="py-2 px-4 border-b  border-slate-950">Total Harga</div>
                    <div class="py-2 px-4 border-b  border-slate-950">Aksi</div>
                </div>

                <div v-for="(keranjang, index) in keranjangs" :key="keranjang.id"
                    class="text-center sm:grid md:grid lg:grid xl:grid grid-cols-8">
                    <div align="justify-center" class="border-b border-slate-950">{{ index + 1 }}</div>
                    <div class=" flex items-center py-2 px-4 border-b border-slate-950">
                        <img :src="'/src/assets/img/' + keranjang.product.gambar" alt="best-produk"
                            class="w-[100px] h-[50px] md:w-[320px] md:h-[200px] object-cover" />
                    </div>
                    <div align="justify-center" class="py-2 px-4 border-b border-slate-950">
                        <strong>{{ keranjang.product.nama }}</strong>
                    </div>
                    <div align="justify-center" class="py-2 px-4 border-b border-slate-950">{{ keranjang.catatan }}</div>
                    <div align="justify-center" class="py-2 px-4 border-b border-slate-950">{{ keranjang.qty }}
                    </div>
                    <div align="justify-center" class="py-2 px-4 border-b border-slate-950">
                        {{ formattedPrice(keranjang.product.harga) }}
                    </div>
                    <div align="justify-center" class="py-2 px-4 border-b border-slate-950">
                        <strong>{{ formattedPrice(keranjang.totalHarga) }}</strong>
                    </div>
                    <div align="justify-center" class="py-2 px-4 border-b border-slate-950">
                        <button @click="hapusKeranjang(keranjang.id)"
                            class="flex items-center bg-red-500 hover:bg-red-700 text-white font-bold py-2 px-4 rounded">
                            <span class="justify-center">
                                <i class="fas fa-trash"></i>
                            </span>
                        </button>
                    </div>
                </div>

                <div class="text-right sm:grid md:grid lg:grid xl:grid grid-cols-8 gap-4">
                    <div class="col-span-7 py-2 px-4 ">
                        <strong>Total Harga :</strong>
                    </div>
                    <div class="col-span-1 py-2 px-4">
                        <strong>{{ subTotal }}</strong>
                    </div>
                </div>
            </div>
        </div>

        <!-- form cekout start -->
        <div class="flex justify-end ">
            <div class="relative  mb-5  mt-5">
                <form action="" class="mt-5" v-on:submit.prevent>
                    <div class="mb-5">
                        <label for="nama">Nama Pemesan :</label>
                        <input type="text" name="nama" id="nama" class="ml-2 ring-2 ring-primary" v-model="pesan.nama" />
                    </div>
                    <div class="mb-5">
                        <label for="noMeja">Nomer Meja :</label>
                        <input type="number" name="noMeja" id="noMeja" class="ml-9 ring-2 ring-primary"
                            v-model="pesan.noMeja" />
                    </div>
                    <div class="mb-5 text-right">
                        <button class="inline-block py-3 px-5 bg-primary rounded-lg hover:opacity-80 text-white"
                            @click="chekout">
                            🛒Pesan
                        </button>
                    </div>
                </form>
            </div>
        </div>
        <!-- form cekout end -->
    </div>

    <Footer />
</template>

<script>
import Navbar from '@/components/Navbar.vue';
import Footer from '@/components/Footer.vue';
import axios from 'axios';

export default {
    name: "keranjang",
    components: {
        Navbar,
        Footer,
        axios
    },
    data() {
        return {
            keranjangs: [],
            props: ['produks'],
            pesan: {}
        }
    },
    methods: {
        setKeranjangs(data) {
            this.keranjangs = data;
        },
        hapusKeranjang(id) {
            // Show a confirmation alert before deleting
            const isConfirmed = window.confirm("Apakah Anda yakin ingin menghapus item ini dari keranjang?");

            if (!isConfirmed) {
                // User cancelled the deletion, do nothing
                return;
            }
            axios
                .delete("https://localhost:7038/api/CartDetail/" + id)
                .then(() => {
                    this.$toast.error("Sukses Menghapus Menu", {
                        type: 'error',
                        position: 'top-right',
                        duration: 3000,
                        dismissible: true,
                    });
                    axios
                        .get("https://localhost:7038/api/CartDetail/")
                        .then((response) => this.setKeranjangs(response.data))
                        .catch((error) => console.log(error))
                })
                .catch((error) => console.log(error))
        },
        chekout() {
            if (this.pesan.nama && this.pesan.noMeja) {
                this.pesan.nama = this.pesan.nama;
                this.pesan.noMeja = this.pesan.noMeja

                // Kirim data pesanan (Order) ke API
                axios
                    .post("https://localhost:7038/api/Order", this.pesan)

                    .then((orderResponse) => {
                        const orderId = orderResponse.data.id; // Dapatkan ID pesanan dari respons POST

                        if (this.keranjangs.length > 0) {
                            // Untuk setiap item dalam keranjang
                            this.keranjangs.forEach((item) => {
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

                        //pesan kesalahan/notif fungsi
                        this.$router.push({ path: "/pesanan-sukses" })
                        this.$toast.success("Sukses Menambahkan Ke Kerang", {
                            type: 'success',
                            position: 'top-right',
                            duration: 3000,
                            dismissible: true,
                        });
                    })
                    .catch((err) => console.log(err))
            } else {
                this.$toast.error("Nama Pemesan Dan Nomor Meja Harus Diisi...", {
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
            .get("https://localhost:7038/api/CartDetail")
            .then((response) => this.setKeranjangs(response.data))
            .catch((error) => console.log(error))
    },
    computed: {
        formattedPrice() {
            return (harga) => {
                return new Intl.NumberFormat('id-ID', { style: 'currency', currency: 'IDR' }).format(harga || 0);
            };
        },
        subTotal() {
            const total = this.keranjangs.reduce((acc, data) => acc + data.product.harga * data.qty, 0);
            return this.formattedPrice(total);
        }

    }

}   
</script>