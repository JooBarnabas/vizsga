<template>
    <div class="btns btnChoose">
        <div class="btns">
            <button class="btnStyle" @click="showVet()">Állatorvosok</button>
            <button class="btnStyle" @click="showOwner()">Gazdák</button>
        </div>
        <div class="title">
            <h1 v-if="isVet">Állatorvosok</h1>
            <h1 v-if="isOwner">Gazdák</h1>
        </div>
        <button class="btnStyle" @click="onLogout()">Kijelentkezés</button>
    </div>

    <div v-if="isVet" class="data">
        <DataTable class="table" v-model:selection="selectedVet" v-model:editingRows="editingRowsVet" :value="vets" editMode="row" dataKey="id"
            @row-edit-save="onRowEditSave" :pt="{
                table: { style: 'min-width: 50rem' },
                column: {
                    bodycell: ({ state }) => ({
                        style: state['d_editing'] && 'padding-top: 0.6rem; padding-bottom: 0.6rem'
                    })
                }
            }">
            <Column selectionMode="multiple" headerStyle="width: 3rem"></Column>
            <Column field="id" header="Azonosító" style="width: 20%"></Column>
            <Column field="name" header="Név" style="width: 20%"></Column>
            <Column field="email" header="Email" style="width: 20%">
                <template #editor="{ data, field }">
                    <InputText v-model="data[field]" />
                </template>
            </Column>
            <Column field="phone" header="Telefonszám" style="width: 20%"></Column>
            <Column :rowEditor="true" style="width: 10%; min-width: 8rem" bodyStyle="text-align:center"></Column>
        </DataTable>
        <div class="btns">
            <button class="btnStyle btnDelete" @click="deleteVet">Törlés</button>
        </div>
    </div>
    <div v-if="isOwner" class="data">
        <DataTable class="table" v-model:selection="selectedOwner" v-model:editingRows="editingRowsOwner" :value="owners" editMode="row" dataKey="id"
            @row-edit-save="onRowEditSave" :pt="{
                table: { style: 'min-width: 50rem' },
                column: {
                    bodycell: ({ state }) => ({
                        style: state['d_editing'] && 'padding-top: 0.6rem; padding-bottom: 0.6rem'
                    })
                }
            }">
            <Column selectionMode="multiple" headerStyle="width: 3rem"></Column>
            <Column field="id" header="Azonosító" style="width: 20%"></Column>
            <Column field="name" header="Név" style="width: 20%"></Column>
            <Column field="email" header="Email" style="width: 20%">
                <template #editor="{ data, field }">
                    <InputText v-model="data[field]" />
                </template>
            </Column>
            <Column :rowEditor="true" style="width: 10%; min-width: 8rem" bodyStyle="text-align:center"></Column>
        </DataTable>
        <div class="btns">
            <button class="btnStyle btnDelete" @click="deleteOwner">Törlés</button>
        </div>
    </div>
</template>

<script setup>
import DataTable from 'primevue/datatable';
import Column from 'primevue/column';
import adminService from '@/services/adminservice';
import InputText from 'primevue/inputtext';

import { ref } from 'vue';
import { storeToRefs } from "pinia";
import { useUserStore } from "@/store/userstore";
import router from '@/router';
import { useToast } from 'vue-toastification';
const toast = useToast();

const { logout } = useUserStore();
const { user } = storeToRefs(useUserStore());

const isVet = ref(false);
const isOwner = ref(false);

const editingRowsVet = ref([]);
const editingRowsOwner = ref([]);

const owners = ref([]);
const vets = ref([]);

const selectedVet = ref();
const selectedOwner = ref();

const emailModify = {
    id: null,
    role: -1,
    email: ""
};

const onRowEditSave = (event) => {
    if (emailModify.role == 0) {
        let { newData, index } = event;
        owners.value[index] = newData;
        emailModify.email = owners.value[index].email;
        emailModify.id = owners.value[index].id;
    } else {
        let { newData, index } = event;
        vets.value[index] = newData;
        emailModify.email = vets.value[index].email;
        emailModify.id = vets.value[index].id;
    }

    adminService.modifyEmail(emailModify, user.value.token).then(resp => {
        toast.success('Sikeres email módosítás!', { position: "top-center" });
    });
};

function showVet(){
    isVet.value = true;
    isOwner.value = false;
    emailModify.role = 1;
}

function showOwner(){
    isVet.value = false;
    isOwner.value = true;
    emailModify.role = 0;
}
function onLogout() {
    logout().then(() => {
        router.push('/');
        toast.success('Sikeres kijelentkezés!', { position: "top-center" });
    })
}

function deleteVet(){
    (selectedVet.value).forEach(vet => {
        adminService.deleteVet(vet.id, user.value.token).then(resp => {
            toast.success('Sikeres törlés!', { position: "top-center" });
            getPeople();
        });
    });
    selectedVet.value = [];
}

function deleteOwner(){
    (selectedOwner.value).forEach(owner => {
        adminService.deleteOwner(owner.id, user.value.token).then(resp => {
            toast.success('Sikeres törlés!', { position: "top-center" });
            getPeople();
        });
    });
    selectedOwner.value = [];
}

function getPeople(){
    adminService.getAllOwner(user.value.token).then(resp =>{
        owners.value = resp.data;
    });
    adminService.getAllVet(user.value.token).then(resp =>{
        vets.value = resp.data;
    });
}
getPeople();
</script>

<style lang="css" scoped>
body {
    padding: 0 !important;
}

.btns {
    display: flex;
    flex-direction: row;
    align-items: center;
    justify-content: space-between;
}
.btnChoose {
    width: 100%;
    background-color: #e9ecef;
    position: fixed;
    z-index: 100;
    margin-top: -60px;
    box-shadow: 0 4px 8px 0 rgba(0, 0, 0, 0.2);
}
.title {
    position: absolute;
    width: 100%;
    text-align: center;
    z-index: -1;
}
.btnStyle {
    padding: 10px 20px;
    margin: 20px 10px;
    background-color: #555;
}
.btnDelete {
    background-color: red;
}
.btnSave {
    background-color: green;
}
h1 {
    color: #555;
}
.table {
    max-width: 1000px;
    margin: 100px 40px 40px 40px;
}
.data {
    display: flex;
    flex-direction: column;
    align-items: center;
}

@media (max-width: 1100px) {
    .table {
        width: 850px;
    }
}
@media (max-width: 900px) {
    .table {
        width: 650px;
        max-height: 500px;
        overflow: scroll;
    }

}
</style>