package timeServer;

import java.io.*;
import java.net.InetAddress;
import java.net.Socket;
import java.net.UnknownHostException;

public class TimeClient {
    public static void main(String[] args) throws UnknownHostException {
        InetAddress address = InetAddress.getByName("localhost");
        String[] cities = new String[]{"Sofia", "Rome", "Madrid", "Berlin", "Paris", "Brussels", "London"};

        for (String city : cities) {
            try (Socket socket = new Socket(address, TimeServer.PORT)) {
                BufferedReader in = new BufferedReader(new InputStreamReader(socket.getInputStream()));
                PrintWriter out = new PrintWriter(new BufferedWriter(new OutputStreamWriter(socket.getOutputStream())), true);

                String zone = String.format("Europe/%s", city);
                out.println(zone);
                String time = in.readLine();
                System.out.printf("Time in %s is: %s%n", zone, time);

            } catch (IOException e) {
                System.err.println("Problem with server communication: " + address);
            }
            try {
                Thread.sleep(2000);
            } catch (InterruptedException e) {
                e.printStackTrace();
            }
        }
    }
}
