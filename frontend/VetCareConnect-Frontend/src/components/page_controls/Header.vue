<template>
  <div class="heading">
    <ul class="navigation">
      <li>
        <div class="hamburgerMenu">
          <img @click="menuToggle()" id="toggleIcon"
            :src="isSideBarOpen ? getImageUrl('close.svg') : getImageUrl('menu.svg')">
        </div>
      </li>
      <li>
        <router-link to="/">
          <img id="logo" class="desktopMode" src="../../assets/images/logo.png" />
        </router-link>
      </li>
      <div class="routers" v-for="route in Routes">
        <li v-if="route.roleAccess.includes(user.role)"><router-link :to="route.link">{{ route.name }}</router-link>
        </li>
      </div>
    </ul>
    <img id="logo" class="phoneMode" src="../../assets/images/logo.png" />
    <div class="sign" v-if="!status.loggedIn">
      <button id="bejelentkezes"><router-link to="/bejelentkezes">Bejelentkezés</router-link></button>
      <span id="regisztracio"><router-link to="/regisztracio">Regisztráció</router-link></span>
    </div>
    <div class="userInfo" v-else>
      <span class="userName">{{ user.name }}</span>
      <img class="profileLoggedIn" @click="userMenuToggle()" :src="getImageUrl('account_circle.svg')">
    </div>
  </div>
  <SideBar v-show="isSideBarOpen"></SideBar>
  <UserMenu v-show="isUserMenuOpen" :userMenuToggle="userMenuToggle" :isUserMenuOpen="isUserMenuOpen"></UserMenu>
</template>

<script setup>
import { RouterLink } from "vue-router";
import SideBar from "./SideBar.vue";
import UserMenu from "./UserMenu.vue";
import { ref } from "vue";
import { storeToRefs } from "pinia";
import { useUserStore } from "@/store/userstore";
const { status, user } = storeToRefs(useUserStore());

const Routes = [
  { name: "Kezdőlap", link: "/", roleAccess: [0, 1, null] },
  { name: "GYIK", link: "/gyik", roleAccess: [0, 1, null] },
  { name: "Állatorvosok", link: "/allatorvosok", roleAccess: [0, null] },
  { name: "Időpont foglalás", link: "/idopontfoglalas", roleAccess: [0] },
  { name: "Kedvenceim", link: "/kedvenceim", roleAccess: [0] },
  { name: "Naptáram", link: "/naptaram", roleAccess: [0] },
  { name: "Naptáram", link: "/orvosi-naptar", roleAccess: [1] },
  { name: "Nyitvatartás", link: "/nyitvatartas", roleAccess: [1] },
  { name: "Admin", link: "/admin", roleAccess: [2] }
]

const isSideBarOpen = ref(false);
function menuToggle() {
  isSideBarOpen.value = !isSideBarOpen.value;
}

const isUserMenuOpen = ref(false);
function userMenuToggle() {
  isUserMenuOpen.value = !isUserMenuOpen.value;
}
function getImageUrl(name) {
  return new URL(`../../assets/icons/${name}`, import.meta.url).href;
}
</script>

<style scoped>
.heading {
  background-color: #50b692;
  display: flex;
  align-items: center;
  justify-content: space-between;
  padding: 8px 8px;
  width: 100%;
  height: 60px;
  box-shadow: 0 4px 8px 0 rgba(0, 0, 0, 0.2), 0 6px 20px 0 rgba(0, 0, 0, 0.19);
  position: fixed;
  top: 0;
  z-index: 99;
}

.navigation li {
  padding-right: 20px;
  align-items: center;
  justify-content: center;
  display: flex;
  display: inline-block;
}

.navigation {
  display: flex;
  align-items: center;
  list-style: none;
  margin: 0;
  padding-left: 0;
  height: 100%;
  width: fit-content;
}

.navigation .routers a {
  display: flex;
  align-items: center;
  justify-content: center;
}

.phoneMode {
  display: none;
}

.hamburgerMenu,
.profile {
  display: none;
  cursor: pointer;
  filter: invert(100%);
}

.profileLoggedIn {
  cursor: pointer;
  filter: invert(100%);
  width: 30px;
}

.hamburgerMenu:hover,
.profile:hover,
.profileLoggedIn:hover {
  transform: scale(1.1);
  transition: 200ms;
}

.heading a {
  font-weight: 500;
  color: #fff;
  text-decoration: none;
}

.heading a.router-link-exact-active {
  color: #246951;
}

.routers a.router-link-exact-active {
  border-radius: 7px 7px 0 0;
  height: 5px;
  width: 110%;
  box-shadow: 0 27px 0 0 #246951;
}

.heading a:hover {
  color: #246951;
  transition: 200ms;
}

.heading #logo {
  height: 28px;
  cursor: pointer;
  z-index: 99;
}

.sign {
  margin-right: 10px;
  display: flex;
  align-items: center;
}

.sign a {
  padding: 10px;
}

.userInfo {
  display: flex;
  align-items: center;
}

.userName {
  color: #fff;
  font-family: 'Roboto', sans-serif;
  margin-right: 15px;
  width: fit-content;
}

#bejelentkezes {
  background-color: #368267;
  border-radius: 100px;
  padding: 6px 8px;
  box-shadow: 0 4px 8px 0 rgba(0, 0, 0, 0.2);
  border: none;
  height: 40px;
  font-size: 16px;
}

@media (max-width: 991px) {

  .routers,
  .sign {
    font-size: 0.9rem;
  }

  .routers a.router-link-exact-active {
    box-shadow: 0 28px 0 0 #246951;
    height: 4px;
  }

}

@media (max-width: 891px) {


  ul {
    display: flex;
    align-items: center;
  }

  .phoneMode {
    display: block;
  }

  .routers,
  .desktopMode {
    display: none;
  }

  .hamburgerMenu,
  #toggleIcon,
  .profile,
  .profileLoggedIn {
    display: block;
    height: 30px;
  }

  .sign {
    display: none;
  }

  .heading {
    padding: 5px 20px;
    justify-content: space-between;
  }

  @media (max-width: 551px) {
    .userName {
      display: none;
    }
  }

}
</style>