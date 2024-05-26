<template>
    <Header></Header>
    <h1 class="pageTitle">Gyakran ismételt kérdések</h1>
    <div class="faq">
        <Accordion :multiple="true" class="questions animation-scale">
            <AccordionTab v-for="question in questions" :header="question.question">
                <p>
                    {{ question.answer }}
                </p>
            </AccordionTab>
        </Accordion>
    </div>
    <Footer></Footer>
</template>

<script setup>
import Header from '@/components/page_controls/Header.vue';
import Footer from '@/components/page_controls/Footer.vue';
import Accordion from 'primevue/accordion';
import AccordionTab from 'primevue/accordiontab';

import { ref } from 'vue';
import mainservices from '@/services/mainservices';

const questions = ref();

mainservices.getAllQuestions().then(resp => {
    questions.value = resp.data;
})

</script>

<style lang="css" scoped>
.faq {
    display: flex;
    align-items: center;
    justify-content: center;
}

.questions {
    margin: 0px 70px;
    width: 1000px;
}

@media (max-width: 650px) {
    .questions {
        margin: 0px 40px;
    }

}
</style>