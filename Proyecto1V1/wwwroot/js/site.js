var url_base = "https://localhost:7092/api";

var medic_form = document.getElementById('medic_form');
if (medic_form != null) {

    var id_number = document.getElementById('id_number');
    var professional_code = document.getElementById('professional_code');
    var full_name = document.getElementById('full_name');
    var email = document.getElementById('email');
    var country = document.getElementById('country');
    var province = document.getElementById('province');
    var canton = document.getElementById('canton');
    var id = document.getElementById('id');

    var btn_medic = document.getElementById('btn_medic');
    btn_medic.disabled = true;

    id_number.addEventListener("keyup", () => {
        if (id_number.value.length > 0) {
            const request = fetch( url_base + "/Medics/id_number/" + id_number.value);
            if (request) {
                request.then(
                    response => response.json())
                    .then(function (data) {
                        if (!data.status) {
                            id.value = data.id;
                            professional_code.value = data.professional_code;
                            full_name.value = data.full_name;
                            email.value = data.email;
                            country.value = data.country;
                            province.value = data.province;
                            canton.value = data.canton;
                            btn_medic.disabled = !validar_medict();
                        } else {
                            id.value = "";
                        }
                    });
            }
        }
        btn_medic.disabled = !validar_medict();
    });
    professional_code.addEventListener("keyup", () => {
        if (professional_code.value.length > 0) {
            const request = fetch(url_base + "/Medics/professional_code/" + professional_code.value);
            if (request) {
                request.then(
                    response => response.json())
                    .then(function (data) {
                        if (!data.status) {
                            id.value = data.id;
                            id_number.value = data.id_number;
                            full_name.value = data.full_name;
                            email.value = data.email;
                            country.value = data.country;
                            province.value = data.province;
                            canton.value = data.canton;
                            btn_medic.disabled = !validar_medict();
                            //id_number.disabled = true;
                        } else {
                            id.value = "";
                            //id_number.disabled = false;
                        }
                    });
            } 
        }
        btn_medic.disabled = !validar_medict();
    });
    full_name.addEventListener("keyup", () => {
        btn_medic.disabled = !validar_medict();
    });
    email.addEventListener("keyup", () => {
        btn_medic.disabled = !validar_medict();
    });
    country.addEventListener("keyup", () => {
        btn_medic.disabled = !validar_medict();
    });
    province.addEventListener("keyup", () => {
        btn_medic.disabled = !validar_medict();
    });
    canton.addEventListener("keyup", () => {
        btn_medic.disabled = !validar_medict();
    });
}

function validar_medict() {
    var id_number = document.getElementById('id_number');
    var professional_code = document.getElementById('professional_code');
    var full_name = document.getElementById('full_name');
    var email = document.getElementById('email');
    var country = document.getElementById('country');
    var province = document.getElementById('province');
    var canton = document.getElementById('canton');
    
    if (id_number.value != "" && professional_code.value != "" && full_name.value != "" && email.value != "" && country.value != "" && province.value != "" && canton.value != "") {
        return true;
    } else {
        return false
    }
}

var clinic_form = document.getElementById('clinic_form');
if (clinic_form != null) {

    var name_ = document.getElementById('name');
    var legal_certificate = document.getElementById('legal_certificate');
    var country = document.getElementById('country');
    var province = document.getElementById('province');
    var canton = document.getElementById('canton');
    var district = document.getElementById('district');
    var phone_number = document.getElementById('phone_number');
    var email = document.getElementById('email');
    var web_site = document.getElementById('web_site');
    var id = document.getElementById('id');

    var btn_clinic = document.getElementById('btn_clinic');
    btn_clinic.disabled = true;

    legal_certificate.addEventListener("keyup", () => {
        if (legal_certificate.value.length > 0) {
            const request = fetch(url_base + "/Clinics/legal_certificate/" + legal_certificate.value);
            if (request) {
                request.then(
                    response => response.json())
                    .then(function (data) {
                        if (!data.status) {
                            name_.value = data.name;
                            email.value = data.email;
                            country.value = data.country;
                            province.value = data.province;
                            canton.value = data.canton;
                            district.value = data.district;
                            phone_number.value = data.phone_number;
                            web_site.value = data.web_site;
                            btn_clinic.disabled = !validar_clinic();
                        } else {
                            id.value = "";
                        }
                    });
            }
        } 
        btn_clinic.disabled = !validar_clinic();
    });

    name_.addEventListener("keyup", () => {
        if (name_.value.length > 0) {
            const request = fetch(url_base + "/Clinics/clinic_name/" + name_.value);
            if (request) {
                request.then(
                    response => response.json())
                    .then(function (data) {
                        
                        if (!data.status) {
                            id.value = data.id;
                            legal_certificate.value = data.legal_certificate;
                            email.value = data.email;
                            country.value = data.country;
                            province.value = data.province;
                            canton.value = data.canton;
                            district.value = data.district;
                            phone_number.value = data.phone_number;
                            web_site.value = data.web_site;
                            btn_clinic.disabled = !validar_clinic();
                        } else {
                            id.value = "";
                        }
                    });
            }
        } 
        btn_clinic.disabled = !validar_clinic();
    })

    country.addEventListener("keyup", () => {
        btn_clinic.disabled = !validar_clinic();
    });
    province.addEventListener("keyup", () => {
        btn_clinic.disabled = !validar_clinic();
    });
    canton.addEventListener("keyup", () => {
        btn_clinic.disabled = !validar_clinic();
    });
    district.addEventListener("keyup", () => {
        btn_clinic.disabled = !validar_clinic();
    });
    phone_number.addEventListener("keyup", () => {
        btn_clinic.disabled = !validar_clinic();
    });
    email.addEventListener("keyup", () => {
        btn_clinic.disabled = !validar_clinic();
    });
    web_site.addEventListener("keyup", () => {
        btn_clinic.disabled = !validar_clinic();
    });
    web_site.addEventListener("change", () => {
        btn_clinic.disabled = !validar_clinic();
    });
    
}

