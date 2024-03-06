import { createRouter, createWebHistory } from 'vue-router'
import MainHome from '@/views/MainHome.vue'
import TambahBuku from '@/views/admin/TambahBuku.vue'
import DaftarBuku from '@/views/DaftarBuku.vue'
import FoodMenu from '@/views/FoodMenu.vue'
import FoodDetails from '@/views/FoodDetails.vue'
import CartItem from '@/views/CartItem.vue'
import PesananSukses from '@/views/PesananSukses.vue'
import TambahMenu from '@/views/admin/TambahMenu.vue'
import MasterAction from '@/views/admin/MasterAction.vue'
import EditMenu from '@/views/admin/EditMenu.vue'
import HistoryPemesanan from '@/views/admin/HistoryPemesanan.vue'

const router = createRouter({
  history: createWebHistory(import.meta.env.BASE_URL),
  routes: [
    {
      path: '/',
      name: 'home',
      component: MainHome
      },
    {
      path: '/tambah-buku',
      name: 'tambah-buku',
      component: TambahBuku
      },
    {
      path: '/daftar-buku',
      name: 'daftar-buku',
      component: DaftarBuku
      },
    {
      path: '/foods',
      name: 'foods',
      component: FoodMenu
      },
    {
      path: '/foods/:id',
      name: 'FoodDetails',
      component: FoodDetails
      },
      {
        path: '/cart',
        name:CartItem,
        component: CartItem
      },
      {
        path: '/order-created',
        name: PesananSukses,
        component: PesananSukses,
         meta: { refreshOnce: true }
      },
      {
        path: '/admin/tambah-menu',
        name: TambahMenu,
        component: TambahMenu
      },
      {
        path: '/admin',
        name: MasterAction,
        component: MasterAction
      },
      {
        path: '/admin/edit-menu/:id',
        name: EditMenu,
        component: EditMenu
      },
      {
        path: '/admin/history-pesan',
        name: HistoryPemesanan,
        component: HistoryPemesanan
      },

  ]
})

export default router
