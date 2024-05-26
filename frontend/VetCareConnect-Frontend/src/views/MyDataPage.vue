<template>
    <Header></Header>
    <div class="main">
        <VetDataEdit v-if="user.role == 1"></VetDataEdit>
        <UserDataEdit v-if="user.role == 0"></UserDataEdit>
    </div>
    <Footer></Footer>
</template>

<script setup>
import Header from '@/components/page_controls/Header.vue';
import Footer from '@/components/page_controls/Footer.vue';
import VetDataEdit from '@/components/vet_components/VetDataEdit.vue'
import UserDataEdit from '@/components/user_components/UserDataEdit.vue'
import { useUserStore } from '@/store/userstore';
import { storeToRefs } from 'pinia';

const { user } = storeToRefs(useUserStore());
</script>

<style scoped>
.main {
    display: flex;
    justify-content: center;
    align-items: center;
    height: 80vh;
}


</style>