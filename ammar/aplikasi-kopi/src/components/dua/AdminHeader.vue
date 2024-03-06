<template>
    <div class="w-full bg-gradient-to-r from-white to-slate-300">
        <div class="flex justify-between items-center h-[50px]">
            <div class="p-1 cursor-pointer hover:bg-slate-200">
                <i class="right-2">
                    <button id="hamburger" name="hamburger" type="button" class="block">
                        <span class="hamburger-line transition duration-300 ease-in-out origin-top-left bg-dark"></span>
                        <span class="hamburger-line transition duration-300 ease-in-out bg-dark"></span>
                        <span class="hamburger-line transition duration-300 ease-in-out origin-bottom-left bg-dark"></span>
                    </button>
                </i>
            </div>
            <div class="py-2 pr-2  flex items-center">
                <input type="text" v-model="value" class="h-[40px] rounded-lg text-center ring-2 ring-primary" placeholder="Serach...." />
            </div>
        </div>
    </div>
</template>

<script>

export default {
    name: "AdminHeader",
    components: {

    }

}
</script>

<style></style>