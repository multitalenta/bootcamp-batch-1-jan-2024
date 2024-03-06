<!-- eslint-disable no-unused-vars -->
<template>
    <NavbarTop/>
    <div class="bg-tertier">
    <div class="mb-12">
    <h1 class="">daftar buku</h1>
</div>


<div class="ml-24 mx-auto">
    <div class="w-full flex flex-wrap justify-center">
    <div class="w-full mx-auto md:w-1/2 xl:w-1/4" v-for="book in books" :key="book.id">

        <div class="bg-white rounded-xl shadow-lg mb-10 overflow-hidden w-3/4">
            
            <img :src="book.image" alt="" class=" hover:scale-90 p-3 transition ease-in">
       
            <div class="px-4 mt-3 mb-5">
                <h3>{{book.judul}}</h3>
                <p>{{ book.penulis }}</p>
                <p>{{ book.penerbit }}</p>
                <p>{{ book.tahun }}</p>
                <p>{{ book.stok }}</p>
                <div class="mt-6">
                <RouterLink to="" class="px-7 py-3 bg-tertier rounded-xl border border-slate-400 mt-6">Lihat Detail</RouterLink>
            </div>
            </div>
        </div>
    </div>
    
</div>
</div>
</div>
</template>



<script setup>
import NavbarTop from '@/components/NavbarTop.vue'
import { onMounted, ref } from 'vue';

// eslint-disable-next-line no-unused-vars
const props = defineProps(['DaftarBuku']);

const books = ref([]);

onMounted(() => {
  fetchBooks();
});

const fetchBooks = () => {
  fetch('../public/data/books.json')
    .then((response) => response.json())
    .then((data) => {
      books.value = data;
    })
    .catch((error) => {
      console.error('Error fetching books', error);
    });
};
</script>
