CREATE DATABASE proyecto1;
use proyecto1;

CREATE TABLE Patients(
	id	int IDENTITY(1,1) PRIMARY KEY,
	name   nvarchar(100) NOT NULL,
	surname_1		nvarchar(100),
	surname_2       nvarchar(100) NOT NULL,
    birth_date      date,
	gender			nvarchar(100) NOT NULL,
	contact_number  nvarchar(100) NOT NULL,
	country         nvarchar(100) NOT NULL,
    province        nvarchar(100) NOT NULL,
	canton			nvarchar(100) NOT NULL,
	district		nvarchar(100),
    marital_status  nvarchar(100) NOT NULL,
    phone_number    nvarchar(100) NOT NULL,
    email           nvarchar(100) NOT NULL,
    register_date   date,
    occupation       nvarchar(100) NOT NULL
);

CREATE TABLE Medics(
	id	int IDENTITY(1,1) PRIMARY KEY,
    id_number       nvarchar(100) NOT NULL,
    professional_code  nvarchar(100) NOT NULL,
	full_name       nvarchar(100) NOT NULL,
    email           nvarchar(100) NOT NULL,
	country         nvarchar(100) NOT NULL,
    province        nvarchar(100) NOT NULL,
	canton			nvarchar(100) NOT NULL
);

CREATE TABLE Clinics(
	id	int IDENTITY(1,1) PRIMARY KEY,
    name            nvarchar(100) NOT NULL,
    legal_certificate nvarchar(100) NOT NULL,
	country         nvarchar(100) NOT NULL,
    province        nvarchar(100) NOT NULL,
	canton			nvarchar(100) NOT NULL,
	district		nvarchar(100),
    phone_number    nvarchar(100) NOT NULL,
    email           nvarchar(100) NOT NULL,
    web_site        nvarchar(100) NOT NULL,
);

CREATE TABLE Vaccines(
	id	int IDENTITY(1,1) PRIMARY KEY,
    name             nvarchar(100) NOT NULL,
    brand            nvarchar(100) NOT NULL,
	application_date date NOT NULL,
    lot_number       nvarchar(100) NOT NULL,
	expiration_date	 date NOT NULL,
	application_place		nvarchar(100),
    observations    nvarchar(255) NOT NULL
);

CREATE TABLE PatientsVaccineInformation(
	id	int IDENTITY(1,1) PRIMARY KEY,
    patient_id      int NOT NULL,
    cv_prv_inj      nvarchar(15) NOT NULL,
	sp_cv_prv_inj   nvarchar(15) NOT NULL,
    cv_bfr_inj      nvarchar(15) NOT NULL,
	reason_inj      nvarchar(255) NOT NULL,
	prg_cv_inj		nvarchar(15),
    vaccine_reactions  nvarchar(15) NOT NULL,
    enum_reactions   nvarchar(255),
    actual_medicines nvarchar(255) NOT NULL,
    bfr_cv_medicines nvarchar(255) NOT NULL,
    CONSTRAINT fk_patients_vaccine_information_patients FOREIGN KEY (patient_id) REFERENCES Patients(id)
);

CREATE TABLE MedicalAppointments(
	id	int IDENTITY(1,1) PRIMARY KEY,
    patient_id      int NOT NULL,
    medic_id        int NOT NULL,
    date            date NOT NULL,
    CONSTRAINT fk_medical_appointments_patients FOREIGN KEY (patient_id) REFERENCES Patients(id),
    CONSTRAINT fk_medical_appointments_medics FOREIGN KEY (medic_id) REFERENCES Medics(id)
);

CREATE TABLE SideEffects(
	id	int IDENTITY(1,1) PRIMARY KEY,
    medical_appointments_id int not null,
    symptoms_persists     nvarchar(15),
    alergies_description  nvarchar(255),
    other_conditions      nvarchar(255),
    dev_cancer            nvarchar(255),
    CONSTRAINT fk_side_effects_medical_appointments FOREIGN KEY (medical_appointments_id) REFERENCES MedicalAppointments(id),
);

CREATE TABLE AdvEventSymptoms(
	id	         int IDENTITY(1,1) PRIMARY KEY,
    description  nvarchar(255) NOT NULL
);

