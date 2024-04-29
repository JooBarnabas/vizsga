import $axios from "./axios.instance";
import { defineStore } from "pinia";
import { Notify, Loading } from "quasar";

Notify.setDefaults({
  position: "bottom",
  textColor: "white",
  timeout: 3000,
  actions: [{ icon: "close", color: "white" }],
});

interface IFields {
  journeyId?: number; // FK
  name?: string;
  email?: string;
  numberOfParticipants?: number;
  lastCovidVaccineDate?: string;
  acceptedConditions?: boolean;
}

interface IState {
  // dataN: Array<IFields>; // store documents (records) after get method(s)
  data: IFields; // temporary object for create, edit and delete method
  // dataOld: IFields; // temporary object, before edit store data here
}

function ShowErrorWithNotify(error: any): void {
  Loading.hide();
  let msg = `Error on N-side: ${error.response.status} ${error.response.statusText}`;
  if (error.response.data) {
    msg += ` - ${error.response.data}`;
  }
  Notify.create({ message: msg, color: "negative" });
}

export const useStoreN = defineStore({
  id: "storeN",
  state: (): IState => ({
    data: {},
  }),
  getters: {},
  actions: {
    async create(): Promise<void> {
      if (this.data) {
        Loading.show();
        $axios
          .post("", this.data)
          .then((res) => {
            Loading.hide();
            if (res && res.data) {
              Notify.create({
                message: `New document with id=${res.data.id} has been saved successfully!`,
                color: "positive",
              });
            }
          })
          .catch((error) => {
            ShowErrorWithNotify(error);
          });
      }
    },
  },
});
