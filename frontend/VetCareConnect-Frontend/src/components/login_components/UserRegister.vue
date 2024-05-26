<template>
    <div class="backToHome">
        <img @click="back()" src="../../assets/icons/arrow_back.svg">
    </div>

    <div class="signInBackground">

        <div v-if="!storeUser.showEmailVerification">
            <div class="main animation-scale">
                <TermsOfUse v-if="buttonTrigger" :TogglePopup="() => TogglePopup()" />
                <!-- Bal oldal -->
                <div class="formCardLeft">
                    <form @submit.prevent="">
                        <h3>Regisztrálás gazdaként</h3>
    
                        <div class="noAccount">
                            <span>Már van fiókja?</span>
                            <router-link to="/bejelentkezes">Bejelentkezés</router-link>
                        </div>
    
                        <div class="nameLabel">
                            <label>Vezetéknév:</label>
                            <label>Keresztnév:</label>
                        </div>
    
                        <div class="nameInput">
                            <InputText v-model="userData.firstName" placeholder="Kiss" />
                            <InputText v-model="userData.lastName" placeholder="János" />
                        </div>
    
                        <label>Tel. szám:</label>
                        <InputMask mask="+36999999999" placeholder="+36201234567" prefix="+36" v-model="userData.phone" />
    
                        <label>Irányítószám:</label>
                        <InputMask mask="9999" placeholder="1234" v-model="userData.postal_code" />
    
                        <label>E-mail cím:</label>
                        <InputText v-model="userData.email" placeholder="bodri@gmail.com" />
    
                        <label>Jelszó:</label>
                        <div class="passInfo">
                            <img src="../../assets/icons/help.svg" @mouseenter="passwordInfoToggle()"
                                @mouseleave="passwordInfoToggle()" class="passwordInfo">
                            <InputText v-model="userData.password" type="password" placeholder="Bodri123" />
                        </div>
    
                        <PasswordRequirements v-if="passwordInfo"></PasswordRequirements>
                        <label>Jelszó újra:</label>
                        <InputText v-model="userData.confirm_password" type="password" placeholder="Bodri123" />
                        <div class="terms">
                            <input type="checkbox" v-model="userData.terms" />
                            <label id="terms" @click="TogglePopup()">Elolvastam az adatvédelmi tájékotatót!</label>
                        </div>
                        <div class="relative">
                            <img src="../../assets/icons/loading.svg" v-if="isButtonDisabled" class="loadingSvg">
                            <Button type="submit" @keydown.enter="handleSubmit()" @click="handleSubmit()" class="btnStyle" label="Regisztráció"
                                :disabled="isButtonDisabled"></Button>
                        </div>
                    </form>
                </div>
    
                <!-- Jobb oldal -->
                <div class="formCardRight">
                    <ul>
                        <li>
                            <img id="logo" src="../../assets/images/logo.png" />
                        </li>
                        <li>
                            <img id="singInDog" src="../../assets/images/sign_in.png" />
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
        <div v-else>
            <ResendEmailVerification :loginData="userData.email"></ResendEmailVerification>
        </div>
    
    </div>
</template>
<script setup>
import { ref } from "vue";
import { useToast } from 'vue-toastification'
import TermsOfUse from "./TermsOfUse.vue";
import PasswordRequirements from "./PasswordRequirements.vue";
import InputMask from 'primevue/inputmask';
import InputText from "primevue/inputtext";
import Button from "primevue/button";
import router from '@/router';
import userservice from "@/services/userservice";
import { useRegexStore } from "@/store/regexstore";
import { useUserStore } from "@/store/userstore";
import ResendEmailVerification from "./ResendEmailVerification.vue";

const store = useRegexStore();
const storeUser = useUserStore();
const toast = useToast();

const isButtonDisabled = ref(false);
const buttonTrigger = ref(false);
const isRegistrationFailed = ref(true);
const isFilled = ref();

const userData = ref({
    firstName: "",
    lastName: "",
    phone: "",
    postal_code: 0,
    email: "",
    password: "",
    confirm_password: "",
    terms: null
})

const registerData = ref()

function back() {
    router.go(-1)
}

