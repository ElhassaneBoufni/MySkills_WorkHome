import { Injectable } from '@angular/core';
import { Adapter } from '../utilities/adapter';
import { Deserializable } from '../utilities/deserializable';

export class AspNetUsers implements Deserializable {

    _FirstName: String;
    _LastName: String;

    constructor(args: {
        firstname: String,
        lastname: String
    }
    ) {
        this._FirstName = args.firstname;
        this._LastName = args.lastname;
    }

    deserialize(input: any): this {
        Object.assign(this, input);
        return this;
    }
}

@Injectable({
    providedIn: 'root'
})

export class AspNetUsersAdapter implements Adapter<AspNetUsers> {

    adapt(item: any): AspNetUsers {
        return new AspNetUsers(item);


    }

}
