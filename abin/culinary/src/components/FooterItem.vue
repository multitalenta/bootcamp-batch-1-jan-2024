<template>
  <div class="bottom-0 w-full mt-14">
    <div
      class="flex flex-col md:flex-row mx-auto pt-20 items-center justify-center md:justify-between bg-tertier text-center md:text-left"
    >
      <div class="mx-auto md:text-left md:mb-10 text-lg text-slate-600 text-center">
        <h3 class="text-3xl font-bold text-center md:text-left text-slate-800">Culinary</h3>
        <p class="mt-3 text-center mx-auto">Jl.Bintaro Kecamatan Pondok Aren</p>
        <p>Jakarta</p>
        <p>Surabaya</p>
        <p>Bandung</p>
      </div>
      <div class="text-left mx-auto md:mb-24">
        <h3 class="text-2xl text-center font-medium md:text-left text-slate-800 mb-2">Kategori</h3>
        <p>
          <RouterLink to="" class="text-xl text-slate-600"
            ><i class="fa-solid fa-arrow-right"></i> Best Foods</RouterLink
          >
        </p>
        <p>
          <RouterLink to="" class="text-xl text-slate-600"
            ><i class="fa-solid fa-arrow-right"></i> Order Food Now</RouterLink
          >
        </p>
      </div>
    </div>
    <p class="text-center bg-tertier pb-5 pt-2 border-t">Created By &copy;3A New Team</p>
  </div>
</template>

<script>
export default {
  name: 'FooterItem'
}
</script>

<style></style>
