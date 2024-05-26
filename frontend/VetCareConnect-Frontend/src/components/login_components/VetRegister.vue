<template>
    <div class="backToHome">
        <img @click="back()" src="../../assets/icons/arrow_back.svg">
    </div>
    {{ store.showEmailVerification }}
    <div class="signInBackground">
        <div v-if="!storeUser.showEmailVerification">
            <div class="main animation-scale">
                <TermsOfUse v-if="buttonTrigger" :TogglePopup="() => TogglePopup()" />
                <!-- Bal oldal -->
                <div class="formCardLeft">
                    <form @submit.prevent="">
                        <h3>Regisztrálás orvosként</h3>
                        <div class="noAccount">
                            <span>Már van fiókja?</span>
                            <router-link to="/bejelentkezes">Bejelentkezés</router-link>
                        </div>
    
                        <div class="pages">
                            <button type="button" class="page btnStyle" @click="active = 0"
                                :class="{ 'activePage': active == 0 }">1</button>
                            <button type="button" class="page btnStyle" @click="active = 1"
                                :class="{ 'activePage': active == 1 }">2</button>
                        </div>
    
                        <TabView v-model:activeIndex="active">
                            <TabPanel>
                                <div class="nameLabel">
                                    <label>Vezetéknév:</label>
                                    <label>Keresztnév:</label>
                                </div>
    
                                <div class="nameInput">
                                    <InputText v-model="vetData.firstName"  placeholder="Dr. Nagy" />
                                    <InputText v-model="vetData.lastName"  placeholder="István"/>
                                </div>
    
                                <label>E-mail cím:</label>
                                <InputText type="email" v-model="vetData.email" placeholder="bodri@gmail.com" />
    
                                <label>Jelszó:</label>
                                <div class="passInfo">
                                    <img src="../../assets/icons/help.svg" @mouseenter="passwordInfoToggle()"
                                        @mouseleave="passwordInfoToggle()" class="passwordInfo">
                                    <InputText v-model="vetData.password" type="password" placeholder="Bodri123" />
                                </div>
    
                                <PasswordRequirements v-if="passwordInfo"></PasswordRequirements>
    
                                <label>Jelszó újra:</label>
                                <InputText v-model="vetData.confirm_password" type="password" placeholder="Bodri123" />
    
                                <button type="button" class="btnStyle" @click="active = 1">Tovább</button>
                            </TabPanel>
    
                            <TabPanel>
                                <label>Telefon szám:</label>
                                <InputMask mask="+36999999999" placeholder="+36201234567" prefix="+36" v-model="vetData.phone" />
    
                                <label>Település, utca, házszám:</label>
                                <InputText v-model="vetData.address" placeholder="Győr, Kossuth Lajos u. 1-3" />
    
                                <div class="addressLabel">
                                    <label>Irányítószám:</label>
                                    <label>Kamarai szám:</label>
                                </div>
    
                                <div class="nameInput">
                                    <InputMask mask="9999" placeholder="1234" v-model="vetData.postal_code" />
                                    <InputMask mask="9999" placeholder="4321" v-model="vetData.stamp_number" />
                                </div>
    
                                <div class="terms">
                                    <input type="checkbox" v-model="vetData.terms" />
                                    <label id="terms" @click="TogglePopup()">Elolvastam az adatvédelmi tájékotatót!</label>
                                </div>
    
                                <div class="relative">
                                    <img src="../../assets/icons/loading.svg" v-if="isButtonDisabled" class="loadingSvg">
                                    <Button type="submit" @key.enter="handleSubmit()" @click="handleSubmit()" class="btnStyle" label="Regisztráció"
                                        :disabled="isButtonDisabled"></Button>
                                </div>
                            </TabPanel>
                        </TabView>
    
    
    
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
            <ResendEmailVerification :loginData="vetData.email"></ResendEmailVerification>
        </div>
    </div>
</template>
<script setup>
import { ref } from "vue";
import TermsOfUse from "./TermsOfUse.vue";
import PasswordRequirements from "./PasswordRequirements.vue";
import TabView from "primevue/tabview";
import TabPanel from "primevue/tabpanel";
import InputMask from 'primevue/inputmask';
import InputText from "primevue/inputtext";
import Button from "primevue/button";
import router from '@/router';
import { useToast } from "vue-toastification";
import userservice from "@/services/userservice";
import { useRegexStore } from "@/store/regexstore";
import { useUserStore } from "@/store/userstore";
import ResendEmailVerification from "./ResendEmailVerification.vue";

const store = useRegexStore();
const storeUser = useUserStore();

const isButtonDisabled = ref(false);
const toast = useToast();
const active = ref(0);
const buttonTrigger = ref(false);

const isFilled = ref(false);
const registerData = ref()
const isRegistrationFailed = ref(true);

