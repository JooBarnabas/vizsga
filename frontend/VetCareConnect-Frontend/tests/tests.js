import { Builder, Browser, By, Key, until } from "selenium-webdriver";
import { test } from "node:test";
import  * as assert from "node:assert";

async function runTests(){
    let driver = await new Builder().forBrowser(Browser.CHROME).build()
    try {
        //login
        await driver.get('https://bgs.jedlik.eu/vetcareconnect/bejelentkezes')
        await driver.wait(until.elementLocated(By.className('middle')))

        let email = await driver.findElement(By.className('middle')).findElement(By.tagName('input'))
        let password = await driver.findElement(By.className('middle')).findElement(By.className('passwordAndEyeIcon')).findElement(By.tagName('input'))
        let submit = await driver.findElement(By.className('p-button p-component btnStyle'))

        await email.sendKeys('maria@example.net')
        await password.sendKeys('Teszt123')
        await driver.executeScript("arguments[0].click()", submit)

        await driver.wait(until.elementLocated(By.className('vetImage')))

        //faq page test
        await driver.get('https://bgs.jedlik.eu/vetcareconnect/gyik')
        await driver.wait(until.elementLocated(By.className('pageTitle')))

        let gyikHeader = await driver.findElement(By.className('pageTitle'))
        await driver.wait(until.elementIsVisible(gyikHeader))

        let gyikHeaderText = await gyikHeader.getText()

        let questions = await driver.findElement(By.className('faq')).findElement(By.tagName('div')).findElements(By.className('p-accordion-tab'))
        await driver.wait(until.elementIsVisible(questions[0]))

        test("Testing faq page", _ => {
                assert.ok(gyikHeader)
                assert.equal(gyikHeaderText, "Gyakran ismételt kérdések")
                assert.equal(questions.length, 4)
            })

        //vetsearch page test
        await driver.get('https://bgs.jedlik.eu/vetcareconnect/allatorvosok')
        await driver.wait(until.elementLocated(By.className('pageTitle')))

        let vetsHeader = await driver.findElement(By.className('pageTitle'))
        await driver.wait(until.elementIsVisible(vetsHeader))

        let vetsHeaderText = await vetsHeader.getText()

        let vetInputs = await driver.findElements(By.tagName('input'))

        test("Testing vetsearch page", _ => {
            assert.ok(vetsHeader)
            assert.equal(vetsHeaderText, "Állatorvosok")
            assert.equal(vetInputs.length, 3)
        })

        //appointment booking page test
        await driver.get('https://bgs.jedlik.eu/vetcareconnect/idopontfoglalas')
        await driver.wait(until.elementLocated(By.className('pageTitle')))

        let appointmentBookingHeader = await driver.findElement(By.className('pageTitle'))
        await driver.wait(until.elementIsVisible(appointmentBookingHeader))

        let appointmentBookingHeaderText = await appointmentBookingHeader.getText()

        let appointmentDetails = await driver.findElements(By.tagName('select'))

        let vet = await driver.findElement(By.tagName('select'))
        await driver.wait(until.elementIsVisible(vet))

        let choosedVet = appointmentDetails[0].findElement(By.tagName('option'))
        await driver.wait(until.elementIsVisible(choosedVet))
        let choosedVetText = await choosedVet.getText()

        let appointments = await driver.findElements(By.tagName('times btnStyle'))

        let choosedType = appointmentDetails[1].findElement(By.tagName('option'))
        await driver.wait(until.elementIsVisible(choosedType))
        let choosedTypeText = await choosedType.getText()

        let choosedPet = appointmentDetails[2].findElement(By.tagName('option'))
        await driver.wait(until.elementIsVisible(choosedPet))
        let choosedPetText = await choosedPet.getText()

        test("Testing appointment booking page", _ => {
            assert.ok(appointmentBookingHeader)
            assert.equal(appointmentBookingHeaderText, "Időpontfoglalás")
            assert.equal(appointmentDetails.length, 3)
            assert.equal(choosedVetText, "Kérem válasszon!")
            assert.equal(appointments.length, 0)
            assert.equal(choosedTypeText, "Kérem válasszon!")
            assert.equal(choosedPetText, "Kérem válasszon!")
        })

        //pets page test
        await driver.get('https://bgs.jedlik.eu/vetcareconnect/kedvenceim')
        await driver.wait(until.elementLocated(By.className('pageTitle')))

        let petsHeader = await driver.findElement(By.className('pageTitle'))
        await driver.wait(until.elementIsVisible(petsHeader))

        let petsHeaderText = await petsHeader.getText()

        let addButton = await driver.findElement(By.className('addPet'))

        test("Testing pets page", _ => {
            assert.ok(petsHeader)
            assert.equal(petsHeaderText, "Kedvenceim")
            assert.ok(addButton)
        })

        //appointments page test
        await driver.get('https://bgs.jedlik.eu/vetcareconnect/naptaram')
        await driver.wait(until.elementLocated(By.className('pageTitle')))

        let appointmentsHeaders = await driver.findElements(By.className('pageTitle'))
        let newButton = await driver.findElement(By.className('newAppointmentButton'))

        await driver.wait(until.elementIsVisible(newButton))

        let nextHeader = appointmentsHeaders[0]
        let nextHeaderText = await nextHeader.getText()

        let beforeHeader = appointmentsHeaders[1]
        let beforeHeaderText = await beforeHeader.getText()

        test("Testing appointments page", _ => {
            assert.ok(nextHeader)
            assert.equal(nextHeaderText, "Következő időpontok")
            assert.ok(beforeHeader)
            assert.equal(beforeHeaderText, "Előző időpontok")
            assert.ok(newButton)
        })
    } finally {
        await driver.quit()
    }
  
}

runTests()