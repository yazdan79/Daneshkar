using System;

public class Person
{
    public string Name;
    public int Age;
    public string NationalId;

    public Person(string name, int age, string nationalId)
    {
        Name = name;
        Age = age;
        NationalId = nationalId;
    }

    public virtual string GetDetails()
    {
        return "Name: " + Name + ", Age: " + Age + ", NationalId: " + NationalId;
    }
}

public class Patient : Person
{
    public string PatientId;
    public List<string> MedicalHistory;

    public Patient(string name, int age, string nationalId, string patientId)
        : base(name, age, nationalId)
    {
        PatientId = patientId;
        MedicalHistory = new List<string>();
    }

    public void AddToMedicalHistory(string disease)
    {
        MedicalHistory.Add(disease);
    }

    public override string GetDetails()
    {
        string history = MedicalHistory.Count > 0 ? string.Join(", ", MedicalHistory) : "No history";
        return $"Patient - Name: {Name}, Age: {Age}, NationalId: {NationalId}, PatientId: {PatientId}, MedicalHistory: {history}";
    }
}

public class Doctor : Person
{
    public string DoctorId;
    public string Specialization;

    public Doctor(string name, int age, string nationalId, string doctorId, string specialization)
        : base(name, age, nationalId)
    {
        DoctorId = doctorId;
        Specialization = specialization;
    }

    public void Diagnose(Patient patient, string disease)
    {
        patient.AddToMedicalHistory(disease);
        Console.WriteLine($"Doctor {Name} diagnosed {patient.Name} with {disease}");
    }

    public override string GetDetails()
    {
        return $"Doctor - Name: {Name}, Age: {Age}, NationalId: {NationalId}, DoctorId: {DoctorId}, Specialization: {Specialization}";
    }
}

public class Room
{
    public int RoomNumber;
    public int Capacity;
    public List<Patient> Patients;

    public Room(int roomNumber, int capacity)
    {
        RoomNumber = roomNumber;
        Capacity = capacity;
        Patients = new List<Patient>();
    }

    public void AssignPatient(Patient patient)
    {
        if (Patients.Count >= Capacity)
        {
            throw new Exception($"Room {RoomNumber} is full!");
        }
        Patients.Add(patient);
        Console.WriteLine($"Patient {patient.Name} assigned to Room {RoomNumber}");
    }
}

public class Hospital
{
    public List<Doctor> Doctors;
    public List<Room> Rooms;

    public Hospital()
    {
        Doctors = new List<Doctor>();
        Rooms = new List<Room>();
    }

    public void AdmitPatient(Patient patient)
    {
        foreach (Room room in Rooms)
        {
            try
            {
                room.AssignPatient(patient);
                return;
            }
            catch
            {

            }
        }
        Console.WriteLine($"No available rooms for patient {patient.Name}");
    }

    public void DischargePatient(Patient patient)
    {
        foreach (Room room in Rooms)
        {
            if (room.Patients.Contains(patient))
            {
                room.Patients.Remove(patient);
                Console.WriteLine($"Patient {patient.Name} has been discharged.");
                return;
            }
        }
        Console.WriteLine($"Patient {patient.Name} not found in any room.");
    }
}

class Program
{
    static void Main(string[] args)
    {
        Hospital hospital = new Hospital();
        Room room1 = new Room(101, 2);
        Room room2 = new Room(102, 1);
        hospital.Rooms.Add(room1);
        hospital.Rooms.Add(room2);

        // ایجاد پزشکان
        Doctor doctor1 = new Doctor("Dr. Reza", 45, "NID123", "D001", "Cardiology");
        Doctor doctor2 = new Doctor("Dr. Sara", 38, "NID456", "D002", "Neurology");
        hospital.Doctors.Add(doctor1);
        hospital.Doctors.Add(doctor2);

        Patient patient1 = new Patient("Ali", 30, "NID789", "P001");
        Patient patient2 = new Patient("Sara", 25, "NID012", "P002");
        Patient patient3 = new Patient("Reza", 40, "NID345", "P003");

        hospital.AdmitPatient(patient1);
        hospital.AdmitPatient(patient2);
        hospital.AdmitPatient(patient3); 

        Console.WriteLine("--------------------");

        doctor1.Diagnose(patient1, "Flu");
        doctor2.Diagnose(patient2, "Migraine");

        Console.WriteLine("--------------------");

        foreach (Room room in hospital.Rooms)
        {
            foreach (Patient p in room.Patients)
            {
                Console.WriteLine(p.GetDetails());
            }
        }

        Console.WriteLine("--------------------");

        hospital.DischargePatient(patient1);
        hospital.DischargePatient(patient3); 

        Console.ReadLine();
    }
}
