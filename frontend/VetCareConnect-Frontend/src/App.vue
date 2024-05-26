<template>
  <RouterView />
</template>

<script setup>
import { RouterView } from 'vue-router'
import { useUserStore } from './store/userstore';

let { user, status } = useUserStore();

if (localStorage.getItem('user') != null ){
   const u = JSON.parse(localStorage.getItem('user'));
   user.name = u.name;
   user.token = u.token;
   user.id = u.id;
   user.role = u.role;
   if (user.token) status.loggedIn = true;
}
</script>

<style scoped>
</style>
