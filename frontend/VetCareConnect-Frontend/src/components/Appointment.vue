<template>
  <div class="nextAppointmentCard animation-scale">
    <p class="title">{{ pet }} {{ title }}</p>
    <p class="vet">Orvos: {{ vet }}</p>
    <p class="vet">Helyszín: {{ postalCode }} {{ vetAddress }}</p>
    <p class="date">{{ formattedDate }}</p>
    <button class="btnStyle btnCancelAppointment" @click="Cancel()" v-if="!isOld && formattedCancelDate < date">Időpont lemondása</button>
    <p v-else-if="!isOld">Ezt az időpontot már nem lehet lemondani.</p>
  </div>
</template>

<script setup>
import { useDateFormat } from "@vueuse/core";
import { useUserStore } from '../store/userstore';
import { ref } from "vue";

const store = useUserStore();
const today = ref(new Date());
const cancelBefore = ref(new Date());
cancelBefore.value.setDate(today.value.getDate() + 2);

const props = defineProps({
  pet: String,
  title: String,
  vet: String,
  vetAddress: String,
  postalCode: Number,
  date: String,
  isOld: Boolean,
  appointmentId: Number
});

const formattedDate = useDateFormat(props.date, "YYYY. MMMM DD. HH:mm");
const formattedCancelDate = useDateFormat(cancelBefore, "YYYY-MM-DD HH:mm");

function Cancel(){
    store.showAppointmentCancel(true);
    store.cancelAppointmentId = props.appointmentId;
}

</script>

<style scoped>
.nextAppointmentCard {
  border-radius: 7px;
  background-color: #50b692;
  justify-self: center;
  width: 350px;
  height: 250px;
  padding: 15px;
  padding-left: 25px;
  margin: 10px;
  box-shadow: 0 4px 8px 0 rgba(0, 0, 0, 0.2), 0 6px 20px 0 rgba(0, 0, 0, 0.19);
  display: flex;
  flex-direction: column;
  justify-content: center;
}

p {
  color: white;
  margin-bottom: 5px;
}

.title {
  font-weight: 700;
  font-size: 18px;
  margin: 0;
}

.vet {
  font-size: 12px;
}

.date {
  font-weight: 700;
  font-size: 20px;
  margin: 5px 0px 0px 0px;
}
.btnCancelAppointment{
  background-color: #246951;
  margin-top: 15px;
  padding: 10px 20px;
  width: 200px;
}

@media (min-width: 1260px) {
  .nextAppointmentCard {
    width: 400px;
  }
  .title {
    font-size: 24px;
  }

  .vet {
    font-size: 15px;
  }

  .date {
    font-size: 25px;
  }
}

@media (max-width: 560px){
  .nextAppointmentCard {
    width: 300px;
    height: 220px;
  }
}
</style>
