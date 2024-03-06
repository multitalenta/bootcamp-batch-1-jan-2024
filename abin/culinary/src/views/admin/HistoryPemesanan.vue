<template>
  <div>
    <h1 class="text-2xl text-center mt-5 mb-10">History Pemesanan</h1>
    <div class="container md:py-3 lg:w-3/4 mx-auto mt-12">
      <div class="flex items-center text-gray-400 ml-5 font-medium py-4 px-4 rounded">
        <RouterLink to="/admin" href="#" class="hover:text-gray-700">Master Action</RouterLink>
        <span class="mx-2">/</span>
        <span class="text-gray-700">History Pemesanan</span>
      </div>
    </div>
    <div v-if="OrderDetails.length > 0">
      <div v-for="(orderGroup, orderId) in orderGroups" :key="orderId" class="container mx-auto px-4">
        <div>
          <h2>Nama Pemesan: {{ orderGroup[0].order.nama }}</h2>
          <h2>Kode Pesanan: {{ orderGroup[0].order.noMeja }}</h2>
          <div v-for="item in orderGroup" :key="item.id" class="ml-10">
            <p>Nama Produk: {{ item.product.nama }}</p>
            <p>Harga Produk: {{ item.product.harga }}</p>
            <p class="">Jumlah Pemesanan: {{ item.qty }}</p>
            <hr class="w-1/2">
          </div>
        </div>
      </div>
    </div>
  </div>
</template>

<script>
import axios from 'axios'

export default {
  name: 'HistoryPemesanan',
  created() {
    document.title = 'Culinary History';
  },
  data() {
    return {
      OrderDetails: [] 
    }
  },
  computed: {
    orderGroups() {
      // Mengelompokkan OrderDetails berdasarkan order_id
      const groupedOrders = {};
      this.OrderDetails.forEach(order => {
        const orderId = order.order.id;
        if (!groupedOrders[orderId]) {
          groupedOrders[orderId] = [];
        }
        groupedOrders[orderId].push(order);
      });
      return groupedOrders;
    }
  },
  methods: {
    setOrderDetails(data) {
      this.OrderDetails = data;
    }
  },
  mounted() {
    axios
      .get('https://localhost:7038/api/OrderDetail')
      .then((response) => this.setOrderDetails(response.data))
      .catch((error) => console.log(error))
  }
}
</script>

<style>
</style>
