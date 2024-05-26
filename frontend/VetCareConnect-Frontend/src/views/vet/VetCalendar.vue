<template>
    <Header></Header>
    <div class="toDoBack">
        <div class="todaysToDo">
            <h2>{{ selectedDay }} időpontok</h2>
            <hr>
            <div class="toDos">
                <div v-if="showDate">
                    <div v-for="appointmentData in appointmentsData">
                        <ToDo :appointmentData="appointmentData"></ToDo>
                    </div>
                </div>
                <div v-else>
                    Önnek nincs időpontja erre a napra!
                </div>

            </div>
        </div>
        <Calendar v-model="appointmentsDate" inline class="vetCalendar" @date-select="getVetAppointments()"
            :min-date="new Date()" />
    </div>
    <Footer></Footer>
</template>

<script setup>
import { ref } from 'vue';
import Header from '@/components/page_controls/Header.vue';
import Footer from '@/components/page_controls/Footer.vue';
import Calendar from 'primevue/calendar'
import ToDo from '@/components/vet_components/ToDo.vue'
import { usePrimeVue } from 'primevue/config';
import { useDateFormat } from "@vueuse/core";
import vetservice from "@/services/vetservice"
import { storeToRefs } from "pinia";
import { useUserStore } from "../../store/userstore";

const { user } = storeToRefs(useUserStore());

const primevue = usePrimeVue();
primevue.config.locale.dayNamesMin = ['V', 'H', 'K', 'Sz', 'Cs', 'P', 'Sz'];
primevue.config.locale.firstDayOfWeek = 1;
primevue.config.locale.monthNames = ['Január', 'Február', 'Március', 'Április', 'Május', 'Június', 'Július', 'Augusztus', 'Szeptember', 'Október', 'November', 'December'];

const appointmentsDate = ref();
const showDate = ref(null);

let selectedDay = useDateFormat(appointmentsDate, "YYYY. MMMM DD-i");

const selectedDayFormatted = ref(useDateFormat(appointmentsDate, "YYYY-MM-DD"));


const appointmentsData = ref();

function getVetAppointments() {
    vetservice.getVetsAppointmentToDays(user.value.token, selectedDayFormatted.value)
        .then((resp) => {
            if (resp.data == "Nincs időpont") {
                showDate.value = false;
            } else {

                appointmentsData.value = resp.data;
                showDate.value = true;
            }
        });

}
getVetAppointments()
</script>

<style scoped>

h2 {
    margin: 14px 0 0;
}

.toDoBack {
    margin-top: 60px;
    display: flex;
    flex-wrap: wrap;
    justify-content: center;
    align-items: center;
    gap: 50px;
    padding: 0 60px;
}

.todaysToDo {
    height: 650px;
    width: 400px;
    border-radius: 7px;
    background-color: #50B692;
    padding: 24px;
    color: white;
    box-shadow: 0 4px 8px 0 rgba(0, 0, 0, 0.2);
    animation: load 0.5s ease-out;

}

.todaysToDo hr {
    border: #368267 3px solid;
    opacity: 1;
    border-radius: 50px;
}

.todaysToDo .toDos {
    overflow-y: auto;
    max-height: 530px;
}

/* width */
.toDos::-webkit-scrollbar {
    width: 7px;
}

/* Track */
.toDos::-webkit-scrollbar-track {
    background: #ccc;
    border-radius: 7px;
}

/* Handle */
.toDos::-webkit-scrollbar-thumb {
    background: #368267;
    border-radius: 7px;
}

/* Handle on hover */
.toDos::-webkit-scrollbar-thumb:hover {
    background: #246951;
}

.vetCalendar {
    width: 800px;
    height: 650px;
    border-radius: 7px;
    box-shadow: 0 4px 8px 0 rgba(0, 0, 0, 0.2);
    animation: load 0.5s ease-out;
}

@media (max-width: 650px) {
    .toDoBack {
        padding: 0px;
    }

    .todaysToDo {
        width: 300px;
    }
    .toDos {
        max-height: 500px !important;

    }
}

</style>