<template>
  <Header></Header>
  <h1 class="pageTitle">Időpontfoglalás</h1>
  <div class="page">
    <div v-if="!showBookApprove" class="book">
      <div class="bookData animation-scale">
        <div class="choosePanel">
          <div>
            <p>Válasszon orvost!</p>
            <select v-model="choosedData.vet" name="vets" id="vets" class="selectClass" @change="refreshTimes()">
              <option value="0" disabled selected hidden>
                Kérem válasszon!
              </option>
              <option v-for="vet in vets" :value="vet">{{ vet.name }}</option>
            </select>
          </div>

          <div>
            <p>
              Válassza ki az időpont típusát!
            </p>
            <select v-model="choosedData.type" name="types" id="type" class="selectClass">
              <option value="0" disabled selected hidden>
                Kérem válasszon!
              </option>
              <option v-for="curetype in cureTypes" :value="curetype">
                {{ curetype.type }}
              </option>
            </select>
          </div>
          <div>
            <p>
              Válassza ki kiskedvencét!
            </p>
            <select v-model="choosedData.pet" @click="havePets()" name="pets" id="pet" class="selectClass">
              <option value="0" disabled selected hidden >
                Kérem válasszon!
              </option>
              <option v-for="pet in pets" :value="pet">{{ pet.name }}</option>
            </select>
          </div>
        </div>
      </div>

      <div class="calendarAndChoosePanel animation-scale">
        <Calendar class="calendar" v-model="choosedDate" :min-date="new Date()" @date-select="refreshTimes()" />
        <div class="chooseDate middle">
          <h3 class="choosedDate">{{ formattedDate }}</h3>
          <div class="line"></div>
          <div v-if="!isClosed" class="dates animation-scale">
            <div v-for="(time, index) in appointments" :key="index">
              <div class="times btnStyle" @click="isActiveToggle(index, time)" :class="{ active: activeIdx == index }">
                {{ time }}
              </div>
            </div>
          </div>
          <div v-else class="closed animation-scale">
            A válaszott orvoshoz erre a napra nem foglalható időpont!
          </div>
          <div>
            <button class="btnStyle btnBook" @click="BookClick()">
              Lefoglalom
            </button>
          </div>
        </div>
      </div>
    </div>
    <div v-else>
      <AppointmentApprove @remove="hideBook" :choosed-vet="choosedData.vet" :choosed-pet="choosedData.pet"
        :choosed-type="choosedData.type" :choosed-date="formattedDate" :choosed-time="choosedData.time"
        :date-format="dateSend">
      </AppointmentApprove>
    </div>
  </div>
  <Footer></Footer>
</template>

<script setup>
import Header from "../../components/page_controls/Header.vue";
import Footer from "../../components/page_controls/Footer.vue";
import Calendar from "../../components/Calendar.vue";
import vetservice from "../../services/vetservice.js";

import { ref, onMounted } from "vue";
import { useDateFormat } from "@vueuse/core";
import { storeToRefs } from "pinia";
import { useUserStore } from "../../store/userstore";
import { defineAsyncComponent } from "vue";
import { useRoute } from "vue-router";
import { useToast } from 'vue-toastification'


const store = useUserStore();
const toast = useToast();

const AppointmentApprove = defineAsyncComponent(() =>
  import("../../components/user_components/AppointmentApprove.vue")
);



const choosedData = ref({
  vet: { id: 0 },
  type: { id: 0 },
  pet: { id: 0 },
  time: "",
});
const choosedDate = ref();
const formattedDate = useDateFormat(choosedDate, "YYYY. MMMM DD.");
const dateSend = useDateFormat(choosedDate, "YYYY-MM-DD");

const activeIdx = ref(-1);

const showBookApprove = ref(false);
const selectedDoctorId = ref(null);
const route = useRoute();

const vets = ref();
const cureTypes = ref([]);
const pets = ref([]);
const appointments = ref([]);
const isClosed = ref(false);


const { user } = storeToRefs(useUserStore());

function isActiveToggle(index, time) {
  activeIdx.value = index;
  choosedData.value.time = time;
}

function BookClick() {
  if (choosedData.value.vet == "") toast.error("Kérem válasszon orvost!", { position: "top-center" });
  else if (choosedData.value.type == "") toast.error("Kérem válassza ki az időpont típusát!", { position: "top-center" });
  else if (choosedData.value.pet == "") toast.error("Kérem válassza ki kisállatát!", { position: "top-center" });
  else if (isClosed.value) toast.error("A választott napra nem foglalható időpont!", { position: "top-center" });
  else if (choosedData.value.time == "") toast.error("Kérem válasszon időpontot!", { position: "top-center" });
  else showBookApprove.value = true;
}


