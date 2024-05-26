<template>
    Home works
</template>

<script setup>
import { ref } from "vue";
import mainservice from "../services/mainservice"

const loadedData = ref();
const sendData = ref();

function loadingData(){
    mainservice.get().then((resp) => {loadedData.value = resp.data}).catch();
}

function postData(){
    mainservice.post(sendData.value).then((resp) => {}).catch();
}
// loadingData();
</script>

<style lang="css" scoped>
</style>