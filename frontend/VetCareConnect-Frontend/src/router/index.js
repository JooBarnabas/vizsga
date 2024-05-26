import { createRouter, createWebHistory } from 'vue-router'
import HomePageVue from '@/views/HomePage.vue'
import NotFoundPageVue from '@/views/NotFoundPage.vue'
import { useUserStore } from '../store/userstore.js'
import { storeToRefs } from 'pinia'
import { useToast } from 'vue-toastification'

const toast = useToast();

const access = {
  '/': [0, 1, 2, null],
  '/idopontfoglalas': [0],
  '/kedvenceim': [0],
  '/naptaram': [0],
  '/bejelentkezes': [null],
  '/bejelentkezes/admin': [null],
  '/regisztracio': [null],
  '/elfelejtett-jelszo': [null],
  '/uj-jelszo/:token': [null],
  '/allatorvosok': [0, 1, null],
  '/gyik': [0, 1, null],
  '/orvosi-naptar': [1],
  '/nyitvatartas': [1],
  '/adataim': [0, 1],
  '/admin': [2],
  '/:catchAll(.*)': [0, 1, 2, null]
};

const router = createRouter({
  history: createWebHistory(import.meta.env.BASE_URL),
  routes: [
    { path: '/', name: 'home', component: HomePageVue },
    { path: '/idopontfoglalas/:doctorId?', name: 'appointmentBooking', component: () => import('@/views/user/AppointmentBookingPage.vue') },
    { path: '/kedvenceim', name: 'pets', component: () => import('@/views/user/PetsPage.vue') },
    { path: '/naptaram', name: 'appointments', component: () => import('@/views/user/AppointmentsPage.vue') },
    { path: '/bejelentkezes', name: 'login', component: () => import('@/views/login/LoginPage.vue') },
    { path: '/bejelentkezes/admin', name: 'adminLogin', component: () => import('@/views/login/AdminLoginPage.vue') },
    { path: '/regisztracio', name: 'register', component: () => import('@/views/login/RegisterPage.vue') },
    { path: '/elfelejtett-jelszo', name: 'forgotPassword', component: () => import('@/views/login/ForgotPasswordPage.vue') },
    { path: '/uj-jelszo/:token?', name: 'resetPassword', component: () => import('@/views/login/PasswordReset.vue') },
    { path: '/allatorvosok', name: 'vets', component: () => import('@/views/VetSearchPage.vue') },
    { path: '/gyik', name: 'gyik', component: () => import('@/views/FrequentlyAskedQuestionsPage.vue') },
    { path: '/orvosi-naptar', name: 'orvosiNaptar', component: () => import('@/views/vet/VetCalendar.vue') },
    { path: '/nyitvatartas', name: 'nyitvatartas', component: () => import('@/views/vet/VetSettingsPage.vue') },
    { path: '/adataim', name: 'myData', component: () => import('@/views/MyDataPage.vue') },
    { path: '/admin', name: 'admin', component: () => import('@/views/AdminPage.vue') },
    // catch all 404
    { path: '/:catchAll(.*)*', name: 'notfound', component: NotFoundPageVue }
  ]
})

router.beforeEach((to, from, next) => {
  const { status, user } = storeToRefs(useUserStore());
  const publicPages = ['/', '/bejelentkezes', '/bejelentkezes/admin', '/regisztracio', '/allatorvosok', '/gyik', '/elfelejtett-jelszo'];
  let autRequired = !publicPages.includes(to.path);
  if (to.path.startsWith("/uj-jelszo")) {
    autRequired = false;
    return next();
  }
  if (!access[to.path]) {
    return next();
  }
  if (autRequired && !status.value.loggedIn) {
    toast.error("Bejelentkezés szükséges!", { position: "top-center" });
    return next('/');
  }
   else if (!to.path.startsWith("/idopontfoglalas/") && !access[to.path].includes(user.value.role)) {
    toast.error("Jogosultság szükséges!", { position: "top-center" });
    if (status.value.loggedIn && user.value.role == 2) {
      return next('/admin');
    }
    return next('/');
  }
  else if (to.path.startsWith("/idopontfoglalas/")) {
    if (status.value.loggedIn && user.value.role == 0) {
      return next();
    } else {
      toast.error("Jogosultság szükséges!", { position: "top-center" });
      return next('/');
    }
  } 
  next();
});

export default router