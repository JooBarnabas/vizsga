<template>
    <Header></Header>
    <div v-if="!store.petDelete && !store.petEdit">
        <PetCreator v-if="isPetCreating" :submit-pet="submitPet" :show-creator="showCreator"></PetCreator>
        <div :class="{'overflowDisable': isPetCreating}">
           
                <h1 class="pageTitle">Kedvenceim</h1>
                <div class="petsCard">

                    <div v-for="pet in store.pets" v-if="store.pets.length > 0">
                        <Pet :pet=pet class="animation-scale"></Pet>
                    </div>

                    <div class="noPetsYet" v-else>
                        <p>Önnek még nincs egy kedvence sem rögzítve... Hozza létre kedvence(i) adatlapját!</p>
                        <img src="../../assets/icons/arrow_forward_ios.svg">
                    </div>

                    <button class="addPet" @click="showCreator">
                        <img class="addPetIcon" src="../../assets/icons/add.svg">
                    </button>

                </div>
                
          
        </div>
    </div>
    <div v-else-if="store.petEdit">
        <PetEdit :modify-pet="modifyPet"></PetEdit>
    </div>
    <div v-else class="petDelete">
        <PetDelete></PetDelete>
    </div>
    <Footer></Footer>
</template>
  
<script setup>
import { ref } from 'vue';
import Header from '@/components/page_controls/Header.vue';
import Footer from '@/components/page_controls/Footer.vue';
import { defineAsyncComponent } from 'vue'
import { useUserStore } from '@/store/userstore';

const store = useUserStore();

const Pet = defineAsyncComponent(() =>
    import('@/components/pet_components/Pet.vue')
)

const PetCreator = defineAsyncComponent(() =>
    import('@/components/pet_components/PetCreator.vue')
)
const PetDelete = defineAsyncComponent(() =>
    import('@/components/pet_components/PetDeleteApprove.vue')
)
const PetEdit = defineAsyncComponent(() =>
    import('@/components/pet_components/PetModify.vue')
)
const isPetCreating = ref(false);

function showCreator() {
    isPetCreating.value = !isPetCreating.value;
}

function submitPet() {
    store.getPets();
    isPetCreating.value = false;
}
function modifyPet(){
    store.getPets();
}
store.getPets();
</script>

<style scoped>
h1 {
    color: #368267;
}

.petsCard {
    display: flex;
    align-items: center;
    flex-wrap: wrap;
}

.addPet {
    background-color: #50B692;
    border-radius: 100%;
    display: flex;
    align-items: center;
    justify-content: center;
    padding: 10px;
    height: max-content;
    width: max-content;
    margin-left: 40px;
    margin-right: 20px;
    cursor: pointer;
    box-shadow: 0 4px 8px 0 rgba(0, 0, 0, 0.2), 0 6px 20px 0 rgba(0, 0, 0, 0.19);
}

button {
    border: 0;
}

.noPetsYet {
    margin: 30px 20px 30px 40px;
    padding: 15px 25px;
    width: 500px;
    background-color: #af3b3b;
    color: white;
    display: flex;
    align-items: center;
    border-radius: 7px;
    box-shadow: 0 4px 8px 0 rgba(0, 0, 0, 0.2), 0 6px 20px 0 rgba(0, 0, 0, 0.19);
}

.noPetsYet img {
    filter: invert(100%);
}

.addPetIcon {
    width: 40px;
    height: 40px;
    filter: invert(100%);
}

.filter {
    display: flex;
    align-items: center;
}

#searchIcon {
    width: 25px;
    right: 4px;
    top: 8px;
    position: absolute;
}

input {
    padding-right: 35px;
    border-radius: 7px;
}

.iconInInput {
    position: relative;
    margin-left: 20px;
    margin-top: 10px;
}
.petDelete{
    display: flex;
    align-items: center;
    justify-content: center;
    height: 80vh;
}


@media (max-width: 552px) {
    .filter {
        flex-direction: column;
        align-items: start;
        margin-bottom: 20px;
    }

    .pageTitle {
        margin-bottom: 10px;
    }

    .iconInInput {
        margin: 0 0 20px 40px;
    }



}
</style>