<template>
    <Header></Header>
    <h1 class="pageTitle">Beállítások</h1>
    <h2 class="titles">Nyitvatartás</h2>
    <div class="openingHours"  >
        <div class="normalOpening animation-scale" v-if="opening.length != 0">
            <DataTable :value="opening" class="openingTable">
                <Column field="day" header="Nap"></Column>
                <Column field="working_hours" header="Nyitvatartás"></Column>
            </DataTable>
            <a href="#edit">
                <button class="btnStyle btnEdit">Módosítás</button>
            </a>
        </div>
        <div class="specialOpening animation-scale" v-if="specialOpening.length != 0">
            <DataTable :value="specialOpening" class="openingTable">
                <Column field="date" header="Dátum"></Column>
                <Column field="working_hours" header="Nyitvatartás"></Column>
            </DataTable>
            <a href="#editSpecial">
                <button class="btnStyle btnEdit">Módosítás</button>
            </a>
        </div>
        <div v-if="specialOpening.length == 0 && opening.length == 0">
            <p>Önnek még nincs nyitvatartása. Kérem adjon hozzá nyitvatartást!</p>
        </div>
    </div>
    <h2 class="titles" id="edit">Nyitvatartás módosítása</h2>
    <div class="main">
        <div class="days">
            <div v-for="day in days">
                <button class="btnStyle btnDays" @click="showDayOpening(day)">
                    {{ day }}
                </button>
            </div>
        </div>
        <div class="opening" v-if="showOpening">
            <div class="daily animation-scale">
                <h1>{{ choosedDay }}</h1>
                <div class="closed">
                    <label v-if="!isOpen">Zárva</label>
                    <label v-else>Nyitva</label> <br />
                    <InputSwitch v-model="isOpen" />
                </div>
                <div v-if="isOpen">
                    <div>
                        <label>Nyitvatartás</label>
                        <InputMask mask="99:99-99:99" placeholder="08:00-16:00" v-model="openingHours" />
                    </div>
                    <div>
                        <label>Munkaközi szünet</label>
                        <InputMask mask="99:99-99:99" placeholder="12:00-13:30" :disabled="!isBreak" v-model="breakHours" />
                        <div>
                            <label v-if="isBreak">Van munkaközi szünet</label>
                            <label v-else>Nincs munkaközi szünet</label> <br>
                            <InputSwitch v-model="isBreak" />
                        </div>
                    </div>
                </div>
                <div v-else>Ön ezen a napon zárva tart!</div>
                <button class="btnStyle" @click="saveOpening()">
                    Nyitvatartás mentése
                </button>
            </div>
        </div>
    </div>

    <h2 class="titles" id="editSpecial">Különleges nyitvatartások módosítása</h2>
    <div class="opening specialOpeningEdit">
        <div class="daily special animation-scale">
            <h2>Különleges nyitvatartás hozzáadása</h2>
            <Calendar v-model="specialDate" dateFormat="yy-mm-dd" :min-date="new Date()" showIcon iconDisplay="input"
                class="calendarSpecial" />
            <div class="closed">
                <label v-if="!isOpenSpecial">Zárva</label>
                <label v-else>Nyitva</label> <br />
                <InputSwitch v-model="isOpenSpecial" />
            </div>
            <div v-if="isOpenSpecial">
                <div>
                    <label>Nyitvatartás</label>
                    <InputMask mask="99:99-99:99" placeholder="08:00-16:00" v-model="specialOpeningHours" />
                </div>
                <div>
                    <label>Munkaközi szünet</label>
                    <InputMask mask="99:99-99:99" placeholder="12:00-13:30" :disabled="!isBreakSpecial"
                        v-model="specialBreakHours" />
                    <div>
                        <label v-if="isBreakSpecial">Van munkaközi szünet</label>
                        <label v-else>Nincs munkaközi szünet</label> <br>
                        <InputSwitch v-model="isBreakSpecial" />
                    </div>
                </div>
            </div>
            <div v-else>Ön ezen a napon zárva tart!</div>
            <button class="btnStyle" @click="saveSpecialOpening()">
                Nyitvatartás mentése
            </button>
        </div>
        <div class="specialTable animation-scale" v-if="specialOpening.length != 0">
            <DataTable v-model:selection="selectSpecialDelete" :value="specialOpening" dataKey="id">
                <Column selectionMode="multiple"></Column>
                <Column field="date" header="Dátum"></Column>
                <Column field="working_hours" header="Nyitvatartás"></Column>
            </DataTable>
            <button class="btnStyle btnDelete" @click="deleteSpecial()">Törlés</button>
        </div>
    </div>
    <Footer></Footer>
