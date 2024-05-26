<template>
    <div class="main">
        <div class="back">
            <div class="front">
                <ul>
                    <li>8-64 közti karakter szám</li>
                    <li>Minimum 1 nagybetű (ABC)</li>
                    <li>Minimum 1 kisbetű (abc)</li>
                    <li>Minimum 1 szám (123)</li>
                </ul>
            </div>
        </div>
    </div>
</template>
<script setup></script>
<style scoped>
.main {
    z-index: 99;
}

.back {
    background-color: white;
    min-width: 230px;
    min-height: 100px;
    border-radius: 10px;
    box-shadow: 0 4px 8px 0 rgba(0, 0, 0, 0.2), 0 6px 20px 0 rgba(0, 0, 0, 0.19);
    position: absolute;
    padding: 10px 15px 0 0;
    top: 5px;
    left: 90px;
}

.front {
    color: #888;
    font-size: 0.8rem;
}
</style>