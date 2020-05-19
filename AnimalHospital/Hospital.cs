using System;
using System.Collections.Generic;
using System.Text;

namespace AnimalHospital
{
    class Hospital
    {   
        // Varible that saves the Hospital name
        public string name;

        // 2 lists, 1 for Patients and 1 for Doctors
        public List<Patient> patients = new List<Patient>();
        public List<Doctor> doctors = new List<Doctor>();

        // Gives a specific hospital a name/ constructs a hospital object
        public Hospital(string name)
        {
            this.name = name;
        }

        // admit a patient unless that the patient allready is admitted
        public void AdmitPatient(Patient patient)
        {
            if(patients.Contains(patient))
            {
                Console.WriteLine("Patient already admitted to {0}.", name);
            } else
            {
                patients.Add(patient);
                Console.WriteLine("{0} was admitted to {1} successfully", patient.name, name);
            }
        }

        // Discharge a patient that is in the hospital
        public void DischargePatient(Patient patient)
        {
            if(!patients.Contains(patient))
            {
                Console.WriteLine("Patient not in this hospital");
            } else
            {
                patients.Remove(patient);
            }
        }

        // Find a specific patient by names
        public Patient FindPatientByName(string name)
        {
            foreach(var p in patients)
            {
                if(p.name == name)
                {
                    return p;
                }
            }

            return null;
        }
    }
}
