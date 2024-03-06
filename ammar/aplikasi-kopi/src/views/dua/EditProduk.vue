<template>
    <!-- start breadcumb -->
    <div class="container">
        <div class="flex items-center text-primary md:ml-5 font-medium bg-primary py-4 px-4 rounded mt-10 mb-10">
            <RouterLink to="/" href="#" class="hover:text-opacity-80 text-white">Produk</RouterLink>
            <span class="mx-2 text-white">/</span>
            <RouterLink to="/menu" href="#" class=" text-white hover:text-opacity-80">From Produk</RouterLink>
            <span class="mx-2 text-white">/</span>
            <span class="text-white"> Form Edit Produk</span>
        </div>
    </div>
    <!-- end breadcumb -->

    <!-- start form input -->
    <div class="container">
        <div class="overflow-x-auto mb-5 mt-10">
            <h1 class="text-4xl text-center font-semibold text-primary mb-5">Form Edit Produk</h1>

            <div class="flex justify-center">
                <div class="w-3/4 bg-slate-100 bg-opacity-50 border-2 border-slate-950 rounded-lg">
                    <!-- <div class="hidden text-center sm:grid md:grid lg:grid xl:grid grid-cols-2">
                        <div class="text-primary py-2 px-4"><strong>ID Produk : </strong></div>
                        <div class="py-2 px-4">
                            <input type="text" class="w-full border-2 border-primary rounded-lg" />
                        </div>
                    </div> -->
                    <!-- <div class="hidden mt-5 text-center sm:grid md:grid lg:grid xl:grid grid-cols-2">
                        <div class="text-primary py-2 px-4"><strong>Kode Produk :</strong></div>
                        <div class="py-2 px-4">
                            <input type="text" class="w-full border-2 border-primary rounded-lg"  />
                        </div>
                    </div> -->
                    <div class="mt-5 hidden text-center sm:grid md:grid lg:grid xl:grid grid-cols-2">
                        <div class="text-primary py-2 px-4"><strong> Nama Produk :</strong></div>
                        <div class="py-2 px-4">
                            <input type="text" class="w-full rounded-lg border-2 border-primary" v-model="formEdit.nama" />
                        </div>
                    </div>
                    <div class="hidden text-center sm:grid md:grid lg:grid xl:grid grid-cols-2">
                        <div class="text-primary py-2 px-4"><strong>Harga Produk : </strong></div>
                        <div class="py-2 px-4">
                            <input type="number" class="w-full rounded-lg border-2 border-primary"
                                v-model="formEdit.harga" />
                        </div>
                    </div>
                    <div class="hidden text-center sm:grid md:grid lg:grid xl:grid grid-cols-2">
                        <div class="text-primary py-2 px-4"><strong>Status Stok : </strong></div>
                        <div class="py-2 px-4">
                            <select class="w-full rounded-lg border-2 border-primary" v-model="formEdit.isReady">
                                <option value="null">==Pilih==</option>
                                <option value="true">Ready</option>
                                <option value="false">Kosong</option>
                            </select>
                        </div>
                    </div>
                    <div class="hidden text-center sm:grid md:grid lg:grid xl:grid grid-cols-2">
                        <div class="text-primary py-2 px-4"><strong>keterangan : </strong></div>
                        <div class="py-2 px-4">
                            <textarea class="w-full border-2 border-primary rounded-lg"
                                v-model="formEdit.keterangan"></textarea>
                        </div>
                    </div>
                    <!-- <div class="hidden text-center sm:grid md:grid lg:grid xl:grid grid-cols-2">
                        <div class="text-primary"><strong> Link Produk : </strong></div>
                        <div class="py-2 px-4">
                            <textarea class="w-full border-2 border-primary rounded-lg" ></textarea>
                        </div>
                    </div> -->
                    <div class="hidden text-center sm:grid md:grid lg:grid xl:grid grid-cols-2">
                        <div class="text-primary py-2 px-4"><strong>Upload Gambar : </strong></div>
                        <div class="py-2 px-4">
                            <input type="file" id="gambar" name="gambar" accept="image/* "
                                class="-mr-10 border border-gray-300 rounded-md focus:outline-none focus:ring focus:ring-highlight text-sm" />
                        </div>
                    </div>
                    <div class="hidden mt-10 mb-10 text-end sm:grid md:grid lg:grid xl:grid grid-cols-1">
                        <div class="py-2 px-4">
                            <RouterLink to="/formproduk" class="bg-red-500 p-3 m-2 rounded-lg">
                                Kembali
                            </RouterLink>
                            <button class="bg-green-500 p-2 m-2 rounded-lg hover:opacity-80" @click="editProduct">
                                Edit
                            </button>
                        </div>
                    </div>
                </div>
            </div>
        </div>
    </div>
    <!-- end form input -->
