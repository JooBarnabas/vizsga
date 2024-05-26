<template>
    <Header></Header>
    <div class="blueCard ">
        <div class="greenCard">
            <div class="">
                <h1>Mi az a VetCare Connect?</h1>
                <p>A VetCare Connect összekapcsolja az állatokat, gazdáikat és állatorvosaikat, valamint segít a gyors és
                    egyszerű kapcsolattartásban.</p>
                <a href="#services"><button class="btnMore" @click="showOwnerTutorial()">Tudj meg többet!</button></a>
            </div>
            <div><img class="vetImage" src="../assets/images/vet_and_dog.png"></div>
        </div>
    </div>

    <div class="cards animation-scale">
        <div class="advantageCards">
            <div class="iconCircle">
                <img src="../assets/icons/connection.svg">
            </div>
            <h1 id="cardTitle">Kapcsolat</h1>
            <p id="cardText">Segítünk a kapcsolat-tartásban a kedvenceid egészsége érdekében, hogy Ők is boldogak legyenek!
            </p>
        </div>

        <div class="advantageCards">
            <div class="iconCircle">
                <img src="../assets/icons/health_metrics.svg">
            </div>
            <h1 id="cardTitle">Egészség</h1>
            <p id="cardText">Fontos számunkra, hogy a felhasználók állandóan támaszkodhassanak a VetCare Connect
                szolgáltatásaira.</p>
        </div>



        <div class="advantageCards">
            <div class="iconCircle">
                <img src="../assets/icons/phone.svg">
            </div>
            <h1 id="cardTitle">Egyszerűség</h1>
            <p id="cardText">Igyekszünk minél könnyebben kezelhető felületet készíteni, hogy Mindenki élvezhesse az
                állattartást!</p>
        </div>

    </div>

    <div class="btns" id="services">
        <a href="#services">
            <button class="btnStyle btnTutorial" @click="showOwnerTutorial()">Gazda útmutató</button>
        </a>
        <a href="#services">
            <button class="btnStyle btnTutorial" @click="showVetTutorial()">Orvos útmutató</button>
        </a>
    </div>

    <div v-if="owner">
        <h1 class="pageTitle">Útmutató gazdáknak</h1>
            <div v-animateonscroll="{ enterClass: 'animation_float_left' }" class="info-cards">
                <div class="steps_card_left">
                    <div>
                        <h2 class="steps">1. Regisztráció</h2>
                        <div class="text">
                            <p>A "Regisztráció" gombra kattintva tud regisztrálni az oldalunkra. Először ki kell választania a
                                felhasználói
                                profilját (gazda), majd az adatok kitöltésével regisztráljon az oldalra!</p>
                            <p>Kérjük ügyeljen az adatai pontos megadására, mivel az email címet a későbbiekben nem tudja
                                megváltoztatni. A
                                többi adat megváltoztatására bejelentkezés után, a neve melletti profil ikonra, majd az "Adataim"
                                menüpontra
                                kattintva van lehetőség.</p>
                        </div>
                    </div>
                    <img src="../assets/images/register.png" class="img_card">
                </div>
            </div>
            <div v-animateonscroll="{ enterClass: 'animation_float_right' }" class="info-cards">
                <div class="steps_card_right">
                    <img src="../assets/images/pets.png" class="img_card">
                    <div>
                        <h2 class="steps">2. Kisállat hozzáadása</h2>
                        <div class="text">
                            <p>Bejelentkezés után a "Kedvenceim" menüpontra kattintva lehet állatokat adni a profilunkhoz.</p>
                            <p>Az állatok adatait később tudja módosítani, az állat profiljának jobb felső sarkában található ikonra
                                kattintva.
                                Itt lehetősége van szerkeszteni, vagy törölni az állatot a profiljából.</p>
                        </div>
                    </div>
                </div>
            </div>
            <div v-animateonscroll="{ enterClass: 'animation_float_left' }" class="info-cards">
                <div class="steps_card_left">
                    <div>
                        <h2 class="steps">3. Állatorvos kiválasztása</h2>
                        <div class="text">
                            <p>Az "Állatorvosok" menüpont alatt tud böngészni a beregisztrált állatorvosok között. Lehetősége van
                                keresni
                                közöttük név, irányítószám és cím alapján.</p>
                            <p>Az "Időpontot foglalok" gombra kattintva elnavigálhat az időpontfoglaló oldalra, ahol automatikusan a
                                kiválasztott orvoshoz tud időpontot foglalni.</p>
                        </div>
                    </div>
                    <img src="../assets/images/vets.png" class="img_card">
                </div>
            </div>
            <div v-animateonscroll="{ enterClass: 'animation_float_right' }" class="info-cards">
                <div class="steps_card_right">
                    <img src="../assets/images/appointment_booking.png" class="img_card">
                    <div>
                        <h2 class="steps">4. Időpont foglalás</h2>
                        <div class="text">
                            <p>Időpontot foglalni az "Időpont foglalás" menüpont alatt, vagy az Útmutató 3. pontjában említett módon
                                tud.
                            </p>
                            <p>Az időpontfoglaláshoz meg kell adnia a kiválasztott orvost, az időpont típusát, a kisállatát, akit az
                                időpontra
                                szeretni vinni, valamint ki tuda választani az időpontot az adott orvoshoz.</p>
                        </div>
                    </div>
                </div>
            </div>
            <div v-animateonscroll="{ enterClass: 'animation_float_left' }" class="info-cards">
                <div class="steps_card_left">
                    <div>
                        <h2 class="steps">5. Lefoglalt időpontok</h2>
                        <div class="text">
                            <p>A "Naptáram" fül alatt tudja megtakinteni az állatorvosi időpontjait.</p>
                            <p>Amennyiben mégsem tud megjelenni az időponton, 2 nappal hamarabb lehetősége van lemondani azt.</p>
                        </div>
                    </div>
                    <img src="../assets/images/appointments.png" class="img_card">
                </div>
            </div>

    </div>

    <div v-if="vet">
        <h1 class="pageTitle">Útmutató orvosoknak</h1>
        <div v-animateonscroll="{ enterClass: 'animation_float_right' }" class="info-cards">
            <div class="steps_card_right">
                <img src="../assets/images/register.png" class="img_card">
                <div>
                    <h2 class="steps">1. Regisztráció</h2>
                    <div class="text">
                        <p>A "Regisztráció" gombra kattintva tud regisztrálni az oldalunkra. Először ki kell választania a
                            felhasználói
                            profilját (orvos), majd az adatok kitöltésével regisztráljon az oldalra!</p>
                        <p>Kérjük ügyeljen az adatai pontos megadására, mivel az email címet a későbbiekben nem tudja
                            megváltoztatni. A
                            többi adat megváltoztatására bejelentkezés után, a neve melletti profil ikonra, majd az "Adataim"
                            menüpontra
                            kattintva van lehetőség.</p>
                    </div>
                </div>
            </div>
        </div>
        <div v-animateonscroll="{ enterClass: 'animation_float_left' }" class="info-cards">
            <div class="steps_card_left">
                <div>
                    <h2 class="steps">2. Nyitvatartás hozzáadása</h2>
                    <div class="text">
                        <p>Bejelentkezés után a "Nyitvatatás" menüpontra kattintva lehet állatokat adni a profilunkhoz.</p>
                        <p>A nyitvatartás módosítására lehetősége van a fent említett menüpontban.</p>
                    </div>
                </div>
                <img src="../assets/images/opening.png" class="img_card">
            </div>
        </div>
        <div v-animateonscroll="{ enterClass: 'animation_float_right' }" class="info-cards">
            <div class="steps_card_right">
                <img src="../assets/images/special_opening.png" class="img_card">
                <div>
                    <h2 class="steps">3. Különleges nyitvatartás</h2>
                    <div class="text">
                        <p>Lehetősége van különleges nyitvatartást felvenni az olyan napokra, amiken valamilyen okból kifolyólag
                            zárva
                            tart vagy másképp tart nyitva, mint a normál nyitvatartás.</p>
                        <p>Az ilyen időpontok kizárólag egy napra szólnak, ezeket a "Nyitvatartás" menüpont alatt tudja
                            beállítani
                            valamint törölni.</p>
                    </div>
                </div>
            </div>
        </div>
        <div v-animateonscroll="{ enterClass: 'animation_float_left' }" class="info-cards">
            <div class="steps_card_left">
                <div>
                    <h2 class="steps">4. Időpontok</h2>
                    <div class="text">
                        <p>Az Ön időpontjait a "Naptáram" fül alatt tudja megtekinteni. A dátum kiválasztásával megjelennek az adott
                            napi kezelések.</p>
                    </div>
                </div>
                <img src="../assets/images/vet_appointments.png" class="img_card">
            </div>
        </div>
    </div>
    <Footer></Footer>