INSERT INTO AdvEventSymptoms (description) VALUES ('Visita al médico o a la consulta de otro profesional de la salud');
INSERT INTO AdvEventSymptoms (description) VALUES ('Visita a la sala de emergencias o al centro de atención urgente');
INSERT INTO AdvEventSymptoms (description) VALUES ('Hospitalización');
INSERT INTO AdvEventSymptoms (description) VALUES ('Hospitalización prolongada (inyección de COVID recibida en el
hospital)');
INSERT INTO AdvEventSymptoms (description) VALUES ('Enfermedad que pone en peligro la vida');
INSERT INTO AdvEventSymptoms (description) VALUES ('Incapacidad o daño permanente');
INSERT INTO AdvEventSymptoms (description) VALUES ('Paciente fallecido');
INSERT INTO AdvEventSymptoms (description) VALUES ('Anomalía congénita o defecto de nacimiento');
INSERT INTO AdvEventSymptoms (description) VALUES ('Aborto espontáneo o nacimiento sin vida');
INSERT INTO AdvEventSymptoms (description) VALUES ('Ninguna de las anteriores');

CREATE TABLE rel_effects_event_symptoms(
	id	                   int IDENTITY(1,1) PRIMARY KEY,
    side_effects_id        int NOT NULL,
    adv_event_symptoms_id  int NOT NULL,
    CONSTRAINT fk_rel_effects_event_symptoms_side_effects FOREIGN KEY (side_effects_id) REFERENCES SideEffects(id),
	CONSTRAINT fk_rel_effects_event_symptoms_adv_event_symptoms FOREIGN KEY (adv_event_symptoms_id) REFERENCES AdvEventSymptoms(id)
);

CREATE TABLE Alergies(
	id	         int IDENTITY(1,1) PRIMARY KEY,
    description  nvarchar(255) NOT NULL
);
CREATE TABLE rel_effects_alergies(
	id	                   int IDENTITY(1,1) PRIMARY KEY,
    side_effects_id        int NOT NULL,
    alergies_id            int NOT NULL,
    CONSTRAINT fk_rel_effects_alergies_side_effects FOREIGN KEY (side_effects_id) REFERENCES SideEffects(id),
	CONSTRAINT fk_rel_effects_alergies_alergies FOREIGN KEY (alergies_id) REFERENCES Alergies(id),
);
INSERT INTO Alergies (description) VALUES ('Medicamentos');
INSERT INTO Alergies (description) VALUES ('Polietilenglicol');
INSERT INTO Alergies (description) VALUES ('Alimentos');
INSERT INTO Alergies (description) VALUES ('Medio ambiente');
INSERT INTO Alergies (description) VALUES ('Otros');
INSERT INTO Alergies (description) VALUES ('Ninguna');

CREATE TABLE NewDiseases(
	id	         int IDENTITY(1,1) PRIMARY KEY,
    description  nvarchar(255) NOT NULL
);
CREATE TABLE rel_effects_diseases(
	id	                   int IDENTITY(1,1) PRIMARY KEY,
    side_effects_id        int NOT NULL,
    new_diseases_id        int NOT NULL,
    CONSTRAINT fk_rel_effects_diseases_side_effects FOREIGN KEY (side_effects_id) REFERENCES SideEffects(id),
	CONSTRAINT fk_rel_effects_diseases_new_diseases FOREIGN KEY (new_diseases_id) REFERENCES NewDiseases(id)
);
INSERT INTO NewDiseases (description) VALUES ('Enfermedad de Addison');
INSERT INTO NewDiseases (description) VALUES ('Alergias');
INSERT INTO NewDiseases (description) VALUES ('Arritmias');
INSERT INTO NewDiseases (description) VALUES ('Fibrilación auricular');
INSERT INTO NewDiseases (description) VALUES ('Vasculitis autoinmune');
INSERT INTO NewDiseases (description) VALUES ('Parálisis de Bell (parálisis facial)');
INSERT INTO NewDiseases (description) VALUES ('Bronquitis');
INSERT INTO NewDiseases (description) VALUES ('Cáncer');
INSERT INTO NewDiseases (description) VALUES ('Enfermedad celíaca (intolerancia al gluten)');
INSERT INTO NewDiseases (description) VALUES ('Enfermedad renal crónica');
INSERT INTO NewDiseases (description) VALUES ('Insuficiencia cardíaca congestiva');
INSERT INTO NewDiseases (description) VALUES ('Enfermedad de Crohn');
INSERT INTO NewDiseases (description) VALUES ('TVP (coágulos de sangre)');
INSERT INTO NewDiseases (description) VALUES ('Diabetes');
INSERT INTO NewDiseases (description) VALUES ('Encefalitis (inflamación cerebral/dolores de cabeza)');
INSERT INTO NewDiseases (description) VALUES ('Epilepsia (convulsiones)');
INSERT INTO NewDiseases (description) VALUES ('Enfermedades del corazón');
INSERT INTO NewDiseases (description) VALUES ('Herpes tipo 1');
INSERT INTO NewDiseases (description) VALUES ('Herpes tipo 2');
INSERT INTO NewDiseases (description) VALUES ('VIH');
INSERT INTO NewDiseases (description) VALUES ('Hipertensión (presión arterial alta)');
INSERT INTO NewDiseases (description) VALUES ('Enfermedad inflamatoria intestinal');
INSERT INTO NewDiseases (description) VALUES ('Enfermedad renal aguda');
INSERT INTO NewDiseases (description) VALUES ('Enfermedad hepática');
INSERT INTO NewDiseases (description) VALUES ('Lupus');
INSERT INTO NewDiseases (description) VALUES ('Aborto espontáneo');
INSERT INTO NewDiseases (description) VALUES ('Esclerosis múltiple');
INSERT INTO NewDiseases (description) VALUES ('Miastenia gravis');
INSERT INTO NewDiseases (description) VALUES ('Infarto de miocardio (ataque al corazón)');
INSERT INTO NewDiseases (description) VALUES ('Miocarditis');
INSERT INTO NewDiseases (description) VALUES ('Osteoartritis');
INSERT INTO NewDiseases (description) VALUES ('Pericarditis');
INSERT INTO NewDiseases (description) VALUES ('Anemia perniciosa');
INSERT INTO NewDiseases (description) VALUES ('Neumonía');
INSERT INTO NewDiseases (description) VALUES ('Parto prematuro');
INSERT INTO NewDiseases (description) VALUES ('Psoriasis');
INSERT INTO NewDiseases (description) VALUES ('Artritis psoriásica');
INSERT INTO NewDiseases (description) VALUES ('Embolia pulmonar');
INSERT INTO NewDiseases (description) VALUES ('Artritis reumatoide');
INSERT INTO NewDiseases (description) VALUES ('Herpes zóster');
INSERT INTO NewDiseases (description) VALUES ('Síndrome de Sjogren');
INSERT INTO NewDiseases (description) VALUES ('Nacimiento sin vida');
INSERT INTO NewDiseases (description) VALUES ('Accidente cerebrovascular');
INSERT INTO NewDiseases (description) VALUES ('Ataques isquémicos transitorios (AIT');
INSERT INTO NewDiseases (description) VALUES ('Trastorno de la tiroides');
INSERT INTO NewDiseases (description) VALUES ('Colitis ulcerosa');

