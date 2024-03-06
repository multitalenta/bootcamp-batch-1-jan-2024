import VueToast from 'vue-toast-notification'
import 'vue-toast-notification/dist/theme-sugar.css'
import './assets/main.css'


import { createApp } from 'vue'
import App from './App.vue'
import router from './router'


const app = createApp(App)

app.use(VueToast)
app.use(router)

app.mount('#app')