</template>
  
<script setup>
import Header from '@/components/page_controls/Header.vue';
import Footer from '@/components/page_controls/Footer.vue';
import { ref } from 'vue';

const owner = ref(false);
const vet = ref(false);

function showOwnerTutorial(){
    owner.value = true;
    vet.value = false;
}

function showVetTutorial(){
    vet.value = true;
    owner.value = false;
}
</script>
  
<style scoped>
.pageTitle {
    font-size: 40px !important;
    text-align: center;
}
a {
    text-decoration: none;
}

.steps {
    margin-left: 50px;
    /* color: #005A70; */
}

.steps_card_left,
.steps_card_right {
    width: 80%;
    padding: 40px;
    color: white;
    display: flex;
    flex-direction: row;
    align-items: center;
    justify-content: center;
    background-color: #005A70;
    border-radius: 0px 7px 7px 0px;
    margin: 40px 0px;
    box-shadow: 0 4px 8px 0 rgba(0, 0, 0, 0.2);
}

.staps_card_left {
    border-radius: 0px 7px 7px 0px;
}

.steps_card_right {
    margin-right: 0;
    margin-left: auto;
    border-radius: 7px 0px 0px 7px;

}

.img_card {
    width: 500px;
    border-radius: 7px;
    box-shadow: 0 4px 8px 0 rgba(0, 0, 0, 0.2), 0 6px 20px 0 rgba(0, 0, 0, 0.19);
}

