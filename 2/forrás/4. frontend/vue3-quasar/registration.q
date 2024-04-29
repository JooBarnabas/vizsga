<template>
  <q-page>
    <div class="row justify-center">
      <div class="col-12 col-sm-8 col-md-6 col-lg-4 q-gutter-md">
        <q-form class="q-gutter-md" @submit="Submit">
          <h4 class="text-center q-mt-lg q-mb-none">Regisztráció</h4>
          <q-select clearable emit-value filled label="Utazás:" map-options />
          <q-input filled label="Az ön neve:" type="text" />
          <q-input filled label="Az Ön e-mail címe:" type="email" />
          <q-input v-model.number="" filled label="Résztvevők száma:" type="number" />
          <q-input clearable filled label="Utolsó COVID oltásának dátuma:" type="date" />
          <div class="row q-mb-md">
            <q-checkbox filled label="Felhasználási feltételeket elfogadom" />
          </div>
          <div class="row justify-center">
            <q-btn class="q-mr-md" color="green" label="Küldés" no-caps type="submit" />
          </div>
          <!-- {{ storeN.data }} -->
        </q-form>
      </div>
    </div>
  </q-page>
</template>