function validar_clinic() {
    var name_ = document.getElementById('name');
    var legal_certificate = document.getElementById('legal_certificate');
    var country = document.getElementById('country');
    var province = document.getElementById('province');
    var canton = document.getElementById('canton');
    var district = document.getElementById('district');
    var phone_number = document.getElementById('phone_number');
    var email = document.getElementById('email');
    var web_site = document.getElementById('web_site');


    if (district.value != "" && phone_number.value != "" && web_site.value != "" && name_.value != "" && legal_certificate.value != "" && email.value != "" && country.value != "" && province.value != "" && canton.value != "") {
        return true;
    } else {
        return false
    }
}

var patient_form = document.getElementById('patient_form');
if (patient_form != null) {

    var id = document.getElementById('id');
    var id_number = document.getElementById('id_number');
    var name_ = document.getElementById('name');
    var surname_1 = document.getElementById('surname_1');
    var surname_2 = document.getElementById('surname_2');
    var birth_date = document.getElementById('birth_date');
    var gender = document.getElementById('gender');
    var contact_number = document.getElementById('contact_number');
    var country = document.getElementById('country');
    var province = document.getElementById('province');
    var canton = document.getElementById('canton');
    var district = document.getElementById('district');
    var marital_status = document.getElementById('marital_status');
    var phone_number = document.getElementById('phone_number');
    var email = document.getElementById('email');
    var register_date = document.getElementById('register_date');
    var occupation = document.getElementById('occupation');
    var id = document.getElementById('id');

    var btn_patient = document.getElementById('btn_patient');
    btn_patient.disabled = true;

    id_number.addEventListener("keyup", () => {
        if (id_number.value.length > 0) {
            const request = fetch(url_base + "/Patients/patient/" + id_number.value);
            if (request) {
                request.then(
                    response => response.json())
                    .then(function (data) {
                        if (!data.status) {
                            id.value = data.id;
                            name_.value = data.name;
                            surname_1.value = data.surname_1;
                            surname_2.value = data.surname_2;
                            birth_date.value = data.birth_date;
                            gender.value = data.gender;
                            contact_number.value = data.contact_number;
                            country.value = data.country;
                            province.value = data.province;
                            canton.value = data.canton;
                            district.value = data.district;
                            marital_status.value = data.marital_status;
                            phone_number.value = data.phone_number;
                            email.value = data.email;
                            register_date.value = data.register_date;
                            occupation.value = data.occupation;
                            btn_patient.disabled = !validar_patient();
                        } else {
                            id.value = "";
                        }
                    });
            }
        }
    });

    name_.addEventListener("change", () => {
        btn_patient.disabled = !validar_patient();
    });
    surname_1.addEventListener("change", () => {
        btn_patient.disabled = !validar_patient();
    });
    surname_2.addEventListener("change", () => {
        btn_patient.disabled = !validar_patient();
    });
    birth_date.addEventListener("change", () => {
        btn_patient.disabled = !validar_patient();
    });
    gender.addEventListener("change", () => {
        btn_patient.disabled = !validar_patient();
    });
    contact_number.addEventListener("change", () => {
        btn_patient.disabled = !validar_patient();
    });
    country.addEventListener("change", () => {
        btn_patient.disabled = !validar_patient();
    });
    province.addEventListener("change", () => {
        btn_patient.disabled = !validar_patient();
    });
    canton.addEventListener("change", () => {
        btn_patient.disabled = !validar_patient();
    });
    district.addEventListener("change", () => {
        btn_patient.disabled = !validar_patient();
    });
    marital_status.addEventListener("change", () => {
        btn_patient.disabled = !validar_patient();
    });
    phone_number.addEventListener("change", () => {
        btn_patient.disabled = !validar_patient();
    });
    email.addEventListener("change", () => {
        btn_patient.disabled = !validar_patient();
    });
    register_date.addEventListener("change", () => {
        btn_patient.disabled = !validar_patient();
    });
    occupation.addEventListener("change", () => {
        btn_patient.disabled = !validar_patient();
    });
    
}

function validar_patient() {
    var id_number = document.getElementById('id_number');
    var name_ = document.getElementById('name');
    var surname_1 = document.getElementById('surname_1');
    var surname_2 = document.getElementById('surname_2');
    var birth_date = document.getElementById('birth_date');
    var gender = document.getElementById('gender');
    var contact_number = document.getElementById('contact_number');
    var country = document.getElementById('country');
    var province = document.getElementById('province');
    var canton = document.getElementById('canton');
    var district = document.getElementById('district');
    var marital_status = document.getElementById('marital_status');
    var phone_number = document.getElementById('phone_number');
    var email = document.getElementById('email');
    var register_date = document.getElementById('register_date');
    var occupation = document.getElementById('occupation');

    if (marital_status.value != "" && contact_number.value != "" && gender.value != "" && birth_date.value != "" && surname_2.value != "" && surname_1.value != "" && id_number.value != "" && district.value != "" && phone_number.value != "" && occupation.value != "" && name_.value != "" && register_date.value != "" && email.value != "" && country.value != "" && province.value != "" && canton.value != "") {
        return true;
    } else {
        return false
    }
}