.text {
    margin: 20px 70px;
}
.btns {
    display: flex;
    flex-direction: row;
    align-items: center;
    justify-content: center;
}
.btnTutorial {
    background-color: #368267;
    font-size: 20px;
    padding: 10px 20px;
    margin: 20px;
}
.blueCard {
    background-color: #005A70;
    width: 100%;
    height: 500px;
    color: white;
    box-shadow: 0 4px 8px 0 rgba(0, 0, 0, 0.2);
    display: flex;
    align-items: center;
}

.greenCard {
    display: flex;
    justify-content: space-between;
    align-items: center;
    background-color: #50B692;
    width: 75%;
    border-radius: 0 7px 7px 0;
    padding: 50px 100px;
    box-shadow: 0 4px 8px 0 rgba(0, 0, 0, 0.2), 0 6px 20px 0 rgba(0, 0, 0, 0.19);
    position: relative;
    font-size: 1rem;
}

.greenCard h1 {
    font-weight: 500;
}

.greenCard p {
    width: 75%;
}

.greenCard .vetImage {
    position: absolute;
    height: 130%;
    bottom: -24px;
    right: 0;
}

.cards {
    display: flex;
    align-items: baseline;
    justify-content: space-around;
}

.advantageCards {
    font-size: 1.2rem;
    max-width: 240px;
    margin: 50px 0 20px 0;
    display: flex;
    align-items: center;
    flex-direction: column;
}