</template>

<script setup>
import Header from "@/components/page_controls/Header.vue";
import Footer from "@/components/page_controls/Footer.vue";
import InputSwitch from "primevue/inputswitch";
import InputMask from "primevue/inputmask";
import Calendar from 'primevue/calendar';
import DataTable from 'primevue/datatable';
import Column from 'primevue/column';

import vetService from "@/services/vetservice";

import { ref, onBeforeMount } from "vue";
import { storeToRefs } from "pinia";
import { useUserStore } from "../../store/userstore";
import { useToast } from 'vue-toastification';
import { useDateFormat } from "@vueuse/core";

const { user } = storeToRefs(useUserStore());
const toast = useToast();

const isBreak = ref();
const isBreakSpecial = ref();
const isOpen = ref();
const isOpenSpecial = ref();

const showOpening = ref(false);
const choosedDay = ref();

const openingHours = ref();
const specialOpeningHours = ref();
const breakHours = ref();
const specialBreakHours = ref();

const opening = ref([]);
const specialOpening = ref([]);
const specialOpeningDates = ref([]);
const selectSpecialDelete = ref();

const error = ref(false);

const specialDate = ref(new Date());
const specialDateFormatted = useDateFormat(specialDate, "YYYY-MM-DD");

let sendOpeningData = [];
let openDays = [];
let dataOpen = [];
let dataBreak = [];
let opened = [];

const days = [
    "hétköznapok",
    "minden nap",
    "hétfő",
    "kedd",
    "szerda",
    "csütörtök",
    "péntek",
    "szombat",
    "vasárnap",
];

function showDayOpening(day) {
    showOpening.value = true;
    choosedDay.value = day;
}

function addOpeningData(data) {
    vetService.addOpeningTime(user.value.token, data).then(resp => {
        getOpenings();
    });
}

function deleteOpening(day) {
    vetService.deleteOpening(user.value.token, day).then(resp => {
        getOpenings();
    });;
}

function getOpenings() {
    vetService.getOpenings(user.value.token).then(resp => {
        opening.value = resp.data;
        (opening.value).forEach(o => {
            openDays.push(o.day);
        });
    });
}

function getSpecialOpenings() {
    vetService.getSpecialOpenings(user.value.token).then(resp => {
        specialOpening.value = resp.data;
        (specialOpening.value).forEach(o => {
            specialOpeningDates.value.push(o.date);
        });
    });
}

function addSpecialOpening(data) {
    vetService.addSpecialOpeningTime(user.value.token, data);
}

function deleteSpecialOpening(id) {
    vetService.deleteSpecialOpening(user.value.token, id);
}

function isOpenTime(day) {
    dataOpen = [];
    dataBreak = [];
    dataOpen = openingHours.value.split("-");
    if (dataOpen[0] > dataOpen[1]) {
        toast.error("Rossz nyitvatartás formátum!", { position: "top-center" });
        error.value = true;
        return;
    }
    if (isBreak.value) {
        dataBreak = breakHours.value.split("-");
        opened = [
            dataOpen[0] + "-" + dataBreak[0],
            dataBreak[1] + "-" + dataOpen[1],
        ];
        if (dataOpen[0] > dataBreak[0]) {
            toast.error("Rossz nyitvatartás formátum!", { position: "top-center" });
            error.value = true;
            return;
        } else if (dataBreak[1] > dataOpen[1]) {
            toast.error("Rossz nyitvatartás formátum!", { position: "top-center" });
            error.value = true;
            return;
        } else if (dataBreak[0] > dataBreak[1]) {
            toast.error("Rossz nyitvatartás formátum!", { position: "top-center" });
            error.value = true;
            return;
        }
        opened.forEach((o) => {
            sendOpeningData.push({ working_hours: o, day: day });
        });
    } else {
        sendOpeningData.push({ working_hours: openingHours.value, day: day });
    }
}

