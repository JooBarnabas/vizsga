<template>
    <div class="signInBackground">
        <div class="front">
            <h1>Kérjük ellenőrizze a email fiókját!</h1>
            <h3>Utolsó lépésként kérjük erősítse meg email címét!</h3>
            <p>Amennyiben valamien probléma lépett fel, vagy lejárt a megerősítő link,<br> kérjük kattintson az alábbi
                gombra az email újraküldéséhez! <br>Mindig a legutolsó levelével erősítse meg az email címét!</p>
            <div class="relative">
                <img src="../../assets/icons/loading.svg" v-if="isButtonDisabled" class="loadingSvg">
                <Button type="submit" @click="handleSubmit()" class="btnStyle" label="Email újraküldése"
                    :disabled="isButtonDisabled"></Button>
                <Button type="submit" @click="goToLogin()" class="btnStyle" label="Bejelentkezés"
                    :disabled="isButtonDisabled"></Button>
            </div>
        </div>
    </div>
</template>

<script setup>
import Button from 'primevue/button';
import { ref } from 'vue';
import router from '@/router';
import { useToast } from "vue-toastification";
import userservice from "@/services/userservice";
import { RouterLink } from 'vue-router';
import { useUserStore } from "@/store/userstore";

const storeUser = useUserStore();
const toast = useToast();

const props = defineProps({
    loginData: String
});

const isButtonDisabled = ref(false);

function goToLogin() {
    router.push('/bejelentkezes');
    storeUser.showEmailVerification = false;
}

function handleSubmit() {
    isButtonDisabled.value = true;
    userservice.resendVerificationEmail(props.loginData)
        .then(resp => {
            toast.success('Email sikeresen elküldve!', { position: 'top-center' });
            isButtonDisabled.value = false;
        })
        .catch(error => {
            toast.error('Hiba!', { position: 'top-center' });
            isButtonDisabled.value = false;
        })
}
</script>

<style scoped>
.front {
    background-color: white;
    border-radius: 7px;
    padding: 20px 40px;
    display: flex;
    flex-direction: column;
    justify-content: center;
    align-items: center;
    width: fit-content;
    height: fit-content;
    box-shadow: 0 4px 8px 0 rgba(0, 0, 0, 0.2);
    margin: 40px;
}

h1,
h3 {
    margin: 5px;
}

h3 {
    color: #368267;
}

.loadingSvg {
    left: 195px;
}

.relative {
    width: 100%;
    display: flex;
    justify-content: center;
    gap: 30px;
}

.btnStyle {
    background-color: #368267;
    padding: 7px 0;
    width: 100%;
    max-width: 200px;

}

@media (max-width: 657px) {
    h1 {
        font-size: 1.4rem;
    }

    h3 {
        font-size: 1rem;
    }

    p {
        font-size: 0.8rem;
    }
}
</style>