.iconCircle img {
    filter: invert(100%);
    width: 30px;
}

.iconCircle {
    background-color: #50B692;
    border-radius: 100%;
    width: 60px;
    height: 60px;
    display: flex;
    justify-content: center;
}

.btnMore {
    background-color: #005A70;
    border: none;
    border-radius: 50px;
    padding: 7px 16px;
    box-shadow: 0 4px 8px 0 rgba(0, 0, 0, 0.2);
    height: 40px;
}

button {
    color: white;
    text-decoration: none;
    font-size: 0.9rem;
}

#cardTitle {
    margin-top: 10px;
    text-align: center;
    color: #368267;
    font-weight: 500;
}

#cardText {
    text-align: center;
    color: #50B692;
    margin: 0;
}


#services {
    margin: 110px 0 20px;
    text-align: center;
    font-size: 1.8rem;
}

.summaryCards {
    display: flex;
    align-items: center;
    justify-content: center;
    flex-wrap: wrap;
}

.summaryCard {
    width: 500px;
    height: 300px;
    display: flex;
    flex-direction: column;
    align-items: center;
    justify-content: center;
    background-color: #50B692;
    border-radius: 7px;
    box-shadow: 0 4px 8px 0 rgba(0, 0, 0, 0.2), 0 6px 20px 0 rgba(0, 0, 0, 0.19);
    color: white;
    padding: 30px;
    margin: 40px;
}

.summaryCard:hover {
    transform: scale(1.05);
    transition: 300ms;
}



@media (max-width: 1330px) {
    .advantageCards {
        font-size: 1rem;
        display: flex;
        flex-direction: column;
        justify-content: start;
    }

    #cardTitle {
        font-size: 1.5rem;
        margin-top: 15px;
    }

    .iconCircle {
        width: 50px;
        height: 50px;
        display: flex;
        align-items: center;
    }

    .iconCircle img {
        height: 25px;
    }

    .vetImage {
        display: none;
    }

    .greenCard p {
        width: 100%;
    }
    .img_card {
        width: 300px;
    }
}

@media (max-width: 991px) {

    .greenCard p,
    button {
        font-size: 1rem;
        margin: 0;
    }

    .greenCard h1 {
        font-size: 1.8rem;
    }

    .greenCard {
        padding: 30px 60px;

    }

    .greenCard p {
        margin-bottom: 25px;
    }
    .steps_card_left, .steps_card_right {
        flex-direction: column;
    }
}

@media (max-width: 891px) {
    .blueCard {
        justify-content: center;
        align-items: center;
    }

    .greenCard {
        border-radius: 7px;
    }

    .cards {
        flex-direction: column;
        align-items: center;
    }

    .info-cards {
        display: flex;
        flex-direction: column;
        align-items: center;
        justify-content: center;
    }
    .steps_card_left, .steps_card_right {
        border-radius: 7px 7px 7px 7px;
        margin: 30px 0px;
        
    }

}

@media (max-width: 720px) {
    .pageTitle {
        margin: 0 30px !important;
    }
    .steps_card_right {
        padding: 40px 0px;
    }
    .steps_card_left {
        padding: 40px 0px;
    }
    .btnTutorial {
        font-size: 14px;
    }
    .btns {
        margin-top: 20px !important;
    }
}

@media (max-width: 450px) {

    .greenCard p,
    button {
        font-size: 0.8rem;
        margin: 0;
    }

    .greenCard {
        padding: 20px 40px;
    }

    .greenCard p {
        margin-bottom: 16px;
    }

    .greenCard h1 {
        font-size: 1.4rem;
    }

    .pageTitle {
        font-size: 30px !important;
        margin: 0 10px !important;

    }
    .img_card {
        width: 200px;
    }
    .steps {
        font-size: 18px;
    }

}
</style>
  