function addOpenings(day) {
    getOpenings();
    if (sendOpeningData.length != 0) {
        if (openDays.includes(day)) {
            deleteOpening(day);
        } else if (day == "minden nap") {
            if (openDays.length != 0) {
                deleteOpening("minden nap");
            }
        } else if (day == "hétköznapok") {
            if (openDays.length != 0) {
                deleteOpening("hétköznapok");
            }
        }
        addOpeningData(sendOpeningData);
        toast.success(`Nyitvatartás elmentve a következő nap(ok)ra: ${day}.`, { position: "top-center" });
    } else {
        if (openDays.includes(day)) {
            deleteOpening(day);
        } else if (day == "minden nap") {
            if (openDays.length != 0) {
                deleteOpening("minden nap");
            }
        } else if (day == "hétköznapok") {
            if (openDays.length != 0) {
                deleteOpening("hétköznapok");
            }
        }
        toast.success(`Nyitvatartás elmentve a következő nap(ok)ra: ${day}.`, { position: "top-center" });
    }

}

function saveOpening() {
    //validálás
    if (isOpen.value) {
        if (openingHours.value == null || openingHours.value == "" || openingHours.value == undefined || openingHours.value.length != 11) {
            toast.error(`Kérem töltse ki a nyitvatartási idő mezőt!`, { position: "top-center" });
            return;
        } else if (isBreak.value) {
            if (breakHours.value == null || breakHours.value == "" || breakHours.value == undefined || breakHours.value.length != 11) {
                toast.error(`Kérem töltse ki a munkaközi szünet mezőt!`, { position: "top-center" });
                return;
            }
        }
    }
    //mentés
    if (choosedDay.value == "hétköznapok") {
        sendOpeningData = [];
        for (let i = 2; i < days.length - 2; i++) {
            if (isOpen.value) {
                isOpenTime(days[i]);
                if (error.value) {
                    error.value = false;
                    return;
                }
            }
        }
        addOpenings("hétköznapok");
    } else if (choosedDay.value == "minden nap") {
        sendOpeningData = [];
        for (let i = 2; i < days.length; i++) {
            if (isOpen.value) {
                isOpenTime(days[i]);
                if (error.value) {
                    error.value = false;
                    return;
                }
            }
        }
        addOpenings("minden nap");
    } else {
        sendOpeningData = [];
        let dayClosed = "";
        for (let i = 2; i < days.length; i++) {
            if (days[i] == choosedDay.value) {
                if (isOpen.value) {
                    isOpenTime(days[i]);
                    if (error.value) {
                        error.value = false;
                        return;
                    }
                }
                else {
                    dayClosed = days[i];
                }
                addOpenings(days[i]);
            }
        }
    }
    getOpenings();
}

function saveSpecialOpening() {
    //validálás
    if (specialOpeningDates.value.includes(specialDateFormatted.value)) {
        toast.error(`Önnek erre a napra már van különleges nyitvatartása! Távolítsa el, majd adjon hozzá másik nyitvatartást!`, { position: "top-center" });
        return;
    }
    if (isOpenSpecial.value) {
        if (specialOpeningHours.value == null || specialOpeningHours.value == "" || specialOpeningHours.value == undefined || specialOpeningHours.value.length != 11) {
            toast.error(`Kérem töltse ki a nyitvatartási idő mezőt!`, { position: "top-center" });
            return;
        } else if (isBreakSpecial.value) {
            if (specialBreakHours.value == null || specialBreakHours.value == "" || specialBreakHours.value == undefined || specialBreakHours.value.length != 11) {
                toast.error(`Kérem töltse ki a munkaközi szünet mezőt!`, { position: "top-center" });
                return;
            }
        }
    }
    //mentés
    sendOpeningData = [];
    dataOpen = [];
    dataBreak = [];
    if (isOpenSpecial.value) {
        dataOpen = specialOpeningHours.value.split("-");
        if (dataOpen[0] > dataOpen[1]) {
            toast.error("Rossz nyitvatartás formátum!", { position: "top-center" });
            error.value = true;
            return;
        }
        if (isBreakSpecial.value) {
            dataBreak = specialBreakHours.value.split("-");
            opened = [
                dataOpen[0] + "-" + dataBreak[0],
                dataBreak[1] + "-" + dataOpen[1],
            ];
            if (dataOpen[0] > dataBreak[0]) {
                toast.error("Rossz nyitvatartás formátum!", { position: "top-center" });
                error.value = true;
                return;
            } else if (dataBreak[1] > dataOpen[1]) {
                toast.error("Rossz nyitvatartás formátum!", { position: "top-center" });
                error.value = true;
                return;
            } else if (dataBreak[0] > dataBreak[1]) {
                toast.error("Rossz nyitvatartás formátum!", { position: "top-center" });
                error.value = true;
                return;
            }
            opened.forEach((o) => {
                sendOpeningData.push({ working_hours: o, date: specialDateFormatted.value });
            });
        } else {
            sendOpeningData.push({ working_hours: specialOpeningHours.value, date: specialDateFormatted.value });
        }

    } else {
        sendOpeningData.push({ working_hours: "zárva", date: specialDateFormatted.value });
    }

    addSpecialOpening(sendOpeningData);
    getSpecialOpenings();
}
function deleteSpecial() {
    if (selectSpecialDelete.value == undefined) {
        toast.error(`Kérem válassza ki, hogy melyik nyitvatartást szeretné törölni!`, { position: "top-center" });
        return;
    }
    (selectSpecialDelete.value).forEach(d => {
        deleteSpecialOpening(d.id);
    });
    specialOpeningDates.value = [];
    getSpecialOpenings();
}

