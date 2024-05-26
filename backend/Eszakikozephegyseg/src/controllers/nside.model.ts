import { Schema, SchemaDefinition, model } from "mongoose";
// https://mongoosejs.com/docs/typescript.html
// https://mongoosejs.com/docs/validation.html
// https://transform.tools/json-to-mongoose

const nsideSchema = new Schema<SchemaDefinition>(
    {
        _id: Number, // default type of PK (with _id identifier): Schema.Types.ObjectId
        vehicle: {
            ref: "oneside", // "onside" -> 1 oldali modell neve, nem kell átírni!
            type: Number,
            required: [true, "Hiányos adatok!"],
        },
        country: {
            type: String,
            required: [true, "Hiányos adatok!"],
        },
        description: {
            type: String,
            required: [true, "Hiányos adatok!"],
        },
        departure: {
            type: Date,
            required: [true, "Hiányos adatok!"],
        },
        capacity: {
            type: Number,
            default: 1,
        },
        pictureUrl: {
            type: String,
        },
    },
    // Mongoose Virtuals: https://mongoosejs.com/docs/tutorials/virtuals.html
    // Virtuals are not included in string version of the model instances by default.
    // To include them, set the virtuals option to true on schema’s toObject and toJSON options.
    { versionKey: false, id: false, toJSON: { virtuals: true }, toObject: { virtuals: true } },
);

// Mongoose also supports populating virtuals.
// Help: https://mongoosejs.com/docs/tutorials/virtuals.html#populate
// You can give the "virtualPop" any name you want:
// nsideSchema.virtual("virtualPop", {
//     ref: "oneside",
//     localField: "vehicle",
//     foreignField: "_id", //ref_Field
//     justOne: true,
// });

// Use virtual for populate in nSide controller:
// const data = await this.nsideM.find().populate("populateFieldNside", "-_id field1 field2 -field3 ...");

const nsideModel = model("nside", nsideSchema, "journeys");

export default nsideModel;
