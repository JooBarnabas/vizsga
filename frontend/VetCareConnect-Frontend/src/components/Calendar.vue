<template>
   
    <Calendar v-model="date" inline class="text-center" dateFormat="dd.mm.yy" />
 
</template>

<script setup>
import Calendar from 'primevue/calendar';
import { usePrimeVue } from 'primevue/config';

import { ref } from "vue";

const date = ref();
const primevue = usePrimeVue();
primevue.config.locale.firstDayOfWeek = 1;
primevue.config.locale.dayNamesMin = ['V', 'H', 'K', 'Sz', 'Cs', 'P', 'Sz'];
primevue.config.locale.monthNames = ['Január', 'Február', 'Március', 'Április', 'Május', 'Június', 'Július', 'Augusztus', 'Szeptember', 'Október', 'November', 'December'];
</script>

<style lang="css">

@media (max-width: 576px) {
 .p-datepicker table td > span {
    width: 1.5rem !important;
    height: 1.5rem !important;
  } 
 
}

</style>