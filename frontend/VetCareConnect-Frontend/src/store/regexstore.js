import { defineStore } from "pinia";

export const useRegexStore = defineStore('regexStore', {
    state: () => ({
        lowerCaseLetters: /[a-záéiíoóöőuúüű]/,
        upperCaseLetters: /[A-ZÁÉIÍOÓÖŐUÚÜŰ]/,
        numbers: /[0-9]/,
        emailPattern: /^[a-zA-Z0-9+_.-]+@[a-zA-Z0-9.-]+\.[a-zA-z]{2,3}$/,
        charactersPattern: /^[a-zA-ZàáâäãåąčćęèéêëėįìíîïłńòóôöõøùúûüųūÿýżźñçčšžÀÁÂÄÃÅĄĆČĖĘÈÉÊËÌÍÎÏĮŁŃÒÓÔÖÕØÙÚÛÜŲŪŸÝŻŹÑßÇŒÆČŠŽ∂ð ,.'-]+$/u,
        addressPattern: /[A-Za-záéiíoóöőuúüűÁÉIÍOÓÖŐUÚÜŰäß\s-]+\.?\s?[0-9]{1,3}\.?-?\/?[a-zA-Z0-9]{0,3}/,
        stampAndPostalPattern: /[0-9]{4}/
    }),
})

