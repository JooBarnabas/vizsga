<template>
    <h1 class="text-center">Kilátók értékelése</h1>
    <div class="form">

        <div class="data">
            <label for="viewpoint">Kilátó:</label>
            <select name="viewpointId" id="viewpoint" v-model="sendData.viewpointId">
                <option value="">Kérem válasszon</option>
                <option v-for="data in viewpoints" :value="data.id">{{ data.viewpointName }}</option>
                
            </select>
        </div>

        <div class="data">
            <label for="email">Az Ön e-mail címe:</label>
            <input v-model="sendData.email" type="text" id="email" name="email">
        </div>

        <div class="data">
            <label for="rating">Értékelés:</label>
            <input v-model="sendData.rating" type="range" min="1" max="10" id="rating" name="rating">
        </div>

        <div class="data">
            <label for="rating">Megjegyzsés:</label>
            <textarea v-model="sendData.comment" id="comment" name="comment" rows="3"></textarea>
        </div>

        <div class="data">
            <input type="checkbox" id="acceptedConditions" name="acceptedConditions">
            <label for="acceptedConditions">Felhasználási feltételeket elfogadom</label>
        </div>

        <div class="data">
            <input type="button" value="Küldés" @click="postData()" style="margin: 0 220px; width: 160px;">
        </div>

        <div class="middle">
           A kilátó eddigi értékelése {{ gotInfo.rating }}, {{ gotInfo.count }} szavazat alapján.
        </div>


        <div class="error" v-show="errorMessage">
            <span>{{ errorMessage }}</span>
            <span>x</span>
        </div>
    </div>
</template>

<script setup>
import { ref } from "vue";
import mainservice from "../services/mainservice"
import router from "@/router";

const viewpoints = ref();
const errorMessage = ref();
const sendData = ref({
    viewpointId: 0,
    email: "",
    rating: 0,
    comment: "",
});

const gotInfo = ref({
    count: 0,
    avarage: 0,
})

function getViewpoints(){
    mainservice.getViewpoints().then((resp) => {viewpoints.value = resp}).catch();
}

getViewpoints();

function postData(){
    mainservice.post(sendData.value).then((resp) => {router.push('/'); gotInfo.value = resp}).catch((err) => {
        console.log(err);
        errorMessage.value = err.data.message;
    });
}
</script>

<style lang="css" scoped>
.text-center{
    text-align: center;
}

.form {
    width: 600px;
    margin: 0 auto;
}

.data {
    margin-bottom: 1rem;
}

label {
    display: block;
    font-size: 1.4rem;
}

input, select {
    font-size: 1.5rem;
    width: 100%;
    padding: 6px;
    border-radius: 6px;
}

input[type='checkbox'] {
    width: unset;    
}

label[for='acceptedConditions'] {
    display: inline-block;
}

#acceptedConditions {
    width: 1.3rem;
    height: 1.3rem;
    margin-right: 8px;
}

.error {
    background-color: red;
    color: white;
    text-align: center;
    font-size: 1.4rem;
    padding: 10px 4px;
    border-radius: 6px;
}

.error span:nth-child(2) {
    float: right;
    padding-right: 4px;
    cursor: pointer;
}

textarea {
	width: 100%;
	resize: none;
	font-size: 1.5rem;
}

.error span:nth-last-of-type(1) {
    cursor: pointer;
}
</style>