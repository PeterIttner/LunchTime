import Swal from "../../lib/sweetalert2/src/sweetalert2.js";

export class Alert {

    toast(message) {
        Swal.fire({
            position: 'top-right',
            width: "16em",
            icon: 'success',
            toast: true,
            title: message,
            showConfirmButton: false,
            timer: 1000
        })
    }

    loaded(subject = "") {
        this.toast(`Laden erfolgreich ${subject}!`)        
    }

    deleted(subject = "") {
        this.toast(`${subject} erfolgreich gelöscht!`);
    }

    updated(subject = "") {
        this.toast(`${subject} erfolgreich gespeichert!`);
    }

    created(subject = "") {
        this.toast(`${subject} erfolgreich erstellt!`);
    }

    fatal() {
        pi.console.logTag("PiAlert", "A fatal error has been triggered");

        Swal.fire({
            position: 'center',
            icon: 'warning',
            toast: false,
            title: "Problem",
            text: "Die Anwendung ist momentan nicht verfügbar. Bitte versuchen Sie es später erneut!",
            showConfirmButton: false,
            timer: 4000
        })
    }
}