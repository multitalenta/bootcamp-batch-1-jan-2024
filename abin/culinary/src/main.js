import './assets/main.css'

import { createApp } from 'vue'
import App from './App.vue'
import router from './router'
import VueToast from 'vue-toast-notification';
import 'vue-toast-notification/dist/theme-default.css';
// import '@vueuse/core'
// import { daisyui } from 'daisyui'
// import 'daisyui/dist/full.css'

const app = createApp(App)
app.use(VueToast);
// app.use(daisyui)
app.use(router)

app.mount('#app')
// app.config.globalProperties.$config = {
//     darkMode: false,
//   };