function TogglePopup() {
    buttonTrigger.value = !buttonTrigger.value;
};

const passwordInfo = ref(false);
function passwordInfoToggle() {
    passwordInfo.value = !passwordInfo.value;
}

function handleSubmit() {
    userData.value.stamp = parseInt(userData.value.stamp);
    userData.value.postal_code = parseInt(userData.value.postal_code);
    console.log(userData.value);
    if (userData.value.firstName == "" || userData.value.lastName == "" || userData.value.phone == "" || userData.value.postal_code == 0 || userData.value.email == "" || userData.value.password == "" || userData.value.confirm_password == "" || userData.value.terms == 0 || userData.value.terms == null) isFilled.value = false;
    else isFilled.value = true;

    if (!isFilled.value) { toast.error("Kérem töltsön ki minden mezőt!", { position: 'top-center' }); }
    else if (!userData.value.firstName.match(store.charactersPattern) || !userData.value.lastName.match(store.charactersPattern)) { toast.error("A név mezők csak betűket tartalmazhatnak!", { position: 'top-center' }); isRegistrationFailed.value = true; }
    else if (!userData.value.email.match(store.emailPattern)) { toast.error("Nem megfelelő email formátum!", { position: 'top-center' }); isRegistrationFailed.value = true; }
    else if (userData.value.password.length < 8) toast.error("A jelszónak minimum 8 karakter hosszúnak kell lenni!", { position: 'top-center' });
    else if (!userData.value.password.match(store.lowerCaseLetters)) toast.error("A jelszó nem tartalmaz kisbetűs karaktert!", { position: 'top-center' });
    else if (!userData.value.password.match(store.upperCaseLetters)) toast.error("A jelszó nem tartalmaz nagybetűs karaktert!", { position: 'top-center' });
    else if (!userData.value.password.match(store.numbers)) toast.error("A jelszó nem tartalmaz számot!", { position: 'top-center' });
    else if (userData.value.password === userData.value.confirm_password) isRegistrationFailed.value = false;
    else {toast.error("Nem egyezik a két jelszó!", { position: 'top-center' }); isRegistrationFailed.value = true; }

    if (!isRegistrationFailed.value) {
        isButtonDisabled.value = true;

        registerData.value = {
            name: userData.value.firstName + " " + userData.value.lastName,
            phone: userData.value.phone.replace(/[/-]/g, ''),
            email: userData.value.email,
            postal_code: userData.value.postal_code,
            password: userData.value.password,
            confirm_password: userData.value.confirm_password,
            role: 0
        }

        userservice.registerUser(registerData.value)
            .then(resp => {
                storeUser.showEmailVerification = true;
                console.log(storeUser.showEmailVerification)
                toast.success('Sikeres regisztráció!', { position: 'top-center' });
                isButtonDisabled.value = false;
            })
            .catch(err => {
                toast.error( err.data.data.email[0] , { position: 'top-center' })
                isButtonDisabled.value = false;
            })

    }



}
</script>
<style scoped>
.main {
    display: flex;
    align-items: center;
    justify-content: center;
    position: relative;
    box-shadow: 0 4px 8px 0 rgba(0, 0, 0, 0.2), 0 6px 20px 0 rgba(0, 0, 0, 0.19);
    border-radius: 7px;
}

.formCardLeft {
    background-color: #fff;
    border-radius: 7px 0 0 7px;
    height: 760px;
    width: 420px;
    padding: 50px;
    display: flex;
    justify-content: center;
}

.loadingSvg {
    left: 80px;
}

.nameLabel {
    display: flex;
    gap: 79px;
}

.nameInput {
    display: flex;
    gap: 10px;
}

.nameInput input {
    width: 160px;
}

.passwordInfo {
    max-width: 20px;
    min-width: 10px;
    z-index: 50;
    cursor: pointer;
    position: absolute;
    right: 15px;
    filter: invert(30%) sepia(12%) saturate(2322%) hue-rotate(108deg) brightness(101%) contrast(80%);
}

#terms {
    cursor: pointer;
}

#terms:hover {
    text-decoration: underline;
}

.passInfo {
    position: relative;
    display: flex;
    justify-content: center;
    align-items: center;
}

#logo {
    width: 220px;
}