CREATE TABLE Symptoms(
	id	         int IDENTITY(1,1) PRIMARY KEY,
    description  nvarchar(255) NOT NULL
);

CREATE TABLE rel_effects_symptoms(
	id	                   int IDENTITY(1,1) PRIMARY KEY,
    side_effects_id        int NOT NULL,
    symptoms_id            int NOT NULL,
    CONSTRAINT fk_rel_effects_symptoms_side_effects FOREIGN KEY (side_effects_id) REFERENCES SideEffects(id),
	CONSTRAINT fk_rel_effects_symptoms_symptoms FOREIGN KEY (symptoms_id) REFERENCES Symptoms(id)
);

INSERT INTO Symptoms (description) VALUES ('Síntomas de COVID o Enfermedad de COVID');
INSERT INTO Symptoms (description) VALUES ('Disminución del bienestar');
INSERT INTO Symptoms (description) VALUES ('Disminución del estado de salud');
INSERT INTO Symptoms (description) VALUES ('Fatiga extrema');
INSERT INTO Symptoms (description) VALUES ('Incapacidad para participar en actividades rutinarias');
INSERT INTO Symptoms (description) VALUES ('Pérdida de energía');
INSERT INTO Symptoms (description) VALUES ('Dolor inexplicable');
INSERT INTO Symptoms (description) VALUES ('Debilidad');
INSERT INTO Symptoms (description) VALUES ('Fiebre inexplicable');
INSERT INTO Symptoms (description) VALUES ('Sensaciones corporales inexplicables');
INSERT INTO Symptoms (description) VALUES ('Sudores nocturnos');
INSERT INTO Symptoms (description) VALUES ('Sofocos');
INSERT INTO Symptoms (description) VALUES ('Intolerancia al frío');
INSERT INTO Symptoms (description) VALUES ('Intolerancia al calor');
INSERT INTO Symptoms (description) VALUES ('Sensibilidad a los cambios de temperatura');
INSERT INTO Symptoms (description) VALUES ('Cambio en la capacidad de caminar');
INSERT INTO Symptoms (description) VALUES ('Cambio en el pensamiento');
INSERT INTO Symptoms (description) VALUES ('Ya no me siento como antes');
INSERT INTO Symptoms (description) VALUES ('Aumento de peso inexplicable');
INSERT INTO Symptoms (description) VALUES ('Pérdida de peso inexplicable');
INSERT INTO Symptoms (description) VALUES ('Sueño fragmentado');
INSERT INTO Symptoms (description) VALUES ('No puedo dormir');
INSERT INTO Symptoms (description) VALUES ('Insomnio');







