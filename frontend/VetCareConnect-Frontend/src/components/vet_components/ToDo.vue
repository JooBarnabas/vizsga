<template>
    <div class="back">
        <h3>{{ useDateFormat(props.appointmentData.cure_date, "YYYY. MMMM DD. HH:mm").value }}</h3>
        <h4>{{ appointmentData.pet_species }}</h4>
        <p> {{ appointmentData.cure_type }}</p>
        <p>Gazda: {{ appointmentData.owner_name }} ({{ appointmentData.owner_phone }})</p>
    </div>

</template>

<script setup>
import { useDateFormat } from '@vueuse/core';

const props = defineProps(["appointmentData"]);
</script>

<style scoped>
.back {
    background-color: #368267;
    border-radius: 7px;
    padding: 16px;
    margin: 0 10px 10px 0;
    box-shadow: 0 4px 8px 0 rgba(0, 0, 0, 0.2);
}
h3, h4 {
    margin: 5px 0px ;
}
p {
    margin: 5px 0px;
}
</style>