<template>
    <div class="appointmentCancelComponent animation-scale">
        <p>Biztosan le szeretné mondani az időpontot?</p>
        <div>
            <button type="submit" @keydown.esc="ClickNo()" class="btnStyle btnNo" @click="ClickNo()">Nem</button>
            <div class="relative">
                <img src="../../assets/icons/loading.svg" v-if="isButtonDisabled" class="loadingSvg">
                <Button type="submit" @key.enter="ClickYes()" @click="ClickYes()" class="btnStyle btnYes" label="Igen"
                    :disabled="isButtonDisabled"></Button>
            </div>
        </div>
    </div>
</template>

<script setup>
import router from '@/router';
import { useUserStore } from "../../store/userstore";
import ownerservice from '@/services/ownerservice';
import { storeToRefs } from "pinia";
import { ref } from 'vue';
import Button from 'primevue/button';
import { useToast } from "vue-toastification";

const toast = useToast();

const { user } = storeToRefs(useUserStore());
const store = useUserStore();
const props = defineProps(['getOwnerAppointments']);

const appointment = {
    id: store.cancelAppointmentId
};

const isButtonDisabled = ref(false)

function ClickNo() {
    store.show = false;
    router.push('/naptaram');
}

function ClickYes() {
    isButtonDisabled.value = true;
    ownerservice.deleteAppointment(appointment.id, user.value.token)
        .then((resp) => {
            props.getOwnerAppointments();
            isButtonDisabled.value = false;
            store.show = false;
            router.push('/naptaram');
            toast.success('Sikeres időpont lemondás!', { position: 'top-center' });
        })
        .catch((err) => {
            isButtonDisabled.value = false;
            router.push('/naptaram');
            toast.error('Valami hiba történt!', { position: 'top-center' });
        });
}

</script>

<style lang="css" scoped>
.appointmentCancelComponent {
    background-color: #50B692;
    width: 500px;
    height: 250px;
    border-radius: 7px;
    color: white;
    display: flex;
    flex-direction: column;
    align-items: center;
    justify-content: center;
    padding: 40px;
    text-align: center;
}

.appointmentCancelComponent div {
    display: flex;
    flex-direction: row;
    align-items: center;
    justify-content: center;
}

.btnNo,
.btnYes {
    margin: 15px;
    margin-top: 5px;
    background-color: #246951;
    padding: 10px 20px;
}

.btnYes {
    padding-left: 30px;
}

.loadingSvg {
    top: 10px;
    left: 15px;
}

@media (max-width: 500px) {
    .appointmentCancelComponent {
        width: 300px;
    }
}
</style>