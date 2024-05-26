<template>
    <div class="backToHome">
        <img @click="back()" src="../../assets/icons/arrow_back.svg">
    </div>

    <div class="signInBackground">
        <div class="main animation-scale">
            <div class="formLeft">
                <form @submit.prevent="">
                    <h3>Admin bejelentkezés</h3>
                    <div class="middle">
                        <label>Felhasználónév:</label>
                        <InputText v-model="loginData.username" placeholder="kissjancsi" />

                        <label>Jelszó:</label>
                        <div class="passwordAndEyeIcon">
                            <img @click="passwordToggle" class="eyeIcon" draggable="false"
                                :src="isVisibilityOn ? getImageUrl('visibility_off.svg') : getImageUrl('visibility_on.svg')" />
                            <InputText :type="typeOfInput" v-model="loginData.password" placeholder="Bodri123" />
                        </div>

                        <div class="relative">
                            <img src="../../assets/icons/loading.svg" v-if="isButtonDisabled" class="loadingSvg">
                            <Button @click="handleSubmit()" class="btnStyle" label="Bejelentkezés"
                                :disabled="isButtonDisabled"></Button>
                        </div>
                    </div>

                </form>
            </div>
            <!-- Jobb oldal -->
            <div class="formRight">
                <ul>
                    <li>
                        <img id="logo" src="../../assets/images/logo.png" draggable="false" />
                    </li>
                    <li>
                        <img id="singinImage" src="../../assets/images/sign_in.png" draggable="false" />
                    </li>
                    <li>
                        <p>
                            <span>Minden</span> állat <br />
                            megérdemli a <span>legjobbat!</span>
                        </p>
                    </li>
                </ul>
            </div>
        </div>

    </div>
</template>

<script setup>
import InputText from 'primevue/inputtext';
import Button from 'primevue/button';
import { ref } from 'vue';
import router from '@/router';
import { useUserStore } from '@/store/userstore';
import { useToast } from 'vue-toastification'

const store = useUserStore();
const { adminLogin } = useUserStore();
const toast = useToast();

const isButtonDisabled = ref(false);
const isVisibilityOn = ref(true);
const typeOfInput = ref("password")

const isFilled = ref(false);
const isLoginFailed = ref(true);

const loginData = ref({
    username: "",
    password: ""
})

function handleSubmit() {
    if (loginData.value.username == "" || loginData.value.password == "") isFilled.value = false;
    else isFilled.value = true;

    if (!isFilled.value) toast.error("Kérem töltsön ki minden mezőt!", { position: 'top-center' });
    else isLoginFailed.value = false;

    if (!isLoginFailed.value) {
        isButtonDisabled.value = true;
        adminLogin(loginData.value)
            .then(resp => {
                router.push('/admin');
                toast.success('Sikeres bejelentkezés!', { position: "top-center" });
                isButtonDisabled.value = false;
            })
            .catch(err => {
                toast.error('Rossz email cím vagy jelszó!', { position: "top-center" });
                isButtonDisabled.value = false;
            })
    }
}

function back() {
    router.go(-1)
}

function passwordToggle() {
    isVisibilityOn.value = !isVisibilityOn.value;

    if (isVisibilityOn.value) typeOfInput.value = "password";
    else typeOfInput.value = "text";
}

function getImageUrl(name) {
  return new URL(`../../assets/icons/${name}`, import.meta.url).href;
}
</script>

<style scoped>
.loadingSvg {
    top: 1px;
    left: 50px;
}

.main {
    display: flex;
}

.formLeft {
    background-color: #fff;
    border-radius: 7px 0 0 7px;
    height: 450px;
    width: 320px;
}

.eyeIcon {
    width: 20px;
    z-index: 50;
    cursor: pointer;
    position: absolute;
    right: 15px;
    filter: invert(33%) sepia(38%) saturate(621%) hue-rotate(108deg) brightness(93%) contrast(92%);
}

.passwordAndEyeIcon {
    position: relative;
    display: flex;
    align-items: center;
}

#logo {
    width: 150px;
}

.formRight {
    height: 450px;
    width: 260px;
    background-color: #246951;
    border-radius: 0 7px 7px 0;
    display: flex;
    padding: 40px 20px;
    align-items: center;
    justify-content: center;
}

.formRight ul {
    display: flex;
    flex-direction: column;
    align-items: center;
    padding: 0;
    list-style: none;
}

.formRight ul #singinImage {
    transform: scaleX(-1);
    padding-right: 40px;
    width: 200px;
}

.formRight ul li {
    margin-top: 44px;
    color: white;
    text-align: center;
    font-size: 1.05rem;
}

.formRight ul li span {
    font-weight: bold;
}

form {
    height: fit-content;
    text-align: left;
    padding: 30px 30px 0 30px;
}

h3 {
    color: #246951;
    margin-top: 0;
    margin-bottom: 15px;
    font-size: 1.6rem;
}

label {
    color: #246951;
    font-weight: bold;
    display: inline-block;
    margin-top: 32px;
}

.btnStyle {
    background: #246951;
    margin-top: 50px;
    width: 100%;
    padding: 7px;
    position: relative;
}

.btnStyle:hover {
    background-color: #368267;
    transition: 200ms;
}

@media (max-width: 768px) {

    label,
    input,
    select,
    p,
    span,
    .btnStyle {
        font-size: 0.8rem;
    }

    .main {
        flex-direction: column-reverse;
    }

    .formRight {
        height: 180px;
        width: 450px;
        padding: 40px 50px;
        border-radius: 10px 10px 0 0;
        flex-direction: column-reverse;
    }

    .formRight ul li,
    .formRight ul li p {
        margin: 0;
    }

    .formLeft {
        border-radius: 0 0 7px 7px;
        height: 360px;
        width: 450px;
        padding: 40px 80px;
    }

    .loadingSvg {
        top: 25px;
        left: 70px;
    }

    form {
        padding: 0;
    }

    label {
        margin: 15px 0 3px;
    }

    h3 {
        margin-bottom: 10px;
    }

    .btnStyle {
        margin-top: 26px;
    }

    .middle {
        display: flex;
        flex-direction: column;
    }

    ul #singinImage {
        display: none;
    }

    #logo {
        width: 160px;
        margin: 30px 0;
    }
}

@media (max-width: 551px) {

    .formRight,
    .formLeft {
        width: 350px;
        padding: 40px;
    }

    .formRight {
        height: 140px;
    }

    #logo {
        width: 140px;
        margin: 20px 0;
    }

    .loadingSvg {
        width: 26px;
        height: 26px;
        top: 28px;
        left: 65px;
    }
}
</style>