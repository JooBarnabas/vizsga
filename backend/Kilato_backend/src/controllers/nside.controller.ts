import { Request, Response, Router } from "express";
import Controller from "../interfaces/controller.interface";
import nsideModel from "./nside.model";

export default class nsideController implements Controller {
    public router = Router();
    private nsideM = nsideModel;

    constructor() {
        this.router.get("/api/locations/:locationName/viewpoints", this.getByKeyword);
        this.router.patch("/api/viewpoints/:id", this.modifyPATCH);
    }

    private getByKeyword = async (req: Request, res: Response) => {
        // Example of filtering in both side:
        try {
            // const myRegex = new RegExp(req.params.locationName, "i"); // "i" for case-insensitive

            // SQL to Aggregation samples:
            // https://www.mongodb.com/docs/manual/reference/sql-aggregation-comparison/
            // https://www.mongodb.com/docs/manual/tutorial/aggregation-zip-code-data-set/
            // https://www.practical-mongodb-aggregations.com/

            const data = await this.nsideM.aggregate([
                {
                    $lookup: { from: "location", foreignField: "_id", localField: "location", as: "location" },
                    // from: The name of the one-side collection!!!
                    // foreignField: Linking field of one-side collection (here the PK: _id)
                    // localField: Linking field of n-side collection (here the FK: location)
                    // as: alias name, here "location", but it can be anything you like
                },
                {
                    // $match: { $or: [{ "location.field1": myRegex }, { description: myRegex }] },
                    $match: { "location.locationName": req.params.locationName },
                },
                {
                    // convert array of objects to simple array (alias name):
                    $unwind: "$location",
                },
                { $project: { _id: 0, prepTime: 0, "location._id": 0 } },
            ]);
            if (data.length == 0) {
                res.status(404).send({ message: "Ebben a hegységben nem találtam kilátót!" });
            }
            res.send(data);
        } catch (error) {
            res.status(400).send({ message: error.message });
        }
    };
    private modifyPATCH = async (req: Request, res: Response) => {
        try {
            const id = req.params.id;
            const body = req.body;
            const updatedDoc = await this.nsideM.findByIdAndUpdate(id, body, { new: true, runValidators: true }).populate("location", "-_id");
            if (updatedDoc) {
                res.status(200).send(updatedDoc);
            } else {
                res.status(404).send({ message: `${id} azonosítóval nem létezik kilátó!` });
            }
        } catch (error) {
            res.status(400).send({ message: error.message });
        }
    };
}
