import $axios from "./axios.instance";
import { defineStore } from "pinia";
import { Notify, Loading } from "quasar";

Notify.setDefaults({
  position: "bottom",
  textColor: "yellow",
  timeout: 3000,
  actions: [{ icon: "close", color: "white" }],
});

interface IFields {
  id?: number;
  veiche?: {
    id?: number;
    type?: string;
  };
  country?: string;
  description?: string;
  departure?: string;
  capacity?: number;
  pictureUrl?: string;
}

interface IFieldsShort {
  id?: number;
  destination?: string;
}

interface IState {
  data1: Array<IFields>; // store documents (records) after get all method
  data1Short: Array<IFieldsShort>; // store documents (records) after get short method
}

function ShowErrorWithNotify(error: any): void {
  Loading.hide();
  let msg = `Error on 1-side: ${error.response.status} ${error.response.statusText}`;
  if (error.response.data) {
    msg += ` - ${error.response.data}`;
  }
  Notify.create({ message: msg, color: "negative" });
}

export const useStore1 = defineStore({
  id: "store1",
  state: (): IState => ({
    data1: [],
    data1Short: [],
  }),
  getters: {},
  actions: {
    async getAll(): Promise<void> {
      Loading.show();
      this.data1 = [];
      $axios
        .get("")
        .then((res) => {
          Loading.hide();
          if (res && res.data) {
            this.data1 = res.data;
          }
        })
        .catch((error) => {
          ShowErrorWithNotify(error);
        });
    },
    async getShort(): Promise<void> {
      Loading.show();
      this.data1Short = [];
      $axios
        .get("")
        .then((res) => {
          Loading.hide();
          if (res && res.data) {
            this.data1Short = res.data;
          }
        })
        .catch((error) => {
          ShowErrorWithNotify(error);
        });
    },
  },
});
