<template>
    <div class="cardsBack">
        <img @click="petMenuToggle()" class="dotsMenu" src="../../assets/icons/dots.svg" />
        <div class="menu">
            <PetMenu v-if="isMenuOpen" :petMenuToggle="petMenuToggle" :editpetId="pet.id" :deletePet="deletePet"
                :editPet="editPet"></PetMenu>
        </div>
        <div>
            <img class="profile" :src="getImageUrl(`${pet.species}.png`)" draggable="false" />
        </div>

        <h3>{{ pet.name }}</h3>
        <div>
            <p>{{ pet.species }}</p>
            <p>{{ pet.gender == 0 ? "nőstény" : "hím" }}</p>
            <p>{{ pet.weight }} kg</p>
            <p id="petComment">{{ pet.comment }}</p>
            <strong>{{ pet.name }} most {{ petAge }} {{ elapsedTime }}.</strong>
        </div>
    </div>
</template>
<script setup>
import { ref } from "vue";
import { defineAsyncComponent } from "vue";
import { useUserStore } from '@/store/userstore';

const store = useUserStore();
const PetMenu = defineAsyncComponent(() => import("./PetMenu.vue"));

const props = defineProps(['pet']);
const isMenuOpen = ref(false);
const elapsedTime = ref();
const petAge = ref()

function elapsedTimeCalc() {
    petAge.value = Math.floor((Date.parse(Date()) - Date.parse(props.pet.born_date)) / (3600000 * 24));
    if (petAge.value <= 30) elapsedTime.value = "napos";
    else if (petAge.value > 30 && petAge.value <= 365) { elapsedTime.value = "hónapos"; petAge.value = Math.floor(petAge.value / 30); }
    else if (petAge.value > 365) { elapsedTime.value = "éves"; petAge.value = Math.floor(petAge.value / 30 / 12); }
}


elapsedTimeCalc();

function petMenuToggle() {
    isMenuOpen.value = !isMenuOpen.value;
}

function deletePet() {
    store.showPetDelete(true);
    store.deletePetId = props.pet.id;
}

function editPet() {
    store.showPetEdit(true);
    store.editPet = props.pet;
}

function getImageUrl(name) {
  return new URL(`../../assets/images/${name}`, import.meta.url).href;
}
</script>

<style scoped>
.cardsBack {
    background-color: #50b692;
    border-radius: 7px;
    height: 420px;
    width: 270px;
    padding: 20px 30px;
    box-shadow: 0 4px 8px 0 rgba(0, 0, 0, 0.2), 0 6px 20px 0 rgba(0, 0, 0, 0.19);
    text-align: center;
    color: #fff;
    margin: 0 0 40px 40px;
    display: flex;
    flex-direction: column;
    justify-content: center;
    align-items: center;
    position: relative;
    overflow-x: auto;
}

.cardsBack:hover {
    background-color: #368267;
    transform: scale(1.05);
    transition: 200ms;
}

.menu {
    position: absolute;
    top: 20px;
    right: 35px;
}

.profile {
    width: 80px;
    height: 80px;
    margin-bottom: 20px;
}

.dotsMenu {
    position: absolute;
    top: 16px;
    right: 12px;
    cursor: pointer;
    filter: invert(100%);
}

.dotsMenu:hover {
    transform: scale(1.1);
}

h3 {
    margin: 0 0 10px;
}

#petComment {
    max-width: 200px;
}
</style>
