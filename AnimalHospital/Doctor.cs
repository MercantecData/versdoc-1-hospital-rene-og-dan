using System;
using System.Collections.Generic;
using System.Text;

namespace AnimalHospital
{
    // The Doctor class symbolizes a real life doctor. 
    class Doctor
    {
        // the properties name and specialty corrospond to the real-life name and specialty of a particular doctor. 
        // assignpatients is a list of all his patients. Its worth noting that there is no method to input data, instead it must be 
        // added directly from other classes. This is a general trend across all classes and will not be commented upon further
        public string name;
        public string speciality;
        public List<Patient> assignedPatients = new List<Patient>();

        //Takes a name and specialty input and uses it to construct a Doctor object. 
        public Doctor(string name, string speciality)
        {
            this.name = name;
            this.speciality = speciality;
        }
    }
}
