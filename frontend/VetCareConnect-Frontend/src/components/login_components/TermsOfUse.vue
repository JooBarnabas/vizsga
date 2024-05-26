<template>
    <div class="darkBack">
        <div class="front">
            <div class="close">
                <img @click="TogglePopup()" src="../../assets/icons/close.svg">
            </div>
            <h3>Adatvédelmi tájékoztató</h3>
            <p>Bármilyen adatkezelésbe is fog egy cég (például kezeli a honlapján megforduló látogatók személyes adatait, az ott regisztráltaknak hírlevelet küld, stb.), tevékenységéről előzetesen tájékoztatnia kell a látogatókat. Az adatvédelmi tájékoztató arra szolgál, hogy a lehető legérthetőbb formában közölje az érintettekkel hogy ki, mire, mikor, hogyan és milyen célból használhatja fel az általuk szolgáltatott adatokat, valamint felvilágosítást nyújtson a jogaikról és – bizonyos esetekben – a jogorvoslati lehetőségeikről.  
                Az előzetes tájékoztató tartalmát jogszabály határozza meg, ahogy azt is, hogy milyen tevékenységeket (pl. hírlevél küldés, direkt marketing célú levelezés, nyereményjáték szervezése) kell a tevékenység megkezdése előtt bejelenteni a hatóság adatvédelmi nyilvántartásába.  
                A mintában piros színnel jelölt részek tartalma a cég adatainak, tevékenységi körének megfelelően módosítandók, illetve amennyiben nincs rá szükség (pl. nyereményjáték, direkt marketing adatkezelés, engedélyköteles tevékenység megnevezése és az engedély száma, stb.), abban az esetben kitörlendő.  
            </p>
            <button @click="TogglePopup()">Értettem</button>
        </div>
    </div>
</template>

<script setup>
const props = defineProps(['TogglePopup']);
</script>

<style scoped>
.front {
    background-color: #fff;
    min-width: 300px;
    border-radius: 7px;
    width: 60%;
    height: 80vh;
    padding: 6vh;
    box-shadow: 0 4px 8px 0 rgba(0, 0, 0, 0.2), 0 6px 20px 0 rgba(0, 0, 0, 0.19);
    overflow-y: scroll;
    position: relative;
}

.close {
    position: absolute;
    top: 5%;
    right: 5%;
}

.close:hover {
    transform: scale(1.1);
    transition: 200ms;
}

button {
    background: #246951;
    font-size: 1.05rem;
    width: 120px;
    border: 0;
    padding: 5px;
    color: white;
    border-radius: 7px;
    box-shadow: 0 4px 8px 0 rgba(0, 0, 0, 0.2), 0 6px 20px 0 rgba(0, 0, 0, 0.19);
    display: flex;
    align-items: center;
    justify-content: center;
}

@media (min-width: 1000px) {
    .front {
        height: fit-content;
    }
}
</style>