<template>
    <!-- web start -->
    <div class="container hidden md:block md:h-[790px]">
        <div class="flex flex-wrap">
            <div class="w-full px-4 mb-10 lg:w-1/2 mt-auto">
                <h2 class="text-base font-semibold md:text-4xl  text-primary mb-10"><strong>Delicius Coffe Menu,</strong> In Display</h2>
                <RouterLink to="" class="-mt-2 py-4 px-6 bg-primary text-slate-100 rounded-lg">
                    Pesan Sekarang
                </RouterLink>
            </div>
            <div class="w-full self-end  px-4 lg:w-1/2 group">
                <div class="mt-10 lg:mt-9 lg:right-0 group-hover:animate-pulse transition duration-100">
                    <img src="@/assets/img/1.svg" alt=""  class="max-w-full mx-auto"/>
                </div> 
            </div>
        </div>
    </div>
    <!-- web end -->

    <!-- mobile start -->
    <div class="container md:hidden lg:hidden xl:hidden sm:block">
        <div class="flex flex-wrap">
            <div class="w-full self-end  px-4 lg:w-1/2 group">
                <div class="mt-5 lg:mt-9 lg:right-0 group-hover:animate-pulse transition duration-100">
                    <img src="@/assets/img/1.svg" alt=""  class="max-w-full mx-auto"/>
                </div> 
            </div>
            <div class="w-full px-4 mb-10 lg:w-1/2">
                <h2 class="text-base font-semibold md:text-4xl mt-10 text-primary mb-5"><strong>Delicius Coffe Menu,</strong> In Display</h2>
                <RouterLink to="" class="mt-10 py-4 px-6 bg-primary text-slate-100 rounded-lg hover:opacity-80">
                    Pesan Sekarang
                </RouterLink>
            </div>
        </div>
    </div>

</template>

<script>
export default {
    name:'AdminHero'
}
</script>

<style>

</style>