const vetData = ref({
    firstName: "",
    lastName: "",
    phone: "",
    stamp_number: 0,
    postal_code: 0,
    address: "",
    email: "",
    password: "",
    confirm_password: "",
    terms: null
});

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

    vetData.value.stamp_number = parseInt(vetData.value.stamp_number);
    vetData.value.postal_code = parseInt(vetData.value.postal_code);
    
    if (vetData.value.firstName == "" || vetData.value.lastName == "" || vetData.value.phone == "" || vetData.value.stamp_number == 0 || vetData.value.postal_code == 0 || vetData.value.address == "" || vetData.value.email == "" || vetData.value.password == "" || vetData.value.confirm_password == "" || vetData.value.terms == 0 || vetData.value.terms == null) isFilled.value = false;
    else isFilled.value = true;
    
    if (!isFilled.value) { toast.error("Kérem töltsön ki minden mezőt!", { position: 'top-center' }); }
    else if (!vetData.value.firstName.match(store.charactersPattern) || !vetData.value.lastName.match(store.charactersPattern)) { toast.error("A név mezők csak betűket tartalmazhatnak!", { position: 'top-center' }); isRegistrationFailed.value = true; }
    else if (!vetData.value.email.match(store.emailPattern)) { toast.error("Nem megfelelő email formátum!", { position: 'top-center' }); isRegistrationFailed.value = true; }
    else if (vetData.value.password.length < 8) toast.error("A jelszónak minimum 8 karakter hosszúnak kell lenni!", { position: 'top-center' });
    else if (!vetData.value.password.match(store.lowerCaseLetters)) toast.error("A jelszó nem tartalmaz kisbetűs karaktert!", { position: 'top-center' });
    else if (!vetData.value.password.match(store.upperCaseLetters)) toast.error("A jelszó nem tartalmaz nagybetűs karaktert!", { position: 'top-center' });
    else if (!vetData.value.password.match(store.numbers)) toast.error("A jelszó nem tartalmaz számot!", { position: 'top-center' });
    else if (vetData.value.password === vetData.value.confirm_password) isRegistrationFailed.value = false;
    else { toast.error("Nem egyezik a két jelszó!", { position: 'top-center' }); isRegistrationFailed.value = true; }

    if (!isRegistrationFailed.value) {
        isButtonDisabled.value = true;
        registerData.value = {
            name: vetData.value.firstName + " " + vetData.value.lastName,
            phone: vetData.value.phone.replace(/[/-]/g, ''),
            email: vetData.value.email,
            stamp_number: vetData.value.stamp_number,
            address: vetData.value.address,
            postal_code: vetData.value.postal_code,
            password: vetData.value.password,
            confirm_password: vetData.value.confirm_password,
            role: 1
        }

        userservice.registerUser(registerData.value)
            .then(resp => {
                storeUser.showEmailVerification = true;
                toast.success('Sikeres regisztráció', { position: 'top-center' });
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
    position: relative;
    box-shadow: 0 4px 8px 0 rgba(0, 0, 0, 0.2), 0 6px 20px 0 rgba(0, 0, 0, 0.19);
    border-radius: 7px;
}


.formCardLeft {
    background-color: #fff;
    border-radius: 7px 0 0 7px;
    height: 650px;
    width: 420px;
    padding: 50px;
}

.addressLabel {
    display: flex;
    gap: 75px;
}

.nameLabel {
    display: flex;
    gap: 85px;
}

.nameLabel label {
    margin-top: 6px;
}

.nameInput {
    display: flex;
    gap: 10px;
}

.nameInput input {
    width: 155px;
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
    width: 100%;
}

#logo {
    width: 220px;
}

.formCardRight {
    height: 650px;
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
    margin-top: 24px;
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

.btnStyle {
    text-align: center;
    margin-top: 30px;
    width: 100%;
    background-color: #246951;
    font-size: 1.05rem;
}

.btnStyle:hover {
    background-color: #368267;
    transition: 200ms;
}

.loadingSvg {
    left: 80px;
    top: 30px;
}

.pages {
    display: flex;
    justify-content: center;
    align-items: center;
    margin-top: 24px;
}

.page {
    display: flex;
    justify-content: center;
    align-items: center;
    border-radius: 50%;
    width: 40px;
    padding: 10px;
    margin: 12px;
    background-color: #50B692;
    color: white;
    cursor: pointer;
}

.activePage {
    background-color: #368267;
}


@media (max-width: 848px) {
    .main {
        flex-direction: column-reverse;
    }

    .formCardLeft {
        width: 400px;
        border-radius: 0 0 7px 7px;
        height: 605px;
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

    #logo {
        width: 200px;
        margin-bottom: 24px;
    }

}

@media (max-width: 468px) {
    .formCardLeft {
        width: 300px;
        padding: 24px;
        height: 560px;
    }

    .formCardRight {
        height: 20px;
        width: 300px;
    }

    input {
        width: 240px;
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
        font-size: 1.4rem;
    }

    #terms {
        font-size: 0.75rem;
    }

    .nameInput {
        width: 240px;
    }

    .nameInput input {
        width: 115px;
        padding: 5px 10px 5px;
    }

    .nameLabel {
        gap: 50px;
    }

    .addressLabel {
        gap: 40px;
    }

    .btnStyle {
        width: 240px;
    }

    .page {
        width: 32px;
        height: 32px;
        border-radius: 50px;
    }
}
</style>