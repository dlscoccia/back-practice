package ui;
import model.Doctor;

import java.util.ArrayList;
import java.util.Scanner;

public class UIDoctorMenu {

    public static ArrayList<Doctor> doctorsAvailableAppointments = new ArrayList<>();

    public static void showDoctorMenu() {
        int response = 0;

        do {
            System.out.println("\n");
            System.out.println("Doctor");
            System.out.println("Welcome " + UIMenu.doctorLogged.getName());
            System.out.println("1. Add Available Appointment");
            System.out.println("2. My scheduled Appointments");
            System.out.println("0. Logout");

            Scanner sc = new Scanner(System.in);
            response = Integer.parseInt(sc.nextLine());

            switch (response) {
                case 1:
                    showAddAvailableAppointmentMenu();
                break;
                case 2:
                    break;
                case 0:
                    UIMenu.showMenu();
                    break;
            }

        } while (response != 0);
    }

    private static void showAddAvailableAppointmentMenu() {
        int response = 0;

        do {
            System.out.println("\n");
            System.out.println(":: Add Available Appointment");

            for (int i = 0; i < 3; i++) {
                int j = i + 1;

                System.out.println(j +". " + UIMenu.MONTHS[i]);
            }
            System.out.println("0. Return");

            Scanner sc = new Scanner(System.in);
            response = Integer.parseInt(sc.nextLine());

            if (response > 0 && response < 4) {
                int monthSelected = response;

                System.out.println(monthSelected + " . " + UIMenu.MONTHS[monthSelected - 1]);
                System.out.println("Insert the date: [dd/mm/yyy]");
                String date = sc.nextLine();

                System.out.println("Your date is: " + date + "\n1. Correct \n2. Change date");
                int responseDate = Integer.parseInt(sc.nextLine());

                if (responseDate == 2) continue;

                int responseTime = 0;
                String time = "";
                do {
                    System.out.println("Insert the time for date: " + date + " [16:00]");
                    time = sc.nextLine();
                System.out.println("Your time is: " + time + "\n1. Correct \n2. Change date");
                responseTime = Integer.parseInt(sc.nextLine());

                } while (responseTime == 2);

                UIMenu.doctorLogged.addAvailableAppointment(date, time);
                checkDoctorAvailableAppointment(UIMenu.doctorLogged);

            } else if( response == 0) {
                showDoctorMenu();
            }
        } while (response != 0);
    }

    private static void checkDoctorAvailableAppointment(Doctor doctor) {
        if (!doctor.getAvailableAppointments().isEmpty() && !doctorsAvailableAppointments.contains(doctor)) {
            doctorsAvailableAppointments.add(doctor);
        }
    }
}
