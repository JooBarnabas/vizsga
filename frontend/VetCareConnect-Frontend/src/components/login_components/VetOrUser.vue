<template>
    <div class="main animation-scale">
        <div class="back">
            <div class="front">
                <h3>Válasszon profil típust!</h3>
                <!-- <p>Ön egy {{ userTypes[activeIdx]?.type }}</p> -->
                <div class="cards">
                    <div v-for="(userType, index) in userTypes">
                        <div @click="isActiveToggle(index)" :class="{ 'selected': activeIdx == index }"
                            class="profileCard">
                            <h4>{{ userType.type }}</h4>
                            <img class="cardImg" :src="getImageUrl(userType.imgSrc)">
                        </div>
                    </div>

                </div>
                <div v-if="activeIdx != -1" class="buttonSection">
                    <button class="btnStyle" @click="sendType">Tovább <img
                            src="../../assets/icons/arrow_back.svg"></button>
                </div>

            </div>

        </div>

    </div>
</template>
<script setup>
import { ref } from "vue";
import { defineEmits } from "vue";
import { useToast } from "vue-toastification";

const toast = useToast();
const emit = defineEmits(['removeVetOrUser'])

const userTypes = [
    { type: "gazda", imgSrc: "pets.svg" },
    { type: "orvos", imgSrc: "stethoscope.svg" }
];

const activeIdx = ref(-1);

function isActiveToggle(index) {
    activeIdx.value = index;
}

function sendType() {
    if (activeIdx.value == -1) {
        toast.warning("Kérem válasszon profil típust!", { position: "top-center" });
    } else {
        emit('removeVetOrUser', activeIdx)
    }
}
function getImageUrl(name) {
  return new URL(`../../assets/icons/${name}`, import.meta.url).href;
}
</script>

<style scoped>
body {
    overflow-y: hidden;
    margin: 0;
}

.main {
    display: flex;
    align-items: center;
    justify-content: center;
    position: relative;

}

.back {
    background-color: #fff;
    border-radius: 7px;
    width: 600px;
    height: 500px;
    display: flex;
    justify-content: center;
    padding-top: 56px;
}

.front {
    display: flex;
    flex-direction: column;
}

.cards {
    display: flex;
    justify-content: center;
    align-items: center;
    gap: 50px;
}


.notSelected {
    background-color: white;
    color: black;
}

.profileCard {
    height: 250px;
    width: 200px;
    border-radius: 7px;
    box-shadow: 0 4px 8px 0 rgba(0, 0, 0, 0.2), 0 6px 20px 0 rgba(0, 0, 0, 0.19);
    display: flex;
    justify-content: start;
    flex-direction: column;
    align-items: center;
    font-size: 1.4rem;
    padding: 20px;
    color: #246951;
    cursor: pointer;
    margin: 20px 0;
}

.profileCard:hover {
    transform: scale(1.05);
    transition: 200ms;
    background-color: #246951;
    color: white;
}

.profileCard:hover .cardImg {
    filter: invert(100%);
}

.cardImg {
    margin-top: 24px;
    filter: invert(30%) sepia(12%) saturate(2322%) hue-rotate(108deg) brightness(101%) contrast(80%);
    width: 60px;
}

h3 {
    color: #246951;
    margin-top: 0;
    margin-bottom: 15px;
    font-size: 1.6rem;
}


.buttonSection {
    display: flex;
    align-items: center;
    justify-content: center;
}

.btnStyle img {
    transform: scaleX(-1);
    filter: invert(100%);
    margin-left: 4px;
    width: 20px;
}

.btnStyle {
    background: #246951;
    width: 50%;
    padding: 7px;
    margin-top: 30px;
}

.btnStyle:hover {
    background-color: #368267;
    transition: 200ms;
}


.submit {
    text-align: center;
    margin-top: 50px;
}

.selected {
    transform: scale(1.1);
    transition: 200ms;
    background-color: #246951;
    color: #fff;
}

.selected .cardImg {
    filter: invert(100%);
}


@media (max-width: 768px) {
    .back {
        width: 400px;
        height: 480px;
    }

    .cards {
        flex-direction: column;
        gap: 24px;
    }

    .profileCard {
        margin: 0;
        height: 100px;
        width: 280px;
        flex-direction: row;
        justify-content: space-between;
    }

    .cardImg {
        margin: 0;
        width: 40px;
    }

    h3 {
        margin-bottom: 32px;
    }

    .btnStyle {
        margin-top: 38px;
    }
}

@media (max-width: 468px) {
    .back {
        width: 300px;
        height: 380px;
    }

    .profileCard {
        height: 60px;
        width: 180px;
    }

    .cardImg {
        width: 32px;
    }

    h3 {
        font-size: 1.4rem;
    }
}
</style>
