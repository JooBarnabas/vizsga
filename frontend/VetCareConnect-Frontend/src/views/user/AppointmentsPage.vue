<template>
  <Header></Header>
  <div v-if="!store.show">
    <div>
      <p class="pageTitle">Következő időpontok</p>
    </div>
    <div class="appointments">
      <div v-for="appointment in ownerAppointments">
        <div v-if="!appointment.is_old">
          <Appointment :pet="appointment.pet_name" :title="appointment.cure_type" :vet="appointment.vet_name"
            :postalCode="appointment.vet_postal_code" :vet-address="appointment.vet_address" :date="appointment.cure_date"
            :is-old="appointment.is_old" :appointment-id="appointment.cure_id"  ></Appointment>
        </div>

      </div>
    </div>
    <div class="buttonContainer">
      <router-link to="/idopontfoglalas">
        <button class="newAppointmentButton animation-scale">
          <svg xmlns="http://www.w3.org/2000/svg" fill="white" height="35" viewBox="0 -960 960 960" width="35">
            <path d="M440-440H200v-80h240v-240h80v240h240v80H520v240h-80v-240Z" />
          </svg>
          Új időpont foglalás
        </button>
      </router-link>
    </div>
    <div>
      <p class="pageTitle">Előző időpontok</p>
    </div>
    <div class="appointments">
      <div v-for="appointment in ownerAppointments">
        <div v-if="appointment.is_old">
          <Appointment :pet="appointment.pet_name" :title="appointment.cure_type" :vet="appointment.vet_name"
            :postalCode="appointment.vet_postal_code" :vet-address="appointment.vet_address" :date="appointment.cure_date"
            :is-old="appointment.is_old"></Appointment>

        </div>
      </div>
    </div>
  </div>
  <div v-else class="cancelAppointment">
    <CancelAppointment :get-owner-appointments="getOwnerAppointments"></CancelAppointment>
  </div>
  <Footer></Footer>
</template>

<script setup>
import Header from "../../components/page_controls/Header.vue";
import Footer from "../../components/page_controls/Footer.vue";
import Appointment from "../../components/Appointment.vue";
import ownerservice from "@/services/ownerservice";
import CancelAppointment from "@/components/user_components/CancelAppointment.vue";

import { onMounted, ref } from "vue";
import { storeToRefs } from "pinia";
import { useUserStore } from "../../store/userstore";

const { user } = storeToRefs(useUserStore());
const store = useUserStore();

const ownerAppointments = ref();
const showCancel = ref(store.show);

function getOwnerAppointments(){
  ownerservice.getAppointments(user.value.token).then((resp) => {
    ownerAppointments.value = resp.data;
  });
}
getOwnerAppointments();
</script>

<style lang="css" scoped>
.appointments {
  display: flex;
  padding: 0;
  justify-content: center;
  align-items: center;
  flex-direction: row;
  flex-wrap: wrap;
}

.buttonContainer {
  display: flex;
  flex-direction: row;
  justify-content: center;
}

.newAppointmentButton {
  background: #50b692;
  font-size: 18px;
  font-weight: 700;
  border: 0;
  margin: 5px;
  padding: 15px;
  width: 250px;
  color: white;
  border-radius: 7px;
  box-shadow: 0 4px 8px 0 rgba(0, 0, 0, 0.2), 0 6px 20px 0 rgba(0, 0, 0, 0.19);
  display: flex;
  align-items: center;
  justify-content: center;
  font-family: "Roboto", sans-serif;
}

.buttonContainer a {
  text-decoration: none;
}

.newAppointmentButton svg {
  margin-bottom: 1px;
}
.cancelAppointment{
  height: 80vh;
  display: flex;
  align-items: center;
  justify-content: center;
}

@media (max-width: 959px) {
  .appointments {
    flex-direction: column;
  }
}
</style>