</template>

<script>
import axios from 'axios';

export default {
    name: "EditProduk",
    props: ['product'],
    components: {
        axios
    },
    data() {
        return {
            formEdit: {
                id:'',
                kode:'',
                nama: '',
                harga: 0,
                isReady: null, // Ubah ke null untuk menandakan belum dipilih
                keterangan: '',
                dateCreated: ''
            },
        }
    },

    methods: {
        async fetchData() {
            try {
                // Lakukan permintaan GET ke endpoint API
                const response = await axios.get(`https://localhost:7038/api/Product/${this.$route.params.id}`);
                const product = response.data;

                // Tentukan status stok berdasarkan nilai di dalam basis data
                const stockStatus = product.isReady ? true : false;

                // Atur objek formEdit dengan data produk yang diperoleh
                this.formEdit = {
                    id: product.id,
                    kode : product.kode,
                    nama: product.nama,
                    harga: product.harga,
                    isReady: stockStatus,
                    keterangan: product.keterangan,
                    dateCreated: product.dateCreated
                };
            } catch (error) {
                // Tangani kesalahan
                console.error('Error fetching product:', error);
                this.$toast.error('Terjadi kesalahan saat mengambil data produk', {
                    type: 'error',
                    position: 'top-right',
                    duration: 3000,
                    dismissible: true
                });
            }
        },
        async editProduct() {
            try {
                // Perbarui isReady sesuai dengan nilai stok yang dipilih
                this.formEdit.Id = this.formEdit.id;
                this.formEdit.Kode = this.formEdit.kode;
                this.formEdit.nama = this.formEdit.nama;
                this.formEdit.harga = this.formEdit.harga;
                this.formEdit.keterangan = this.formEdit.keterangan;
                this.formEdit.isReady = this.stockStatus;
                this.formEdit.dateCreated = this.formEdit.dateCreated
                

                // Kirim permintaan PUT untuk memperbarui produk
                const response = await axios.put(`https://localhost:7038/api/Product/${this.$route.params.id}`, this.formEdit);

                // Opsional, tampilkan pesan sukses atau redirect pengguna
                console.log('Produk berhasil diedit:', response.data);
                this.$toast.success('Produk berhasil diedit', {
                    position: 'top-right',
                    duration: 3000,
                    dismissible: true
                });

                // Opsional, redirect pengguna setelah edit berhasil
                this.$router.push('/formproduk');
            } catch (error) {
                // Tangani kesalahan, tampilkan pesan error, dll.
                console.error('Error saat mengedit produk:', error);

                // Tampilkan pesan kesalahan lebih rinci jika tersedia
                if (error.response) {
                    console.error('Status respons:', error.response.status);
                    console.error('Data respons:', error.response.data);
                }

                this.$toast.error('Error saat mengedit produk. Silakan coba lagi.', {
                    position: 'top-right',
                    duration: 3000,
                    dismissible: true
                });
            }
        },
    },
    mounted() {
        this.fetchData();

    },

}   
</script>