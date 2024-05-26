import { Request, Response, Router } from "express";
import Controller from "../interfaces/controller.interface";
import nsideModel from "./nside.model";

export default class nsideController implements Controller {
    public router = Router();
    private nsideM = nsideModel;

    constructor() {
        this.router.get("/api/journey", this.getAll);
        this.router.get("/api/journey/:vehicle", this.getById);
        this.router.post("/api/journey", this.create);
        this.router.delete("/api/journey/:id", this.delete);
    }

    private getAll = async (req: Request, res: Response) => {
        try {
            const data = await this.nsideM.find().populate("vehicle");
            // or:
            // const data = await this.nsideM.find().populate("virtualPop");
            res.send(data);
        } catch (error) {
            res.status(400).send({ message: error.message });
        }
    };

    private getById = async (req: Request, res: Response) => {
        try {
            const vehicle = req.params.vehicle;
            const data = await this.nsideM.find({ vehicle: vehicle }).populate("vehicle");
            if (data.length > 0) {
                res.send(data);
            } else {
                res.status(404).send("A megadott járművel nem érhető el utazási ajánlat.");
            }
        } catch (error) {
            res.status(400).send({ message: error.message });
        }
    };

    private create = async (req: Request, res: Response) => {
        try {
            const body = req.body;
            const createdDocument = new this.nsideM({
                ...body,
            });
            const savedDocument = await createdDocument.save();
            res.status(201).send(savedDocument);
        } catch (error) {
            res.status(400).send({ message: error.message });
        }
    };

    private delete = async (req: Request, res: Response) => {
        try {
            const id = req.params.id;
            const successResponse = await this.nsideM.findByIdAndDelete(id);
            if (successResponse) {
                res.sendStatus(204);
            } else {
                res.status(404).send({ message: `Az ajánlat nem létezik!` });
            }
        } catch (error) {
            res.status(400).send({ message: error.message });
        }
    };
}
