package udpChat;

import java.io.BufferedReader;
import java.io.IOException;
import java.io.InputStreamReader;
import java.net.DatagramPacket;
import java.net.DatagramSocket;
import java.net.InetAddress;

public class MessageSender implements Runnable {

    public static final int PORT = 7331;
    private final DatagramSocket socket;
    private final String hostname;

    public MessageSender(DatagramSocket socket, String hostname) {
        this.socket = socket;
        this.hostname = hostname;
    }

    private void sendMessage(String message) throws IOException {
        byte[] buffer = message.getBytes();
        InetAddress address = InetAddress.getByName(hostname);
        DatagramPacket packet = new DatagramPacket(buffer, buffer.length, address, PORT);
        socket.send(packet);
    }

    @Override
    public void run() {
        boolean connected = false;
        do {
            try {
                this.sendMessage("Hello");
                connected = true;
            } catch (IOException e) {
                e.printStackTrace();
            }
        } while (!connected);

        BufferedReader in = new BufferedReader(new InputStreamReader(System.in));
        while (true) {
            try {
                while (!in.ready()) {
                    Thread.sleep(100);
                    this.sendMessage(in.readLine());
                }
            } catch (IOException | InterruptedException e) {
                System.err.println(e.getMessage());
            }
        }
    }
}
