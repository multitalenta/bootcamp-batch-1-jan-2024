  <template>
  <nav>
    <header
      class="absoulte top-0 left-0 w-full flex items-center z-10 justify-evenly bg-transparent"
    >
      <div class="container">
        <div class="flex items-center justify-between relative xl:mx-20">
          <div class="px-4">
            <RouterLink
              to="/"
              class="font-extrabold text-2xl block py-6 text-highlight tracking-widest uppercase"
              >Culinary</RouterLink
            >
          </div>

          <!-- elemen kanan -->
          <div class="flex items-center">
            <button
              id="hamburger"
              name="hamburger"
              type="button"
              class="block absolute right-4 lg:hidden"
            >
              <span
                class="hamburger-line transition duration-300 ease-in-out w-[30px] h-[2px] my-2 block bg-slate-950 origin-top-left"
              ></span>
              <span
                class="hamburger-line transition duration-300 ease-in-out w-[30px] h-[2px] my-2 block bg-slate-950"
              ></span>
              <span
                class="hamburger-line transition duration-300 ease-in-out w-[30px] h-[2px] my-2 block bg-slate-950 origin-bottom-left"
              ></span>
            </button>
            <!-- NAVBAR -->
            <nav
              id="nav-menu"
              class="hidden absolute py-5 bg-white shadow-lg rounded-lg max-w-[250px] w-full right-4 top-full lg:block lg:static lg:max-w-full lg:bg-transparent lg:shadow-none lg:rounded-none lg:dark:bg-transparent"
            >
              <ul class="block lg:flex">
                <li class="group">
                  <RouterLink
                    to="/"
                    class="text-lg text-dark py-2 mx-8 flex group-hover:text-tertier font-semibold lg:mx-4 focus:text-tertier focus:font-bold"
                    >Home</RouterLink
                  >
                </li>
                <li class="group">
                  <RouterLink
                    to="/foods"
                    class="text-lg text-dark py-2 mx-8 flex group-hover:text-tertier font-semibold lg:mx-4 focus:text-tertier focus:font-bold"
                    >Foods</RouterLink
                  >
                </li>
                <li class="group">
                  <RouterLink
                    to="/cart"
                    class="text-lg text-dark py-2 mx-8 flex group-hover:text-tertier font-semibold lg:mx-4 focus:text-tertier focus:font-bold"
                    >Cart
                    <i class="fa fa-cart-shopping ml-1 text-highlight"></i>
                    <span
                      class="py-[0.5] px-2 ml-2 rounded-md mx-auto bg-tertier font-bold text-slate-800"
                      >{{ updateKeranjang ? updateKeranjang.length : jumlah_pesanan.length }}</span
                    >
                  </RouterLink>
                </li>
              </ul>
            </nav>
          </div>
        </div>
      </div>
    </header>
    <!-- HEADER END -->
  </nav>
</template>

<script>
import axios from 'axios'
export default {
  name: "NavbarTop",

  data(){
    return{
      jumlah_pesanan:[]
    }
  },
  props:['updateKeranjang'],
  methods:{
    setJumlah(data){
      this.jumlah_pesanan = data
    }
  },
  mounted(){
    axios
      .get('https://localhost:7038/api/CartDetail')
      .then((response) => this.setJumlah(response.data))
      .catch((error) => console.log(error))
  }
};
</script>


<script setup>
import { ref, onMounted } from 'vue';

const navbarFixed = ref(false);
const hamburgerActive = ref(false);

onMounted(() => {
    window.addEventListener('scroll', handleScroll);
    const hamburger = document.querySelector('#hamburger');
    const navMenu = document.querySelector('#nav-menu');

    if (hamburger && navMenu) {
        hamburger.addEventListener('click', () => {
            hamburgerActive.value = !hamburgerActive.value;
            navMenu.classList.toggle('hidden', !hamburgerActive.value);
        });
    }
});

function handleScroll() {
    const header = document.querySelector('header');
    const fixedNav = header.offsetTop;

    navbarFixed.value = window.pageYOffset > fixedNav;
}

</script>