getOpenings();
getSpecialOpenings();
onBeforeMount(() => {
    getOpenings();
    getSpecialOpenings();
});
</script>

<style lang="css" scoped>
.titles {
    margin-left: 40px;
    color: #368267;
    font-weight: 500;
}

.main {
    display: flex;
    flex-direction: column;
    justify-content: center;
    align-items: center;
}

.daily {
    background-color: #50b692;
    height: 420px;
    width: 350px;
    border-radius: 7px;
    padding: 40px;
    color: white;
    font-weight: 500;
}

.daily div {
    margin-bottom: 10px;
}

.opening {
    margin: 30px 40px;
    display: flex;
    align-items: center;
    justify-content: center;
}

.openingHours {
    margin: 0px 50px;
    display: flex;
    align-items: start;
    justify-content: center;
    flex-direction: row;
}

.normalOpening, .specialOpening {
    margin: 0px 20px;
    width: 280px;
    display: flex;
    flex-direction: column;
    justify-content: center;
    align-items: center;
}

.btnStyle {
    background-color: #246951;
    padding: 10px 20px;
}

.btnEdit {
    margin-top: 20px;
}

a {
    text-decoration: none;
}

.p-inputswitch {
    margin-bottom: 0px !important;
}

.days {
    display: flex;
    flex-direction: row;
    flex-wrap: wrap;
    margin: 20px;
    align-items: center;
    justify-content: center;
}

.btnDays {
    margin: 10px;
    padding: 10px 20px;
    width: 140px;
}

.special {
    width: 350px;
    height: 500px;
    margin: 0px 20px;
}

.specialTable {
    display: flex;
    flex-direction: column;
    align-items: center;
    justify-content: center;
    margin: 0px 20px;
}
.specialOpeningEdit {
    display: flex;
    align-items: start;
    justify-content: center;
}
.openingTable {
    width: 280px;
}

.btnDelete {
    background-color: #af3b3b;
    margin-top: 20px;
}
.calendarSpecial {
    margin-bottom: 10px;
    width: 150px;
}
@keyframes load {
    0%{
        transform: scale(0.5);
        opacity: 0;
    }
    100%{
        transform: scale(1);
        opacity: 1;
    }
}
@media(max-width: 991px) {
    .days {
        flex-direction: column;
    }

    .main {
        flex-direction: row;
    }
}
@media(max-width: 750px) {
    .openingHours {
        flex-direction: column;
        align-items: center;
    }
    .normalOpening {
        margin-bottom: 50px;
    }
    
}

@media (max-width: 900px) {
    .specialOpeningEdit {
        display: flex;
        flex-direction: column;
        align-items: center;
        justify-content: center;
    }
    .specialTable {
        margin-top: 40px;
    }
}

@media (max-width: 576px) {
    .days {
        flex-direction: row;
    }

    .main {
        flex-direction: column;
    }

    .daily {
        width: 300px;
    }
}
</style>
