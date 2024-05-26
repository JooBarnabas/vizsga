<template>
    <div class="backToHome">
        <img @click="back()" src="../../assets/icons/arrow_back.svg">
    </div>
    <div class="signInBackground">
        <div class="passwordBack">
            <form @submit.prevent="">

                <h3>Elfelejtette a jelszavát?</h3>
                <p>Kérjük írja be a regisztrációnál használt e-mail címét. Kapni fog egy levelet, amelyben tájékoztatjuk
                    hogyan tudja helyreállítani a jelszavát.</p>

                <label>E-mail cím:</label>

                <InputText placeholder="bodri@gmail.com" v-model="loginData.email"></InputText>

                <div class="rememberPassword">
                    Eszébe jutott? <router-link to="/bejelentkezes">Jelentkezzen be!</router-link>
                </div>

                <div class="relative">
                            <img src="../../assets/icons/loading.svg" v-if="isButtonDisabled" class="loadingSvg">
                            <Button type="submit" @keydown.enter="handleSubmit()" @click="handleSubmit()" class="btnStyle" label="Email küldése"
                                :disabled="isButtonDisabled" />
                        </div>
            </form>
        </div>
    </div>
</template>
<script setup>
import { ref } from 'vue';
import router from '@/router';
import { useToast } from 'vue-toastification'
import InputText from 'primevue/inputtext';
import Button from 'primevue/button';
import userservice from '@/services/userservice';
import { useUserStore } from "@/store/userstore";
import { useRegexStore } from "@/store/regexstore";

const regStore = useRegexStore();
const store = useUserStore();
const toast = useToast();

const loginData = ref({
    email: ""
});

const isFilled = ref(false);
const isEmailFaliled = ref(true);
const isButtonDisabled = ref(false);

function back() {
    router.go(-1)
}

function handleSubmit() {
    if (loginData.value.email == "") isFilled.value = false;
    else isFilled.value = true;

    if (!isFilled.value) toast.error("Kérem töltsön ki minden mezőt!", { position: 'top-center' });
    else if (!loginData.value.email.match(regStore.emailPattern)) {
        toast.error("Nem megfelelő email formátum!", { position: 'top-center' });
        isEmailFaliled.value = true;
    } else isEmailFaliled.value = false;

    if (!isEmailFaliled.value) {
        isButtonDisabled.value = true;

        userservice.sendPasswordResetEmail(loginData.value)
            .then(resp => {
                isButtonDisabled.value = false;
                toast.success('E-mail küldve!', { position: "top-center" });
                // router.push('/uj-jelszo')
            })
            .catch(err => {
                isButtonDisabled.value = false;
                toast.error('Hiba történt az email küldésekor!', { position: 'top-center' })
            })
    }
}

</script>


<style scoped>
.passwordBack {
    background-color: white;
    border-radius: 10px;
    height: 360px;
    width: 400px;
    padding: 45px;
    box-shadow: 0 4px 8px 0 rgba(0, 0, 0, 0.2), 0 6px 20px 0 rgba(0, 0, 0, 0.19);
    text-align: left;
    color: #246951;
    display: flex;
    justify-content: center;
}

h3 {
    margin: 0 0 10px;
}

p {
    font-size: 0.8rem;
    margin-bottom: 30px;
}

.passwordBack label {
    text-align: left;
    font-weight: bold;
}

.btnStyle {
    background: #246951;
    width: 100%;
    padding: 7px;
    margin: 40px 0;
}

.rememberPassword {
    font-size: 0.9rem;
    text-align: right;
    margin-top: 3px;
    margin-bottom: 20px;
    cursor: pointer;
}

.rememberPassword a {
    color: #246951;
    text-decoration: none;
    font-size: 0.8rem;
}

.rememberPassword a:hover {
    text-decoration: underline;
}
</style>