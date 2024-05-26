<template>
    <div class="listbox" @mouseleave="userMenuToggle()">
        <div class="list" v-for="menu in MenuItems">
            <routerLink class="menuImg" :to="menu.route"><img :src="getImageUrl(menu.img)">{{ menu.name }}</routerLink>
        </div>
        <div v-if="status.loggedIn">
            <hr>
            <div class="list" @click="onLogout()">
                <li class="logOut"><img src="../../assets/icons/logout.svg">
                    <p>Kijelentkezés</p>
                </li>
            </div>
            <div class="logOutAllDevice" @click="onlogOutAllDevice()">
                <p>Kijelentkezés minden eszközről</p>
            </div>
        </div>
    </div>
</template>

<script setup>
import router from '@/router';
import { useUserStore } from '../../store/userstore.js';
import { storeToRefs } from "pinia";
import { useToast } from 'vue-toastification';

const { status } = storeToRefs(useUserStore());
const { logout, logOutAllDevice } = useUserStore();
const props = defineProps(['userMenuToggle', 'isUserMenuOpen'])
const toast = useToast();

const MenuItems = [
    { name: "Adataim", route: "/adataim", img: "profile-line.svg" },
    { name: "GYIK", route: "/gyik", img: "question-mark.svg" }
]

function onlogOutAllDevice() {
    logOutAllDevice().then(() => {
        props.userMenuToggle();
        toast.success('Sikeres kijelentkezés minden eszközről!', { position: "top-center" });
        router.push('/');
    })
}

function onLogout() {
    logout().then(() => {
        props.userMenuToggle();
        toast.success('Sikeres kijelentkezés!', { position: "top-center" });
        router.push('/');
    })
}

function getImageUrl(name) {
  return new URL(`../../assets/icons/${name}`, import.meta.url).href;
}
</script>

<style scoped>
.listbox {
    width: 200px;
    border: 1px solid #368267;
    background-color: #50B692;
    border-radius: 7px;
    padding: 15px 20px 15px;
    position: fixed;
    top: 65px;
    right: 5px;
    z-index: 99;
    box-shadow: 0 4px 8px 0 rgba(0, 0, 0, 0.2);
}

.listbox .list {
    list-style: none;
    margin: 0;
    padding: 0;
}

.listbox .list {
    padding: 5px 6px;
    border-radius: 7px;
    cursor: pointer;
}

.listbox .list a {
    text-decoration: none;
    color: white;
}

.listbox .list:hover {
    background-color: #368267;
}

.logOut {
    color: white;
    display: flex;
    align-items: center;
}

.logOut img {
    width: 20px;
    margin-right: 10px;
}

.logOut p {
    margin: 0;
}

.logOutAllDevice {
    color: #fff;
    font-size: 0.9rem;
    cursor: pointer;
    padding: 5px 6px;
}

.logOutAllDevice p {
    margin: 0;
}

.menuImg {
    display: flex;
    align-items: center;
}

.menuImg img {
    width: 20px;
    margin-right: 10px;
}

hr {
    color: #368267;
    border: #368267 2px solid;
}
</style>