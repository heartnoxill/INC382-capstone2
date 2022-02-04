using System;

namespace ASS2
{
    public class Patient
    {
        string patientName;
        string patientSurname;
        int patientAge;
        string patientGender;
        int patientHeight;
        int patientWeight;
        int deposit;
        string basicSymptom;

        public string PatientName
        {
            get { return patientName; }
            set { patientName = value; }
        }
        public string PatientSurname
        {
            get { return patientSurname; }
            set { patientSurname = value; }
        }
        public int PatientAge
        {
            get { return patientAge; }
            set { patientAge = value; }
        }
        public string PatientGender
        {
            get { return patientGender; }
            set { patientGender = value; }
        }
        public int PatientHeight
        {
            get { return patientHeight; }
            set { patientHeight = value; }
        }
        public int PatientWeight
        {
            get { return patientWeight; }
            set { patientWeight = value; }
        }
        public int Deposit
        {
            get { return deposit; }
            set { deposit = value; }
        }
        public string BasicSymptom
        {
            get { return basicSymptom; }
            set { basicSymptom = value; }
        }
    }
    public class BookingWebsite
    {
        int queueNumber;
        public static void createQueue()
        {
            return;
        }
        public static void readQueue()
        {
            return;
        }
        public static void updateQueue()
        {
            return;
        }
        public static void deleteQueue()
        {
            return;
        }
    }
    public class Admin
    {
        string adminUsername;
        string adminPassword;
        public static void adminLogin()
        {
            return;
        }
    }
    public class DoctorRoom
    {
        string doctorUsername;
        string doctorPassword;
        public static void doctorLogin()
        {
            return;
        }
        public static void diagnosis()
        {
            return;
        }
        public static void prescribe()
        {
            return;
        }
    }
    public class HospitalSystem
    {
        public static void bookRoom()
        {
            return;
        }
        public static void bookPharmacist()
        {
            return;
        }
    }
    public class PharmacistRoom
    {
        string pharmUsername;
        string pharmPassword;
        public static void pharmacistLogin()
        {
            return;
        }
        public static void giveMedicine()
        {
            return;
        }
    }
    public class Room
    {
        string datetime_room;
        string location;
        public static void reserve()
        {
            return;
        }
    }

    class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("Hello World!");

            Patient patient = new Patient();

        }
    }
}