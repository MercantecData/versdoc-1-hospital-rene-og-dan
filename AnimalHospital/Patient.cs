using System;
using System.Collections.Generic;
using System.Text;

namespace AnimalHospital
{
    class Patient
    {
        // 3 varible that saves the name, age and the doctor of the patient
        public string name;
        public int age;
        public Doctor doctor;

        // gives a specific patient a name and age
        public Patient(string name, int age)
        {
            this.name = name;
            this.age = age;
        }

        // Admits a patient to a specific hospital
        public void AdmitTo(Hospital hospital)
        {
            hospital.AdmitPatient(this);
        }

        // assign a doctor to a specific patient
        public void AssignDoctor(Doctor doctor) {
            this.doctor = doctor;
        } 
    }
}