function hideBook() {
  showBookApprove.value = false;
}

function refreshTimes() {
  const freeAppointmentData = {
    id: choosedData.value.vet.id,
    date: dateSend.value
  };
  if (choosedData.value.vet.id != null) {
    vetservice
      .getFreeAppointments(
        freeAppointmentData.id,
        freeAppointmentData.date,
        user.value.token
      )
      .then((resp) => {
        appointments.value = resp.data;
        if (appointments.value == "Zárva!") {
          isClosed.value = true;
        } else {
          isClosed.value = false;
        }
      });
  }
}

onMounted(() => {
  vetservice.getAllVet(user.value.token).then((resp) => {
    vets.value = resp.data;
    if (route.params.doctorId != "") {
      selectedDoctorId.value = parseInt(route.params.doctorId);
      choosedData.value.vet = vets.value.find(
        (x) => x.id == selectedDoctorId.value
      );
      refreshTimes();
    } else choosedData.value.vet = 0;
  });
  vetservice.getAllCureTypes().then((resp) => {
    cureTypes.value = resp.data;
    choosedData.value.type = 0;

  });

  vetservice.getUsersPets(user.value.token).then((resp) => {
    pets.value = resp.data;
    choosedData.value.pet = 0;
    havePets();
  });
});

function havePets() {
  if (pets.value.length ==  0) toast.warning("Önnek nincs kiskedvence!", { position: "top-center" });
}



</script>

<style scoped>
.page {
  display: flex;
  flex-direction: row;
  align-items: center;
  justify-content: center;
}

.header {
  text-align: center;
  color: #246951;
  margin-top: 20px;
  margin-bottom: 30px;
}

.book {
  display: flex;
  flex-direction: row;
  align-items: start;
  justify-content: center;
}

.bookData {
  margin-right: 20px;
}

.calendarAndChoosePanel {
  display: flex;
  flex-direction: row;
  margin-left: 20px;
}

.middle {
  display: flex;
  align-items: center;
  flex-direction: column;
}

.active {
  border: 1.5px solid #064931;
  background-color: #064931 !important;
}

.btnBook {
  background-color: #50b692;
  margin-top: 15px;
  padding: 10px 20px;
}

.colorMeaning {
  height: 35px;
  width: 35px;
  border-radius: 100%;
}

.choosed {
  background-color: #3ca27e;
  margin-right: 10px;
  margin-bottom: 5px;
}

.choosedRow {
  display: flex;
  flex-direction: row;
  align-items: center;
}

.canBeReservated {
  background-color: #3ca27e;
  margin-right: 10px;
  opacity: 50%;
}

.canBeReservatedRow {
  display: flex;
  flex-direction: row;
  align-items: center;
}

.meanings {
  padding-top: 25px;
  padding-left: 25px;
  height: 130px;
  display: flex;
  flex-direction: column;
}

.meanings div {
  margin-bottom: 5px;
  align-items: center;
  text-wrap: nowrap;
}

.choosePanel {
  background-color: #50b692;
  border-radius: 7px;
  color: white;
  width: 300px;
  height: 400px;
  min-width: 300px;
  padding: 40px;
  margin: 0;
}

.choosePanel div {
  margin-bottom: 20px;
}

.choosePanel div p {
  margin-bottom: 5px;
}

.selectClass {
  width: 215px;
  height: 50px;
  border: none;
  border-radius: 7px;
  background-color: #368267;
  padding: 5px 0 5px 10px;
  color: white;
  font-size: 16px;
}

.chooseDate {
  background-color: #368267;
  height: 480px;
  width: 380px;
  min-width: 250px;
  padding: 40px;
  color: white;
  border-radius: 0px 7px 7px 0px;
}

.line {
  height: 5px;
  background-color: #50b692;
  border-radius: 7px;
  width: 100%;
}

.times {
  width: 60px;
  height: 30px;
  background-color: #50b692;
  border-radius: 7px;
  margin: 5px;
  text-align: center;
  padding: 5px;
}

.calendar {
  height: 480px;
  width: 410px;
}

.meaningsInDates {
  display: none;
}

.dates {
  flex-wrap: wrap;
  display: flex;
  justify-content: center;
}

