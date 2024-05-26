<template>
    <div class="container">
        <h1>404</h1>
        <img id="notFound" src="../assets/images/not_found.png">
        <h3>Van egy kis bibi...</h3>
        <p>Kérjük próbálja újra később!</p>

    </div>
</template>

<script setup>
</script>

<style scoped>
#notFound {
    width: 600px;
    margin-bottom: 30px;

}

.container {
    display: flex;
    align-items: center;
    flex-direction: column;
}

.container h1 {
    font-size: 70px;
    margin-bottom: 30px;
    color: #50B692;
}

.container h3 {
    font-size: 30px;
    color: #368267;
}</style>