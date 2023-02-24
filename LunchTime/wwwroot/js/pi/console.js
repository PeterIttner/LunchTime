export class Console {

    isEnabled = false;

    textColor = "#bada55";
    textBackgroundColor = "#222";

    tagTextColor = "white";
    tagTextBackgroundColor = "green";
    tagBorderColor = "white";

    enable() {
        this.isEnabled = true;
        this.logTag("piconsole",`
 _______  ___         _______  _______  __    _  _______  _______  ___      _______ 
|       ||   |       |       ||       ||  |  | ||       ||       ||   |    |       |
|    _  ||   |       |       ||   _   ||   |_| ||  _____||   _   ||   |    |    ___|
|   |_| ||   |       |       ||  | |  ||       || |_____ |  | |  ||   |    |   |___ 
|    ___||   |  ___  |      _||  |_|  ||  _    ||_____  ||  |_|  ||   |___ |    ___|
|   |    |   | |   | |     |_ |       || | |   | _____| ||       ||       ||   |___ 
|___|    |___| |___| |_______||_______||_|  |__||_______||_______||_______||_______|

Logging is enabled
Logging can be disabled by pi.console.disable()
`);
    }

    textStyle() {
        return `
background: ${this.textBackgroundColor};
color: ${this.textColor};
`;
    }

    tagStyle() {
        return `
background: ${this.tagTextBackgroundColor};
color: ${this.tagTextColor};
border: 1px solid ${this.tagBorderColor};
padding: 5px;
`;
    }

    disable() {
        this.isEnabled = false;
    }

    group(data) {
        if (!this.isEnabled) {
            return;
        }

        console.group(data);
    }

    groupEnd(data) {
        if (!this.isEnabled) {
            return;
        }

        console.groupEnd(data);
    }

    log(...data) {
        if (!this.isEnabled) {
            return;
        }
        
        const [a, ...rest] = [...data];

        console.log(`%c${a}`, this.textStyle(), rest);
    }

    logTag(tag, ...data) {
        if (!this.isEnabled) {
            return;
        }

        const [a, ...rest] = [...data];

        console.log(`%c${tag}%c ${a}`, this.tagStyle() , this.textStyle(), rest);
    }
}