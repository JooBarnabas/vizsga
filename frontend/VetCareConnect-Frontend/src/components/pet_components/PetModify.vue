<template>
    <SureInEdit v-if="store.showSure" @cancel="cancelEditing" @editDatas="editDatas" class="animation-scale"></SureInEdit>
    <div class="main">
        <button @click="back()" class="btnStyle btnBack"><img style="filter: invert(100);"
                src="../../assets/icons/arrow_back.svg">Vissza</button>
        <div class="animation-scale">
            <div class="dataHeader">
                <img src="../../assets/icons/profile-line.svg">
                <h1>{{ editedPetData.name }} adatai</h1>
            </div>
            <div class="dataSheet">
                <label>Név:</label>
                <InputText v-model="editedPetData.name"></InputText>

                <label>Chip szám (15 számjegy):</label>
                <InputMask v-model="editedPetData.chip_number" mask="999999999999999" />
                
                <label>Törzskönyv száma (8 számjegy):</label>
                <InputMask v-model="editedPetData.pedigree_number" mask="99999999" />

                <label>Fajtajelleg:</label>
                <Dropdown v-model="editedPetData.species" :options="species" showClear placeholder="Kérem válasszon!" class="petDropdown" />

                <label>Ivar:</label>
                <Dropdown v-model="editedPetData.gender" :options="genders" showClear placeholder="Kérem válasszon!" class="petDropdown" />

                <label>Súlya (kg):</label>
                <InputNumber v-model="editedPetData.weight" placeholder="0" :minFractionDigits="0" :maxFractionDigits="2"
                    :min="0.1" :max="999" suffix=" kg" :useGrouping="false" />

                <label>Születési dátuma:</label>
                <Calendar v-model="editedPetData.born_date" class="bornDate" :max-date="new Date()" dateFormat="yy-mm-dd"
                    placeholder="éééé.hh.nn" />

                <label>Megjegyzés:</label>
                <Textarea v-model="editedPetData.comment" placeholder="Allergiák, különlegességek, stb." rows="4" cols="40"
                    autoResize></Textarea>

                <button type="submit" @keydown.enter="saveChanges()" @click="saveChanges()" class="btnStyle">Változások mentése</button>
            </div>
        </div>
        <div class="placeholder"></div>
    </div>
</template>

<script setup>
import SureInEdit from '../SureInEdit.vue';
import InputText from 'primevue/inputtext';
import InputNumber from 'primevue/inputnumber';
import InputMask from 'primevue/inputmask';
import Dropdown from 'primevue/dropdown';
import Textarea from 'primevue/textarea';
import Calendar from 'primevue/calendar';
import petservice from '@/services/petservice';

import { useUserStore } from '@/store/userstore';
import { useRegexStore } from "@/store/regexstore";
import { useToast } from 'vue-toastification';
import { storeToRefs } from 'pinia';
import { ref } from 'vue';
import { useDateFormat } from "@vueuse/core";

const store = useUserStore();
const regStore = useRegexStore();
const { user } = storeToRefs(useUserStore());
const toast = useToast();
const props = defineProps(['modifyPet']);

const species = ['kutya', 'macska', 'hörcsög', 'nyúl', 'papagáj', 'ló', 'malac'];
const genders = ['hím', 'nőstény'];


const petGender = store.editPet.gender == 0 ? 'nőstény' : 'hím';

const editedPetData = ref({
    id: store.editPet.id,
    name: store.editPet.name,
    species: store.editPet.species,
    gender: petGender,
    weight: store.editPet.weight,
    born_date: store.editPet.born_date,
    comment: store.editPet.comment,
    chip_number: store.editPet.chip_number,
    pedigree_number: store.editPet.pedigree_number
})

let petData = {
    id: store.editPet.id,
    name: store.editPet.name,
    species: store.editPet.species,
    gender: petGender,
    weight: store.editPet.weight,
    born_date: store.editPet.born_date,
    comment: store.editPet.comment,
    chip_number: store.editPet.chip_number,
    pedigree_number: store.editPet.pedigree_number
}

store.showSureInEdit(false);

function back() {
    store.showPetEdit(false);
    toast.warning('Módosítások elvetve!', { position: "top-center" });
}

function cancelEditing() {
    store.showSureInEdit(false);
    store.showPetEdit(false)
    toast.warning('Módosítások elvetve!', { position: "top-center" });
}

function saveChanges() {
    if (editedPetData.value.name == "" ||
    editedPetData.value.chip_number == 0 ||
    editedPetData.value.pedigree_number == 0 ||
    editedPetData.value.species == null ||
    editedPetData.value.gender == null ||
    editedPetData.value.weight == 0 ||
    editedPetData.value.born_date == null) {
        toast.error("Kérem töltsön ki minden mezőt!", { position: 'top-center' });
    } else if (editedPetData.value.name == petData.name &&
    editedPetData.value.species == petData.species &&
    editedPetData.value.gender == petData.gender &&
    editedPetData.value.weight == petData.weight &&
    editedPetData.value.born_date == petData.born_date &&
    editedPetData.value.comment == petData.comment &&
    editedPetData.value.chip_number == petData.chip_number &&
    editedPetData.value.pedigree_number == petData.pedigree_number) {
        toast.error('Nem történt változás!', { position: "top-center" });
    } else if (!regStore.charactersPattern.test(editedPetData.value.name)) toast.error('Nem megfelelő név formátum!', { position: "top-center" });
    else {
        if (editedPetData.value.gender == "hím") editedPetData.value.gender = 1;
        else editedPetData.value.gender = '0';
        store.showSureInEdit(true);
    }
}

function editDatas() {
    const formattedBornDate = useDateFormat(editedPetData.value.born_date, "YYYY-MM-DD");
    editedPetData.value.born_date = formattedBornDate.value;
    petservice.modifyPet(editedPetData.value, user.value.token)
        .then((resp) => {
            store.showSureInEdit(false);
            store.showPetEdit(false);
            props.modifyPet();
            store.getPets();
            toast.success('Sikeres módosítás!', { position: "top-center" });
        });
}
</script>

<style scoped>
.main {
    display: flex;
    justify-content: center;
    align-items: start;
    margin-top: 40px;
}

.dataHeader {
    width: 500px;
}

.dataSheet {
    width: 500px;
    padding: 30px 80px;
}

.placeholder {
    width: 120px;
    margin-left: 30px;
    background-color: white;
}

label {
    font-weight: 500;
    color: #246951;
    margin: 10px 0 2px;
}

.btnStyle {
    margin: 15px 0 12px;
    background: #246951;
    width: 100%;
}

.btnBack {
    background-color: #246951;
    width: 120px;
    margin-right: 30px;
}

input, textarea, .p-dropdown, .p-inputtext, .p-inputnumber, .bornDate, .saveChanges {
    width: 100%;
}

button:hover {
    background-color: #368267;
    transition: 200ms;
}

@media (max-width: 850px){
    .main {
        display: flex;
        flex-direction: column;
        align-items: center;
        margin-top: 40px;
    }
    .btnBack {
        margin-left: -350px;
    }
}
@media (max-width: 550px){

    .btnBack {
        margin-left: -200px;
    }
    .dataSheet, .dataHeader {
        width: 350px;
    }

    .dataSheet {
        padding: 30px;
    }
}
@media (max-width: 450px){

    .btnBack {
        margin-left: -150px;
    }
    .dataSheet, .dataHeader {
        width: 300px;
    }

    .dataSheet {
        padding: 20px;
    }
}
</style>