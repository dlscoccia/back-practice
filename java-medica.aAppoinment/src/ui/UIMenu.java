package ui;

import model.Doctor;
import model.Patient;

import java.util.ArrayList;
import java.util.Scanner;

public class UIMenu {

    public static final String[] MONTHS = {"Enero","Febrero","Marzo","Abril","Mayo","Junio","Julio","Agosto", "Septiembre", "Octubre", "Noviembre", "Diciembre"};
    public static Doctor doctorLogged;
    public static Patient patientLogged;

    public static void showMenu(){
        System.out.println("Welcome to My Appointments");
        System.out.println("Selecciona la opción deseada");

        int response = 0;
        do {
            System.out.println("1. Doctor");
            System.out.println("2. Patient");
            System.out.println("0. Salir");

            Scanner sc = new Scanner(System.in);
            response = Integer.parseInt(sc.nextLine());

            switch (response){
                case 1:
                    System.out.println("Doctor");
                    response = 0;
                    authUser(1);
                    break;
                case 2:
                    response = 0;
                    authUser(2);
                    showPatientMenu();

                    break;
                case 0:
                    System.out.println("Thank you for you visit");
                    break;
                default:
                    System.out.println("Please select a correct answer");
            }
        }while (response != 0);
    }

    private static void authUser(int userType) {
        ArrayList<Doctor> doctors = new ArrayList<>();
        doctors.add(new Doctor("Alejandro Guerra", "alejandro@gmail.com"));
        doctors.add(new Doctor("karen Sosa", "karen@gmail.com"));
        doctors.add(new Doctor("Rocio López", "rocio@gmail.com"));

        ArrayList<Patient> patients = new ArrayList<>();
        patients.add(new Patient("Fonzi Lord", "fonzi@gmail.com"));
        patients.add(new Patient("Roberto Andres", "roberto@gmail.com"));
        patients.add(new Patient("Juliana Luna", "juliana@gmail.com"));

        boolean emailCorrect = false;

        do {
            System.out.println("Insert a valid email");
            Scanner sc = new Scanner(System.in);
            String email = sc.nextLine();

        if (userType == 1) {
            for (Doctor d: doctors) {
                if (d.getEmail().equals(email)) {
                    emailCorrect = true;
                    doctorLogged = d;
                    UIDoctorMenu.showDoctorMenu();
                }
            }
        }

        if (userType == 2) {
            for (Patient p: patients) {
                if (p.getEmail().equals(email)) {
                    emailCorrect = true;
                    patientLogged = p;
                }
            }
        }

        } while (!emailCorrect);
    }

    static void showPatientMenu(){
        int response = 0;
        do {
            System.out.println("\n\n");
            System.out.println("Patient");
            System.out.println("1. Book an appointment");
            System.out.println("2. My appointments");
            System.out.println("0. Return");

            Scanner sc = new Scanner(System.in);
            response = Integer.valueOf(sc.nextLine());

            switch (response){
                case 1:
                    System.out.println("::Book an appointment");
                    for (int i = 0; i < 4; i++) {
                        System.out.println(i +". " + MONTHS[i]);
                    }
                    break;
                case 2:
                    System.out.println("::My appointments");
                    break;
                case 0:
                    showMenu();
                    break;
            }
        }while (response != 0);
    }
}
