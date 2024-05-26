<template>
    <div class="form">
        <div class="data">
            <label for="location">Hegység:</label>
            <select v-model="locationName" name="locationId" id="location" @change="loadingViewpoints()">
                <option value="">Kérem válasszon</option>
                <option v-for="data in mountains" :key="data.id" :value="data.locationName">{{ data.locationName }}</option>
            </select>
        </div>
    </div>
    <div class="middle">
        <div v-for="view in viewpoints" class="viewpoint">
            <h2>{{view.viewpointName}}</h2>
            <div>
                <ul>
                    <li>
                        <label>Hegység:</label>
                        <span>{{view.mountain}}</span>
                    </li>
                    <li>
                        <label>Magassága:</label>
                        <span>{{view.height}} m</span>
                    </li>
                    <li>
                        <label>Épült:</label>
                        <span>{{view.built}}</span>
                    </li>
                </ul>
            </div>
            <p class="description">
                {{ view.description }}
            </p>
            <div class="image">
                <img src="https://viewpoint.jedlik.cloud/images/kalapat.jpg">
            </div>
        </div>
    </div>
        
   
</template>

<script setup>
import { ref } from "vue";
import mainservice from "../services/mainservice"

const mountains = ref();
const locationName = ref();
const viewpoints = ref();
const sendData = ref();

function loadingMountains(){
    mainservice.getMountains().then((resp) => {mountains.value = resp;}).catch();
}

function loadingViewpoints(){
    mainservice.getByName(locationName.value).then((resp) => {viewpoints.value = resp}).catch();
}

loadingMountains();

function postData(){
    mainservice.post(sendData).then((resp) => {}).catch();
}
</script>

<style lang="css" scoped>
.form {
    margin-bottom: 3rem;
    text-align: center;
}

.form .data {
    margin-bottom: 1rem;
}

.form label {
    display: inline-block;
    font-size: 2rem;
    margin-right: 0.5rem;
}

.form input, select {
    font-size: 1.5rem;
    /* width: 100%; */
    padding: 6px;
    border-radius: 6px;
}

#viewpoints {
    display: flex;
    flex-wrap: wrap;
    justify-content: space-evenly;
}

.viewpoint {
    border: 2px solid #777;
    border-radius: 10px;
    background-color: rgb(255, 228, 196);
    min-width: 400px;
    max-width: 600px;
    font-size: 1.5rem;
    
    margin-bottom: 1rem;
}

.viewpoint h2 {
    text-align: center;
    margin: 0;
    padding: 0.25rem;
    background-color: rgb(200, 190, 156);
    border-top-left-radius: 10px;    
    border-top-right-radius: 10px;    
}

.viewpoint ul {
    margin-left: 2rem;
}

.viewpoint ul li label {
    width: 8rem;
    display: inline-block;
}

.viewpoint ul li span {
    font-weight: bold;
}

.viewpoint .description {
    background-color: rgb(200, 190, 156);
    padding: 0.25rem 1.5rem; 
    margin: 0;
    text-align: justify;
    font-size: 1.2rem;
}

.viewpoint img{
    max-width: 100%;
    max-height: 20rem;
    margin: 0.2rem auto;
    border-radius: 20px;
}

.viewpoint .image {
    text-align: center;
}

.middle {
    display: flex;
    justify-content: center;
    align-items: center;
    flex-wrap: wrap;
    gap: 10vh;
}
</style>