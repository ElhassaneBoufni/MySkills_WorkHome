import { Injectable } from "@angular/core";
import { Adapter } from '../utilities/adapter';
import { Deserializable } from '../utilities/deserializable';

export class Skill implements Deserializable {
     Id: String;
     title: String;
     recommended: number;
     level: String;
     parentId: String;

    constructor() {
    }

    deserialize(input: any): this {
        Object.assign(this, input);
        return this;
    }
}

@Injectable({
    providedIn: 'root'
})
export class SkillAdapter implements Adapter<Skill> {
    adapt(item: any): Skill {
        return new Skill().deserialize(item);
    }
}
