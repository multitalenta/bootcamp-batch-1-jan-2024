<template>
    <div class="w-full h-full flex">
        <AdminSidebar />
        <div class="w-full h-full flex flex-col">
            <AdminHeader />
            <div class="flex-grow">
                <TambahProduk />
            </div>
        </div>
    </div>
</template>

<script>
import AdminHeader from "@/components/dua/AdminHeader.vue";
import AdminSidebar from "@/components/dua/AdminSidebar.vue";
import DashboardAdmin from "./DashboardAdmin.vue";
import TambahProduk from "./TambahProduk.vue";
import FormProduk from "./FormProduk.vue";

export default {
    name: "MainAdmin",
    components: {
    AdminHeader,
    AdminSidebar,
    DashboardAdmin,
    TambahProduk,
    FormProduk
}

}
</script>

<style></style>