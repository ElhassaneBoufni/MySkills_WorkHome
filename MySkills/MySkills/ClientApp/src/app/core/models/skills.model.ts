import { Injectable } from '@angular/core';
import { Adapter } from '../utilities/adapter';
import { Deserializable } from '../utilities/deserializable';

export class Skills implements Deserializable {
    skillId: string;
    title: string;
    applicationUserId?: string;
    recommended?: number;

    constructor(args: {
        skillId: string,
        title: string,
        applicationUserId?: string,
        recommended?: number
    }
    ) {
        this.skillId = args.skillId;
        this.title = args.title;
        this.applicationUserId = args.applicationUserId;
    }

    deserialize(input: any): this {
        Object.assign(this, input);
        return this;
    }
}

@Injectable({
    providedIn: 'root'
})
export class SkillAdapter implements Adapter<Skills> {
    adapt(item: any): Skills {
        return new Skills(item);
    }
}
