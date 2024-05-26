<template>
    <div class="backToHome">
        <img @click="back()" src="../../assets/icons/arrow_back.svg" />
    </div>
    <div class="signInBackground">
        <VetOrUser v-if="isUserTypeSended" @removeVetOrUser="getUserType"></VetOrUser>
        <VetRegister v-if="chosedType == 'vet'"></VetRegister>
        <UserRegiser v-if="chosedType == 'user'"></UserRegiser>
    </div>
</template>

<script setup>
import router from "@/router";
import { ref } from "vue";
import VetOrUser from "../../components/login_components/VetOrUser.vue";
import { defineAsyncComponent } from 'vue'

const VetRegister = defineAsyncComponent(() =>
  import('../../components/login_components/VetRegister.vue')
)

const UserRegiser = defineAsyncComponent(() =>
  import('../../components/login_components/UserRegister.vue')
)


const isUserTypeSended = ref(true);
const chosedType = ref("");

function getUserType(indexOfChosed) {
    if (indexOfChosed.value == 0) chosedType.value = "user";
    else if (indexOfChosed.value == 1) chosedType.value = "vet";
    else return;
    isUserTypeSended.value = false;
}

function back() {
    router.go(-1);
}
</script>

<style lang="css" scoped></style>
