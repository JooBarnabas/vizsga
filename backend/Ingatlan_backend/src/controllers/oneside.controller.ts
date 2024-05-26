import { Router } from "express";
import Controller from "../interfaces/controller.interface";
import onesideModel from "./oneside.model";

export default class nsideController implements Controller {
    public router = Router();
    private onesideM = onesideModel;

    constructor() {}
}