.formCardRight {
    height: 760px;
    width: 340px;
    background-color: #246951;
    border-radius: 0 7px 7px 0;
    display: flex;
    padding: 50px 30px 50px 20px;
    align-items: center;
    justify-content: center;
}

.formCardRight ul {
    display: flex;
    flex-direction: column;
    align-items: center;
    padding: 0;
    list-style: none;
}

.formCardRight ul #singInDog {
    transform: scaleX(-1);
    padding-right: 50px;
    width: 280px;
}

.formCardRight ul li {
    margin-top: 60px;
    color: white;
    text-align: center;
    font-size: 1.2rem;
}

.formCardRight ul li span {
    font-weight: bolder;
}

form {
    background-color: white;
    height: 100%;
    text-align: left;
    border-radius: 7px 0 0 7px;
    width: fit-content;
}

h3 {
    color: #246951;
    margin-top: 0;
    margin-bottom: 15px;
    font-size: 1.6rem;
}

label {
    font-size: 0.9rem;
    color: #246951;
    font-weight: bolder;
    letter-spacing: 0;
    display: inline-block;
    margin-top: 25px;
}

input,
.password {
    display: block;
    box-sizing: border-box;
    width: 100%;
    padding: 5px 40px 5px 10px;
    color: #000;
    border-radius: 7px;
    background-color: #ededed;
    border: 1px solid #c5c5c5;
    outline: none;
    max-height: 45px;
}

input[type="checkbox"] {
    display: inline-block;
    width: 16px;
    margin: 0 10px 0 0;
    position: relative;
    top: 2px;
}

input[type="checkbox"]:checked {
    accent-color: #246951;
}

.btnStyle {
    text-align: center;
    margin-top: 30px;
    background: #246951;
    width: 100%;
}

.btnStyle:hover {
    background-color: #368267;
    transition: 200ms;
}

.noAccount {
    text-align: left;
    margin-top: 10px;
    font-size: 0.9rem;
}

.noAccount span {
    font-weight: bold;
    margin-right: 10px;
    color: #246951;
}

.noAccount a {
    text-decoration: none;
    color: #005a70;
}

.noAccount a:hover {
    text-decoration: underline;
}

@media (max-width: 848px) {
    .main {
        flex-direction: column-reverse;
    }

    .formCardLeft {
        width: 400px;
        border-radius: 0 0 7px 7px;
        height: fit-content;
        padding: 36px;
    }

    .formCardRight {
        width: 400px;
        border-radius: 7px 7px 0 0;
        height: 200px;
        padding: 24px 0 0;

    }

    .loadingSvg {
        left: 60px;
    }

    input,
    .passInfo,
    .btnStyle,
    .nameInput {
        width: 300px;
    }

    .nameInput input {
        width: 145px;
    }

    #singInDog {
        display: none;
    }

    .formCardRight ul li,
    p {
        margin: 0;
        font-size: 0.9rem;
    }

    label {
        font-size: 0.8rem;
        margin-top: 16px;
    }

    h3 {
        font-size: 1.3rem;
    }

    .noAccount {
        font-size: 0.8rem;
    }

    #logo {
        width: 200px;
        margin-bottom: 24px;
    }

    #terms {
        font-size: 0.75rem;
    }

}

@media (max-width: 468px) {
    .formCardLeft {
        width: 300px;
        padding: 24px;
        height: 560px;
        height: fit-content;
    }

    .formCardRight {
        height: 20px;
        width: 300px;
    }

    input,
    .passInfo,
    .btnStyle,
    .nameInput {
        width: 252px;
    }

    .loadingSvg {
        left: 45px;
    }

    #logo,
    .formCardRight ul li,
    p {
        display: none;
    }

    h3 {
        font-size: 1.2rem;
        margin-bottom: 12px;
    }

    .noAccount,
    #terms {
        font-size: 0.7rem;
    }

    .nameInput input {
        width: 121px;
        padding: 5px 10px 5px;
    }

    .terms input {
        margin-right: 8px;
    }

    .nameLabel {
        gap: 50px;
    }
    .terms {
    display: flex;
    flex-direction: row;
    justify-content: center;
}
}
</style>