import { Injectable } from '@angular/core';
import { Adapter } from '../utilities/adapter';
import { Deserializable } from '../utilities/deserializable';

export class Faq implements Deserializable {
    _Question: String;
    _Response: String;

    constructor(args: {
        question: String,
        response: String
    }
    ) {
        this._Question = args.question;
        this._Response = args.response;
    }

    deserialize(input: any): this {
        Object.assign(this, input);
        return this;
    }
}

@Injectable({
    providedIn: 'root'
})
export class FaqAdapter implements Adapter<Faq> {
    adapt(item: any): Faq {
        return new Faq(item);
    }
}