.errorMessage {
  align-items: center;
  justify-content: center;
  display: flex;
  margin-top: 10px;
  font-size: small;
  margin-bottom: 0px;
  background-color: #d63227;
  height: 30px;
  text-align: center;
  border: 1px solid red;
  border-radius: 7px;
}

.closed {
  text-align: center;
  background-color: #50b692;
  border-radius: 7px;
  margin: 10px;
  padding: 10px;
}

.chooseDate {
  text-align: center;
}

h3 {
  margin-top: 0px !important;
  margin-bottom: 10px !important;
}

/*----------- media töréspontok ------------*/
@media (min-width: 1200px) {

  .header {
    font-size: large;
    font-weight: 400;
  }

  .chooseDate {
    height: 480px;
    width: 380px;
    min-width: 250px;
    padding: 40px;
  }

  .choosePanel div {
    padding: 0px;
  }

  .calendar {
    overflow: hidden;
    border-radius: 7px 0 0 7px;
  }
}

@media (max-width: 1200px) {
  .book {
    flex-direction: column;
    align-items: center;
  }

  .bookData {
    margin: 0px;
    margin-bottom: 15px;
    width: fit-content;
    display: flex;
    justify-content: center;

  }

  .header {
    font-size: 4rem;
    font-weight: 400;
  }

  .calendar {
    overflow: hidden;
    border-radius: 7px 0 0 7px;
  }

  .calendarAndChoosePanel {
    margin: 0px;
    margin-top: 15px;
    margin-bottom: 30px !important;
  }

  .choosePanel {
    width: 790px;
    height: 170px;
    display: flex;
    align-items: center;
    justify-content: center;
    padding: 30px;
  }

  .choosePanel div {
    padding: 0px;
    margin: 5px;
    text-align: center;
    align-items: center;
    display: flex;
    flex-direction: column;
  }

  .choosePanel.p {
    margin-top: 0px;
  }

  .meanings {
    margin: auto;
    padding: 10px 40px;
    align-items: center;
    width: 300px;
  }

  .errMess {
    margin-bottom: -10px;
  }

  .meaningsInDates {
    display: flex;
    background-color: #246951;
    border-radius: 7px;
    margin-top: 10px;
    align-items: start;
    justify-content: center;
  }

  .meaningsInDates div {
    display: flex;
    flex-direction: row;
  }

  .meaningsInDates div p {
    text-align: center;
  }

  .meaningsOutside {
    display: none;
  }
}

@media (max-width: 991px) {
  .header {
    font-size: 4rem;
    font-weight: 400;
  }

  .choosePanel {
    height: 380px;
    width: 410px;
    min-width: 250px;
    padding: 30px;
    display: flex;
    flex-direction: column;
    align-items: center;
  }

  .calendar {
    height: 450px;
    border-radius: 7px !important;
    overflow: hidden !important;
  }

  .calendarAndChoosePanel {
    margin-top: 20px;
    flex-direction: column;
  }

  .chooseDate {
    width: 410px;
    height: 480px;
    border-radius: 7px;
    margin-top: 20px;
  }

  .meaningsInDates {
    display: block;
    padding: 20px;
    background-color: #246951;
    border-radius: 7px;
    margin-top: 20px;
    align-items: center;
  }

  .meaningsOutside {
    display: none;
  }
}

@media (max-width: 768px) {
  .calendar {
    height: 380px;
    border-radius: 7px;
    overflow: hidden !important;
  }
}

@media (max-width: 576px) {
  .header {
    font-size: 2rem;
    margin-bottom: 15px;
  }

  .calendar {
    width: 250px;
    height: 280px;
    overflow: hidden !important;
  }

  .bookData {
    flex-direction: column;
  }

  .chooseDate {
    width: 250px;
  }

  .choosePanel {
    height: 350px;
    width: 250px;
    padding: 30px;
  }

  .meaningsInDates {
    display: none;
  }

  .meanings {
    align-items: start;
  }

  .meaningsOutside {
    display: flex;
    flex-direction: column;
    justify-content: start;
    margin-bottom: 0;
    height: 100px;
    padding: 16px 0 0;
    width: fit-content;
  }

  .selectClass {
    height: 30px;
    width: 200px;
    font-size: 0.8rem;
  }

  .chooseDate {
    height: 500px;
  }

  .dates {
    justify-content: center !important;
  }

  .choosedDate {
    font-size: 1.1rem;
  }

  .errorMessage {
    font-size: xx-small;
  }
}
</style>
