using System;

namespace AnimalHospital
{
    // this class is where our program is being run from, as it contains our main
    class Program
    {
        // creates a public static variable hospital that represents the hospital we are at, with lists of patients of doctors.
        // Putting it as static makes it accessible from within main, this is used with both variables and local methods.
        public static Hospital hospital;

        // Main is a critical part of the program as it tells the computer where to start.
        static void Main(string[] args)
        {
            // we call InitializeHospital() and then we tell the program to continously call MainMenu until that method returns falls
            hospital = InitializeHospital();
            while (MainMenu()) {}

            //once all else is done the program writes goodbye
            Console.WriteLine("Goodbye!");
        }

        // MainMenu is our primary menu, it gives us a set of options to choose from that alters the database or gives us feedback. Either way
        // it returns true or false
        static bool MainMenu()
        {
            // Starts out by clearing the console and writing introductory text
            Console.Clear();
            Console.WriteLine("Welcome to {0}. You have the following options:", hospital.name);
            Console.WriteLine("1. Admit a patient to the hospital");
            Console.WriteLine("2. Discharge a patient");
            Console.WriteLine("3. See a list of all patients in the hospital");
            Console.WriteLine("4. See a list of all doctors in the hospital");
            Console.WriteLine("5. Assign a specific doctor to a specific patient");
            Console.WriteLine("0. Quit the Program");
            Console.WriteLine();

            // takes a character and then runs it through a series of if-else checks that give an output for 0-5
            var k = Console.ReadKey().KeyChar;
            Console.WriteLine();
            // tells the system to call AdmitPatient()
            if(k == '1')
            {
                AdmitPatient();
            } 

            // Asks for the name of the patient and checks whether that patient is in the database. If that is the case the patient is discharged,
            // otherwise feedback is given but no database changes. 
            else if(k == '2')
            {
                Console.WriteLine("What is the patients name?");
                String input = Console.ReadLine();
                try
                {
                    hospital.DischargePatient(hospital.FindPatientByName(input));
                    Console.WriteLine("Patient discharged");
                }
                catch
                {
                    Console.WriteLine(" \n Beware!! Patient does not exist!!");
                }
                
            }
            
            // Prints a list consisting of all patients that have been admitted to the hospital
            else if(k == '3')
            {
                Console.WriteLine("Here you can see all patients");

                foreach (Patient p in hospital.patients)
                {
                    Console.WriteLine(p.name);
                }
            }

            // Prints a list consisting of all doctors that work at the hospital
            else if (k == '4')
            {
                Console.WriteLine("Here you can see all doctors");
                foreach(Doctor d in hospital.doctors)
                {
                    Console.WriteLine(d.name);
                }
            }

            // Asks for the name of doctor and patient. After that it checks whether both are in the database. If they are it assigns the doctor to the 
            // patient and puts the patient on the doctors list of patients. 
            else if (k == '5')
            {
                Console.WriteLine("What is the name of the patient");
                String patientName = Console.ReadLine();
                Console.WriteLine("What is the name of the doctor");
                String doctorName = Console.ReadLine();

                Doctor localdoc = null;
                Patient localPatient = null;
                foreach(Doctor doc in hospital.doctors)
                {
                    if (doc.name == doctorName) {
                        localdoc = doc;
                    }
                }
                foreach (Patient pat in hospital.patients)
                {
                    if (pat.name == patientName)
                    {
                        localPatient = pat;
                    }
                }

                if(localPatient != null && localdoc != null)
                {
                    localPatient.AssignDoctor(localdoc);
                    localdoc.assignedPatients.Add(localPatient);
                    Console.WriteLine("Doctor and patient have been linked ");
                } 
                else
                {
                    Console.WriteLine("Patient or doctorname written wrong");
                }
            }

            // this returns false which ends the while loop.
            else if (k == '0')
            {
                return false;
            }

            Console.WriteLine("Press any key to continue...");
            Console.ReadKey();
            return true;
        }

        // Admid a patient to a hospital
        static void AdmitPatient()
        {
            string name;
            int age;

            Console.WriteLine("What is the patients name?");
            name = Console.ReadLine();

            Console.WriteLine("What is the patients age?");
            while(!int.TryParse(Console.ReadLine(), out age))
            {
                Console.WriteLine("You must write a number, try again");
            }

            new Patient(name, age).AdmitTo(hospital);
        }

        // initilize a hospital and give the hospital a name and some doctors 
        static Hospital InitializeHospital()
        {
            Hospital hospital = new Hospital("Animal Hospital");

            hospital.doctors.AddRange(new Doctor[]
            {
                new Doctor("Matt Tennant", "Spinal Injury"),
                new Doctor("David Smith", "Knee Injury"),
                new Doctor("Jodie Tyler", "Oncology"),
                new Doctor("Rose Whitaker", "Intensive Care")
            });

            return hospital;
        }
    }
}
