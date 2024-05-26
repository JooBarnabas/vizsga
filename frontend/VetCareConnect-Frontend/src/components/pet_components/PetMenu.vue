<template>
    <div class="back" @mouseleave="petMenuToggle()">
        <div class="front">
            <div class="petEdit" @click="editPet()">
                <img src="../../assets/icons/edit.svg">
                <p>Szerkesztés</p>
            </div>
            <hr>
            <div class="petDelete" @click="deletePet()">
                <img src="../../assets/icons/delete.svg">
                <p>Törlés</p>
            </div>
        </div>
    </div>
</template>

<script setup>
const props = defineProps(['petMenuToggle', 'deletePet', 'editPet']);
</script>

<style scoped>
.back {
    background-color: #fff;
    border-radius: 7px;
    height: max-content;
    width: 180px;
    padding: 8px 8px;
    box-shadow: 0 4px 8px 0 rgba(0, 0, 0, 0.2), 0 6px 20px 0 rgba(0, 0, 0, 0.19);
    color: #888;
    display: flex;
    justify-content: start;
}

.front {
    width: 100%;
}

hr {
    margin: 8px;
    color: #888;
}

.petDelete,
.petEdit {
    display: flex;
    align-items: center;
    border-radius: 7px;
    font-weight: 700;
    padding: 8px;
    cursor: pointer;
}

.petEdit:hover {
    background-color: #eee;
}

.petDelete:hover {
    background-color: #f0bac0;
    color: #af3b3b;
}

.petDelete:hover img {
    filter: invert(37%) sepia(7%) saturate(7110%) hue-rotate(319deg) brightness(85%) contrast(95%);
}

p {
    margin: 0;
}

img {
    height: 22px;
    width: auto;
    margin-right: 8px;
    filter: invert(59%) sepia(0%) saturate(2%) hue-rotate(170deg) brightness(91%) contrast(93%);
}
</style>