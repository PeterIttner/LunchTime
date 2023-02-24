import { Alert } from "./alert.js";
import { Console } from "./console.js";

export class Pi {
    constructor() {
        this.alert = new Alert();
        this.console = new Console();
    }
}