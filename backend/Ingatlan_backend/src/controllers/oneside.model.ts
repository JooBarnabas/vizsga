// https://mongoosejs.com/docs/validation.html#built-in-validators
// https://transform.tools/json-to-mongoose

import { Schema, SchemaDefinition, model } from "mongoose";

const onesideSchema = new Schema<SchemaDefinition>(
    {
        _id: Number,
        nev: {
            type: String,
            required: true,
            unique: true,
        },
    },
    // Virtuals are not included in string version of the model instances by default.
    // To include them, set the virtuals option to true on schema’s toObject and toJSON options.
    { versionKey: false, id: false, toJSON: { virtuals: true }, toObject: { virtuals: true } },
);

// Mongoose also supports populating virtuals.
// Help: https://mongoosejs.com/docs/tutorials/virtuals.html#populate
// You can give the "virtualPop" any name you want:
// onesideSchema.virtual("virtualPop", {
//     ref: "nside",
//     localField: "_id",
//     foreignField: "kategoria", // ref_Field
//     justOne: false,
// });

// Use virtual for populate in oneSide controller:
// const data = await this.onesideM.find().populate("populateFieldOneSide", "-_id field1 field2 -field3 ...");

const onesideModel = model("oneside", onesideSchema, "kategoriak");

export default onesideModel;
