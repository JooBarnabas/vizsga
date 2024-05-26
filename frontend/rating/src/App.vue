<script setup>
import { RouterLink, RouterView } from 'vue-router'
</script>

<template>
  <header>
    <nav class="navbar navbar-expand-lg navbar-light bg-light">
        <div class="container-fluid">
            <a class="navbar-brand"><router-link to="/">Kilátók Magyarországon</router-link></a>
            <button class="navbar-toggler" type="button" data-bs-toggle="collapse" data-bs-target="#navbarNav"
                aria-controls="navbarNav" aria-expanded="false" aria-label="Toggle navigation">
                <span class="navbar-toggler-icon"></span>
            </button>
            <div class="collapse navbar-collapse" id="navbarNav">
                <ul class="navbar-nav">
                    <li class="nav-item">
                        <a class="nav-link"><router-link to="/">Nyitólap</router-link></a>
                    </li>
                    <li class="nav-item">
                        <a class="nav-link" ><router-link to="/rating">Értékelés</router-link></a>
                    </li>
                </ul>
            </div>
        </div>
    </nav>
  </header>

  <RouterView />
</template>

<style scoped>
a{
  color: black;
  text-decoration: none;
}


</style>
