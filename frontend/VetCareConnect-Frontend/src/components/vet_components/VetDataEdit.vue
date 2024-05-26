<template>
    <SureInEdit v-if="!store.showSure" @cancel="cancelEditing" @editDatas="editDatas"></SureInEdit>
    <div class="main animation-scale">
        <div class="myDatas">
            <div class="dataHeader">
                <img src="../../assets/icons/profile-line.svg">
                <h1>Adataim</h1>
            </div>
            <div class="dataSheet">
                <label>Név:</label>
                <InputText v-model="editedVetData.name" />

                <label>Orvosi azonosító:</label>
                <InputMask mask="9999" placeholder="0000" v-model="editedVetData.stamp_number" />

                <label>Telefon szám:</label>
                <InputMask mask="99/999-9999" placeholder="00/000-0000" v-model="editedVetData.phone" />

                <label>Irányítószám:</label>
                <InputText placeholder="9022" v-model="editedVetData.postal_code" />
                
                <label>Lakcím:</label>
                <InputText placeholder="Győr, Arany János u. 52." v-model="editedVetData.address" />

                <button type="submit" @keydown.enter="saveChanges()" class="btnStyle" @click="saveChanges()">Változások mentése</button>
                <div class="profileDelete">
                    <p class="showConfirmation">Kijelentkezés és profil törlése</p>
                </div>
            </div>
        </div>

    </div>
</template>

<script setup>
import { ref } from 'vue';
import SureInEdit from '../SureInEdit.vue';
import InputText from 'primevue/inputtext';
import InputMask from 'primevue/inputmask';
import { useToast } from 'vue-toastification';
import userservice from '@/services/userservice';
import { useUserStore } from '@/store/userstore';
import { storeToRefs } from 'pinia';
import { useRegexStore } from "@/store/regexstore";

const regStore = useRegexStore();
const store = useUserStore();
const { user } = storeToRefs(useUserStore());
const toast = useToast();

const editedVetData = ref({
    name: "",
    phone: "",
    stamp_number: 0,
    address: "",
    postal_code: 0,
})

const VetData = ref({
    name: "",
    phone: "",
    stamp_number: 0,
    address: "",
    postal_code: 0,
});

function cancelEditing() {
    editedVetData.value.name = VetData.value.name;
    editedVetData.value.phone = VetData.value.phone;
    editedVetData.value.stamp_number = VetData.value.stamp_number;
    editedVetData.value.address = VetData.value.address;
    editedVetData.value.postal_code = VetData.value.postal_code;
    store.showSureInEdit(true);
    toast.warning('Módosítások elvetve!', { position: "top-center" });
}

function editDatas() {
    store.showSureInEdit(true);
    toast.success('Sikeres módosítás!', { position: "top-center" });
    userservice.modifyUserData(editedVetData.value, user.value.token)
        .then((resp) => {
            user.value.name = editedVetData.value.name;
            localStorage.setItem('user', JSON.stringify(user.value))
            VetData.value.name = editedVetData.value.name;
            VetData.value.phone = editedVetData.value.phone;
            VetData.value.address = editedVetData.value.address;
            VetData.value.stamp_number = editedVetData.value.stamp_number;
            VetData.value.postal_code = editedVetData.value.postal_code;
        });

}


store.showSureInEdit(true);
function sureInEdit() {
    store.showSureInEdit(false);
}

function getUsersData() {
    userservice.getUserData(user.value.token)
        .then((resp) => {
            editedVetData.value = resp.data.data;
            VetData.value.name = resp.data.data.name;
            VetData.value.phone = resp.data.data.phone;
            VetData.value.address = resp.data.data.address;
            VetData.value.stamp_number = resp.data.data.stamp_number;
            VetData.value.postal_code = resp.data.data.postal_code;
        });
}
getUsersData();

function saveChanges() {
    if (editedVetData.value.name === VetData.value.name &&
        editedVetData.value.phone.replace(/[/-]/g, '') === VetData.value.phone.replace(/[/-]/g, '') &&
        editedVetData.value.address === VetData.value.address &&
        editedVetData.value.stamp_number == VetData.value.stamp_number &&
        editedVetData.value.postal_code == VetData.value.postal_code) {
        toast.error('Nem történt változás!', { position: "top-center" });
    } else if (!editedVetData.value.name.match(regStore.charactersPattern)) toast.error('Nem megfelelő név formátum!', { position: "top-center" });
    else sureInEdit();
}

</script>

<style scoped>
.main {
    display: flex;
    justify-content: center;
    align-items: center;
    height: 80vh;
}

label {
    font-weight: 600;
    color: #246951;
}

input {
    margin-bottom: 28px;
    width: 70%;
}

button {
    margin: 36px 0 12px;
    background: #246951;
    width: 70%;
}

button:hover {
    background-color: #368267;
    transition: 200ms;
}
</style>