import { Injectable } from '@angular/core';
import { Adapter } from '../utilities/adapter';
import { Deserializable } from '../utilities/deserializable';

export class Skills implements Deserializable {
    _Id: String;
    _Title: String;
    _Level?: String;
    _ParentId?: String;
    _Recommended?: number;

    constructor(args: {
        skillId: String,
        title: String,
        level?: String,
        parentId?: String,
        recommended?: number
    }
    ) {
        this._Id = args.skillId;
        this._Title = args.title;
        this._Level = args.level;
        this._ParentId = args.parentId;
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
