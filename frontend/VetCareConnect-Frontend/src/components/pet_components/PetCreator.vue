<template>
    <div class="darkBack">
        <div class="petCreatingForm animation-scale">

            <div class="close">
                <img @click="showCreator()" src="../../assets/icons/arrow_back.svg">
            </div>

            <h4>Hozza létre kedvence adatlapját!</h4>
            <p class="mandatory">* Kötelező kitölteni</p>
            <form submit.pervent="handleSubmit"></form>
            
            <div class="pages">
                <button class="page" @click="active = 0" :class="{ 'activePage': active == 0 }">1</button>
                <button class="page" @click="active = 1" :class="{ 'activePage': active == 1 }">2</button>
            </div>

            <TabView v-model:activeIndex="active">
                <TabPanel>
                    <label>Kedvence neve*:</label>
                    <InputText v-model.trim="pet.name"></InputText>

                    <label>Chip szám (15 számjegy)*:</label>
                    <InputMask v-model="pet.chip_number" mask="999999999999999" />

                    <label>Törzskönyv száma (8 számjegy)*:</label>
                    <InputMask v-model="pet.pedigree_number" mask="99999999" />

                    <label>Fajtajelleg*:</label>
                    <Dropdown v-model="pet.species" :options="species" showClear placeholder="Kérem válasszon!"
                        class="petDropdown" />

                        <label>Ivar*:</label>
                        
                        <Dropdown v-model="pet.gender" :options="genders" showClear placeholder="Kérem válasszon!"
                        class="petDropdown" />
                        <button class="btnStyle" @click="active = 1">Tovább</button>
                    </TabPanel>
                    

                <TabPanel>
                    <label>Testtömeg (kg)*:</label>
                    <InputNumber v-model="pet.weight" placeholder="0" :minFractionDigits="0" :maxFractionDigits="2"
                    :min="0.1" :max="999" suffix=" kg" :useGrouping="false" />
                    <label>Születési dátuma*:</label>
                    <Calendar class="bornDate" v-model="pet.born_date" :max-date="new Date()" dateFormat="yy.mm.dd"
                        placeholder="éééé.hh.nn" />
                    <label>Megjegyzés:</label>
                    <Textarea class="petComment" maxlength="160" placeholder="Allergiák, különlegességek, stb." v-model.trim="pet.comment" rows="4" cols="40"
                        autoResize></Textarea>
                    <button type="submit" @keydown.enter="handleSubmit()" class="btnStyle" @click="handleSubmit()">Létrehozás</button>
                </TabPanel>
            </TabView>

        </div>
    </div>
</template>

<script setup>
import { ref } from 'vue';
import { useUserStore } from '@/store/userstore';
import { storeToRefs } from 'pinia';
import { useDateFormat } from "@vueuse/core";
import { useToast } from 'vue-toastification';
import petservice from '../../services/petservice.js'
import InputMask from 'primevue/inputmask';
import TabView from 'primevue/tabview';
import TabPanel from 'primevue/tabpanel';
import InputText from 'primevue/inputtext';
import Dropdown from 'primevue/dropdown';
import InputNumber from 'primevue/inputnumber';
import Calendar from 'primevue/calendar';
import Textarea from 'primevue/textarea';

const active = ref(0);

const { user } = storeToRefs(useUserStore());
const toast = useToast();
const props = defineProps(['showCreator', 'submitPet']);

const species = ['kutya', 'macska', 'hörcsög', 'nyúl', 'papagáj', 'ló', 'malac'];
const genders = ['hím', 'nőstény']
const genderForReset = ref();

const isFilled = ref(false);

const pet = ref({
    name: "",
    chip_number: 0,
    pedigree_number: 0,
    species: "",
    gender: -1,
    weight: 0,
    born_date: useDateFormat(Date(), "YYYY.MM.DD").value,
    comment: ""
})

function petGenderFormat(petsGender) {
    if (petsGender == 'nőstény') return 0;
    else return 1;
}

function handleSubmit() {
    if (pet.value.name == "" || parseInt(pet.value.chip_number) == 0 || parseInt(pet.value.pedigree_number) == 0 || pet.value.species == "" || pet.value.gender == -1 || pet.value.weight == 0 || pet.value.born_date == "") isFilled.value = false;
    else isFilled.value = true;
    genderForReset.value = pet.value.gender;

    if (!isFilled.value) toast.error("Kérem töltsön ki minden mezőt!", { position: 'top-center' });
    else {
        pet.value.born_date = useDateFormat(pet.value.born_date, "YYYY.MM.DD");
        pet.value.gender = petGenderFormat(pet.value.gender);
        petservice.postNewPet(pet.value, user.value.token)
            .then((resp) => {
                props.submitPet();
            })
            .catch((err) => {
                toast.error('Kérem töltsön ki minden mezőt helyesen!', { position: "top-center" });
                pet.value.gender = genderForReset.value;
            });
    }
}
</script>

<style scoped>
.petCreatingForm {
    background-color: white;
    border-radius: 7px;
    padding: 40px 30px 30px;
    display: flex;
    align-items: center;
    flex-direction: column;
    position: relative;
}

.petComment {
    max-height: 150px;
}

.p-dropdown,
.p-inputtext,
.p-inputnumber,
.bornDate {
    width: 300px;
}

.mandatory {
    font-size: 0.8rem;
    margin: 0 0 12px;
}

.pages {
    display: flex;
    justify-content: center;
    align-items: center;
}

.page {
    display: flex;
    justify-content: center;
    align-items: center;
    border-radius: 100px;
    width: 38px;
    height: 38px;
    padding: 7px;
    margin: 12px;
    background-color: #50B692;
    color: white;
    cursor: pointer;
    border: none;
}



.activePage {
    background-color: #368267;
}

button {
    width: 300px;
    margin-top: 20px;
    background-color: #50B692;
    padding: 6px 10px;
    box-shadow: 0 4px 8px 0 rgba(0, 0, 0, 0.2);
}

label {
    margin: 12px 0 2px;
}

h4 {
    font-size: 1.2rem;
    margin: 12px 0 4px;
}

.close {
    position: absolute;
    top: 20px;
    left: 20px;
    cursor: pointer;
}

.close:hover {
    transform: scale(1.1);
    transition: 200ms;
}

@media (max-width: 514px) {
    h4 {
        font-size: 1.1rem;
        margin: 12px 0 0;
    }

    .page {
        font-size: 0.8rem;
        width: 80px;
        height: 20px;
        margin: 12px 12px 0;
    }

    .petCreatingForm {
        width: 350px;
        padding: 30px;
    }

    .p-dropdown,
    .p-inputtext,
    .p-inputnumber,
    .bornDate,
    button {
        width: 260px;
    }
}
</style>