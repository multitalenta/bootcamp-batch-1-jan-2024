<template>
    <div class="max-h-full w-[300px] bg-slate-200 text-center">
        <div class="bg-primary h-[50px]">
            <div class="text-xl font-bold text-center flex items-center justify-center h-full text-white">NgopsBar</div>
        </div>

        <div class="flex flex-col justify-between h-[calc(100vh)] bg-slate-100">
            <div class="menu-man text-left px-2 whitespace-nowrap">
                <div class="profile flex justify-center items-center text-center p-5">
                    <div class="text-center">
                        <img src="../assets/img/1.svg" alt="" class="p-1 w-24 h-24 rounded-full ring-2 ring-primary">
                        <h5 class="text-xl text-primary font-medium leading-tight mb-2"> my name</h5>
                        <p class="text-primary ">Admin</p>
                    </div>
                </div>

                <div class="py-3 mt-2 rounded-lg cursor-pointer text-white hover:text-slate-400 bg-primary ">
                    <router-link to="/dashboard" class="px-2 flex space-x-2">
                        <span class="fa-sharp fa-solid fa-gauge" ></span>
                        <span>Dashboard</span>
                    </router-link>

                </div>
                <div class="py-3 mt-2 rounded-lg cursor-pointer text-white hover:text-slate-400 bg-primary">
                    <router-link to="" class="px-2 flex space-x-2">
                        <span class="fa-solid fa-users-line"></span>
                        <span>User</span>
                    </router-link>
                </div>
                <div class="py-3 mt-2 rounded-lg cursor-pointer text-white hover:text-slate-400 bg-primary">
                    <router-link to="/formproduk" class="px-2 flex space-x-2">
                        <span class="fa-solid fa-layer-group"></span>
                        <span>Produk</span>
                    </router-link>
                </div>
                <div class="py-3 mt-2 rounded-lg cursor-pointer text-white hover:text-slate-400 bg-primary">
                    <router-link to="" class="px-2 flex space-x-2">
                        <span class="fa-regular fa-address-book"></span>
                        <span>Contact</span>
                    </router-link>
                </div>
                <div class="py-3 mt-2 rounded-lg cursor-pointer text-white hover:text-slate-400 bg-primary">
                    <router-link to="" class="px-2 flex space-x-2">
                        <span class="fa-solid fa-people-group"></span>
                        <span>Costomer</span>
                    </router-link>
                </div>
                <div class="py-3 mt-2 rounded-lg cursor-pointer text-white hover:text-slate-400 bg-primary">
                    <div class="px-2 flex space-x-2">
                        <span class="fa-solid fa-gears"></span>
                        <span>Setting</span>
                    </div>
                </div>
                <div class="menu-man text-left px-2 justify-self-end whitespace-nowrap">
                    <div class="py-3 mt-2 rounded-lg cursor-pointer text-white hover:text-slate-400 bg-primary">
                        <a href="" target="_blank" class="px-2 flex space-x-2">
                            <span class="fas fa-user"></span>
                            <span>About Me</span>
                        </a>
                    </div>
                </div>
            </div>
        </div>
    </div>
</template>

<script>

export default {
    name: "AdminSidebar",
    components: {

    }

}
</script>

<style></style>