import {
  createRouter,
  createWebHistory
} from 'vue-router'
import MainHome from '@/views/MainHome.vue'
import Menu from '@/views/Menu.vue'
import Detail from '@/views/DetailMenu.vue'
import keranjang from '@/views/Keranjang.vue'
import sukses from '@/views/PesananSukses.vue'

// dua
import MainAdmin from '@/views/dua/MainAdmin.vue'
import DashboardAdmin from '@/views/dua/DashboardAdmin.vue'
import FormProduk from '@/views/dua/FormProduk.vue'
import TambahProduk from '@/views/dua/TambahProduk.vue'
import EditProduk from '@/views/dua/EditProduk.vue'



const router = createRouter({
  history: createWebHistory(
    import.meta.env.BASE_URL),
  routes: [{
      path: '/',
      name: 'home',
      component: MainHome
    },
    {
      path: '/menu',
      name: 'menu',
      component: Menu
    },
    {
      path: '/detail/:id',
      name: 'detail',
      component: Detail
    },
    {
      path: '/keranjang',
      name: 'keranjang',
      component: keranjang
    },
    {
      path: '/pesanan-sukses',
      name: 'pesanan-sukses',
      component: sukses
    },
    // admin
    {
      path: '/mainadmin',
      name: 'MainAdmin',
      component: MainAdmin
    },
    {
      path: '/dashboard',
      name: 'DashboardAdmin',
      component: DashboardAdmin
    },
    {
      path: '/formproduk',
      name: 'FormProduk',
      component: FormProduk
    },
    {
      path: '/tambahproduk',
      name: 'TambahProduk',
      component: TambahProduk
    },
    {
      path: '/editproduk/:id',
      name: 'EditProduk',
      component: EditProduk
    },
  ]
  
 
})



export default router