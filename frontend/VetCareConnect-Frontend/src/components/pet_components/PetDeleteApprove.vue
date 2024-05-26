<template>
    <div class="petDeleteComponent animation-scale">
        <h3>Biztosan kitörli a kisállatát?</h3>
        <div class="middle">
            <button class="btnStyle btnYes" @click="ClickYes()">Igen</button>
            <button type="submit" @keydown.esc="ClickNo()" class="btnStyle btnNo" @click="ClickNo()">Mégse</button>
        </div>
    </div>
</template>

<script setup>
import router from '@/router';
import { useUserStore } from "../../store/userstore";
import petservice from '../../services/petservice.js'
import { storeToRefs } from 'pinia';

const store = useUserStore();
const { user } = storeToRefs(useUserStore());

function ClickNo() {
    store.petDelete = false;
    router.push('/kedvenceim');
}

function ClickYes() {
    store.petDelete = false;
    petservice.deletePet(store.deletePetId, user.value.token)
    .then((resp) => {
        store.getPets();
        router.push('/kedvenceim');
    });
}

</script>

<style lang="css" scoped>
.petDeleteComponent {
    background-color: #50B692;
    width: 400px;
    height: 200px;
    box-shadow: 0 4px 8px 0 rgba(0, 0, 0, 0.3);
    border-radius: 7px;
    color: white;
    display: flex;
    flex-direction: column;
    align-items: center;
    justify-content: center;
    padding: 40px;
    text-align: center;
}

.middle {
    display: flex;
    gap: 16px;
}

.btnStyle {
    padding: 8px 16px;
    border-radius: 7px;
    margin-top: 12px;
}

.btnYes {
    background-color: #368267;
    border: none;
}

.btnNo {
    border: none;
    background-color: #50B692;
    padding: 0;
    box-shadow: none;
}

@media (max-width: 500px) {
    .petDeleteComponent {
        width: 300px;
    }
}
</style>