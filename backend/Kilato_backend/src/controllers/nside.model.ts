import { Schema, SchemaDefinition, model } from "mongoose";
// https://mongoosejs.com/docs/typescript.html
// https://mongoosejs.com/docs/validation.html
// https://transform.tools/json-to-mongoose

const nsideSchema = new Schema<SchemaDefinition>(
    {
        _id: Number, // default type of PK (with _id identifier): Schema.Types.ObjectId
        location: {
            ref: "oneside", // "onside" -> 1 oldali modell neve, nem kell átírni!
            type: Number,
            required: true,
            index: true,
        },
        description: {
            type: String,
            required: true,
        },
        mountain: {
            type: String,
            required: true,
            unique: true,
            maxLength: 30,
        },
        height: {
            type: Number,
            min: [1, "Egy kilátónak legalább 1 méter magasnak kell lennie!"],
        },
        built: {
            type: Date,
            default: new Date(),
            validate: {
                validator: function (v: Date) {
                    return v <= new Date();
                },
                message: "Az aktuális dátumnál nem adhat meg későbbi dátumot!",
            },
        },
        imageUrl: {
            type: String,
            maxlength: 50,
            required: true,
            default: "http://elit.jedlik.eu/viewpoints/no-img.jpg",
        },
        viewpointName: {
            type: String,
            required: true,
            unique: true,
            maxlength: 50,
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
//     localField: "location",
//     foreignField: "_id", //ref_Field
//     justOne: true,
// });

// Use virtual for populate in nSide controller:
// const data = await this.nsideM.find().populate("populateFieldNside", "-_id field1 field2 -field3 ...");

const nsideModel = model("nside", nsideSchema, "viewpoint");

export default nsideModel;
